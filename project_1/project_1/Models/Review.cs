//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project_1.Models
{
	
	public partial class review
	{
		public int id { get; set; }
		public string name { get; set; }
		public int score { get; set; }
		public string message { get; set; }
		public int rest_id { get; set; }
	
		public virtual restuarant restuarant { get; set; }
	}
}