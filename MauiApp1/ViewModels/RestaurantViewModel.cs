using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiApp1.Models;
using MauiApp1.Services;
using SQLite;

namespace MauiApp1.ViewModels
{
    internal class RestaurantViewModel : ObservableObject
    {
        public static RestaurantViewModel Current {  get; set; }

        SQLiteConnection connection;

        public RestaurantViewModel()
        {
            Current = this;
            connection = DatabaseService.Connection;
        }
        public List<RestaurantModel> Restaurants
        {
            get
            {
                return connection.Table<RestaurantModel>().ToList();
            }
        }
        public void SaveRestaurant(RestaurantModel model)
        {
            //If it has an id, then it already exists and we can update it
            if(model.Id > 0)
            {
                connection.Update(model);
            }
            //if not, it's new and add it
            else
            {
                connection.Insert(model);
            }
        }
        public void DeleteRestaurant(RestaurantModel model)
        {
            //if it has an Id, we can delete it
            if (model.Id > 0)
            {
                connection.Delete(model);
            }
        }

    }
}
