using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Flight_Manager.Models
{
    public class ReservationDataModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Enter your First name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Enter your Middle name")]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Enter your Last name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Enter your EGN") ]
        public string EGN { get; set; }
        [Required(ErrorMessage = "Enter your Phone number")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Enter your nationality name")]
        public string Nationality { get; set; }
        [Required(ErrorMessage = "Enter your Ticket type")]
        [Display(Name = "Ticket Type")]
        public TicketEnum TicketType { get; set; }
        public virtual FlightDataModel Flight { get; set; }
    }
}
