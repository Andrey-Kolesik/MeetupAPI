using Business_Logic_Layer.Models;

namespace Business_Logic_Layer.Services.IServices
{
    public interface IEventService
    {
        Task<EventModel> AddEvent(EventModel eventModel);
        Task<EventModel> DeleteEvent(int id);
        Task<EventModel> UpdateEvent(int id, EventModel eventModel);
        Task<IEnumerable<EventModel>> GetAllEvents();
        Task<EventModel> GetEventById(int id);
    }
}
