namespace CE.Chepeat.Domain.Aggregates.PasswordResetToken;
public class ResetPasswordRequest
{
    public string Token { get; set; }
    public string NewPassword { get; set; }
}
