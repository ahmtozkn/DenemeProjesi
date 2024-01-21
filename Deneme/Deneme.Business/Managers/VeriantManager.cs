using Deneme.Business.Dtos;
using Deneme.Business.Services;
using Deneme.Data.Entities;
using Deneme.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.Business.Managers
{
    public class VeriantManager : IVeriantService
    {
        private readonly IRepository<VeriantDetailEntity> _repository;
        public VeriantManager(IRepository<VeriantDetailEntity> repository)
        {
                _repository = repository;
        }
        public void AddVeriant(AddVeriantDto addVeriantDto)
        {
            var entity = new VeriantDetailEntity()
            {

                Name = addVeriantDto.Name,
            };
            _repository.Add(entity);
        }

        public void DeleteVeriant(int id)
        {
           _repository.Delete(id);
        }

        public void EditVeriant(EditVeriantDto editVeriantDto)
        {
            var entity = _repository.GetById(editVeriantDto.Id);

            entity.Name = editVeriantDto.Name;

        }

        public List<ListVeriantDto> GetAllVeriants()
        {
            var list = _repository.GetAll().Select(x => new ListVeriantDto()
            {
                Id = x.Id,
                Name = x.Name,

            }).ToList();
            return list;
        }

        public EditVeriantDto GetVeriant(int id)
        {
           var entity=_repository.GetById(id);
            var veriantDto = new EditVeriantDto()
            {
                Id = entity.Id,
                Name = entity.Name,

            };
            return veriantDto;

        }
    }
}
