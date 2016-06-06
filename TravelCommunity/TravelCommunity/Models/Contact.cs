using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelCommunity.Models
{
    public class Contact
    {
        public int id { get; set; }
        public string Name {get; set; }
        public string FamilyName { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public virtual ApplicationUser AppUser {get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
    }
}