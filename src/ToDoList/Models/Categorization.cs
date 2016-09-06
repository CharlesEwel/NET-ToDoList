using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.Models
{
    [Table("Categorizations")]
    public class Categorization
    {
        [Key]
        public int CategorizationId { get; set; }
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    } 
}
