using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CooksCorner1._0.Models
{
    public class File
    {
        [Key]
        public int FileId { get; set; }
        [StringLength(255)]
        public string FileName { get; set; }
        [StringLength(100)]
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public FileType FileType { get; set; }
        public int RecipeId { get; set; }

        [ForeignKey("RecipeId")]
        public virtual RecipeModel Recipes { get; set; }

    }
}