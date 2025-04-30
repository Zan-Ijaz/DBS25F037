using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Primitives;

namespace skillhub.CommonLayer.Model.Users
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required, MaxLength(45)]
        public string FirstName { get; set; }

        [Required, MaxLength(45)]
        public string LastName { get; set; }

        [Required, MaxLength(255), EmailAddress]
        public string Email { get; set; }

        [Required, MaxLength(255)]
        public string PasswordHash { get; set; } 

        [MaxLength(255)]
        public string? ProfilePicture { get; set; }

        public bool IsActive { get; set; } = true;

        [Required]
        public int RoleId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime JoinDate { get; set; } = DateTime.UtcNow;

        [MaxLength(500)]
        public string? Bio { get; set; }

        [MaxLength(11)]
        public string? Phone { get; set; }

        [Required]
        public int Country { get; set; }

    }

}
