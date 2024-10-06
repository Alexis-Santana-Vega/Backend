using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CE.Chepeat.Domain.Aggregates.Auth;

namespace CE.Chepeat.Domain.Interfaces.Infraestructure;
public interface IAuthInfraestructure
{
    Task<RespuestaDB> RegistrarUsuario(RegistrationRequest request);
    Task<RespuestaDB> LoginUsuario(LoginRequest request);
}
