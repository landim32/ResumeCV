using Microsoft.AspNetCore.Mvc;
using ResumeCV.Domain.Services.Interfaces;
using ResumeCV.DTOs;

namespace ResumeCV.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResumeController : ControllerBase
    {
        private readonly IResumeService _resumeService;

        public ResumeController(IResumeService resumeService)
        {
            _resumeService = resumeService ?? throw new ArgumentNullException(nameof(resumeService));
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

        // PUT /Resume/{id}
        [HttpPut("{id:long}")]
        public ActionResult Update(long id, [FromBody] ResumeDTO resume)
        {
            if (id <= 0) return BadRequest("id deve ser maior que zero.");
            if (resume is null) return BadRequest("resume é obrigatório.");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            // garante consistência do id
            resume.ResumeId = id;

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
    }
}
