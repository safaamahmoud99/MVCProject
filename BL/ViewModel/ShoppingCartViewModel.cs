using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModel
{
    public class ShoppingCartViewModel
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public double totalPrice { get; set; }
        public virtual ApplicationUserIDentity appUser { get; set; }
        public virtual ICollection<ShoppingCartProducts> ShoppingCartProducts { get; set; }
    }
}
