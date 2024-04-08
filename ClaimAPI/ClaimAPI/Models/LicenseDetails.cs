using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClaimAPI.Models
{
    public enum VehicleClass { Transport, LMV, HGV }
    public enum DriverType { Permanent, Learner }

    [Table("LicenseDetails")]
    public class LicenseDetails
    {
        [Key]
        [Column("DL_NO",TypeName ="Varchar(30)")]
        public string DLNO { get; set; }

        [Column("Issuing_RTO", TypeName = "VARCHAR(200)")]
        public string Issuing_RTO { get; set; }

        [Column("License_Effective_From")]
        [DataType(DataType.DateTime)]
        public DateTime License_Effective_From { get; set; }

        [Column("License_Expiry_Date")]
        [DataType(DataType.DateTime)]
        public DateTime License_Expiry_Date { get; set; }

        [Column("VehicleClass")]
        [EnumDataType(typeof(VehicleClass))]
        public VehicleClass VehicleClass { get; set; }

        [Column("DriverType")]
        [EnumDataType(typeof(DriverType))]
        public DriverType DriverType { get; set; }

      
    }
}
