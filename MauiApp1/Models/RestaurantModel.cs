using INFT_2051.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class RestaurantModel : ObservableObject
    {
        //This is how getters and setters are specified in C#
        //Restaurant information

        //Restaurant name
        public string RName { get; set; }
        public int Address { get; set; }
        public string Category { get; set; }
        public string Rate { get; set; }
        //Restaurant memories
        public string RMemories { get; set; }
        //Restaurant Image
        public string RImageFilePath { get; set; }
    }
}
