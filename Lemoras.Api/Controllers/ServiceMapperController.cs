using AutoMapper;

namespace Lemoras.Api.Controllers
{
    public class ServiceMapperController<TService> : ServiceController<TService> where TService : class
    {
        protected internal readonly IMapper _mapper;

        public ServiceMapperController(IMapper mapper, TService service)
            :base(service)
        {
            _mapper = mapper;
        }
    }
}