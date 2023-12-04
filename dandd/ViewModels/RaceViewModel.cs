using CommunityToolkit.Mvvm.ComponentModel;
using dandd.Models;
using dandd.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace dandd.ViewModels
{
    internal partial class RaceViewModel : ObservableObject
    {
        private readonly RaceService _service;


        [ObservableProperty]
        public int _count;

        [ObservableProperty]
        public ObservableCollection<Race> _races;

        public ICommand GetAllRacesCommand { get; }
        public RaceViewModel()
        {
            _service = new RaceService(); //
            GetAllRacesCommand = new Command(async () => await LoadRacesAsync()); //
            Task.Run(async () => await LoadRacesAsync());
        }

        private async Task LoadRacesAsync()
        {
            try
            {
                RaceResponse raceResponse = await _service.GetAllRacesAsync();
                Races = new ObservableCollection<Race>(raceResponse.Results);
                Count = raceResponse.Count;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
