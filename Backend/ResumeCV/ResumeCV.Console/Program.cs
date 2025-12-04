using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ResumeCV.Application;
using ResumeCV.Domain.Services;
using ResumeCV.Domain.Services.Interfaces;
using System.Diagnostics;

const long RESUME_ID = 10;

// Carrega configuração do appsettings.json
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true)
    .Build();

var connectionString = configuration.GetConnectionString("ResumeCVContext") 
    ?? throw new InvalidOperationException("Connection string 'ResumeCVContext' não encontrada.");

var services = new ServiceCollection();

// Registra dependências (usa Initializer do projeto)
Initializer.Configure(services, connectionString, scoped: true);

// Cria o ServiceProvider
using var provider = services.BuildServiceProvider();

// Resolve o serviço (registrado como IResumeService -> ResumeService)
var resumeServiceInterface = provider.GetRequiredService<IResumeService>();

// Se precisar da instância concreta ResumeService:
var resumeService = (ResumeService)resumeServiceInterface;

// Exemplo simples de uso
Console.WriteLine($"Instância criada: {resumeService.GetType().FullName}");
Console.WriteLine($"Conectado ao banco: {connectionString.Split(';')[0]}");

var streamPdf = resumeService.GeneratePdf(RESUME_ID);

// Salva o PDF em um arquivo
var fileName = $"Resume_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
var filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

using (var fileStream = File.Create(filePath))
{
    streamPdf.CopyTo(fileStream);
}

Console.WriteLine($"PDF salvo em: {filePath}");

// Abre o PDF com o programa padrão
try
{
    Process.Start(new ProcessStartInfo
    {
        FileName = filePath,
        UseShellExecute = true
    });
    Console.WriteLine("PDF aberto com sucesso!");
}
catch (Exception ex)
{
    Console.WriteLine($"Erro ao abrir o PDF: {ex.Message}");
}
