using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ASPNET5WEBAPIAngularJS.Models
{
    public class WebSiteMasters
	{
		[Key]
		public int WebID { get; set; }
        [Required]
        [Display(Name = "VisitDate")]
        public DateTime VisitDate { get; set; }
        [Required]
		[Display(Name = "WebSite")]
		public string WebName { get; set; }
		[Required]
		[Display(Name = "Visits")]
		public int Visits { get; set; }

	}
}
