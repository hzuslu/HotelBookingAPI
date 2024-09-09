using Otel.BusinessLayer.Abstract;
using Otel.DataAccessLayer.Abstract;
using Otel.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel.BusinessLayer.Concrete
{
    internal class SubscribeManager : ISubscribeService
    {
        private readonly ISubscribeDal _subscribeDal;

        public SubscribeManager(ISubscribeDal subscribeDal)
        {
            _subscribeDal = subscribeDal;
        }

        public void TDelete(Subscribe entity)
        {
           _subscribeDal.Delete(entity);
        }

        public Subscribe TGetByID(int id)
        {
           return _subscribeDal.GetByID(id);
        }

        public List<Subscribe> TGetList()
        {
            return _subscribeDal.GetList();
        }

        public void TInsert(Subscribe entity)
        {
           _subscribeDal.Insert(entity);
        }

        public void TUpdate(Subscribe entity)
        {
           _subscribeDal.Update(entity);
        }
    }
}