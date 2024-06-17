using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Authentication;
using Business.Repositories.BrandRepository;
using Business.Repositories.ColorRepository;
using Business.Repositories.ContractRepository;
using Business.Repositories.EmailParameterRepository;
using Business.Repositories.ModelRepository;
using Business.Repositories.OperationClaimRepository;
using Business.Repositories.PaymentMethodRepository;
using Business.Repositories.PersonRepository;
using Business.Repositories.PersonTypeRepository;
using Business.Repositories.PhoneRepository;
using Business.Repositories.ProductRepository;
using Business.Repositories.RangeRepository;
using Business.Repositories.StateRepository;
using Business.Repositories.UserOperationClaimRepository;
using Business.Repositories.UserRepository;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Repositories.BrandRepository;
using DataAccess.Repositories.ColorRepository;
using DataAccess.Repositories.ContractRepository;
using DataAccess.Repositories.EmailParameterRepository;
using DataAccess.Repositories.ModelRepository;
using DataAccess.Repositories.OperationClaimRepository;
using DataAccess.Repositories.PaymentMethodRepository;
using DataAccess.Repositories.PersonRepository;
using DataAccess.Repositories.PersonTypeRepository;
using DataAccess.Repositories.PhoneRepository;
using DataAccess.Repositories.ProductRepository;
using DataAccess.Repositories.RangeRepository;
using DataAccess.Repositories.StateRepository;
using DataAccess.Repositories.UserOperationClaimRepository;
using DataAccess.Repositories.UserRepository;

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


            builder.RegisterType<PersonManager>().As<IPersonService>();
            builder.RegisterType<EfPersonDal>().As<IPersonDal>();

            builder.RegisterType<PhoneManager>().As<IPhoneService>();
            builder.RegisterType<EfPhoneDal>().As<IPhoneDal>();

            builder.RegisterType<PersonTypeManager>().As<IPersonTypeService>();
            builder.RegisterType<EfPersonTypeDal>().As<IPersonTypeDal>();

            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();

            builder.RegisterType<ContractManager>().As<IContractService>();
            builder.RegisterType<EfContractDal>().As<IContractDal>();

            builder.RegisterType<PaymentMethodManager>().As<IPaymentMethodService>();
            builder.RegisterType<EfPaymentMethodDal>().As<IPaymentMethodDal>();

            builder.RegisterType<StateManager>().As<IStateService>();
            builder.RegisterType<EfStateDal>().As<IStateDal>();

            builder.RegisterType<RangeManager>().As<IRangeService>();
            builder.RegisterType<EfRangeDal>().As<IRangeDal>();

            builder.RegisterType<BrandManager>().As<IBrandService>();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>();

            builder.RegisterType<ModelManager>().As<IModelService>();
            builder.RegisterType<EfModelDal>().As<IModelDal>();

            builder.RegisterType<ColorManager>().As<IColorService>();
            builder.RegisterType<EfColorDal>().As<IColorDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();

            builder.RegisterType<TokenHandler>().As<ITokenHandler>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new Castle.DynamicProxy.ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();
        }
    }
}
