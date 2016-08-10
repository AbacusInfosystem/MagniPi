using MagniPiBusinessEntities.AboutUs;
using MagniPiDataAccess.AboutUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagniPiManager.AboutUs
{
    public class AboutUsManager
    {
        AboutUsRepo _aboutusRepo;

        public AboutUsManager()
        {
            _aboutusRepo = new AboutUsRepo();
        }

        public void Update_About_Us(AboutUsInfo aboutus)
        {
            _aboutusRepo.Update_About_Us(aboutus);
        }

        public AboutUsInfo Get_About_Us_By_Id(int About_Us_Id)
        {
            return _aboutusRepo.Get_About_Us_By_Id(About_Us_Id);
        }

    }
}
