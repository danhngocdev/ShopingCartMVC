﻿using System;
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
            [Required(ErrorMessage = "User Name is required"), MinLength(5), MaxLength(15)]
            public string UserName { get; set; }
            [Required(ErrorMessage = "Password is required"), MinLength(5), MaxLength(100)]
            public string Password { get; set; }
            [Compare("Password", ErrorMessage = "The Password and Password Email fields do not match.")]
            public string ConfirmPassword { get; set; }
            public DateTime? CreatedDate { get; set; }
            public DateTime? EditedDate { get; set; }
            [Required(ErrorMessage = "Full Name is required"), MinLength(6), MaxLength(50)]
            public string FullName { get; set; }
            [Required(ErrorMessage = "Phone is required")]
            public string Phone { get; set; }
            [Required(ErrorMessage = "Email is required"), EmailAddress]
            public string Email { get; set; }
            [Required(ErrorMessage = "Address is required"), MinLength(6), MaxLength(50)]
            public String Address { get; set; }
            
            public bool Status { get; set; }
            public ICollection<UserGroup> UserGroups { get; set; }
            public virtual Role Role { get; set; }
          
            //public ICollection<UserGroup> UserGroups { get; set; }
            //public virtual Role Role { get; set; }

        }
}
