namespace Portfolio.UI.Pages;

sealed public partial class Credentials
{
    private MudCarousel<string> _carousel = default!;
    private readonly bool _showArrows = true;
    private readonly bool _showBullets = true;
    private readonly bool _enableSwipeGesture = true;
    private readonly bool _autoCycle = false;
    private readonly IList<string> _images = new List<string>();
    private int selectedIndex = 0;

    protected override void OnInitialized()
    {
        _images.Add(@"Credentials/IvyTechTcSdev.png");
        _images.Add(@"Credentials/SkillSoft.png");
        _images.Add(@"Credentials/TestOut.png");
        _images.Add(@"Credentials/Comptia.png");
    }

    private async Task AddAsync()
    {
        await Task.Delay(1);
        _carousel.MoveTo(_images.Count - 1);
    }

    private async Task DeleteAsync(int index)
    {
        if (_images.Any())
        {
            _images.RemoveAt(index);
            await Task.Delay(1);
            _carousel.MoveTo(System.Math.Max(System.Math.Min(index, _images.Count - 1), 0));
        }
    }
}
