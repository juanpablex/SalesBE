using Business.Aspects.Secured;
using Business.Repositories.ModelRepository.Constants;
using Business.Repositories.ModelRepository.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.ModelRepository;
using Entities.Concrete;

namespace Business.Repositories.ModelRepository
{
    public class ModelManager : IModelService
    {
        private readonly IModelDal _modelDal;
        public ModelManager(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }

        //[SecuredAspect()]
        [ValidationAspect(typeof(ModelValidator))]
        [RemoveCacheAspect("IModelService.Get")]
        public async Task<IResult> Add(Model model)
        {
            await _modelDal.Add(model);
            return new SuccessResult(ModelMessages.AddedModel);
        }

        //[SecuredAspect()]
        [RemoveCacheAspect("IModelService.Get")]
        public async Task<IResult> Delete(Model model)
        {
            await _modelDal.Delete(model);
            return new SuccessResult(ModelMessages.DeletedModel);
        }

        public async Task<IDataResult<Model>> GetById(int id)
        {
            return new SuccessDataResult<Model>(await _modelDal.Get(p => p.Id == id));
        }

        public async Task<Model> GetFirst()
        {
            return await _modelDal.GetFirst();
        }

        [CacheAspect()]
        public async Task<IDataResult<List<Model>>> GetList()
        {
            return new SuccessDataResult<List<Model>>(await _modelDal.GetAll());
        }

        //[SecuredAspect()]
        [ValidationAspect(typeof(ModelValidator))]
        [RemoveCacheAspect("IModelService.Get")]
        public async Task<IResult> Update(Model model)
        {
            await _modelDal.Update(model);
            return new SuccessResult(ModelMessages.UpdatedModel);
        }
    }
}
