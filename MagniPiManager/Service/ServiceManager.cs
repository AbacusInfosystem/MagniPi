using MagniPiBusinessEntities.Common;
using MagniPiBusinessEntities.Service;
using MagniPiDataAccess.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagniPiManager.Service
{
    public class ServiceManager
    {

        ServiceRepo _serviceRepo;

        public ServiceManager()
        {
            _serviceRepo = new ServiceRepo();
        }

        public int Insert_Service(ServiceInfo service)
        {
            return _serviceRepo.Insert_Service(service);
        }

        public void Update_Service(ServiceInfo service)
        {
            _serviceRepo.Update_Service(service);
        }

        public List<ServiceInfo> Get_Services(ref PaginationInfo Pager)
        {
            return _serviceRepo.Get_Services(ref Pager);
        }

        public ServiceInfo Get_Service_By_Id(int Service_Id)
        {
            return _serviceRepo.Get_Service_By_Id(Service_Id);
        }

        public List<ServiceInfo> Get_Services_By_Service_Title(ref PaginationInfo Pager, string Service_Title)
        {
            return _serviceRepo.Get_Services_By_Service_Title(ref Pager, Service_Title);
        }

    }
}
