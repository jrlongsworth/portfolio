namespace Portfolio.UI.Shared;

public partial class MainLayout
{
    private MudTheme _theme = default!;
    private MudThemeProvider _mudThemeProvider = new MudThemeProvider();
    private bool _drawerOpen = true;
    private bool _isDarkMode = false;
    private string _themeIcon = Icons.Material.Filled.LightMode;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _theme = GetMudTheme();
            _isDarkMode = await _mudThemeProvider.GetSystemPreference();
            await _mudThemeProvider.WatchSystemPreference(OnSystemPreferenceChanged);
            StateHasChanged();
        }
    }

    private async Task OnSystemPreferenceChanged(bool newValue)
    {
        await Task.Run(() => _isDarkMode = newValue);
        StateHasChanged();
    }

    private MudTheme GetMudTheme()
    {
        string primary = "008080";
        string secondary = "#80002A";
        string tertiary = "#802B00";

        return new MudTheme()
        {
            Palette = new PaletteLight()
            {
                Primary = primary,
                Secondary = secondary,
                Tertiary = tertiary,
                AppbarBackground = primary,
                Black = "#343741",
                Background = "#FFFFFF7D",
                BackgroundGrey = "#FFFFFFC0",
                Surface = "#FFFFFF7D",
                TextPrimary = "#000000",
                TextSecondary = "#7D7D7D",
                DrawerBackground = "#27282F",
                DrawerText = "#FFFFFFC0",
                AppbarText = "#FFFFFFC0",
                LinesDefault = "#FFFFFF7D",
                ActionDefault = "#7D7D7D",
                ActionDisabled = "#E8E9E9",
                Info = "#DA1A32",
                PrimaryDarken = "#DA1A32"
            },

            PaletteDark = new PaletteDark()
            {
                Primary = primary,
                Secondary = secondary,
                Tertiary = tertiary,
                AppbarBackground = primary,
                Black = "#343741",
                Background = "#343741",
                BackgroundGrey = "#3437417D",
                Surface = "#343741",
                TextPrimary = "#FFFFFFC0",
                TextSecondary = "#FFFFFFC0",
                DrawerBackground = "#27282F",
                DrawerText = "#FFFFFFC0",
                AppbarText = "#FFFFFFC0",
                LinesDefault = "#34374120",
                ActionDefault = "#6E7280",
                ActionDisabled = "#818589",
                Info = "#DA1A32",
                PrimaryDarken = "#DA1A32"
            },

            LayoutProperties = new LayoutProperties()
            {
                DrawerWidthLeft = "260px",
                DrawerWidthRight = "300px"
            }
        };
    }

    private void DrawerToggle() => _drawerOpen = !_drawerOpen;
    private void ThemeToggle()
    {
        _isDarkMode = !_isDarkMode;
        if (_isDarkMode)
        {
            _themeIcon = Icons.Material.Filled.LightMode;
        }
        else
        {
            _themeIcon = Icons.Material.Filled.DarkMode;
        }
    }
}
