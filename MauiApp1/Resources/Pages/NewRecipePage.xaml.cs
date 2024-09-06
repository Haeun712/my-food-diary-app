namespace MauiApp1.Resources.Pages;

public partial class NewRecipePage : ContentPage
{
	public NewRecipePage()
	{
		InitializeComponent();
	}
    public async Task<PermissionStatus> GetCameraPermission()
    {
        PermissionStatus status = await Permissions.RequestAsync<Permissions.Camera>();

        if (status == PermissionStatus.Granted)
            return status;

        if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
        {
            // Prompt the user to turn on in settings
            // On iOS once a permission has been denied it may not be requested again from the application
            await DisplayAlert("Warning", "You need to manually enable camera access for this app in settings.", "OK");
            return status;
        }

        if (Permissions.ShouldShowRationale<Permissions.Camera>())
        {
            // Prompt the user with additional information as to why the permission is needed
            await DisplayAlert("Warning", "This app requires camera access to add photos for your character", "OK");
        }

        status = await Permissions.RequestAsync<Permissions.Camera>();

        return status;
    }
    private async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var recipeName = RecipeNameEntry.Text;
        var serves = RecipeServesEntry.Text;
        var ingredients = IngredientsEditor.Text;
        var directions = DirectionsEditor.Text;

        if (string.IsNullOrWhiteSpace(recipeName))
        {
            await DisplayAlert("Error", "Please enter a recipe name.", "OK");
            return;
        }

        // ������ ������ ���� ���� (ex) �����ͺ��̽� or API�� ����Ͽ� ����)
        // ex) LocalDatabase.SaveRecipe(recipeName, ingredients, directions);

        // ���� ���� �޽��� ǥ�� �� ���� �������� ���ư���
        await DisplayAlert("Success", "Recipe saved successfully!", "OK");
        await Navigation.PopAsync();
    }

    private async void OnAddPhotoButtonClicked(object sender, EventArgs e)
    {
        FileResult result = null;
        // ���� ���� ���� (��: MediaPicker�� ����� �� ����)
        PermissionStatus status = await GetCameraPermission();
        if (status == PermissionStatus.Granted)
        {
            result = await MediaPicker.PickPhotoAsync();
        }
        if (result != null)
        {
            var stream = await result.OpenReadAsync();
            RecipeImage.Source = ImageSource.FromStream(() => stream);
        }
    }
}