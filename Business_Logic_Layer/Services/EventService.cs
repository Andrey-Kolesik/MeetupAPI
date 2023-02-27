using AutoMapper;
using Business_Logic_Layer.Models;
using Business_Logic_Layer.Services.IServices;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repositories.IRepositories;

namespace Business_Logic_Layer.Services
{
    public class EventService : IEventService
    {
        private readonly IMapper _mapper;
        private readonly IEventRepository<Event> _eventRepository;
        public EventService(IEventRepository<Event> eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<EventModel> AddEvent(EventModel eventModel)
        {
            if (eventModel == null)
            {
                throw new ArgumentNullException(nameof(eventModel));
            }
            else
            {
                var result = _mapper.Map<Event>(eventModel);
                var response = await _eventRepository.Create(result);
                return _mapper.Map<EventModel>(response);
            }
        }

        public async Task<EventModel> DeleteEvent(int Id)
        {
            if (Id != 0)
            {
                var data = await _eventRepository.GetById(Id);
                await _eventRepository.Delete(data);
                return _mapper.Map<EventModel>(data);
            }
            return null;
        }

        public async Task<EventModel> UpdateEvent(int Id, EventModel eventModel)
        {
            if (Id != 0)
            {

                var data = await _eventRepository.GetById(Id);
                if (data != null)
                {
                    eventModel.Id = Id;
                    var result = _mapper.Map<Event>(eventModel);
                    await _eventRepository.Update(result);
                }
                return _mapper.Map<EventModel>(data);
            }
            return null;
        }

        public async Task<IEnumerable<EventModel>> GetAllEvents()
        {
            var data = await _eventRepository.GetAll();
            var result = _mapper.Map<IEnumerable<EventModel>>(data);
            return result;
        }

        public async Task<EventModel> GetEventById(int Id)
        {
            var data = await _eventRepository.GetById(Id);
            var result = _mapper.Map<EventModel>(data);
            return result;
        }

    }
}

