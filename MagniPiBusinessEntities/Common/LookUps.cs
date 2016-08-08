using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagniPiBusinessEntities.Common
{
    public static class LookUps
    {
        public static Dictionary<int, string> Get_File_Type()
        {
            Dictionary<int, string> file_Type = new Dictionary<int, string>();

            file_Type.Add(1, FileType.Image.ToString());
            file_Type.Add(2, FileType.Video.ToString());

            return file_Type;
        }



    }
}
