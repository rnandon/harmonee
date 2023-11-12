using harmonee.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace harmonee.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyEventController : ControllerBase
    {
        private readonly IFamilyEventRepository _repository;

        public FamilyEventController(IFamilyEventRepository repository)
        {
            _repository = repository;
        }
    }
}
