using Business.Aspects.Secured;
using Business.Repositories.ColorRepository.Constants;
using Business.Repositories.ColorRepository.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.ColorRepository;
using Entities.Concrete;

namespace Business.Repositories.ColorRepository
{
    public class ColorManager : IColorService
    {
        private readonly IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        //[SecuredAspect()]
        [ValidationAspect(typeof(ColorValidator))]
        [RemoveCacheAspect("IColorService.Get")]
        public async Task<IResult> Add(Color color)
        {
            await _colorDal.Add(color);
            return new SuccessResult(ColorMessages.AddedColor);
        }

        //[SecuredAspect()]
        [RemoveCacheAspect("IColorService.Get")]
        public async Task<IResult> Delete(Color color)
        {
            await _colorDal.Delete(color);
            return new SuccessResult(ColorMessages.DeletedColor);
        }

        public async Task<IDataResult<Color>> GetById(int id)
        {
            return new SuccessDataResult<Color>(await _colorDal.Get(p => p.Id == id));
        }

        public async Task<Color> GetFirst()
        {
            return await _colorDal.GetFirst();
        }

        [CacheAspect()]
        public async Task<IDataResult<List<Color>>> GetList()
        {
            return new SuccessDataResult<List<Color>>(await _colorDal.GetAll());
        }

        //[SecuredAspect()]
        [ValidationAspect(typeof(ColorValidator))]
        [RemoveCacheAspect("IColorService.Get")]
        public async Task<IResult> Update(Color color)
        {
            await _colorDal.Update(color);
            return new SuccessResult(ColorMessages.UpdatedColor);
        }
    }
}
