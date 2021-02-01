using System.ComponentModel.DataAnnotations;

namespace MpaCore.PhoneBook.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}