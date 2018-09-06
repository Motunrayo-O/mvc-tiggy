using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcTiggy.Models
{
    public class AdventureCostViewModel
    {

        public List<Adventure> Adventures;
        public SelectList CostRanges;
        public decimal adventureMaxCost { get; set; }
    }
    
}
