using MagniPiBusinessEntities.Common;
using MagniPiDataAccess.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagniPiManager.Authentication
{
    public class AuthenticationManager
    {
        AuthenticationRepo _authRepo;

        public AuthenticationManager()
        {
            _authRepo = new AuthenticationRepo();
        }


        public SessionInfo AuthernticateLogin(SessionInfo session)
        {
            return _authRepo.AuthernticateLogin(session);
        }


    }
}
