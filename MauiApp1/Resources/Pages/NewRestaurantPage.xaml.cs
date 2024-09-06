namespace MauiApp1.Resources.Pages;

public partial class NewRestaurantPage : ContentPage
{
	public NewRestaurantPage()
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
    // 사진 추가 버튼 클릭 이벤트 처리
    private async void OnAddPhotoButtonClicked(object sender, EventArgs e)
    {
        FileResult result = null;
        // 사진 선택 로직 (예: MediaPicker를 사용할 수 있음)
        PermissionStatus status = await GetCameraPermission();
           if (status == PermissionStatus.Granted)
           {
               result = await MediaPicker.PickPhotoAsync();
           }
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
        var restaurantCategory = RestaurantCategoryEntry.Text;
        var restaurantRate = (int)RestaurantRateSlider.Value;
        var restaurantMemo = RestaurantMemoEditor.Text;

        // 여기에 레스토랑 데이터를 저장하는 로직을 추가
        // ex) 데이터베이스나 API를 통해 데이터를 저장

        // 저장 후, 이전 페이지로 돌아가기
        await DisplayAlert("Success", "Restaurant saved successfully!", "OK");
        await Navigation.PopAsync();
    }
}