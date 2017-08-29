using Microsoft.Practices.ServiceLocation;
using BI.GST.Application.Interface;
using BI.GST.Infra.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.AppService
{
    public class BaseAppService : IBaseAppService
    {
        private IUnitOfWork _uow;

        public void BeginTransaction()
        {
            _uow = ServiceLocator.Current.GetInstance<IUnitOfWork>();
            _uow.BeginTransaction();
        }

        public void Commit()
        {
            _uow.SaveChanges();
        }

        //recebe validationResult do dominio e converte todos os resultados das validações para uma classe de application, para que a controller possa conhecer
    }
}
