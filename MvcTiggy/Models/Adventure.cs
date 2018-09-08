using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

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
        public int Duration { get; set; }
        public Interval DurationUnits { get; set; }

        public ICollection<AdventureMember> AdventureMembers { get; set; }
       

        [DisplayName("Estimated Cost")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal EstimatedCost { get; set; }

        public byte[] Image { get; set; }

        [NotMapped]
        public string ImageSource
        {
            get
            {
                string mimeType = "image/jpeg";
                string base64 = Convert.ToBase64String(Image);
                return string.Format("data:{0};base64,{1}", mimeType, base64);
            }
        }

        #endregion
    }
}
