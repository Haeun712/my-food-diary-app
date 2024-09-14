using MauiApp1.Models;
using MauiApp1.Resources.Pages;
using MauiApp1.ViewModels;

namespace MauiApp1.Resources.Pages;

public partial class RestaurantListPage : ContentPage
{
    RestaurantViewModel viewModel;
	public RestaurantListPage()
	{
        BindingContext = viewModel = new RestaurantViewModel();
        InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnPropertyChanged("Restaurants");
    }
    private async void OnAddRestaurantButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NewRestaurantPage(new RestaurantModel()
        {
            Rate = 3
        }));
    }
    private void Restaurant_Tapped(object sender, ItemTappedEventArgs e)
    {
        RestaurantModel tapped = (RestaurantModel)e.Item;
        Navigation.PushAsync(new ViewRestaurantPage(tapped));
    }
    private async void OnMyRecipesButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RecipeListPage());
    }

    private async void OnMyRestaurantsButtonClicked(object sender, EventArgs e)
    {
        //Refresh the page
        await Navigation.PushAsync(new RestaurantListPage());
    }
}