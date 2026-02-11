using Markdig;
using Markdig.Extensions.Tables;
using Markdig.Syntax;
using Markdig.Syntax.Inlines;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using ResumeCV.Infra.Interfaces.Pdf;
using System;
using System.Linq;

namespace ResumeCV.Infra.Pdf
{
    public class MarkdownRenderer: IMarkdownRenderer
    {
        private int _baseFontSize;
        private bool _justify;

        public void Render(IContainer container, string markdown, int fontSize, bool justify = false)
        {
            if (string.IsNullOrWhiteSpace(markdown))
                return;

            _baseFontSize = fontSize;
            _justify = justify;

            var pipeline = new MarkdownPipelineBuilder()
                .UseAdvancedExtensions()
                .Build();

            var document = Markdown.Parse(markdown, pipeline);

            container.Column(col =>
            {
                foreach (var block in document)
                {
                    RenderBlock(col, block);
                }
            });
        }

        private void RenderBlock(ColumnDescriptor column, Block block)
        {
            switch (block)
            {
                case HeadingBlock heading:
                    RenderHeading(column, heading);
                    break;

                case ParagraphBlock paragraph:
                    RenderParagraph(column, paragraph);
                    break;

                case ListBlock list:
                    RenderList(column, list);
                    break;

                case CodeBlock code:
                    RenderCodeBlock(column, code);
                    break;

                case QuoteBlock quote:
                    RenderQuote(column, quote);
                    break;

                case ThematicBreakBlock:
                    RenderHorizontalRule(column);
                    break;

                case Table table:
                    RenderTable(column, table);
                    break;

                case HtmlBlock html:
                    // HTML blocks são ignorados por enquanto
                    break;

                default:
                    // Fallback para tipos não implementados
                    var textBlock = column.Item()
                        .PaddingBottom(5)
                        .Text(block.ToString() ?? string.Empty)
                        .FontSize(_baseFontSize).
                        Justify();
                    if (_justify) textBlock.Justify();
                    break;
            }
        }

        private void RenderHeading(ColumnDescriptor column, HeadingBlock heading)
        {
            var fontSize = heading.Level switch
            {
                1 => _baseFontSize * 1.8f,
                2 => _baseFontSize * 1.6f,
                3 => _baseFontSize * 1.4f,
                4 => _baseFontSize * 1.2f,
                5 => _baseFontSize * 1.1f,
                _ => _baseFontSize * 1.0f
            };

            column.Item()
                .PaddingTop(heading.Level == 1 ? 10 : 8)
                .PaddingBottom(4)
                .DefaultTextStyle(x => x.FontSize(fontSize).Bold())
                .Text(text =>
                {
                    RenderInlines(text, heading.Inline);
                    if (_justify) text.Justify();
                });
        }

        private void RenderParagraph(ColumnDescriptor column, ParagraphBlock paragraph)
        {
            column.Item()
                .PaddingBottom(2)
                .DefaultTextStyle(x => x.FontSize(_baseFontSize))
                .Text(text =>
                {
                    RenderInlines(text, paragraph.Inline);
                    if (_justify) text.Justify();
                });
        }

        private void RenderList(ColumnDescriptor column, ListBlock list)
        {
            column.Item().PaddingBottom(2).Column(listCol =>
            {
                var index = 1;
                foreach (ListItemBlock item in list)
                {
                    listCol.Item().PaddingLeft(5).PaddingBottom(2).Row(row =>
                    {
                        // Bullet ou número
                        var bullet = list.IsOrdered ? $"{index}." : "•";
                        row.ConstantItem(10).Text(bullet).FontSize(_baseFontSize);

                        // Conteúdo do item
                        row.RelativeItem().Column(itemCol =>
                        {
                            foreach (var block in item)
                            {
                                if (block is ParagraphBlock para)
                                {
                                    itemCol.Item()
                                        .DefaultTextStyle(x => x.FontSize(_baseFontSize))
                                        .Text(text =>
                                        {
                                            RenderInlines(text, para.Inline);
                                            if (_justify) text.Justify();
                                        });
                                }
                                else
                                {
                                    RenderBlock(itemCol, block);
                                }
                            }
                        });
                    });
                    index++;
                }
            });
        }

        private void RenderCodeBlock(ColumnDescriptor column, CodeBlock code)
        {
            var codeText = string.Join("\n", code.Lines.Lines.Select(l => l.ToString()));

            column.Item()
                .PaddingBottom(8)
                .Background(Colors.Grey.Lighten3)
                .Padding(10)
                .Text(codeText)
                .FontFamily("Courier New")
                .FontSize(_baseFontSize * 0.9f)
                .FontColor(Colors.Grey.Darken4);
        }

        private void RenderQuote(ColumnDescriptor column, QuoteBlock quote)
        {
            column.Item()
                .PaddingBottom(8)
                .BorderLeft(3)
                .BorderColor(Colors.Grey.Medium)
                .PaddingLeft(10)
                .DefaultTextStyle(x => x.FontColor(Colors.Grey.Darken2))
                .Column(quoteCol =>
                {
                    foreach (var block in quote)
                    {
                        RenderBlock(quoteCol, block);
                    }
                });
        }

        private void RenderHorizontalRule(ColumnDescriptor column)
        {
            column.Item()
                .PaddingVertical(10)
                .Height(1)
                .Background(Colors.Grey.Medium);
        }

        private void RenderTable(ColumnDescriptor column, Table table)
        {
            column.Item().PaddingBottom(8).Table(tbl =>
            {
                // Define colunas
                var columnCount = table.ColumnDefinitions.Count;
                
                tbl.ColumnsDefinition(cols =>
                {
                    for (int j = 0; j < columnCount; j++)
                    {
                        cols.RelativeColumn();
                    }
                });

                // Renderiza linhas
                foreach (TableRow row in table)
                {
                    var isHeader = row.IsHeader;
                    
                    foreach (TableCell cell in row)
                    {
                        tbl.Cell()
                            .Border(0.5f)
                            .BorderColor(Colors.Grey.Medium)
                            .Padding(5)
                            .Background(isHeader ? Colors.Grey.Lighten3 : Colors.White)
                            .DefaultTextStyle(x => x.FontSize(_baseFontSize * 0.9f))
                            .Column(cellCol =>
                            {
                                foreach (var block in cell)
                                {
                                    if (block is ParagraphBlock para)
                                    {
                                        var style = isHeader 
                                            ? cellCol.Item().DefaultTextStyle(x => x.Bold())
                                            : cellCol.Item();
                                        
                                        style.Text(text =>
                                        {
                                            RenderInlines(text, para.Inline);
                                            if (_justify) text.Justify();
                                        });
                                        
                                    }
                                    else
                                    {
                                        RenderBlock(cellCol, block);
                                    }
                                }
                            });
                    }
                }
            });
        }

        private void RenderInlines(TextDescriptor text, ContainerInline? inline)
        {
            if (inline == null) return;

            foreach (var item in inline)
            {
                switch (item)
                {
                    case LiteralInline literal:
                        text.Span(literal.Content.ToString());
                        break;

                    case EmphasisInline emphasis:
                        RenderEmphasis(text, emphasis);
                        break;

                    case CodeInline code:
                        text.Span(code.Content)
                            .FontFamily("Courier New")
                            .FontSize(_baseFontSize * 0.9f)
                            .BackgroundColor(Colors.Grey.Lighten3)
                            .FontColor(Colors.Grey.Darken4);
                        break;

                    case LinkInline link:
                        RenderLink(text, link);
                        break;

                    case LineBreakInline:
                        text.Span("\n");
                        break;

                    case HtmlInline:
                        // HTML inline é ignorado
                        break;

                    case AutolinkInline autolink:
                        text.Span(autolink.Url)
                            .FontColor(Colors.Blue.Darken1)
                            .Underline();
                        break;

                    case ContainerInline container:
                        RenderInlines(text, container);
                        break;

                    default:
                        text.Span(item.ToString() ?? string.Empty);
                        break;
                }
            }
        }

        private void RenderEmphasis(TextDescriptor text, EmphasisInline emphasis)
        {
            foreach (var inline in emphasis)
            {
                var content = GetInlineText(inline);
                
                if (emphasis.DelimiterCount == 2) // Bold (**)
                {
                    text.Span(content).Bold();
                }
                else if (emphasis.DelimiterCount == 1) // Italic (*)
                {
                    text.Span(content).Italic();
                }
                else
                {
                    text.Span(content);
                }
            }
        }

        private void RenderLink(TextDescriptor text, LinkInline link)
        {
            var linkText = GetInlineText(link);
            text.Span(linkText)
                .FontColor(Colors.Blue.Darken1)
                .Underline();
            
            // Adiciona URL entre parênteses se for diferente do texto
            if (!string.IsNullOrWhiteSpace(link.Url) && link.Url != linkText)
            {
                text.Span($" ({link.Url})").FontSize(_baseFontSize * 0.8f).FontColor(Colors.Grey.Medium);
            }
        }

        private string GetInlineText(Inline inline)
        {
            return inline switch
            {
                LiteralInline literal => literal.Content.ToString(),
                CodeInline code => code.Content,
                LineBreakInline => "\n",
                ContainerInline container => GetContainerInlineText(container),
                _ => inline.ToString() ?? string.Empty
            };
        }

        private string GetContainerInlineText(ContainerInline container)
        {
            var result = string.Empty;
            foreach (var item in container)
            {
                result += GetInlineText(item);
            }
            return result;
        }
    }
}
