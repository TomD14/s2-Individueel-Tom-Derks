using System;
using System.Collections.Generic;
using System.Text;
using CMS_Individueel_Project.Contract;
using CMS_Individueel_Project.Data;

namespace CMS_Individueel_Project.Factory
{
    public static class LampFactory
    {
        public static ILampDAL AddLampDAL()
        {
            return new LampDAL();
        }
    }
}
