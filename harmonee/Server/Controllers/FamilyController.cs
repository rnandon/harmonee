using harmonee.Server.Data;
using harmonee.Shared.Data;
using harmonee.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace harmonee.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyController : ControllerBase
    {
        private readonly IFamilyRepository _familyRepository;

        public FamilyController(IFamilyRepository familyRepository)
        {
            _familyRepository = familyRepository;
        }

        [HttpPost]
        public Family? CreateNewFamily(Family model)
        {
            if (!model.IsValid(out var errors))
            {
                BadRequest(errors);
            }

            return _familyRepository.Add(model);
        } 
    }
}
