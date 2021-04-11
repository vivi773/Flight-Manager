using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Flight_Manager.Models
{
    public class FlightDataModel
    {
        [Key]
        public int AirlineID { get; set; }
        [Required]
        [Display(Name = "Airline Name")]
        public string AirlineName { get; set; }
        [Required]
        [Display(Name = "From")]
        public string FromLocation { get; set; }
        [Required]
        [Display(Name = "To")]
        public string ToLocation { get; set; }
        [Display(Name = "Departure Time")]
        public DateTime DepatureTime { get; set; }
        [Display(Name = "Arrival Time")]
        public DateTime ArrivalTime { get; set; }
        [Required]
        [Display(Name = "Pilot Name")]
        public string PilotName { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        [Display(Name = "Business Capacity")]
        public int BusinessCapacity { get; set; }
        public virtual ICollection<ReservationDataModel> Passengers { get; set; }
    }
}
