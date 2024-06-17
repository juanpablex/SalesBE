using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Authentication;
using Business.Repositories.EmailParameterRepository;
using Business.Repositories.OperationClaimRepository;
using Business.Repositories.UserOperationClaimRepository;
using Business.Repositories.UserRepository;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Repositories.EmailParameterRepository;
using DataAccess.Repositories.OperationClaimRepository;
using DataAccess.Repositories.UserOperationClaimRepository;
using DataAccess.Repositories.UserRepository;

using Business.Repositories.PersonRepository;
using Business.Repositories.PersonTypeRepository;
using Business.Repositories.PhoneRepository;
using Business.Repositories.ProductRepository;
using Business.Repositories.ModelRepository;
using Business.Repositories.BrandRepository;
using Business.Repositories.ColorRepository;

using DataAccess.Repositories.BrandRepository;
using DataAccess.Repositories.ColorRepository;
using DataAccess.Repositories.ModelRepository;
using DataAccess.Repositories.PersonRepository;
using DataAccess.Repositories.PersonTypeRepository;
using DataAccess.Repositories.PhoneRepository;
using DataAccess.Repositories.ProductRepository;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OperationClaimManager>().As<IOperationClaimService>();
            builder.RegisterType<EfOperationClaimDal>().As<IOperationClaimDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>();
            builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>();

            builder.RegisterType<EmailParameterManager>().As<IEmailParameterService>();
            builder.RegisterType<EfEmailParameterDal>().As<IEmailParameterDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();

            builder.RegisterType<TokenHandler>().As<ITokenHandler>();

            builder.RegisterType<PersonManager>().As<IPersonService>();
            builder.RegisterType<EfPersonDal>().As<IPersonDal>();

            builder.RegisterType<PhoneManager>().As<IPhoneService>();
            builder.RegisterType<EfPhoneDal>().As<IPhoneDal>();

            builder.RegisterType<PersonTypeManager>().As<IPersonTypeService>();
            builder.RegisterType<EfPersonTypeDal>().As<IPersonTypeDal>();

            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();

            builder.RegisterType<BrandManager>().As<IBrandService>();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>();

            builder.RegisterType<ModelManager>().As<IModelService>();
            builder.RegisterType<EfModelDal>().As<IModelDal>();

            builder.RegisterType<ColorManager>().As<IColorService>();
            builder.RegisterType<EfColorDal>().As<IColorDal>();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new Castle.DynamicProxy.ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();
        }
    }
}
