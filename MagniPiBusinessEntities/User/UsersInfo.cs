using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagniPiBusinessEntities.User
{
    public class UsersInfo
    {
        public int User_Id { get; set; }

        public string First_Name { get; set; }

        public string Last_Name { get; set; }

        public string Contact { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Gender { get; set; }

        public string User_Name { get; set; }

        public string Password { get; set; }

        public string Image { get; set; }

        public bool Is_Active { get; set; }

        public int Created_By { get; set; }

        public int Updated_By { get; set; }

        public DateTime Created_On { get; set; }

        public DateTime Updated_On { get; set; }

    }

}
