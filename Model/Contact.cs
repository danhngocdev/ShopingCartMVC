using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class Contact
	{
		[Key]
		public int ID { get; set; }
		public string Content { get; set; }
		public bool Status { get; set; }
	}
}
