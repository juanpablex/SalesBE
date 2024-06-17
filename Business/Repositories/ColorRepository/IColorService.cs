using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.ColorRepository
{
    public interface IColorService
    {
        Task<IResult> Add(Color color);
        Task<IResult> Update(Color color);
        Task<IResult> Delete(Color color);
        Task<IDataResult<List<Color>>> GetList();
        Task<IDataResult<Color>> GetById(int id);
        Task<Color> GetFirst();
    }
}
