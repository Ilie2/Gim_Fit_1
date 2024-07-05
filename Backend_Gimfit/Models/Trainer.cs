using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Backend_Gimfit.Models
{
    public class Trainer
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; } = "Trainer";
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Experience { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public ICollection<Client> Clients { get; set; } = new List<Client>();
        [JsonIgnore]
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }


}
