using harmonee.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace harmonee.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyListController : ControllerBase
    {
        private readonly IFamilyListRepository _repository;

        public FamilyListController(IFamilyListRepository repository)
        {
            _repository = repository;
        }
    }
}
