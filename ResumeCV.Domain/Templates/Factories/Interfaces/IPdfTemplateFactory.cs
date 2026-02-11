using ResumeCV.Domain.Templates.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeCV.Domain.Templates.Factories.Interfaces
{
    public interface IPdfTemplateFactory
    {
        IPdfBaseTemplate Create();
    }
}
