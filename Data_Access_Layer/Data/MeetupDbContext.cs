using Data_Access_Layer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer.Data;

public partial class MeetupDbContext : DbContext
{
    public MeetupDbContext(DbContextOptions<MeetupDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Event> Events { get; set; }
}
