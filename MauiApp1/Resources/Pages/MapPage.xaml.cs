using MauiApp1.Models;
using Microsoft.Maui.Maps;

namespace MauiApp1.Resources.Pages;

public partial class MapPage : ContentPage
{
	private string _address;
	private string _name;
	public MapPage(RestaurantModel model)
	{
		InitializeComponent();
		_address = model.Address;
		_name = model.Name;
		LoadBingMap();
	}

	private async void LoadBingMap()
	{
		if (_address == null) //no address information 
		{
			await DisplayAlert("No address", "There is no address information for this restaurant.", "cancel");
		}
		else
		{
			IEnumerable<Location> locations = await Geocoding.Default.GetLocationsAsync(_address);

			Location location = locations?.FirstOrDefault();
			if (location != null)
			{
				myMap.Pins.Add(new Microsoft.Maui.Controls.Maps.Pin()
				{
					Location = location,
					Label = _name,
					Address = _address,
				});

				myMap.MoveToRegion(MapSpan.FromCenterAndRadius(location, Distance.FromKilometers(2)));
			}
			else
			{
				await DisplayAlert("Not valid address", "The address does not exist.", "cancel");
			}
		}
	}
    
}
