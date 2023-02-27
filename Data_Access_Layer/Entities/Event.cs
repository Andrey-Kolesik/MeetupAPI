namespace Data_Access_Layer.Entities;

public partial class Event
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
