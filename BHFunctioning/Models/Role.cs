using System.ComponentModel.DataAnnotations;

namespace BHFunctioning.Models
{
    public class Role
    {
        [Required]
        public string Name { get; set; }
    }

    public class EditRoleModel
    {
        
        public string Id { get; set; }

        [Display(Name = "Role")]
        [Required(ErrorMessage = "Role Name is required")]
        public string Name { get; set; }
        public List<string> Users { get; set; } = new();

    }

    public class UserRoleModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }
    
}