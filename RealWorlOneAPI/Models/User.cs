using System.ComponentModel.DataAnnotations;

namespace RealWorlOneAPI.Models {
    /// <summary>
    /// User
    /// </summary>
    public class User {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
