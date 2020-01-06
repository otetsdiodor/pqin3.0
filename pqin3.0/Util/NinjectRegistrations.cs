using Microsoft.AspNet.Identity;
using Ninject.Modules;
using ORMF;
using pqin3._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pqin3._0.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserStore<User>>().To<UserStore>();
            Bind<IAuthRepo<User>>().To<AuthRepository<User>>();
        }
    }
}