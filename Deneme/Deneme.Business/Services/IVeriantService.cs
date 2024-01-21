using Deneme.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.Business.Services
{
   public  interface IVeriantService
    {
        void AddVeriant(AddVeriantDto addVeriantDto);
        void EditVeriant(EditVeriantDto editVeriantDto);
        List<ListVeriantDto> GetAllVeriants();

        EditVeriantDto GetVeriant(int id);

        void DeleteVeriant(int id);

    }
}
