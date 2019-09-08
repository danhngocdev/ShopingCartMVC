using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class User
	{
		[Key]
		public int UserId { get; set; }
		[ForeignKey("Role")]
		public int RoleId { get; set; }
		[Required]
		[RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage ="user name không được chứa ký tự đặc biệt")]
		public string UserName { get; set; }
		[Required]
		public string Password { get; set; }
		[Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
		[NotMapped]
		public string ConfirmPassword { get; set; }
		public DateTime? CreatedDate { get; set; }
		public DateTime? EditedDate { get; set; }
		[Required]
		public string FullName { get; set; }
		[Required]
		[RegularExpression(@"^([0-9]{10})$",ErrorMessage ="không đúng định dạng phone")]
		public string Phone { get; set; }
		[Required]
		[RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$", ErrorMessage ="Không đúng định dạng mail")]
		public string Email { get; set; }
		public string Address { get; set; }
		public bool Status { get; set; }
		public virtual Role Role { get; set; }
	}
}
