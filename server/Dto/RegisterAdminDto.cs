using System.ComponentModel.DataAnnotations;

namespace server.Dto
{
    public class RegisterAdminDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        

     
        


    }
}
