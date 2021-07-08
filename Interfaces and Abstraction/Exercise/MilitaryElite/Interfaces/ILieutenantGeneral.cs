using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interfaces
{
    public interface ILieutenantGeneral
    {
        ICollection<IPrivate> Set { get; }
    }
}
