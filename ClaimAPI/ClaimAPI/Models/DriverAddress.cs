using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ClaimAPI.Models
{
    [Table("DriverAddress")]
    public class DriverAddress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Address_Id")]
        [JsonIgnore]
        public long AddressId { get; set; }

        [Column("Door_No", TypeName = "Varchar(10)")]
        public string DoorNo { get; set; }

        [Column("Street_Name", TypeName = "Varchar(100)")]
        public string streetName { get; set; }

        [Column("City", TypeName = "Varchar(100)")]
        public string City { get; set; }

        [Column("State", TypeName = "Varchar(100)")]
        public string State { get; set; }

        [Column("Country", TypeName = "Varchar(100)")]
        public string Country { get; set; }

        [Column("Pincode")]
        public long Pincode { get; set; }

        [ForeignKey("LicenseDetails")]
        [Column("DL_FK")]
        public string DLNO { get; set; }
        public LicenseDetails LicenseDetails { get; set; }

    }
}
