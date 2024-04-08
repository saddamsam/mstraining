using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClaimAPI.Models
{
    [Owned]
    public class FullName
    {
        [Column("FirstName",TypeName = "VARCHAR(200)")]
        public string FirstName { get; set; }

        [Column("MiddleName", TypeName = "VARCHAR(200)")]
        public string MiddleName { get; set; }

        [Column("LastName", TypeName = "VARCHAR(200)")]
        public string LastName { get; set; }
    }
}
