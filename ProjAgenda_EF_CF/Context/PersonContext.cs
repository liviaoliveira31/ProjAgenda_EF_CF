using ProjAgenda_EF_CF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAgenda_EF_CF.Context
{
    internal class PersonContext: DbContext
    {
       
        public DbSet<Person> Persons { get; set; }
        public DbSet<Telephone> Telephone { get; set; }
    }
}
