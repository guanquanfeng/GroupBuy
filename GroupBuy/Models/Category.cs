using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GroupBuy.Models
{
    public class Category
    {
        public Category()
        {
            this.Products = new HashSet<Product>();
        }
        [Key]
        public int CateId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string CateName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}