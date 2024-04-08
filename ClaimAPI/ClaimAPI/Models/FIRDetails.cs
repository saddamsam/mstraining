using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClaimAPI.Models
{
    public enum EventType { ACCIDENT, THEFT, ASSAULT, OTHERS}
    [Table("FIRDetails")]
    public class FIRDetails
    {
        [Key]
        [Column("FIRNO",TypeName ="Varchar(20))")]
        public string FIRNO { get; set; }

        [Column("NameOfPoliceStation", TypeName = "Varchar(200))")]
        public string NameOfPoliceStation { get; set; }

        [Column("EventType")]
        [EnumDataType(enumType:typeof(EventType))]
        public EventType EventType { get; set; }

        [Column("EventStatement", TypeName = "Varchar(500))")]
        public string EventStatement { get; set; }


    }
}
