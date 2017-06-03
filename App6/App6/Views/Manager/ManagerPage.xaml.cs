using Rbauto.Models;
using Rbauto.Services;
using Rbauto.ViewModels.Manager;
using Xamarin.Forms;

namespace Rbauto.Views
{
    public partial class ManagerPage : ContentPage
    {
        public ManagerPage()
        {
            InitializeComponent();

            var model = BindingContext as ManagerViewModel;
            if (!model.HasManager)
            {
                ChangeCompany();
            }
        }

        void ChangeCompany_Activated(object sender, System.EventArgs e)
        {
            ChangeCompany();
        }

        private void ChangeCompany()
        {
            MessagingCenter.Subscribe<ManagerInfoPage>(this, ManagerInfoPage.AccountChangedMessage, (page) =>
            {
                (BindingContext as ManagerViewModel)?.RefreshData();
            });
            Navigation.PushAsync(new ManagerInfoPage());
            MessagingCenter.Unsubscribe<ManagerPage>(this, ManagerInfoPage.AccountChangedMessage);
        }

        async void ClearCompany_Activated(object sender, System.EventArgs e)
        {
            AccountStore.ClearAccount();
            (BindingContext as ManagerViewModel)?.RefreshData();
            ChangeCompany();
        }

        protected override bool OnBackButtonPressed()
        {
            // Отключаем кнопку назад если нет сохраненного менеджера
            return (BindingContext as ManagerViewModel).HasManager ? base.OnBackButtonPressed() : true;
        }
    }
}
