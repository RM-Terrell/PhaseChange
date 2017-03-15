using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using PhaseChange.Models;

namespace PhaseChange.DTOs
{
    public class CustomerDTO
    {

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewLetter { get; set; }

        public byte MembershipTypeId { get; set; }
                                                  
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; } 
    }
}