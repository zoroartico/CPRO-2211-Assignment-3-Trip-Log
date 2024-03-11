using Microsoft.Build.Framework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CPRO_2211_Assignment_3_Trip_Log.Models
{
    public class TripModel
    {

        //Basic Trip Object containing key elements of a Trip
        public int TripId { get; set; }
        public string Destination { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Accommodation { get; set; }

        //uses regex to enforce consistency
        [RegularExpression(@"^\(\d{3}\) \d{3}-\d{4}$",
            ErrorMessage = "The Phone field is invalid. Must be 10 digits")]
        public string? AccommodationPhone { get; set; }

        //uses regex to check for characters before and after an @,
        //then checks for period and 2 or more chars.
        [RegularExpression(@"^[a-zA-Z0-9._%+\-]+@[a-zA-Z0-9.\-]+\.[a-zA-Z]{2,}$",
            ErrorMessage = "The Email field is invalid. Correct format is example@email.com")]
        public string? AccommodationEmail { get; set; }
        public string? ThingToDo1 { get; set; }
        public string? ThingToDo2 { get; set; }
        public string? ThingToDo3 { get; set; }
    }
}
