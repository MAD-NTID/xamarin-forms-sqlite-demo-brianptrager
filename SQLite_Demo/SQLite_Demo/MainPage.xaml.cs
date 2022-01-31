using SQLite;
using SQLite_Demo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace SQLite_Demo
{
    public partial class MainPage : ContentPage
    {
        public static ObservableCollection<Coffee> coffeesOC;
        SQLiteAsyncConnection connection;
        public MainPage()
        {
            InitializeComponent();

            //if (coffees == null)
            //    //coffees = new ObservableCollection<Coffee>();
            //    coffees = new List<Coffee>();

            if (connection == null)
                connection = ConnectToDB();

            CreateTable();
            AddDataToTable();
            RetrieveData();

            BindingContext = this;
            //coffeeList.ItemsSource = coffees;
        }

        public SQLiteAsyncConnection ConnectToDB()
        {
            return new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, "coffeedb.db"));
        }

        public async void CreateTable()
        {
            await connection.CreateTableAsync<Coffee>();
        }

        public async void AddDataToTable()
        {
            Coffee c = new Coffee()
            {

                Name = "Regular Coffee",
                Brand = "Dunkin"
            };
            int id;
            id = await connection.InsertAsync(c);

            c = new Coffee()
            {
                Name = "Pike Place",
                Brand = "Starbucks"
            };

            id = await connection.InsertAsync(c);
           // await DisplayAlert("Result", id.ToString(), "OK");
        }

        public async void RetrieveData()
        {
            var query = connection.Table<Coffee>();

            List<Coffee> coffees = await query.ToListAsync();

            coffeesOC = new ObservableCollection<Coffee>(coffees);

            //await DisplayAlert("Result", coffeesOC.Count.ToString(), "OK");
        }

    }
}
