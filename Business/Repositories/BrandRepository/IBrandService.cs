using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.BrandRepository
{
    public interface IBrandService
    {
        Task<IResult> Add(Brand brand);
        Task<IResult> Update(Brand brand);
        Task<IResult> Delete(Brand brand);
        Task<IDataResult<List<Brand>>> GetList();
        Task<IDataResult<Brand>> GetById(int id);
        Task<Brand> GetFirst();
    }
}
