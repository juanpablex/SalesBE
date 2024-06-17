using Business.Aspects.Secured;
using Business.Repositories.BrandRepository.Constants;
using Business.Repositories.BrandRepository.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.BrandRepository;
using Entities.Concrete;

namespace Business.Repositories.BrandRepository
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        //[SecuredAspect()]
        [ValidationAspect(typeof(BrandValidator))]
        [RemoveCacheAspect("IBrandService.Get")]
        public async Task<IResult> Add(Brand brand)
        {
            await _brandDal.Add(brand);
            return new SuccessResult(BrandMessages.AddedBrand);
        }

        //[SecuredAspect()]
        [RemoveCacheAspect("IBrandService.Get")]
        public async Task<IResult> Delete(Brand brand)
        {
            await _brandDal.Delete(brand);
            return new SuccessResult(BrandMessages.DeletedBrand);
        }

        public async Task<IDataResult<Brand>> GetById(int id)
        {
            return new SuccessDataResult<Brand>(await _brandDal.Get(p => p.Id == id));
        }

        public async Task<Brand> GetFirst()
        {
            return await _brandDal.GetFirst();
        }

        [CacheAspect()]
        public async Task<IDataResult<List<Brand>>> GetList()
        {
            return new SuccessDataResult<List<Brand>>(await _brandDal.GetAll());
        }

        //[SecuredAspect()]
        [ValidationAspect(typeof(BrandValidator))]
        [RemoveCacheAspect("IBrandService.Get")]
        public async Task<IResult> Update(Brand brand)
        {
            await _brandDal.Update(brand);
            return new SuccessResult(BrandMessages.UpdatedBrand);
        }
    }
}
