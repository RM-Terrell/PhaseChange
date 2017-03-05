using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhaseChange.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)] //Data annotations
        public string Name { get; set; }
        public bool IsSubscribedToNewLetter { get; set; }
        public MembershipType MembershipType { get; set; } //Navigation property
        public byte MembershipTypeId { get; set; }//Treated as a forgeign key automagically
        public DateTime? Birthdate { get; set; }
    }
}