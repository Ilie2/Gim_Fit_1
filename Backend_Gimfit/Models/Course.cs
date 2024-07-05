using System.Text.Json.Serialization;

namespace Backend_Gimfit.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public int Capacity { get; set; }
        public int SubscriptionId { get; set; }
        public Subscription Subscription { get; set; }
        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; }
    }
}
