



using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrate;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrate.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AboutManager>().As<IAboutService>().SingleInstance();
            builder.RegisterType<EfAboutDal>().As<IAboutDal>().SingleInstance();

            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

            builder.RegisterType<ContentManager>().As<IContentService>().SingleInstance();
            builder.RegisterType<EfContentDal>().As<IContentDal>().SingleInstance();

            builder.RegisterType<ContactManager>().As<IContactService>().SingleInstance();
            builder.RegisterType<EfContactDal>().As<IContactDal>().SingleInstance();

            builder.RegisterType<HeadingManager>().As<IHeadingService>().SingleInstance();
            builder.RegisterType<EfHeadingDal>().As<IHeadingDal>().SingleInstance();

            builder.RegisterType<WriterManager>().As<IWriterService>().SingleInstance();
            builder.RegisterType<EfWriteDal>().As<IWriterDal>().SingleInstance();

            builder.RegisterType<BadgeStyleManager>().As<IBadgeStyleService>().SingleInstance();
            builder.RegisterType<EfBadgeStyleDal>().As<IBadgeStyleDal>().SingleInstance();


            builder.RegisterType<MessageManager>().As<IMessageService>().SingleInstance();
            builder.RegisterType<MessageDal>().As<IMessageDal>().SingleInstance();


            builder.RegisterType<ImagesManager>().As<IImagesService>().SingleInstance();
            builder.RegisterType<EfImagesDal>().As<IImagesDal>().SingleInstance();

            builder.RegisterType<SkilssCardManager>().As<ISkilssCardService>().SingleInstance();
            builder.RegisterType<EfSkilssCardDal>().As<ISkilssCardDal>().SingleInstance();



            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
