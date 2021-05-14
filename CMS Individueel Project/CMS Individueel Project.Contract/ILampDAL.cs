using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Individueel_Project.Contract
{
    public interface ILampDAL
    {
        Task AddLampAsync([Bind("Id,Model,Watt,Kleur,Prijs,Aantal")] LampDTO lamp);
    }
}
