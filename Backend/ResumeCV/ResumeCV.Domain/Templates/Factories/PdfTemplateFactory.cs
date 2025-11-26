using ResumeCV.Domain.Templates.Factories.Interfaces;
using ResumeCV.Domain.Templates.Interfaces;
using ResumeCV.Infra.Interfaces.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeCV.Domain.Templates.Factories
{
    public class PdfTemplateFactory: IPdfTemplateFactory
    {
        private readonly IMarkdownRenderer _markdownRenderer;

        public PdfTemplateFactory(IMarkdownRenderer markdownRenderer)
        {
            _markdownRenderer = markdownRenderer;
        }

        public IPdfBaseTemplate Create()
        {
            return new PdfTemplate1(_markdownRenderer);
        }

    }
}
