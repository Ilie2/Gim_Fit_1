using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Backend_Gimfit.Models
{
    public class Client
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; } = "Client";
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Subscription { get; set; }
        public string Description { get; set; }
        public int? TrainerId { get; set; }  // Poate fi null dacă nu are un trainer
        [JsonIgnore]
        public Trainer Trainer { get; set; }
        [JsonIgnore]

        public virtual List<CourseSchedule> CourseSchedules { get; set; }
    }
}
