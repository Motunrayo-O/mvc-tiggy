using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcTiggy.Models
{
    public class Adventure
    {
        public Adventure()
        {
        }

        #region Properties

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [DisplayName("Departure Date")]
        [DataType(DataType.Date)]
        public DateTime PlannedDate { get; set; }

        [DisplayName("Estimated Cost")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal EstimatedCost { get; set; }

        #endregion
    }
}
