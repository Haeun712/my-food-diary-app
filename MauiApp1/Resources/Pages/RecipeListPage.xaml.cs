using MauiApp1.Models;
using MauiApp1.ViewModels;

namespace MauiApp1.Resources.Pages;

public partial class RecipeListPage : ContentPage
{
    RecipeViewModel viewModel;
	public RecipeListPage()
	{
        BindingContext = viewModel = new RecipeViewModel();
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnPropertyChanged("Recipes");
    }
    private async void OnAddRecipeButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NewRecipePage(new RecipeModel()));
    }

    private void Recipe_Tapped(object sender, ItemTappedEventArgs e)
    {
        RecipeModel tapped = (RecipeModel)e.Item;
        Navigation.PushAsync(new ViewRecipePage(tapped));
    }

    private async void OnMyRecipesButtonClicked(object sender, EventArgs e)
    {
        //Refresh the page
        await Navigation.PushAsync(new RecipeListPage());
    }

    private async void OnMyRestaurantsButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RestaurantListPage());
    }
   
}