namespace MauiApp1.Resources.Pages;

public partial class NewRestaurantPage : ContentPage
{
	public NewRestaurantPage()
	{
		InitializeComponent();
	}
    // ���� �߰� ��ư Ŭ�� �̺�Ʈ ó��
    private async void OnAddPhotoButtonClicked(object sender, EventArgs e)
    {
        // ���� ���� ���� (��: MediaPicker�� ����� �� ����)
        var result = await MediaPicker.PickPhotoAsync();
        if (result != null)
        {
            var stream = await result.OpenReadAsync();
            RestaurantImage.Source = ImageSource.FromStream(() => stream);
        }
    }

    // ���� ��ư Ŭ�� �̺�Ʈ ó��
    private async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var restaurantName = RestaurantNameEntry.Text;
        var restaurantAddress = RestaurantAddressEntry.Text;
        var restaurantRate = (int)RestaurantRateSlider.Value;
        var restaurantMemo = RestaurantMemoEditor.Text;

        // ���⿡ ������� �����͸� �����ϴ� ������ �߰�
        // ex) �����ͺ��̽��� API�� ���� �����͸� ����

        // ���� ��, ���� �������� ���ư���
        await DisplayAlert("Success", "Restaurant saved successfully!", "OK");
        await Navigation.PopAsync();
    }
}