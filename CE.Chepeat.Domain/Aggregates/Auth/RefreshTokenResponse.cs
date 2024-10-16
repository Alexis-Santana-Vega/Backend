namespace CE.Chepeat.Domain.Aggregates.Auth;
public class RefreshTokenResponse
{
    public int NumError { get; set; }
    public string Result { get; set; }
    public string Token { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty ;
}
