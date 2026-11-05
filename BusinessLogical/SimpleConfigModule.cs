using Data;
using Entities;
using Interfaces;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogical
{
    public class SimpleConfigModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Prosthesis>>().To<EntityRepository<Prosthesis>>().InSingletonScope();
            //Bind<IRepository<Prosthesis>>().To<DapperRepository<Prosthesis>>().InSingletonScope();
        }
    }
}
