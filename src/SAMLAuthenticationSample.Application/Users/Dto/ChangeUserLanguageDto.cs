using System.ComponentModel.DataAnnotations;

namespace SAMLAuthenticationSample.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}