using MauiApp1.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;

namespace MauiApp1.Services
{
    internal static class DatabaseService
    {
        private static string _databaseFile;
        private static string DatabaseFile
        {
            get
            {
                if(_databaseFile == null)
                {
                    string databaseDir = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, "data");
                    System.IO.Directory.CreateDirectory(databaseDir);

                    _databaseFile = Path.Combine(databaseDir, "fooddiary_data.sqlite");
                }
                return _databaseFile;
            }
        }
        private static SQLiteConnection _connection;
        public static SQLiteConnection Connection
        {
            get
            {
                if(_connection == null)
                {
                    _connection = new SQLiteConnection(DatabaseFile);
                    _connection.CreateTable<RecipeModel>();
                    _connection.CreateTable<RestaurantModel>();
                }
                return _connection;
            }
        }
    }
}
