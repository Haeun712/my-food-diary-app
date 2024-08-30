namespace MauiApp1.Resources.Pages;

public partial class RecipeListPage : ContentPage
{
	public RecipeListPage()
	{
		InitializeComponent();
	}

    private async void OnAddRecipeButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NewRecipePage());
    }

    private async void OnMyRecipesButtonClicked(object sender, EventArgs e)
    {
        // ���� �������̹Ƿ� �������� ����
    }

    private async void OnMyRestaurantsButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RestaurantListPage());
    }
}