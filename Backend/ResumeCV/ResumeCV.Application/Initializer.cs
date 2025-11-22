using Microsoft.Extensions.DependencyInjection;
using ResumeCV.Infra.Context;
using ResumeCV.Infra.Repositories;
using ResumeCV.Domain.Entities;
using ResumeCV.Infra.Mapping.Profiles;
using AutoMapper;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using ResumeCV.Infra.Interfaces.Repositories;
using ResumeCV.Domain.Entities.Interfaces;
using ResumeCV.Domain.Services.Interfaces;
using ResumeCV.Domain.Services;
using ResumeCV.Infra.Interfaces.UnitOfWork;
using ResumeCV.Infra.UnitOfWork;
using Microsoft.Extensions.Logging;

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
                services.AddDbContext<ResumeCVContext>(x => x.UseLazyLoadingProxies().UseNpgsql(connection));
            else
                services.AddDbContextFactory<ResumeCVContext>(x => x.UseLazyLoadingProxies().UseNpgsql(connection));

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
            injectDependency(typeof(IResumeCourseRepository<IResumeCourseModel>), typeof(ResumeCourseRepository), services, scoped);
            injectDependency(typeof(IResumeInfoRepository<IResumeInfoModel>), typeof(ResumeInfoRepository), services, scoped);
            injectDependency(typeof(IResumeJobRepository<IResumeJobModel>), typeof(ResumeJobRepository), services, scoped);
            injectDependency(typeof(IResumeLanguageRepository<IResumeLanguageModel>), typeof(ResumeLanguageRepository), services, scoped);
            injectDependency(typeof(IResumeSkillRepository<IResumeSkillModel>), typeof(ResumeSkillRepository), services, scoped);
            #endregion

            #region AutoMapper
            // Registra o perfil de mapeamento (ResumeProfile) e todos os profiles no mesmo assembly
            services.AddAutoMapper(cfg => { }, typeof(ResumeProfile).Assembly);
            #endregion

            #region Service
            injectDependency(typeof(IResumeService), typeof(ResumeService), services, scoped);
            #endregion

            //injectDependency(typeof(IUserClient), typeof(UserClient), services, scoped);


            //services.AddAuthentication("BasicAuthentication")
            //    .AddScheme<AuthenticationSchemeOptions, LocalAuthHandler>("BasicAuthentication", null);

        }
    }
}
