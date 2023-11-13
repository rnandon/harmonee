using harmonee.Server.Data;
using harmonee.Shared.Models;
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

        [HttpGet]
        public FamilyList? Get([FromRoute] Guid id)
        {
            return _repository.GetById(id);
        }

        [HttpPost]
        public IEnumerable<FamilyList> GetMany([FromBody] IEnumerable<Guid> ids)
        {
            return _repository.GetMany(ids);
        }

        [HttpGet("ByFamily/{familyId}")]
        public IEnumerable<FamilyList> GetByFamily(Guid familyId)
        {
            return _repository.GetByFamily(familyId);
        }

        [HttpPost]
        public bool Create(FamilyList familyList)
        {
            if (!familyList.IsValid(out var errors))
            {
                BadRequest(errors);
            }

            return _repository.Add(familyList);
        }

        [HttpPut]
        public bool Update(FamilyList familyList)
        {
            if (!familyList.IsValid(out var errors, true))
            {
                BadRequest(errors);
            }

            return _repository.Update(familyList);
        }

        [HttpDelete]
        public bool Delete(Guid id)
        {
            return _repository.Delete(id);
        }
    }
}
