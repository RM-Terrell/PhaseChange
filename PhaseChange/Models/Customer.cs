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

        [Required(ErrorMessage ="Enter customer's name")] //How to over ride message
        [StringLength(255)] //Data annotations
        public string Name { get; set; }

        public bool IsSubscribedToNewLetter { get; set; }

        public MembershipType MembershipType { get; set; } //Navigation property

        [Display(Name = "Membership Type")] //Over rides display from default
        public byte MembershipTypeId { get; set; }//Treated as a forgeign key automagically. 
                                                  // Byte is implicitly requried. Use byte? if you want nullable

        [Display(Name = "Date of Birth")]
        public DateTime? Birthdate { get; set; } //"?" makes it nullable
    }
    
}

