using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CE.Chepeat.Application.Services;

namespace CE.Chepeat.Application.Presenters;
public class EmailPresenter : IEmailPresenter
{
    private readonly IEmailService _emailService;
    private readonly IUnitRepository _unitRepository;

    public EmailPresenter(IEmailService emailService, IUnitRepository unitRepository)
    {
        _emailService = emailService;
        _unitRepository = unitRepository;
    }
    public async Task SendEmailAsync(string to)
    {
        var user = await _unitRepository.authInfraestructure.ObtenerPorEmail(to);
        await _emailService.SendEmailAsync(to, "Bienvenido", "Views/Emails/WelcomeTemplate.cshtml", user);
    }
}
