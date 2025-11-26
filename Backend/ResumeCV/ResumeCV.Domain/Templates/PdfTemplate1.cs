using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using ResumeCV.Domain.Entities.Interfaces;
using ResumeCV.Domain.Templates.Interfaces;
using ResumeCV.Infra.Interfaces.Pdf;
using SkiaSharp;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;

namespace ResumeCV.Domain.Templates
{
    public class PdfTemplate1 : IPdfBaseTemplate
    {
        private const int MAIN_COLUMN_RATIO = 5;
        private const int RIGHT_COLUMN_RATIO = 2;
        private readonly IMarkdownRenderer _markdownRenderer;

        public PdfTemplate1(IMarkdownRenderer markdownRenderer)
        {
            _markdownRenderer = markdownRenderer ?? throw new ArgumentNullException(nameof(markdownRenderer));
        }

        public Stream GeneratePdf(IResumeModel resume)
        {
            if (resume is null) throw new ArgumentNullException(nameof(resume));

            var stream = new MemoryStream();

            // Coleta de dados auxiliares
            var skills = resume.Courses
                               .SelectMany(c => c.Skills ?? Enumerable.Empty<IResumeSkillModel>())
                               .Concat(resume.Infos.SelectMany(i => i.Skills ?? Enumerable.Empty<IResumeSkillModel>()))
                               .Concat(resume.Jobs.SelectMany(j => j.Skills ?? Enumerable.Empty<IResumeSkillModel>()))
                               .Where(s => !string.IsNullOrWhiteSpace(s?.Name))
                               .Select(s => s!.Name)
                               .Distinct(StringComparer.InvariantCultureIgnoreCase)
                               .ToList();

            var languages = resume.Languages ?? Enumerable.Empty<IResumeLanguageModel>();

            QuestPDF.Settings.License = LicenseType.Community;

            // Gera documento com QuestPDF
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(0); // Remove margem para ter controle total
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(11));

                    page.Content().Row(row =>
                    {
                        // Coluna principal esquerda (75% - 3/4 da página)
                        row.RelativeItem(MAIN_COLUMN_RATIO)
                            .Background(Colors.White)
                            .Padding(25)
                            .Column(main =>
                            {
                                //Header
                                main.Item().Text((resume.Name ?? string.Empty).ToUpper()).FontSize(18).Bold();
                                main.Item().Text(resume.JobDescription ?? string.Empty).FontSize(12).SemiBold().FontColor(Colors.Grey.Darken4);
                                var contacts = string.Join(" • ", new[]
                                {
                                    !string.IsNullOrWhiteSpace(resume.Phone) ? $"📞 {resume.Phone}" : null,
                                    !string.IsNullOrWhiteSpace(resume.Email) ? $"📧 {resume.Email}" : null,
                                    !string.IsNullOrWhiteSpace(resume.Address) ? $"📍 {resume.Address}" : null
                                }.Where(x => !string.IsNullOrWhiteSpace(x)));
                                if (!string.IsNullOrWhiteSpace(contacts))
                                {
                                    main.Item().PaddingBottom(10).Text(contacts).FontSize(9).FontColor(Colors.Grey.Medium);
                                }
                                // Experiências / Jobs
                                if (resume.Jobs != null && resume.Jobs.Any())
                                {
                                    main.Item().PaddingBottom(2).Text("Experiência").FontSize(14).Bold();
                                    main.Item().PaddingBottom(20).Height(1).Background(Colors.Grey.Lighten2);

                                    foreach (var job in resume.Jobs)
                                    {
                                        main.Item().PaddingBottom(10).Column(jobCol =>
                                        {
                                            var period = FormatRange(job.StartDate, job.EndDate);
                                            jobCol.Item().Row(r =>
                                            {
                                                r.RelativeItem().Text($"{job.Position} — {job.Business1}").Bold();
                                                r.ConstantItem(120).AlignRight().Text(period).FontSize(9).FontColor(Colors.Grey.Medium);
                                            });

                                            if (!string.IsNullOrWhiteSpace(job.Business2))
                                                jobCol.Item().Text(job.Business2).FontSize(10).FontColor(Colors.Grey.Darken3);

                                            if (!string.IsNullOrWhiteSpace(job.Location))
                                                jobCol.Item().Text($"Local: {job.Location}").FontSize(9).FontColor(Colors.Grey.Medium);

                                            if (!string.IsNullOrWhiteSpace(job.Resume))
                                            {
                                                jobCol.Item().PaddingTop(4).Element(container =>
                                                    _markdownRenderer.Render(container, job.Resume, 9));
                                            }

                                            if (job.Skills != null && job.Skills.Any())
                                            {
                                                var jobSkills = string.Join(", ", job.Skills.Where(s => !string.IsNullOrWhiteSpace(s?.Name)).Select(s => s!.Name));
                                                if (!string.IsNullOrWhiteSpace(jobSkills))
                                                    jobCol.Item().PaddingTop(4).Text($"Skills: {jobSkills}").FontSize(9).FontColor(Colors.Grey.Medium);
                                            }
                                        });
                                    }
                                }

                                // Cursos / Formação
                                if (resume.Courses != null && resume.Courses.Any())
                                {
                                    main.Item().PaddingTop(15).PaddingBottom(4).Text("Formação / Cursos").FontSize(14).Bold();
                                    foreach (var course in resume.Courses)
                                    {
                                        main.Item().PaddingBottom(10).Column(courseCol =>
                                        {
                                            var period = FormatRange(course.StartDate, course.EndDate);
                                            courseCol.Item().Row(r =>
                                            {
                                                r.RelativeItem().Text(course.Title).Bold();
                                                r.ConstantItem(120).AlignRight().Text(period).FontSize(9).FontColor(Colors.Grey.Medium);
                                            });

                                            if (!string.IsNullOrWhiteSpace(course.Institute))
                                                courseCol.Item().Text(course.Institute).FontSize(10).FontColor(Colors.Grey.Darken3);

                                            if (!string.IsNullOrWhiteSpace(course.Location))
                                                courseCol.Item().Text($"Local: {course.Location}").FontSize(9).FontColor(Colors.Grey.Medium);

                                            if (!string.IsNullOrWhiteSpace(course.Resume))
                                            {
                                                courseCol.Item().PaddingTop(4).Element(container =>
                                                    _markdownRenderer.Render(container, course.Resume, 9));
                                            }

                                            if (course.Skills != null && course.Skills.Any())
                                            {
                                                var cskills = string.Join(", ", course.Skills.Where(s => !string.IsNullOrWhiteSpace(s?.Name)).Select(s => s!.Name));
                                                if (!string.IsNullOrWhiteSpace(cskills))
                                                    courseCol.Item().PaddingTop(4).Text($"Skills: {cskills}").FontSize(9).FontColor(Colors.Grey.Medium);
                                            }
                                        });
                                    }
                                }

                                // Infos (links / projetos / extras)
                                if (resume.Infos != null && resume.Infos.Any())
                                {
                                    main.Item().PaddingTop(15).PaddingBottom(4).Text("Informações").FontSize(14).Bold();
                                    foreach (var info in resume.Infos)
                                    {
                                        main.Item().PaddingBottom(10).Column(infoCol =>
                                        {
                                            infoCol.Item().Text(info.Title).Bold();
                                            if (!string.IsNullOrWhiteSpace(info.Url))
                                                infoCol.Item().Text(info.Url).FontSize(9).FontColor(Colors.Blue.Darken1);
                                            
                                            if (!string.IsNullOrWhiteSpace(info.Resume))
                                            {
                                                infoCol.Item().Element(container =>
                                                    _markdownRenderer.Render(container, info.Resume, 9));
                                            }
                                            
                                            if (info.Skills != null && info.Skills.Any())
                                            {
                                                var iskills = string.Join(", ", info.Skills.Where(s => !string.IsNullOrWhiteSpace(s?.Name)).Select(s => s!.Name));
                                                if (!string.IsNullOrWhiteSpace(iskills))
                                                    infoCol.Item().Text($"Skills: {iskills}").FontSize(9).FontColor(Colors.Grey.Medium);
                                            }
                                        });
                                    }
                                }
                            });

                        // Coluna lateral direita (25% - 1/4 da página) com fundo azul
                        row.RelativeItem(RIGHT_COLUMN_RATIO)
                            .Background(Colors.Blue.Darken2)
                            .Padding(10)
                            .Column(rightCol =>
                            {
                                // Foto redonda no topo
                                if (!string.IsNullOrWhiteSpace(resume.PhotoUrl))
                                {
                                    using var httpClient = new HttpClient();
                                    var imageBytes = httpClient.GetByteArrayAsync(resume.PhotoUrl).Result;
                                    var circularImageBytes = CreateCircularImage(imageBytes, 100);

                                    rightCol.Item()
                                        .PaddingBottom(15)
                                        .AlignCenter()
                                        .Width(100)
                                        .Height(100)
                                        .Image(circularImageBytes);
                                }

                                rightCol.Item().DefaultTextStyle(x => x.FontColor(Colors.White));

                                // Sumário / resumo (campo Resume) - Usando Markdown
                                if (!string.IsNullOrWhiteSpace(resume.Resume))
                                {
                                    rightCol.Item().PaddingBottom(2).Text("Resumo").FontSize(14).Bold().FontColor(Colors.White);
                                    rightCol.Item().PaddingBottom(10).Height(1).Background(Colors.White);
                                    rightCol.Item().DefaultTextStyle(x => x.FontSize(8).FontColor(Colors.White))
                                        .Element(container =>
                                            _markdownRenderer.Render(container, resume.Resume!, 8));
                                }

                                // Skills agregadas
                                if (skills.Any())
                                {
                                    rightCol.Item().PaddingTop(20).PaddingBottom(10).Text("Skills").FontSize(14).Bold().FontColor(Colors.White);
                                    rightCol.Item().Column(scol =>
                                    {
                                        foreach (var s in skills)
                                        {
                                            scol.Item().PaddingVertical(2).Text($"• {s}").FontSize(10).FontColor(Colors.White);
                                        }
                                    });
                                }

                                // Languages
                                if (languages.Any())
                                {
                                    rightCol.Item().PaddingTop(20).PaddingBottom(10).Text("Idiomas").FontSize(14).Bold().FontColor(Colors.White);
                                    foreach (var lang in languages)
                                    {
                                        rightCol.Item().PaddingVertical(2).Text($"• {lang.Language} — Nível {lang.Level}").FontSize(10).FontColor(Colors.White);
                                    }
                                }
                            });
                    });

                    // Rodapé com layout em colunas
                    page.Footer()
                        .Background(Colors.White)
                        .Row(row =>
                        {
                            // Coluna esquerda do footer (75%)
                            row.RelativeItem(MAIN_COLUMN_RATIO)
                                .Background(Colors.White)
                                .Padding(25)
                                .AlignCenter()
                                .Text(txt =>
                                {
                                    txt.Span("Página ").FontSize(9);
                                    txt.CurrentPageNumber().FontSize(9);
                                    txt.Span(" de ").FontSize(9);
                                    txt.TotalPages().FontSize(9);
                                });

                            // Coluna direita do footer (25%) - azul
                            row.RelativeItem(RIGHT_COLUMN_RATIO)
                                .Background(Colors.Blue.Darken2)
                                .Padding(10)
                                .AlignCenter()
                                .Text(DateTime.Now.ToString("dd/MM/yyyy"))
                                .FontSize(9)
                                .FontColor(Colors.White);
                        });
                });
            })
            .GeneratePdf(stream);

            stream.Position = 0;
            return stream;
        }

        private static byte[] CreateCircularImage(byte[] imageBytes, int size)
        {
            using var inputStream = new MemoryStream(imageBytes);
            using var original = SKBitmap.Decode(inputStream);

            // Cria um bitmap para a imagem circular
            using var surface = SKSurface.Create(new SKImageInfo(size, size, SKColorType.Rgba8888, SKAlphaType.Premul));
            var canvas = surface.Canvas;

            // Limpa o canvas com transparência
            canvas.Clear(SKColors.Transparent);

            // Cria um path circular
            var path = new SKPath();
            path.AddCircle(size / 2f, size / 2f, size / 2f);
            canvas.ClipPath(path, SKClipOperation.Intersect, true);

            // Calcula o redimensionamento mantendo proporção
            var sourceRect = new SKRect(0, 0, original.Width, original.Height);
            var destRect = new SKRect(0, 0, size, size);

            // Desenha a imagem dentro do círculo
            using var paint = new SKPaint
            {
                IsAntialias = true,
                FilterQuality = SKFilterQuality.High
            };

            canvas.DrawBitmap(original, sourceRect, destRect, paint);

            // Converte para bytes em formato PNG (com transparência)
            using var image = surface.Snapshot();
            using var data = image.Encode(SKEncodedImageFormat.Png, 100);
            return data.ToArray();
        }

        private static string FormatRange(DateTime? start, DateTime? end)
        {
            if (!start.HasValue && !end.HasValue) return string.Empty;

            string Format(DateTime d)
            {
                // Se não tiver dia relevante, mostrar mês/ano; caso contrário mostrar data completa
                return d.Day == 1 && d.Hour == 0 && d.Minute == 0 && d.Second == 0
                    ? d.ToString("MMM yyyy", CultureInfo.InvariantCulture)
                    : d.ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
            }

            var s = start.HasValue ? Format(start.Value) : string.Empty;
            var e = end.HasValue ? Format(end.Value) : "Presente";
            return string.IsNullOrWhiteSpace(s) ? e : $"{s} — {e}";
        }
    }
}
