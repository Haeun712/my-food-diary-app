using MauiApp1.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    [SQLite.Table("restaurants")]
    public class RestaurantModel : ObservableObject
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        //Restaurant information
        [MaxLength(300)]
        public string Name { get; set; }
        public string Address { get; set; }
        public string Category { get; set; }
        public int Rate { get; set; }
        public string Memories { get; set; }
        public bool IsVisibleImage { get; set; }
        public string ImageFilePath { get; set; }
    }
}
