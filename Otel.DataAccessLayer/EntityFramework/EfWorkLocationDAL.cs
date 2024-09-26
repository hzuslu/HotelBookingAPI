﻿using Otel.DataAccessLayer.Abstract;
using Otel.DataAccessLayer.Concrete;
using Otel.DataAccessLayer.Repositories;
using Otel.EntityLayer.Concrete;

namespace Otel.DataAccessLayer.EntityFramework
{
    public class EfWorkLocationDAL : GenericRepository<WorkLocation>, IWorkLocationDal
    {
        public EfWorkLocationDAL(DataContext dataContext) : base(dataContext)
        {
        }
    }
}