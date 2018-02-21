using System;
using System.ComponentModel.DataAnnotations;

namespace Sysemn.ApiSwagger.Models
{
    public class UserModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
