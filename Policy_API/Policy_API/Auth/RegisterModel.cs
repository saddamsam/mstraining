using System.ComponentModel.DataAnnotations;

namespace Policy_API.Auth
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="User Name is Required")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
        
        [Required(ErrorMessage ="Email is Required")]
        public string Email { get; set; }
    }
}
