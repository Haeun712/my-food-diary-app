# My Food Diary 
Developed for Android and Windows platform

A mobile app that allows users to save, view, and share their own food recipes, favourite restaurants information, and precious memories of the food like a diary. It is designed to help them preserve their personal food-related experiences and facilitate the sharing of those experiences with others, such as restaurant recommendations and recipe sharing. Therefore, as a memory aid, it can provide a solution of memory-related issues, such as forgetting recipes, restaurant names, or the name of dishes, in their daily lives.

## App Features
### 🧾 Recipe Info Management
  * **Add new recipe**: enter the recipe details (name, serves, ingredients, directions) and memories in the provided fields.
  * **Add photo**: Add an image of the finished dish.
  * **Save recipe**: save the recipe information to the local storage.
  * **Show recipes**: show the list of recipes saved in the local storage.
  * **View recipe**: view saved information and image of the recipe.
  * **Modify recipe**: edit the recipe details and memories.
  * **Delete recipe**: delete recipe from the local storage. 
  * **Share recipe**: share the recipe with others via email.

 ### 🍴 Restaurant Info Management
  * **Add new restaurant**: enter the restaurant details (name, address, rate, category) and memories in the provided fields.
  * **Add photo**: Add an image of food served at the restaurant.
  * **Save restaurant**: save the restaurant information to the local storage.
  * **Show restaurants**: show the list of restaurants saved in the local storage.
  * **View restaurant**: view saved information and image of the restaurant.
  * **Modify restaurant**: edit the restaurant details and memories.
  * **Delete restaurant**: delete the restaurant from the local storage. 
  * **Confirmation Message**: prevent accidental deletion.
  * **Share restaurant**: share the restaurant with others via email.
  * **View restaurant on the map**: find the restaurant on the map using the stored restaurant address.

## Technical Features
Features|Reasons
---|---|
Camera|Enable to attach an image of food when storing recipes and restaurants.|
File Storage|Save and manage the recipe and restaurant information in the local storage.|
Share API|Share the saved recipe and restaurant information with others by sending an email|
Bing Map|Show the restaurant on the map in the window platform|
Geocoding|Convert textual restaurant addresses into the corresponding geographic coordinates, latitude and longitude.|


## Wireframe
Below is the wireframe, which has been implemented to reflect the intended user interface and flow of the application.
![Wireframe of My Food Diary](images/UpdatedWireframe.jpg)

### Technolgoies Used
* C#
* .NET MAUI
* SQLite 
* Git & GitHub

## Limitations
### Geocoding Incompletion
```csharp
private async void LoadBingMap()
{
 //Geocoding restaruent address
 //Reference: https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/device/geocoding?view=net-maui-8.0&tabs=windows
 IEnumerable<Location> locations = await Geocoding.Default.GetLocationAsync(_address);
 Location location = location?.FirstOrDefault();
}
```
This code snippet implements geocoding to convert user-entered restaurant addresses into map coordinates using .NET MAUI’s built-in geocoding API. Despite following the official Microsoft documentation and encountering no build-time errors, the location variable consistently returns null.

Multiple troubleshooting efforts were made, including:

* Running Microsoft’s sample code with no modifications

* Exploring alternative APIs (e.g., Google Maps Geocoding API)

* Seeking assistance from course instructors

The issue remains unresolved and is documented here for transparency. 

## License

Please do not reuse or redistribute without appropriate attribution.

## References
Freepik. (n.d.). Recipe book icon. https://www.freepik.com/icon/recipe-book_10646894#fromView=search&page=10&position=74&uuid=560b6c4f-81db-4d86-9e23-a910e052882b.

Uxwing. (n.d.). Photos icon. https://uxwing.com/photos-icon/

Uxwing. (n.d.). Map icon. https://uxwing.com/map-icon/

Wikimedia Commons. (2024). File: Ei-share-apple.svg. https://commons.wikimedia.org/wiki/File:Ei-share-apple.svg

SVG Repo. (n.d.). Garbage bin svg vector. https://www.svgrepo.com/svg/195606/garbage-bin 

Versluis, G. (2023, June 21). Maps controls for Windows with .NET MAUI and Bing Maps [Video]. YouTube. https://www.youtube.com/watch?v=G3fIVJGabUQ

Microsoft. (2023, November 29). Geocoding. https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/device/geocoding?view=net-maui-8.0&tabs=windows 

Microsoft. (2024, August 30). Map. https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/map?view=net-maui-8.0

Microsoft. (2023, November 29). Share. https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/data/share?view=net-maui-8.0&tabs=windows 

