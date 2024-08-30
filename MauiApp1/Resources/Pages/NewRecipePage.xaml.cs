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

        // 레시피 데이터 저장 로직 (ex) 데이터베이스 or API를 사용하여 저장)
        // ex) LocalDatabase.SaveRecipe(recipeName, ingredients, steps);

        // 저장 성공 메시지 표시 후 이전 페이지로 돌아가기
        await DisplayAlert("Success", "Recipe saved successfully!", "OK");
        await Navigation.PopAsync();
    }

    private async void OnAddPhotoButtonClicked(object sender, EventArgs e)
    {
        // 사진 파일 선택
        var result = await FilePicker.Default.PickAsync(PickOptions.Images);

        if (result != null)
        {
            // 선택한 파일의 스트림을 가져오기
            using (var stream = await result.OpenReadAsync())
            {
                // 이미지를 Image 컨트롤에 표시
                RecipeImage.Source = ImageSource.FromStream(() => stream);
                RecipeImage.IsVisible = true; // 이미지를 표시
            }
        }
    }
}