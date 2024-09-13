using MauiApp1.Models;
using MauiApp1.ViewModels;

namespace MauiApp1.Resources.Pages;

public partial class NewRecipePage : ContentPage
{
    RecipeModel model;
	public NewRecipePage(RecipeModel m)
	{
        model = m;
        BindingContext = model;

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
    public async Task<PermissionStatus> GetMediaPermission()
    {
        PermissionStatus status = await Permissions.RequestAsync<Permissions.StorageRead>();

        if (status == PermissionStatus.Granted)
            return status;

        if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
        {
            // Prompt the user to turn on in settings
            // On iOS once a permission has been denied it may not be requested again from the application
            await DisplayAlert("Warning", "You need to manually enable camera access for this app in settings.", "OK");
            return status;
        }

        if (Permissions.ShouldShowRationale<Permissions.StorageRead>())
        {
            // Prompt the user with additional information as to why the permission is needed
            await DisplayAlert("Warning", "This app requires camera access to add photos for your character", "OK");
        }

        status = await Permissions.RequestAsync<Permissions.StorageRead>();

        return status;
    }
    private async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        if(model.Name == null ||  model.Name.Length < 1)
        {
            await DisplayAlert("Error", "Please enter a recipe name.", "OK");
            return;
        }
        RecipeViewModel.Current.SaveRecipe(model);
        await DisplayAlert("Success", "Recipe saved successfully!", "OK");
        await Navigation.PushAsync(new RecipeListPage());
    }

    private async void OnAddPhotoButtonClicked(object sender, EventArgs e)
    {
        FileResult photo = null;
        if (MediaPicker.Default.IsCaptureSupported && DeviceInfo.Platform != DevicePlatform.WinUI)
        {
            PermissionStatus status = await GetCameraPermission();
            if (status == PermissionStatus.Granted)
            {
                photo = await MediaPicker.CapturePhotoAsync();
            }
        }
        else
        {
            PermissionStatus status = await GetMediaPermission();
            if(status == PermissionStatus.Granted)
            {
                photo = await MediaPicker.PickPhotoAsync();
            }
        }
        if (photo != null)
        {
            //Check if images folder exists
            string imagesDir = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, "images");
            System.IO.Directory.CreateDirectory(imagesDir);

            var newFile = Path.Combine(imagesDir, photo.FileName);
            using (var stream = await photo.OpenReadAsync())
            using (var newStream = File.OpenWrite(newFile))
            {
                await stream.CopyToAsync(newStream);
            }

            model.ImageFilePath = newFile;
            model.OnPropertyChanged("ImageFilePath");
        }
    }
}