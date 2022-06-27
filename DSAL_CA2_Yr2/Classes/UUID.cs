using System;
using System.Collections.Generic;
using System.Text;

namespace DSAL_CA2_Yr2.Classes
{
    static class UUID
    {
        public static string GenerateUUID()
        {
            Guid uuid = Guid.NewGuid();
            string UUID = uuid.ToString();
            return UUID;
        }
    }
}
