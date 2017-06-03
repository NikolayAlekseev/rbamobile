using Rbauto.Extensions;
using Rbauto.Models;
using Rbauto.Services;

namespace Rbauto.ViewModels.Manager
{
    public class ManagerViewModel : BaseViewModel
    {
        private AccountEntity _account;
        
        public ManagerViewModel()
        {
            RefreshData();

            Title = "Персональный менеджер";
        }

        public void RefreshData()
        {
            _account = AccountStore.LoadAccount();
            OnPropertyChanged(nameof(AccountName));
            OnPropertyChanged(nameof(OwnerName));
            OnPropertyChanged(nameof(BranchName));
            OnPropertyChanged(nameof(Communication1));
            OnPropertyChanged(nameof(Communication2));
            OnPropertyChanged(nameof(Communication3));
            OnPropertyChanged(nameof(Communication4));
            OnPropertyChanged(nameof(Communication1IsVisible));
            OnPropertyChanged(nameof(Communication2IsVisible));
            OnPropertyChanged(nameof(Communication3IsVisible));
            OnPropertyChanged(nameof(Communication4IsVisible));
            OnPropertyChanged(nameof(CommunicationType1));
            OnPropertyChanged(nameof(CommunicationType2));
            OnPropertyChanged(nameof(CommunicationType3));
            OnPropertyChanged(nameof(CommunicationType4));
        }

        public string AccountName => _account?.AccountName;
        public string OwnerName => _account?.OwnerName;
        public bool HasManager => _account != null;
        public string BranchName => _account?.BranchName;
        public string Communication1 => _account?.Communication1;
        public string Communication2 => _account?.Communication2;
        public string Communication3 => _account?.Communication3;
        public string Communication4 => _account?.Communication4;
        public bool Communication1IsVisible => !string.IsNullOrEmpty(_account?.Communication1);
        public bool Communication2IsVisible => !string.IsNullOrEmpty(_account?.Communication2);
        public bool Communication3IsVisible => !string.IsNullOrEmpty(_account?.Communication3);
        public bool Communication4IsVisible => !string.IsNullOrEmpty(_account?.Communication4);
        public string CommunicationType1 => _account?.CommunicationCode1.GetCommunicationTypeName();
        public string CommunicationType2 => _account?.CommunicationCode2.GetCommunicationTypeName();
        public string CommunicationType3 => _account?.CommunicationCode3.GetCommunicationTypeName();
        public string CommunicationType4 => _account?.CommunicationCode4.GetCommunicationTypeName();
    }
}