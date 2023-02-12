using Microsoft.Build.Framework;

namespace WebClient.Shared.Authorization
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
