namespace MauiApp1.Resources.Pages;

public partial class NewRestaurantPage : ContentPage
{
	public NewRestaurantPage()
	{
		InitializeComponent();
	}
    // 사진 추가 버튼 클릭 이벤트 처리
    private async void OnAddPhotoButtonClicked(object sender, EventArgs e)
    {
        // 사진 선택 로직 (예: MediaPicker를 사용할 수 있음)
        var result = await MediaPicker.PickPhotoAsync();
        if (result != null)
        {
            var stream = await result.OpenReadAsync();
            RestaurantImage.Source = ImageSource.FromStream(() => stream);
        }
    }

    // 저장 버튼 클릭 이벤트 처리
    private async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var restaurantName = RestaurantNameEntry.Text;
        var restaurantAddress = RestaurantAddressEntry.Text;
        var restaurantRate = (int)RestaurantRateSlider.Value;
        var restaurantMemo = RestaurantMemoEditor.Text;

        // 여기에 레스토랑 데이터를 저장하는 로직을 추가
        // ex) 데이터베이스나 API를 통해 데이터를 저장

        // 저장 후, 이전 페이지로 돌아가기
        await DisplayAlert("Success", "Restaurant saved successfully!", "OK");
        await Navigation.PopAsync();
    }
}