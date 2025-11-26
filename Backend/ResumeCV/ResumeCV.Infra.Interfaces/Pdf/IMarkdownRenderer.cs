using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeCV.Infra.Interfaces.Pdf
{
    public interface IMarkdownRenderer
    {
        void Render(IContainer container, string markdown, int fontSize);
    }
}
