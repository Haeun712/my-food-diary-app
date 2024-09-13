using MauiApp1.Models;
using MauiApp1.ViewModels;

namespace MauiApp1.Resources.Pages;

public partial class ViewRecipePage : ContentPage
{
    RecipeModel model;
    public ViewRecipePage(RecipeModel m)
	{
        model = m;
        BindingContext = model; 
        InitializeComponent();
	}
    //Modify the recipe
    private async void OnModifyButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NewRecipePage(model));
    }

    //Delete the recipe
    private async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        //Confirm to delete
        if(await DisplayAlert("Confirm Delete", "Are you sure you want to delete this recipe? This cannot be undone","Yes","No")!=true)
        {
            return;
        }
        RecipeViewModel.Current.DeleteRecipe(model);
        await Navigation.PushAsync(new RecipeListPage());
    }

    private async void OnShareButtonClicked(object sender, EventArgs e)
    {
        // Implement share functionality
    }
}