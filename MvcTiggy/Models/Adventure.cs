using System;
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
        public DateTime PlannedDate { get; set; }
        public decimal EstimatedCost { get; set; }

        #endregion
    }
}
