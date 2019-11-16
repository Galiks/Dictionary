﻿using BusinessLogicLayer;
using DataAccessLayer;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer
{
    public static class NinjectCommon
    {
        private static readonly IKernel _kernel = new StandardKernel();

        public static IKernel Kernel => _kernel;

        public static void Registration()
        {
            _kernel.Bind<IUserLogic>().To<UserLogic>();
            _kernel.Bind<IUserDao>().To<UserDao>();
        }
    }
}