using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.PersonTypeRepository
{
    public interface IPersonTypeService
    {
        Task<IResult> Add(PersonType persontype);
        Task<IResult> Update(PersonType persontype);
        Task<IResult> Delete(PersonType persontype);
        Task<IDataResult<List<PersonType>>> GetList();
        Task<IDataResult<PersonType>> GetById(int id);
        Task<PersonType> GetFirst();
    }
}
