using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Policy_API.Models
{
    [Owned]
    public class FullName
    {
        [Column("First_Name",TypeName="varchar(100)")]
        [Required]
        [RegularExpression("^[a-zA-Z]{5,25}$",ErrorMessage ="First Name Should be in alphabets within 5 to 50 characters")]
        public string FirstName { get; set; } = string.Empty;

        [Column("Middle_Name", TypeName = "varchar(100)")]
        public string MiddleName { get; set; } = string.Empty;

        [Column("Last_Name", TypeName = "varchar(100)")]
        [Required]
        [RegularExpression("^[a-zA-Z]{5,25}$", ErrorMessage = "First Name Should be in alphabets within 5 to 50 characters")]
        public string LastName { get; set; } = string.Empty;
    }
}
