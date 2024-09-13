using MauiApp1.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    [SQLite.Table("recipes")]
    public class RecipeModel : ObservableObject
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }

        //Recipe information
        [MaxLength(300)]
        public string Name { get; set; }
        public int Serves { get; set; } 
        public string Ingredients {  get; set; } 
        public string Directions { get; set; }
        public string Memories { get; set; }
        public string ImageFilePath { get; set; }
    }
}
