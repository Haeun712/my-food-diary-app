using MauiApp1.Models;
using MauiApp1.ViewModels;
using Microsoft.Maui.ApplicationModel.DataTransfer;

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
        string rate_text = $"Rate: {model.Rate}\n\n";
        string category_text = null;
        string address_text = null;
        string memories_text  = null;
        //check saved data of the recipe
        //if there is no corresponding data, it will be not included in the share text
        if (model.Category != "")
        {
            category_text = $"Category: {model.Category}\n";
        }
        if (model.Address != "")
        {
            address_text = $"Address: {model.Address}\n\n";
        }
        
        if (model.Memories != "")
        {
            memories_text = $"Memories\n {model.Memories}";
        }
        var text = $"{model.Name}\n{rate_text}{category_text}{address_text}{memories_text}";
        //call share API
        //https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/data/share?view=net-maui-8.0&tabs=android
        await Share.Default.RequestAsync(new ShareTextRequest
        {
            Text = text,
            Title = "Restaurant Share"
        });
    }
    private async void OnMapButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MapPage(model));
    }
}