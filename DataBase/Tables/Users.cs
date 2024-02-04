using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorManager.DataBase
{
    public class Users
    {
        [Key]
        public int ID { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? JobTitle { get; set; }
        public string? PhoneNumber { get; set; }
        public int? CommercialOnce { get; set; }
        public int? MakingPaintsOnce { get; set; }
        public int? MakingPaintsCount { get; set; }
        public int? RequestRecipesOnce { get; set; }
        public int? CheckAnalogueOnce { get; set; }
        public string? IP { get; set; }
    }
}
