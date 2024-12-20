using P02.Models;

namespace P02.Pages;

public partial class Coordenadas : ContentPage
{
    private GeoLoc geoLoc;

    public Coordenadas()
    {
        InitializeComponent();
        geoLoc = new GeoLoc
        {
            Latitude = "0.0000",
            Longitude = "0.0000",
            Altitude = "0.0000"
        };
        BindingContext = geoLoc;
        _ = loadGeoLoc();
    }

    private async Task<GeoLoc> loadGeoLoc()
    {
        geoLoc = new GeoLoc();
        try
        {
            Location location = await Geolocation.Default.GetLastKnownLocationAsync();

            if (location != null)
            {
                geoLoc.Longitude = location.Longitude.ToString();
                geoLoc.Latitude = location.Latitude.ToString();
                geoLoc.Altitude = location.Altitude.ToString();
            }
        }
        catch (FeatureNotSupportedException fnsEx)
        {
            return geoLoc;
        }
        catch (FeatureNotEnabledException fneEx)
        {
            return geoLoc;
        }
        catch (PermissionException pEx)
        {
            return geoLoc;
        }
        catch (Exception ex)
        {
            return geoLoc;
        }

        OnPropertyChanged(nameof(geoLoc));
        return geoLoc;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        BindingContext = geoLoc;
    }
    private async void OnBack(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}