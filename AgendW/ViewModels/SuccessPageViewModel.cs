using AgendW.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AgendW.ViewModels
{
    public class SuccessPageViewModel : INotifyPropertyChanged
    {
        public Atendimento Atendimento { get; private set; }

        public SuccessPageViewModel(Atendimento atendimento)
        {
            Atendimento = atendimento;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // Implement INotifyPropertyChanged members here if needed

        private ICommand _goBackCommand;
        public ICommand GoBackCommand => _goBackCommand ??= new Command(async () => await GoBack());

        private async Task GoBack()
        {
            await App.Current.MainPage.Navigation.PopToRootAsync();
        }


    }
}
