using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NTools.ACL;
using NTools.ACL.Interfaces;
using ResumeCV.Domain.Entities;
using ResumeCV.Domain.Entities.Interfaces;
using ResumeCV.Domain.Services;
using ResumeCV.Domain.Services.Interfaces;
using ResumeCV.Domain.Templates.Factories;
using ResumeCV.Domain.Templates.Factories.Interfaces;
using ResumeCV.Infra.Context;
using ResumeCV.Infra.Interfaces.Pdf;
using ResumeCV.Infra.Interfaces.Repositories;
using ResumeCV.Infra.Interfaces.UnitOfWork;
using ResumeCV.Infra.Mapping.Profiles;
using ResumeCV.Infra.Pdf;
using ResumeCV.Infra.Repositories;
using ResumeCV.Infra.UnitOfWork;
using System.Reflection.Metadata;

namespace ResumeCV.Application
{
    public static class Initializer
    {

        private static void injectDependency(Type serviceType, Type implementationType, IServiceCollection services, bool scoped = true)
        {
            if (scoped)
                services.AddScoped(serviceType, implementationType);
            else
                services.AddTransient(serviceType, implementationType);
        }

        public static void Configure(IServiceCollection services, string? connection, bool scoped = true)
        {
            if (scoped)
            {
                services.AddDbContext<ResumeCVContext>(x => 
                {
                    x.UseLazyLoadingProxies()
                     .UseNpgsql(connection)
                     .EnableSensitiveDataLogging() // Adicione aqui
                     .EnableDetailedErrors();      // Opcional: mais detalhes de erros
                });
            }
            else
            {
                services.AddDbContextFactory<ResumeCVContext>(x => 
                {
                    x.UseLazyLoadingProxies()
                     .UseNpgsql(connection)
                     .EnableSensitiveDataLogging() // Adicione aqui também
                     .EnableDetailedErrors();      // Opcional
                });
            }

            // Registra o sistema de logging do .NET para permitir injeção de ILogger<T>
            services.AddLogging();

            #region Infra
            injectDependency(typeof(ResumeCVContext), typeof(ResumeCVContext), services, scoped);
            injectDependency(typeof(IUnitOfWork), typeof(UnitOfWork), services, scoped);
            //injectDependency(typeof(ILogCore), typeof(LogCore), services, scoped);
            #endregion

            #region Repository
            // Repositórios de infraestrutura / domínio
            injectDependency(typeof(IResumeRepository<IResumeModel>), typeof(ResumeRepository), services, scoped);
            //injectDependency(typeof(IResumeSkillRepository<IResumeSkillModel>), typeof(ResumeSkillRepository), services, scoped);
            #endregion

            #region AutoMapper
            // Registra o perfil de mapeamento (ResumeProfile) e todos os profiles no mesmo assembly
            services.AddAutoMapper(cfg => { }, typeof(ResumeProfile).Assembly);
            #endregion

            #region Service
            injectDependency(typeof(IResumeService), typeof(ResumeService), services, scoped);
            #endregion

            injectDependency(typeof(IFileClient), typeof(FileClient), services, scoped);
            injectDependency(typeof(IMarkdownRenderer), typeof(MarkdownRenderer), services, scoped);
            injectDependency(typeof(IPdfTemplateFactory), typeof(PdfTemplateFactory), services, scoped);


            //services.AddAuthentication("BasicAuthentication")
            //    .AddScheme<AuthenticationSchemeOptions, LocalAuthHandler>("BasicAuthentication", null);

        }
    }
}
