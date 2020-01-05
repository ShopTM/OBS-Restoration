using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class DbFactory
    {
        public static IUnitOfWork GetInstance()
        {
            return new UnitOfWork(true);
        }

        public static IUnitOfWork GetNotTrackingInstance()
        {
            return new UnitOfWork(false);
        }
    }
}
