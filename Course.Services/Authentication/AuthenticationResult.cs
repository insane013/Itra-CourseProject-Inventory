namespace Course.Services.Authentication;

public class AuthenticationResult
{
    public bool Succeeded { get; init; }
    public ICollection<string> Errors { get; init; } = new List<string>();
    public static AuthenticationResult Success => new AuthenticationResult { Succeeded = true };
}
