using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Business.Abstract;
using TravelGuide.Business.Concreate;
using TravelGuide.Data.Abstract;
using TravelGuide.Data.Concreate.EntityFramework;

namespace TravelGuide.Business.DependencyInjection.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<NoteManager>().As<INoteService>();
            builder.RegisterType<EfNoteDal>().As<INoteDal>();


            builder.RegisterType<AuthanticationManager>().As<IAuthanticationService>();

        }
    }
}
