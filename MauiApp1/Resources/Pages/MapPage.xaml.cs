using System.Web;
namespace MauiApp1.Resources.Pages;

public partial class MapPage : ContentPage
{
	private string _address;
	public MapPage(string address)
	{
		InitializeComponent();
		_address = address;
		LoadBingMap();
	}

	private void LoadBingMap()
	{
		var encodedAddress = HttpUtility.UrlEncode(_address);
		string mapUrl = $"https://www.bing.com/maps?q={encodedAddress}";

		myMapWebView.Source = mapUrl;
	}
    
}
