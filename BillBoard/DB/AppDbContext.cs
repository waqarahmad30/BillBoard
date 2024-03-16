using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.SqlClient;
using BillBoard.Models;

namespace BillBoard.DB
{
    public class AppDbContext:DbContext
    {
        public AppDbContext():base("conn")
        {

        }
        public DbSet<ContactForm> CntForm { get; set; }
        public DbSet<User> cred { get; set; }
    }
}