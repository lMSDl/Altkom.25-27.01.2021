using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Flags]
    public enum Roles
    {
        Admin = 1 << 0,
        Read = 1 << 1,
        Create = 1 << 2,
        Delete = 1 << 3,
        Update = 1 << 4
    }
}
