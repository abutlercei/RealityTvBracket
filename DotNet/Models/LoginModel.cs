using Microsoft.AspNetCore.Mvc;

// Used in UserProfileController to receive login information and validate credentials
public class LoginModel
{
    [FromForm(Name = "login_username")]
    public string? Username { get; set; }

    [FromForm(Name = "login_password")]
    public string? Password { get; set; }
}