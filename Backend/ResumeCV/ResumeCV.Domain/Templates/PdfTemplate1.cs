using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using ResumeCV.Domain.Entities.Interfaces;
using ResumeCV.Domain.Templates.Interfaces;
using ResumeCV.DTOs.Enums;
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
        private const int MAIN_COLUMN_RATIO = 7;
        private const int RIGHT_COLUMN_RATIO = 4;
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
                               .OrderBy(s => s.SkillType)
                               .Select(s => s!.Name)
                               .Distinct(StringComparer.InvariantCultureIgnoreCase)
                               .ToList();

            var languages = resume.Languages ?? Enumerable.Empty<IResumeLanguageModel>();

            // Filtra links (InfoType = 1)
            var links = resume.Infos?
                .Where(i => i.InfoType == InfoTypeEnum.Links && !string.IsNullOrWhiteSpace(i.Url))
                .ToList() ?? new List<IResumeInfoModel>();

            // Filtra outras infos (não links)
            var otherInfos = resume.Infos?
                .Where(i => i.InfoType != InfoTypeEnum.Links)
                .ToList() ?? new List<IResumeInfoModel>();

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
                                    main.Item().Text(contacts).FontSize(9).FontColor(Colors.Grey.Medium);
                                }

                                // Links (InfoType = 1)
                                if (links.Any())
                                {
                                    var linksText = string.Join(" • ", links.Select(link => 
                                        $"🔗 {link.Url}"));
                                    main.Item().PaddingBottom(10).Text(linksText).FontSize(9).FontColor(Colors.Blue.Darken1);
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
                                                r.ConstantItem(120).PaddingTop(2).AlignRight().Text(period).FontSize(8).FontColor(Colors.Grey.Medium);
                                            });

                                            if (!string.IsNullOrWhiteSpace(job.Business2))
                                                jobCol.Item().Text(job.Business2).FontSize(10).FontColor(Colors.Grey.Darken3);

                                            if (!string.IsNullOrWhiteSpace(job.Location))
                                                jobCol.Item().Text($"Local: {job.Location}").FontSize(9).FontColor(Colors.Grey.Medium);

                                            if (!string.IsNullOrWhiteSpace(job.Resume))
                                            {
                                                jobCol.Item().PaddingTop(2).Element(container =>
                                                    _markdownRenderer.Render(container, job.Resume, 9, true));
                                            }

                                            if (job.Skills != null && job.Skills.Any())
                                            {
                                                var jobSkills = string.Join(", ", job.Skills.Where(s => !string.IsNullOrWhiteSpace(s?.Name)).Select(s => s!.Name));
                                                if (!string.IsNullOrWhiteSpace(jobSkills))
                                                    //jobCol.Item().PaddingTop(4).Text($"Competências: {jobSkills}").FontSize(8).FontColor(Colors.Grey.Medium);
                                                    jobCol.Item().Text($"Competências: {jobSkills}").FontSize(8).FontColor(Colors.Grey.Medium).Justify();
                                            }
                                        });
                                    }
                                }

                                // Infos (projetos / extras - excluindo links)
                                if (otherInfos.Any())
                                {
                                    main.Item().PaddingTop(15).PaddingBottom(4).Text("Informações").FontSize(14).Bold();
                                    foreach (var info in otherInfos)
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
                                            _markdownRenderer.Render(container, resume.Resume!, 8, true));
                                }

                                // Skills agregadas
                                if (skills.Any())
                                {
                                    rightCol.Item().PaddingTop(20).PaddingBottom(2).Text("Competências").FontSize(14).Bold().FontColor(Colors.White);
                                    rightCol.Item().PaddingBottom(10).Height(1).Background(Colors.White);
                                    
                                    var skillsText = string.Join(" • ", skills);
                                    rightCol.Item().Text(skillsText).FontSize(8).FontColor(Colors.White).Justify();
                                }

                                // Cursos / Formação
                                if (resume.Courses != null && resume.Courses.Any())
                                {
                                    rightCol.Item().PaddingTop(20).PaddingBottom(2).Text("Formação / Cursos").FontSize(14).Bold().FontColor(Colors.White);
                                    rightCol.Item().PaddingBottom(10).Height(1).Background(Colors.White);
                                    
                                    foreach (var course in resume.Courses)
                                    {
                                        rightCol.Item().PaddingBottom(10).Column(courseCol =>
                                        {
                                            var period = FormatRange(course.StartDate, course.EndDate, false);
                                            
                                            courseCol.Item().Text(course.Title).Bold().FontSize(10).FontColor(Colors.White);
                                            
                                            // Institute e data na mesma linha
                                            if (!string.IsNullOrWhiteSpace(course.Institute) || !string.IsNullOrWhiteSpace(period))
                                            {
                                                courseCol.Item().Row(r =>
                                                {
                                                    if (!string.IsNullOrWhiteSpace(course.Institute))
                                                        r.RelativeItem().Text(course.Institute).FontSize(8).FontColor(Colors.White);
                                                    
                                                    if (!string.IsNullOrWhiteSpace(period))
                                                        r.AutoItem().AlignRight().Text(period).FontSize(8).FontColor(Colors.White);
                                                });
                                            }

                                            if (!string.IsNullOrWhiteSpace(course.Location))
                                                courseCol.Item().Text($"Local: {course.Location}").FontSize(7).FontColor(Colors.Grey.Lighten2);

                                            if (!string.IsNullOrWhiteSpace(course.Resume))
                                            {
                                                courseCol.Item().PaddingTop(2).DefaultTextStyle(x => x.FontSize(7).FontColor(Colors.White))
                                                    .Element(container =>
                                                        _markdownRenderer.Render(container, course.Resume, 7, true));
                                            }

                                            if (course.Skills != null && course.Skills.Any())
                                            {
                                                var cskills = string.Join(", ", course.Skills.Where(s => !string.IsNullOrWhiteSpace(s?.Name)).Select(s => s!.Name));
                                                if (!string.IsNullOrWhiteSpace(cskills))
                                                    courseCol.Item().PaddingTop(2).Text($"Skills: {cskills}").FontSize(7).FontColor(Colors.Grey.Lighten2).Justify();
                                            }
                                        });
                                    }
                                }

                                // Languages
                                if (languages.Any())
                                {
                                    rightCol.Item().PaddingTop(20).PaddingBottom(2).Text("Idiomas").FontSize(14).Bold().FontColor(Colors.White);
                                    rightCol.Item().PaddingBottom(10).Height(1).Background(Colors.White);
                                    
                                    foreach (var lang in languages)
                                    {
                                        rightCol.Item().PaddingVertical(2).Row(r =>
                                        {
                                            // Nome do idioma à esquerda
                                            r.RelativeItem().Text(lang.Language).FontSize(10).FontColor(Colors.White);
                                            
                                            // Nível no centro
                                            r.AutoItem().PaddingHorizontal(5).Text(GetLevelText(lang.Level)).FontSize(9).FontColor(Colors.White);
                                            
                                            // 5 círculos à direita representando o nível
                                            r.AutoItem().Row(bulletRow =>
                                            {
                                                for (int i = 1; i <= 5; i++)
                                                {
                                                    // Círculo preenchido se o nível for >= i, caso contrário círculo vazio
                                                    string bullet = i <= lang.Level ? "●" : "○";
                                                    bulletRow.AutoItem().PaddingLeft(2).Text(bullet).FontSize(10).FontColor(Colors.White);
                                                }
                                            });
                                        });
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

        private static string FormatRange(DateTime? start, DateTime? end, bool showDuration = true)
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

            // Calcula a diferença em anos e meses
            string duration = string.Empty;
            if (showDuration && start.HasValue)
            {
                var endDate = end ?? DateTime.Now;
                var years = endDate.Year - start.Value.Year;
                var months = endDate.Month - start.Value.Month;

                if (months < 0)
                {
                    years--;
                    months += 12;
                }

                // Ajuste fino: se o dia final for menor que o dia inicial, reduz um mês
                if (endDate.Day < start.Value.Day)
                {
                    months--;
                    if (months < 0)
                    {
                        years--;
                        months += 12;
                    }
                }

                // Formata a duração
                if (years > 0 && months > 0)
                    duration = $" ({years}a{months}m)";
                else if (years > 0)
                    duration = $" ({years}a)";
                else if (months > 0)
                    duration = $" ({months}m)";
            }

            return string.IsNullOrWhiteSpace(s) ? e : $"{s} — {e}{duration}";
        }

        private static string GetLevelText(int level)
        {
            return level switch
            {
                1 => "Básico",
                2 => "Intermediário",
                3 => "Avançado",
                4 => "Fluente",
                5 => "Nativo",
                _ => "Básico"
            };
        }
    }
}
