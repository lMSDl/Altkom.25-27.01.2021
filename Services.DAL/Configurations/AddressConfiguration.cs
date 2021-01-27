using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Configurations
{
    public class AddressConfiguration : EntityTypeConfiguration<Address>
    {
        public AddressConfiguration()
        {
            HasMany(x => x.Residents).WithOptional(x => x.Address);
            //HasMany(x => x.Residents).WithRequired(x => x.Address);
        }
    }
}
