using Business.Aspects.Secured;
using Business.Repositories.PhoneRepository.Constants;
using Business.Repositories.PhoneRepository.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.PhoneRepository;
using Entities.Concrete;

namespace Business.Repositories.PhoneRepository
{
    public class PhoneManager : IPhoneService
    {
        private readonly IPhoneDal _phoneDal;
        public PhoneManager(IPhoneDal phoneDal)
        {
            _phoneDal = phoneDal;
        }

        //[SecuredAspect()]
        [ValidationAspect(typeof(PhoneValidator))]
        [RemoveCacheAspect("IPhoneService.Get")]
        public async Task<IResult> Add(Phone phone)
        {
            await _phoneDal.Add(phone);
            return new SuccessResult(PhoneMessages.AddedPhone);
        }

        //[SecuredAspect()]
        [RemoveCacheAspect("IPhoneService.Get")]
        public async Task<IResult> Delete(Phone phone)
        {
            await _phoneDal.Delete(phone);
            return new SuccessResult(PhoneMessages.DeletedPhone);
        }

        public async Task<IDataResult<Phone>> GetById(int id)
        {
            return new SuccessDataResult<Phone>(await _phoneDal.Get(p => p.Id == id));
        }

        public async Task<Phone> GetFirst()
        {
            return await _phoneDal.GetFirst();
        }

        [CacheAspect()]
        public async Task<IDataResult<List<Phone>>> GetList()
        {
            return new SuccessDataResult<List<Phone>>(await _phoneDal.GetAll());
        }

        //[SecuredAspect()]
        [ValidationAspect(typeof(PhoneValidator))]
        [RemoveCacheAspect("IPhoneService.Get")]
        public async Task<IResult> Update(Phone phone)
        {
            await _phoneDal.Update(phone);
            return new SuccessResult(PhoneMessages.UpdatedPhone);
        }
    }
}
