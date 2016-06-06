using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelCommunity.Models
{
    public class Phone
    {
    
        public int id { get; set; }
        public int Number { get; set; }
        public int contactId { get; set; }
        public virtual Contact Contact { get; set; }
    }
}