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
        public MembershipTypeDTO MembershipType { get; set; }  //Linked this to a DTO instead of the model to avoid having the model too coupled. Mapped it instead.

        //[Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; } 
    }
}