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
    public class EfRoomDAL : GenericRepository<Room>, IRoomDal
    {
        public EfRoomDAL(DataContext dataContext) : base(dataContext)
        {
        }
    }
}