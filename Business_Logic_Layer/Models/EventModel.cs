namespace Business_Logic_Layer.Models
{
    public class EventModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Plan { get; set; }

        public string? Organizer { get; set; }

        public string? Speaker { get; set; }

        public string? Place { get; set; }

        public DateTime? Date { get; set; }
    }
}
