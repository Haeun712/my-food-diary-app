using MauiApp1.Models;
using MauiApp1.ViewModels;

namespace MauiApp1.Resources.Pages;

public partial class ViewRestaurantPage : ContentPage
{
    RestaurantModel model;
    public ViewRestaurantPage(RestaurantModel m)
    {
        model = m;
        BindingContext = model;
        InitializeComponent();
    }
    //Modify the recipe
    private async void OnModifyButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NewRestaurantPage(model));
    }

    //Delete the recipe
    private async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        //Confirm to delete
        if (await DisplayAlert("Confirm Delete", "Are you sure you want to delete this restaurant? This cannot be undone", "Yes", "No") != true)
        {
            return;
        }
        RestaurantViewModel.Current.DeleteRestaurant(model);
        await Navigation.PushAsync(new RestaurantListPage());
    }

    private async void OnShareButtonClicked(object sender, EventArgs e)
    {
        // Implement share functionality
    }
    private async void OnMapButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MapPage(model.Address));
    }
}