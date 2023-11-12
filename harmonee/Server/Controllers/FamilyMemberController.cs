using harmonee.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace harmonee.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyMemberController : ControllerBase
    {
        private readonly IFamilyMemberRepository _repository;

        public FamilyMemberController(IFamilyMemberRepository repository)
        {
            _repository = repository;
        }
    }
}
