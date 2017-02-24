using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
namespace ASPNET5WEBAPIAngularJS.Models
{
    public class WebSiteMastersAppContext : DbContext
	{
		public DbSet<WebSiteMasters> WebSites { get; set; }
	}
}
