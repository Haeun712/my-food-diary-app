using INFT_2051.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class RecipeModel : ObservableObject
    {
        //This is how getters and setters are specified in C#
        //Recipe information

        //Food Name
        public string FName { get; set; }
        public int Serves { get; set; } 
        public string Ingredients {  get; set; } 
        public string Directions { get; set; }
        //Food Memories
        public string FMemories { get; set; }
        //Food Image
        public string FImageFilePath { get; set; }
    }
}
