using Otel.DataAccessLayer.Abstract;
using Otel.DataAccessLayer.Concrete;
using Otel.DataAccessLayer.Repositories;
using Otel.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel.DataAccessLayer.EntityFramework
{
    public class EfStaffDAL : GenericRepository<Staff>, IStaffDal
    {
        public EfStaffDAL(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
