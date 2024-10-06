using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CE.Chepeat.Domain.Aggregates.Auth;

namespace CE.Chepeat.Application.Presenters;
public class AuthPresenter : IAuthPresenter
{
    private readonly IUnitRepository _unitRepository;
    private readonly IMapper _mapper;

    public AuthPresenter(IUnitRepository unitRepository, IMapper mapper)
    {
        _unitRepository = unitRepository;
        _mapper = mapper;
    }
    public async Task<RespuestaDB> RegistrarUsuario(RegistrationRequest request)
    {
        request.Password =  BCrypt.Net.BCrypt.HashPassword(request.Password);
        return await _unitRepository.authInfraestructure.RegistrarUsuario(request);
    }
}

