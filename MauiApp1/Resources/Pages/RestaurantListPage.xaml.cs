namespace MauiApp1.Resources.Pages;

public partial class RestaurantListPage : ContentPage
{
	public RestaurantListPage()
	{
		InitializeComponent();
	}
    private async void OnAddRestaurantButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NewRestaurantPage());
    }

    private async void OnMyRecipesButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RecipeListPage());
    }

    private async void OnMyRestaurantsButtonClicked(object sender, EventArgs e)
    {
        // ���� �������̹Ƿ� �������� ����
    }
}