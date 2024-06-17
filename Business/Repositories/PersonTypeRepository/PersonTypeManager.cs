using Business.Aspects.Secured;
using Business.Repositories.PersonTypeRepository.Constants;
using Business.Repositories.PersonTypeRepository.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.PersonTypeRepository;
using Entities.Concrete;

namespace Business.Repositories.PersonTypeRepository
{
    public class PersonTypeManager : IPersonTypeService
    {
        private readonly IPersonTypeDal _persontypeDal;
        public PersonTypeManager(IPersonTypeDal persontypeDal)
        {
            _persontypeDal = persontypeDal;
        }

        //[SecuredAspect()]
        [ValidationAspect(typeof(PersonTypeValidator))]
        [RemoveCacheAspect("IPersonTypeService.Get")]
        public async Task<IResult> Add(PersonType persontype)
        {
            await _persontypeDal.Add(persontype);
            return new SuccessResult(PersonTypeMessages.AddedPersonType);
        }

        //[SecuredAspect()]
        [RemoveCacheAspect("IPersonTypeService.Get")]
        public async Task<IResult> Delete(PersonType persontype)
        {
            await _persontypeDal.Delete(persontype);
            return new SuccessResult(PersonTypeMessages.DeletedPersonType);
        }

        public async Task<IDataResult<PersonType>> GetById(int id)
        {
            return new SuccessDataResult<PersonType>(await _persontypeDal.Get(p => p.Id == id));
        }

        public async Task<PersonType> GetFirst()
        {
            return await _persontypeDal.GetFirst();
        }

        [CacheAspect()]
        public async Task<IDataResult<List<PersonType>>> GetList()
        {
            return new SuccessDataResult<List<PersonType>>(await _persontypeDal.GetAll());
        }

        //[SecuredAspect()]
        [ValidationAspect(typeof(PersonTypeValidator))]
        [RemoveCacheAspect("IPersonTypeService.Get")]
        public async Task<IResult> Update(PersonType persontype)
        {
            await _persontypeDal.Update(persontype);
            return new SuccessResult(PersonTypeMessages.UpdatedPersonType);
        }
    }
}
