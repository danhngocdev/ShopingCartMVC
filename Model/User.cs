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
        
            public string UserName { get; set; }
           
            public string Password { get; set; }
            
            public DateTime? CreatedDate { get; set; }
            public DateTime? EditedDate { get; set; }
        
            public string FullName { get; set; }
       
            public string Phone { get; set; }
          
            public string Email { get; set; }
         
            public string Address { get; set; }
            
            public bool Status { get; set; }
            public ICollection<UserGroup> UserGroups { get; set; }
            public virtual Role Role { get; set; }
            public ICollection<WishList> wishLists { get; set; }
        //public ICollection<UserGroup> UserGroups { get; set; }
        //public virtual Role Role { get; set; }

    }
}
