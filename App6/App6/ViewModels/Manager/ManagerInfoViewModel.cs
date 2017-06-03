using System.Threading.Tasks;
using System.Windows.Input;
using Rbauto.Models;
using Rbauto.Services;
using Xamarin.Forms;

namespace Rbauto.ViewModels.Manager
{
    public class ManagerInfoViewModel : BaseViewModel
    {
        private string _inn;
        

        public ManagerInfoViewModel()
        {
            Title = "Персональный менеджер";

            ManagerFindCommand = new Command(async () => await FindAccountAsync(), () => !InProgress);

            IsControlEnabled = true;
        }

        public string Inn
        {
            get { return _inn; }
            set
            {
                _inn = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsValidInn));
                OnPropertyChanged(nameof(InnColor));
                OnPropertyChanged(nameof(NextButtonBackgroundColor));
                OnPropertyChanged(nameof(NextButtonTextColor));
            }
        }

        public bool InProgress
        {
            get { return _inProgress; }
            set
            {
                _inProgress = value;
                OnPropertyChanged();
                ((Command)ManagerFindCommand).ChangeCanExecute();
                IsControlEnabled = !value;
            }
        }

        public bool IsControlEnabled
        {
            get { return _isControlEnabled; }
            set
            {
                _isControlEnabled = value;
                OnPropertyChanged();
            }
        }

        public bool IsValidInn => InnService.CheckINN(Inn);

        public Color InnColor => IsValidInn ? Color.FromHex("083d69") : Color.Gray;

        public Color NextButtonBackgroundColor => IsValidInn ? Color.FromHex("F0811E") : Color.FromHex("#EFC199");

        public Color NextButtonTextColor => IsValidInn ? Color.White : Color.Black;

        public async Task<AccountEntity> FindAccountAsync()
        {
            InProgress = true;

            var account = await Task.Run(() => CrmApiService.GetAccountByInnAsync(Inn).Result);

            InProgress = false;
            return account;
        }

        public ICommand ManagerFindCommand { get; }

        public bool HasBackButton
        {
            get { return _hasBackButton; }
            set
            {
                _hasBackButton = value;
                OnPropertyChanged();
            }
        }

        private bool _inProgress;
        private bool _isControlEnabled;
        private bool _hasBackButton;
    }
}