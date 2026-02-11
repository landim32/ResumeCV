using Microsoft.AspNetCore.Mvc;
using NTools.ACL.Interfaces;
using ResumeCV.Domain.Services.Interfaces;
using ResumeCV.DTOs;
using System.Collections.Generic;

namespace ResumeCV.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResumeController : ControllerBase
    {
        private const string BUCKET_NAME = "resumecv";

        private readonly IResumeService _resumeService;
        private readonly IFileClient _fileClient;

        public ResumeController(IResumeService resumeService, IFileClient fileClient)
        {
            _resumeService = resumeService ?? throw new ArgumentNullException(nameof(resumeService));
            _fileClient = fileClient ?? throw new ArgumentNullException(nameof(fileClient));
        }

        // GET /Resume/{id}
        [HttpGet("{id:long}")]
        public ActionResult<ResumeDTO> Get(long id)
        {
            if (id <= 0) return BadRequest("id deve ser maior que zero.");

            var resume = _resumeService.GetById(id);
            if (resume == null) return NotFound();

            return Ok(resume);
        }

        // GET /Resume/user/{userId}
        [HttpGet("user/{userId:long}")]
        public ActionResult<IList<ResumeDTO>> ListByUser(long userId)
        {
            if (userId <= 0) return BadRequest("userId deve ser maior que zero.");

            var list = _resumeService.ListByUser(userId);
            return Ok(list);
        }

        // POST /Resume
        [HttpPost]
        public ActionResult Create([FromBody] ResumeDTO resume)
        {
            if (resume is null) return BadRequest("resume é obrigatório.");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var id = _resumeService.Add(resume);
            return CreatedAtAction(nameof(Get), new { id }, null);
        }

        // PUT /Resume
        [HttpPut]
        public ActionResult Update([FromBody] ResumeDTO resume)
        {
            //if (id <= 0) return BadRequest("id deve ser maior que zero.");
            if (resume is null) return BadRequest("resume é obrigatório.");
            if (resume.ResumeId <= 0) return BadRequest("id deve ser maior que zero.");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            // garante consistência do id
            //resume.ResumeId = id;

            _resumeService.Update(resume);
            return NoContent();
        }

        // DELETE /Resume/{id}
        [HttpDelete("{id:long}")]
        public ActionResult Delete(long id)
        {
            if (id <= 0) return BadRequest("id deve ser maior que zero.");

            _resumeService.Delete(id);
            return NoContent();
        }

        [RequestSizeLimit(100_000_000)]
        [HttpPost("{idResume:long}/uploadPhoto")]
        public async Task<ActionResult> UploadPhoto(long idResume, IFormFile file)
        {
            if (idResume <= 0) return BadRequest("idResume cant be empty.");

            if (file == null || file.Length == 0)
            {
                //_logger.LogError("No file uploaded");
                return BadRequest("No file uploaded");
            }
            var resume = _resumeService.GetById(idResume);

            if (resume == null) return BadRequest("Resume not found.");

            var fileName = await _fileClient.UploadFileAsync(BUCKET_NAME, file);
            var fileUrl = await _fileClient.GetFileUrlAsync(BUCKET_NAME, fileName);

            resume.PhotoUrl = fileUrl;
            _resumeService.Update(resume);

            return Ok(fileUrl);
        }
    }
}
