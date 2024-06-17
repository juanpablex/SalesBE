using Core.DataAccess.EntityFramework;
using DataAccess.Context.EntityFramework;
using Entities.Concrete;
using Entities.Dtos.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.PersonRepository
{
    public class EfPersonDal : EfEntityRepositoryBase<Person, SimpleContextDb>, IPersonDal
    {
      
    }
}