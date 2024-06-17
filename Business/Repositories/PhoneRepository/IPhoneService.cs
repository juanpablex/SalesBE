using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.PhoneRepository
{
    public interface IPhoneService
    {
        Task<IResult> Add(Phone phone);
        Task<IResult> Update(Phone phone);
        Task<IResult> Delete(Phone phone);
        Task<IDataResult<List<Phone>>> GetList();
        Task<IDataResult<Phone>> GetById(int id);
        Task<Phone> GetFirst();
    }
}
