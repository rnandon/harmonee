using harmonee.Server.Data;
using harmonee.Shared.Data;
using harmonee.Shared.Models;
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

        [HttpGet]
        public FamilyMember GetFamilyMember([FromRoute] Guid userId, [FromRoute] Guid familyId)
        {
            var familyMember = _repository.GetById(userId, familyId);
            if (familyMember is null)
            {
                NotFound();
            }

            return familyMember;
        }

        [HttpGet("{familyId}/allMembers")]
        public IEnumerable<FamilyMember> GetByFamily(Guid familyId)
        {
            return _repository.GetByFamilyId(familyId);
        }

        [HttpGet("{userId}/allFamilies")]
        public IEnumerable<FamilyMember> GetByUser(Guid userId)
        {
            return _repository.GetByUserId(userId);
        }

        [HttpPost]
        public bool CreateNewFamilyMember([FromBody] FamilyMember model)
        {
            if (!model.IsValid(out var errors))
            {
                BadRequest(errors);
            }

            return _repository.Add(model);
        }

        [HttpPost]
        public bool CreateNewFamilyMember([FromRoute] Guid userId, [FromRoute] Guid familyId)
        {
            if (userId == Guid.Empty || familyId == Guid.Empty)
            {
                BadRequest();
            }

            var model = new FamilyMember
            {
                UserId = userId,
                FamilyId = familyId
            };

            return _repository.Add(model);
        }

        [HttpDelete]
        public bool DeleteFamilyMember([FromRoute] Guid userId, [FromRoute] Guid familyId)
        {
            return _repository.Delete(userId, familyId);
        }
    }
}
