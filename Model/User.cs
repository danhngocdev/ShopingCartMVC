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
        //[ForeignKey("Role")]
        //public int RoleId { get; set; }
        [Required(ErrorMessage = "User Name is required"), MinLength(5), MaxLength(16)]
        [RegularExpression(@"[\w]+", ErrorMessage = "UserName không được chức các ký tự đặc biệt")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required"), MinLength(4), MaxLength(16)]
        [RegularExpression(@"[\w]+", ErrorMessage = "Password không được chức các ký tự đặc biệt")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Full Name is required"), MinLength(6), MaxLength(50)]
        [RegularExpression(@"[\w]+", ErrorMessage = "Full Name không được chức các ký tự đặc biệt")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        [RegularExpression(@"^(09|03|08|05|02)[\d]{8}$")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Email is required"), EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Address is required"), MinLength(6), MaxLength(50)]
        public String Address { get; set; }
        [Required(ErrorMessage = "Department is required"), MinLength(2), MaxLength(30)]
        public string Avatar { get; set; }
        public bool Status { get; set; }
        //public ICollection<UserGroup> UserGroups { get; set; }
        //public virtual Role Role { get; set; }
      
    }
}
