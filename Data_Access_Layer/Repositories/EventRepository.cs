using Data_Access_Layer.Data;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer.Repositories
{
    public class EventRepository : IEventRepository<Event>
    {
        private readonly MeetupDbContext _context;
        public EventRepository(MeetupDbContext meetupDb)
        {
            _context = meetupDb;
        }

        public async Task<Event> Create(Event eventModel)
        {
            try
            {
                _context.Events.Add(eventModel);
                await _context.SaveChangesAsync();
                return eventModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Delete(Event eventModel)
        {
            try
            {
                if (eventModel != null)
                {
                    var obj = _context.Remove(eventModel);
                    if (obj != null)
                    {
                        await _context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            try
            {
                return await _context.Events.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Event> GetById(int Id)
        {
            try
            {
                return _context.Events.AsNoTracking().Single(c => c.Id == Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Update(Event eventModel)
        {
            try
            {
                if (eventModel != null)
                {
                    _context.Events.Update(eventModel);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
