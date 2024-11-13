using System.ComponentModel.DataAnnotations;

namespace APIAngularReact.Dtos
{
    public class dtoLogin
    {
        [Required]
        public string UserName { get; set; }

        [Required]

        public string Password { get; set; }


    }
}
