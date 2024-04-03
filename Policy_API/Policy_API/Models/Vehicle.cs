using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Policy_API.Models
{
    public enum FuelType { PETROL, DIESEL, ELECTRIC, GAS, HYBRID}

    [Table("Vehicle")]
    public class Vehicle
    {
        [Key]
        [Column("Registration_No")]
        public string RegistrationNo { get; set; }

        [Column("Maker",TypeName ="Varchar(100)")]
        public string Maker { get; set; }

        [Column("DOR")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0: dd/MM/yyyy}")]
        public string DOR { get; set; }

        [Column("Engine_No", TypeName = "Varchar(100)")]
        public string EngineNo { get; set; }

        [Column("Chassis_No", TypeName = "Varchar(100)")]
        public string ChassisNo { get; set; }

        [Column("Fuel_Type")]
        [EnumDataType(enumType: typeof(FuelType))]
        public FuelType FuelType { get; set; }
        
        [Column("Color", TypeName = "Varchar(30)")]
        public string Color { get; set; }
    }
}
