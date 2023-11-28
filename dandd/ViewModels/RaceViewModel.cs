using CommunityToolkit.Mvvm.ComponentModel;
using dandd.Models;
using dandd.Services;
using System.Windows.Input;

namespace dandd.ViewModels
{
    internal partial class RaceViewModel : ObservableObject
    {
        private readonly RaceService _service;

        [ObservableProperty]
        public int _Count;

        [ObservableProperty]
        public List<Race> _results;

        public ICommand GetAllRacesCommand { get; }
        public RaceViewModel()
        {
            Results = new RaceResponse().Results;
            _service = new RaceService();
            GetAllRacesCommand = new Command(async () => await LoadRacesAsync());
        }

        private async Task LoadRacesAsync()
        {
            try
            {
                var response = await _service.GetAllRacesAsync();
                Results = response.Results;
                Count = response.Count;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
