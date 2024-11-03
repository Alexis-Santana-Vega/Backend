using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE.Chepeat.Domain.Aggregates.Auth;
public class LoginResponse
{
    public int NumError { get; set; }
    public string Result { get; set; }
    public string Token { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
    public DTOs.User? User { get; set; } = null;
}
