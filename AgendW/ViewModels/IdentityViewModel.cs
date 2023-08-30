using AgendW.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AgendW.ViewModels
{
    public class IdentityViewModel : INotifyPropertyChanged
    {

        public Action NavigateToAgendamentoPageAction { get; set; }

        public ICommand LoginCommand { get; private set; }

        private readonly IAuthenticationService _authenticationService;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _email;
    public string Email
    {
        get { return _email; }
        set 
        {
            _email = value; 
            OnPropertyChanged(nameof(Email));
        }
    }

        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        private string _password;
    public string Password
    {
        get { return _password; }
        set 
        {
            _password = value; 
            OnPropertyChanged(nameof(Password));
        }
    }

        public IdentityViewModel(IAuthenticationService authenticationService) {
            _authenticationService = authenticationService;

            LoginCommand = new Command (async () => await LoginAsync());
        }

        public async Task LoginAsync()
        {
            try
            {
                IsLoading = true;
                var authResponse = await _authenticationService.LoginAsync(Email, Password);
                if (authResponse != null && !string.IsNullOrEmpty(authResponse.AccessToken))
                {
                    //Store the token and user details
                    await SecureStorage.SetAsync("app.token", authResponse.AccessToken);
                    var userJson = JsonSerializer.Serialize(authResponse.UserToken);
                    await SecureStorage.SetAsync("app.user", userJson);

                    //Navigate to page
                    //Device.BeginInvokeOnMainThread(() =>
                    //{
                    IsLoading = false;
                        NavigateToAgendamentoPageAction?.Invoke();
                    //});
                }
            }
            catch (Exception ex)
            {
                //Device.BeginInvokeOnMainThread(async () =>
                //{
                IsLoading = false;
                    await App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
                //});
            }
        }


    }
}
