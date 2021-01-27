using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Configurations
{
    public class PersonConfiguration : EntityTypeConfiguration<Person>
    {
        public PersonConfiguration()
        {
            //HasKey(x => x.Id);

            Property(x => x.LastName).IsRequired().HasMaxLength(15);

            Ignore(x => x.NamedayDate);
            Ignore(x => x.SomeInt);
        }
    }
}
