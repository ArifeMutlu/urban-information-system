using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Ioc;
using Domain;

namespace Core.Uow
{
    internal class UnitOfWork
    {
        internal static Context CurrentSession
        {
            get
            {
                return ServiceIoc.Container.Resolve<Context>();
            }
        }
        internal static Context ApplicationStartContext
        {
            get
            {
                return ServiceIoc.Container.Resolve<Context>("ApplicationStartContext");
            }
        }
    }
}
