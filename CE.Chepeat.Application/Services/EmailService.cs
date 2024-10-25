using CE.Chepeat.Application.Commons;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using RazorLight;
using System.Threading.Tasks;

namespace CE.Chepeat.Application.Services;

public class EmailService : IEmailService
{
    private readonly SmtpSettings _smtpSettings;
    private readonly RazorLightEngine _razorLightEngine;

    public EmailService(IOptions<SmtpSettings> smtpSettings)
    {
        _smtpSettings = smtpSettings.Value;

        _razorLightEngine = new RazorLightEngineBuilder()
            .UseEmbeddedResourcesProject(typeof(EmailService))
            .UseMemoryCachingProvider()
            .EnableDebugMode()
            .Build();
    }

    public async Task SendEmailAsync(string to, string subject, string templateName, object model)
    {
        // Renderizar la plantilla HTML
        string body = await _razorLightEngine.CompileRenderAsync(templateName, model);

        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(_smtpSettings.From));
        email.To.Add(MailboxAddress.Parse(to));
        email.Subject = subject;

        var bodyBuilder = new BodyBuilder { HtmlBody = body };
        email.Body = bodyBuilder.ToMessageBody();

        using var smtp = new SmtpClient();
        await smtp.ConnectAsync(_smtpSettings.SmtpServer, _smtpSettings.Port, _smtpSettings.UseSsl);
        await smtp.AuthenticateAsync(_smtpSettings.Username, _smtpSettings.Password);
        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true);
    }
}

