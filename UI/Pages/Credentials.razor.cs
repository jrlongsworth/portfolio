namespace Portfolio.UI.Pages;

sealed public partial class Credentials
{
    private MudCarousel<string> _carousel = default!;
    private readonly bool _showArrows = true;
    private readonly bool _showBullets = true;
    private readonly bool _enableSwipeGesture = true;
    private readonly bool _autoCycle = false;
    private readonly IList<string> _source = new List<string>() { "Item 1", "Item 2", "Item 3", "Item 4" };
    private int selectedIndex = 2;

    private async Task AddAsync()
    {
        _source.Add($"Item {_source.Count + 1}");
        await Task.Delay(1);
        _carousel.MoveTo(_source.Count - 1);
    }

    private async Task DeleteAsync(int index)
    {
        if (_source.Any())
        {
            _source.RemoveAt(index);
            await Task.Delay(1);
            _carousel.MoveTo(System.Math.Max(System.Math.Min(index, _source.Count - 1), 0));
        }
    }
}
