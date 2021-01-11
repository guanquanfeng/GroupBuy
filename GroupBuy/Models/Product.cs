using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GroupBuy.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 1)]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Totle { get; set; }
        public int Remaining { get; set; }
        public bool InStock { get; set; }
        public string UserName { get; set; }
        
        public string ImageUrl { get; set; }
        public int CateId { get; set; }
        [ForeignKey("CateId")]
        public virtual Category Categories { get; set; }
        public bool Star { get; set; }
    }
}