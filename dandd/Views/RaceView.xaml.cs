using dandd.ViewModels;

namespace dandd.Views;

public partial class RaceView : ContentPage
{
    private RaceViewModel _raceViewModel;
    public RaceView()
    {
        InitializeComponent();
        _raceViewModel = new RaceViewModel();
        BindingContext = _raceViewModel;
    }

}