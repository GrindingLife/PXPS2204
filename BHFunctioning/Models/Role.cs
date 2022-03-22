using System.ComponentModel.DataAnnotations;

namespace BHFunctioning.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
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

}