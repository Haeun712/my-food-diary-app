using MauiApp1.Models;
using MauiApp1.ViewModels;
using System.ComponentModel;
using Microsoft.Maui.ApplicationModel.DataTransfer;
using static System.Net.Mime.MediaTypeNames;

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
        string serves_text = null;
        string ingredient_text = null;
        string direction_text = null;
        string memories_text = null;
        //check saved data of the recipe
        //if there is no corresponding data, it will be not included in the share text
        if(model.Serves > 0)
        {
            serves_text = $"Serves: {model.Serves}\n\n";
        }
        if(model.Ingredients != "")
        {
            ingredient_text = $"Ingredient\n {model.Ingredients}\n\n";
        }
        if(model.Directions != "")
        {
            direction_text = $"Direction\n {model.Directions}\n\n";
        }
        if (model.Memories != "")
        {
            memories_text = $"Memories\n {model.Memories}\n";
        }
        var text = $"{model.Name}\n\n{serves_text}{ingredient_text}{direction_text}{memories_text}";
        //call share API
        //https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/data/share?view=net-maui-8.0&tabs=android
        await Share.Default.RequestAsync(new ShareTextRequest
        {
            Text = text,
            Title = "Recipe Share"
        });
    }
}