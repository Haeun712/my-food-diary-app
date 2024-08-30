namespace MauiApp1.Resources.Pages;

public partial class NewRecipePage : ContentPage
{
	public NewRecipePage()
	{
		InitializeComponent();
	}
    private async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var recipeName = RecipeNameEntry.Text;
        var ingredients = IngredientsEditor.Text;
        var steps = StepsEditor.Text;

        if (string.IsNullOrWhiteSpace(recipeName))
        {
            await DisplayAlert("Error", "Please enter a recipe name.", "OK");
            return;
        }

        // ������ ������ ���� ���� (ex) �����ͺ��̽� or API�� ����Ͽ� ����)
        // ex) LocalDatabase.SaveRecipe(recipeName, ingredients, steps);

        // ���� ���� �޽��� ǥ�� �� ���� �������� ���ư���
        await DisplayAlert("Success", "Recipe saved successfully!", "OK");
        await Navigation.PopAsync();
    }

    private async void OnAddPhotoButtonClicked(object sender, EventArgs e)
    {
        // ���� ���� ����
        var result = await FilePicker.Default.PickAsync(PickOptions.Images);

        if (result != null)
        {
            // ������ ������ ��Ʈ���� ��������
            using (var stream = await result.OpenReadAsync())
            {
                // �̹����� Image ��Ʈ�ѿ� ǥ��
                RecipeImage.Source = ImageSource.FromStream(() => stream);
                RecipeImage.IsVisible = true; // �̹����� ǥ��
            }
        }
    }
}