using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.ModelRepository
{
    public interface IModelService
    {
        Task<IResult> Add(Model model);
        Task<IResult> Update(Model model);
        Task<IResult> Delete(Model model);
        Task<IDataResult<List<Model>>> GetList();
        Task<IDataResult<Model>> GetById(int id);
        Task<Model> GetFirst();
    }
}
