using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ClaimAPI.Models
{

    public enum Gender { MALE,FEMALE,TRANSGENDER }

    [Table("DriverDetails")]
    public class DriverDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("DD_Id")]
        [JsonIgnore]
        public long DriverDetailsId { get; set; }

        public FullName Name { get; set; }

        [Column("RelationshipWithIssuer", TypeName = "VARCHAR(200)")]
        public string RelationshipWithIssuer { get; set; }

        [Column("ContactNumber")]
        public long ContactNumber { get; set; }

        [Column("DOB")]
        [DataType(DataType.DateTime)]
        public DateTime DOB { get; set; }

        [Column("Gender")]
        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }

        [ForeignKey("LicenseDetails")]
        [Column("DL_FK")]
        public string DLNO { get; set; }
        public LicenseDetails LicenseDetails { get; set; }

    }
}
