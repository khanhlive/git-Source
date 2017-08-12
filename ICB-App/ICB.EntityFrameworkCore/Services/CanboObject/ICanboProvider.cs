using ICB.EntityFrameworkCore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICB.EntityFrameworkCore.Services.CanboObject
{
    public interface ICanboProvider : IApplicationProvider<Models.DMCanBo, int>
    {
    }
}
