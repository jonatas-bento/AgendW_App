using AgendW.Models;
using Newtonsoft.Json;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static AgendW.Services.AuthenticationService;
using AgendW.Views;

namespace AgendW.ViewModels
{
    public class AtendimentoViewModel : INotifyPropertyChanged
    {
        private static readonly string BaseUrl = "http://192.168.8.106:5000/api/";

        
        public AtendimentoViewModel()
        {

            CurrentAtendimento = new Atendimento();
            CurrentAtendimento.DataDesejadaAtendimento = DateTime.Now;
            SaveAtendimentoCommand = new Command<Atendimento>(async (atendimento) => await SaveAtendimento(atendimento));
            GetAtendimentoCommand = new Command(async () => await GetAtendimentos());
            DeleteAtendimentoCommand = new Command<int>(async (id) => await DeleteAtendimento(id));
            UpdateAtendimentoCommand = new Command<Atendimento>(async (atendimento) => await UpdateAtendimento(atendimento));
        }
        public ICommand SaveAtendimentoCommand { get; set; }
        public ICommand GetAtendimentoCommand { get; set; }
        public ICommand DeleteAtendimentoCommand { get; set; }
        public ICommand UpdateAtendimentoCommand { get; set; }

        public INavigation Navigation { get; set; }

        public void InitializeWithUserData()
        {
            LoadUserData();
        }

        private async void LoadUserData()
        {
            string userJson = await SecureStorage.GetAsync("app.user");
            if (!string.IsNullOrEmpty(userJson))
            {
                UserTokenViewModel userToken = JsonConvert.DeserializeObject<UserTokenViewModel>(userJson);
                NomeCliente = userToken.Nome;
                EmailCliente = userToken.Email;

            }
        }

        private int id;
        private string tipoAtendimento;
        private string nomeCliente;
        private string emailCliente;
        private string telCliente;
        private string placaCarro;
        private string marcaCarro;
        private string modeloCarro;
        private DateTime dataDesejadaAtendimento;
        private bool pneus;
        private bool freios;
        private bool suspensao;
        private bool escapamento;
        private bool trocaOleo;
        private bool revisaoPadrao;
        private bool alinhamentoEBalanceamento;
        private bool mecanicaLeve;
        private string status;
        private string motivoCancelamento;
        private string unidadeAtendimento;
        private string descricaoProblema;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private Atendimento _currentAtendimento;
        public Atendimento CurrentAtendimento
        {
            get { return _currentAtendimento; }
            set
            {
                _currentAtendimento = value;
                OnPropertyChanged(nameof(CurrentAtendimento));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string TipoAtendimento
        {
            get { return tipoAtendimento; }
            set
            {
                tipoAtendimento = value;
                OnPropertyChanged(nameof(TipoAtendimento));
            }
        }
        public string NomeCliente
        {
            get { return nomeCliente; }
            set
            {
                nomeCliente = value;
                OnPropertyChanged(nameof(NomeCliente));
            }
        }
        public string EmailCliente
        {
            get { return emailCliente; }
            set
            {
                emailCliente = value;
                OnPropertyChanged(nameof(EmailCliente));
            }
        }
        public string TelCliente
        {
            get { return telCliente; }
            set
            {
                telCliente = value;
                OnPropertyChanged(nameof(TelCliente));
            }
        }
        public string PlacaCarro
        {
            get { return placaCarro; }
            set
            {
                placaCarro = value;
                OnPropertyChanged(nameof(PlacaCarro));
            }
        }
        public string MarcaCarro
        {
            get { return marcaCarro; }
            set
            {
                marcaCarro = value;
                OnPropertyChanged(nameof(MarcaCarro));
            }
        }
        public string ModeloCarro
        {
            get { return modeloCarro; }
            set
            {
                modeloCarro = value;
                OnPropertyChanged(nameof(ModeloCarro));
            }
        }
        public DateTime DataDesejadaAtendimento
        {
            get { return dataDesejadaAtendimento; }
            set
            {
                dataDesejadaAtendimento = DateTime.Now;
                OnPropertyChanged(nameof(DataDesejadaAtendimento));
            }
        }

        public bool Pneus
        {
            get { return pneus; }
            set
            {
                pneus = value;
                OnPropertyChanged(nameof(Pneus));
            }
        }

        public bool Freios
        {
            get { return freios; }
            set
            {
                freios = value;
                OnPropertyChanged(nameof(Freios));
            }
        }

        public bool Suspensao
        {
            get { return suspensao; }
            set
            {
                suspensao = value;
                OnPropertyChanged(nameof(Suspensao));
            }
        }

        public bool Escapamento
        {
            get { return escapamento; }
            set
            {
                escapamento = value;
                OnPropertyChanged(nameof(Escapamento));
            }
        }

        public bool TrocaOleo
        {
            get { return trocaOleo; }
            set
            {
                trocaOleo = value;
                OnPropertyChanged(nameof(TrocaOleo));
            }
        }

        public bool RevisaoPadrao
        {
            get { return revisaoPadrao; }
            set
            {
                revisaoPadrao = value;
                OnPropertyChanged(nameof(RevisaoPadrao));
            }
        }

        public bool AlinhamentoEBalanceamento
        {
            get { return alinhamentoEBalanceamento; }
            set
            {
                alinhamentoEBalanceamento = value;
                OnPropertyChanged(nameof(AlinhamentoEBalanceamento));
            }
        }

        public bool MecanicaLeve
        {
            get { return mecanicaLeve; }
            set
            {
                mecanicaLeve = value;
                OnPropertyChanged(nameof(MecanicaLeve));
            }
        }

        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        public string? MotivoCancelamento
        {
            get { return motivoCancelamento; }
            set
            {
                motivoCancelamento = value;
                OnPropertyChanged(nameof(MotivoCancelamento));
            }
        }

        private TimeSpan _horaAtendimento;

        public TimeSpan HoraAtendimento
        {
            get => _horaAtendimento;
            set
            {
                if (_horaAtendimento != value)
                {
                    _horaAtendimento = value;
                    OnPropertyChanged(nameof(HoraAtendimento));
                }
            }
        }


        public string UnidadeAtendimento
        {
            get { return unidadeAtendimento; }
            set
            {
                unidadeAtendimento = value;
                OnPropertyChanged(nameof(UnidadeAtendimento));
            }
        }

        public string DescricaoProblema
        {
            get { return descricaoProblema; }
            set
            {
                descricaoProblema = value;
                OnPropertyChanged(nameof(DescricaoProblema));
            }
        }

        private Atendimento _atendimento;
        public Atendimento Atendimento
        {
            get { return _atendimento; }
            set
            {
                if (_atendimento != value)
                {
                    _atendimento = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<Atendimento> _atendimentosList;

        public ObservableCollection<Atendimento> AtendimentosList
        {
            get { return _atendimentosList; }
            set
            {
                _atendimentosList = value;
                OnPropertyChanged();
            }
        }

        



        public async Task LoadAtendimento(int id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var json = await client.GetStringAsync($"http://localhost:5000/api/atendimentos/{id}");
                    var atendimento = JsonConvert.DeserializeObject<Atendimento>(json);
                    Atendimento = atendimento;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task GetAtendimentos()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var json = await client.GetStringAsync($"http://192.168.8.106:5000/api/atendimentos");
                    var atendimentos = JsonConvert.DeserializeObject<List<Atendimento>>(json);
                    AtendimentosList = new ObservableCollection<Atendimento>(atendimentos);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        private readonly HttpClient _client = new HttpClient();

        public async Task SaveAtendimento(Atendimento atendimento)
        {
            try
            {

                //concatenate date and hour
                DateTime dataAtendimento = atendimento.DataDesejadaAtendimento; // your DateTime value
                TimeSpan horaDeAtendimento = HoraAtendimento; // your TimeOnly value

                DateTime combinedDateTime = dataAtendimento.Add(horaDeAtendimento);

                var settings = new JsonSerializerSettings
                {
                    DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                    DateFormatString = "yyyy-MM-ddTHH:mm:ss.fffZ"
                };

                atendimento.DataDesejadaAtendimento = combinedDateTime;
                atendimento.TipoAtendimento = "Agendamento";
                atendimento.Status = "Aguardando atendimento";
                var serializedAtendimento = JsonConvert.SerializeObject(atendimento, settings);
                var content = new StringContent(serializedAtendimento, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync(BaseUrl + "atendimentos", content);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var newAtendimento = JsonConvert.DeserializeObject<Atendimento>(result);
                    await Navigation.PushAsync(new SuccessPage(newAtendimento));
                    
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateAtendimento(Atendimento atendimento)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var serializedAtendimento = JsonConvert.SerializeObject(atendimento);
                    var content = new StringContent(serializedAtendimento, Encoding.UTF8, "application/json");

                    // Since it's an update, you likely need to include the ID in the URL.
                    var response = await client.PutAsync($"http://192.168.8.106:5000/api/atendimentos/{atendimento.Id}", content);

                    // Check if the response indicates success.
                    if (!response.IsSuccessStatusCode)
                    {
                        // Here you can get more details about the error. 
                        // Note: Don't always send the entire content of the error message to the end user; it might contain sensitive details.
                        var errorContent = await response.Content.ReadAsStringAsync();
                        throw new Exception($"Server responded with error {response.StatusCode}: {errorContent}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred when updating the atendimento: {ex.Message}");
            }
        }

        public async Task DeleteAtendimento(int id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    // Call the API endpoint with the specific ID to delete the Atendimento
                    var response = await client.DeleteAsync($"http://192.168.8.106:5000/api/atendimentos/{id}");

                    // Check if the response indicates success.
                    if (!response.IsSuccessStatusCode)
                    {
                        // Here you can get more details about the error. 
                        // Note: Don't always send the entire content of the error message to the end user; it might contain sensitive details.
                        var errorContent = await response.Content.ReadAsStringAsync();
                        throw new Exception($"Server responded with error {response.StatusCode}: {errorContent}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred when deleting the atendimento with ID {id}: {ex.Message}");
            }
        }


    }
}
