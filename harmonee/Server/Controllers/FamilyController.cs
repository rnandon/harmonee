using harmonee.Server.Data;
using harmonee.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace harmonee.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyController : ControllerBase
    {
        private readonly FamilyRepository _familyRepo;
        private readonly FamilyMemberRepository _familyMemberRepo;
        private readonly FamilyEventRepository _familyEventRepo;
        private readonly FamilyListRepository _familyListRepo;

        public FamilyController(
            FamilyRepository familyRepo,
            FamilyMemberRepository familyMemberRepo,
            FamilyEventRepository familyEventRepo,
            FamilyListRepository familyListRepo
        )
        {
            _familyRepo = familyRepo;
            _familyMemberRepo = familyMemberRepo;
            _familyEventRepo = familyEventRepo;
            _familyListRepo = familyListRepo;
        }

        [HttpPost]
        public Family? CreateNewFamily(Family model)
        {
            if (!model.IsValid(out var errors))
            {
                BadRequest(errors);
            }

            return _familyRepo.Add(model);
        } 
    }
}
