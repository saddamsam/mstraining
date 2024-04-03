using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Policy_API.Models
{
    [Table("Address")]
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Address_Id")]
        [JsonIgnore]
        public long AddressId { get; set; }
        
        [Column("Door_No",TypeName ="Varchar(10)")]
        public string DoorNo { get; set; }
        
        [Column("Street_Name", TypeName = "Varchar(100)")]
        public string streetName { get; set; }

        [Column("City", TypeName = "Varchar(100)")]
        public string City { get; set; }

        [Column("State", TypeName = "Varchar(100)")]
        public string State { get; set; }
        
        [Column("Country", TypeName ="Varchar(100)")]
        public string Country { get; set; }
        
        [Column("Pincode")]
        public long Pincode { get; set; }

        [ForeignKey("PolicyHolder")]
        [Column("AdharCard_No_FK")]
        public string AdharCardNo { get; set; }
        [JsonIgnore]
        public PolicyHolder PolicyHolder { get; set; }
    }
}
