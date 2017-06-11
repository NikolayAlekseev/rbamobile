using Rbauto.Services;
using Rbauto.ViewModels.Manager;
using System;
using Xamarin.Forms;

namespace Rbauto.Views
{
    public partial class ManagerInfoPage : ContentPage
    {
        public ManagerInfoPage()
        {
            InitializeComponent();

            var model = BindingContext as ManagerInfoViewModel;
            model.HasBackButton = AccountStore.LoadAccount() != null;
        }

        public const string AccountChangedMessage = "AccountChanged";

        private void Inn_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = (Entry)sender;

            if (entry.Text?.Length > 12)
            {
                entry.TextChanged -= Inn_OnTextChanged;
                entry.Text = e.OldTextValue;
                entry.TextChanged += Inn_OnTextChanged;
            }
        }

        async void NextButton_OnClicked(object sender, EventArgs e)
        {
            var model = BindingContext as ManagerInfoViewModel;
            if (model == null) return;
            if (string.IsNullOrEmpty(model.Inn))
            {
                await DisplayAlert(null, "Необходимо ввести ИНН", "Закрыть");
                Inn.Focus();
                return;
            }
            if (!model.IsValidInn)
            {
                await DisplayAlert(null, "Введён некорректный ИНН", "Закрыть");
                Inn.Focus();
                return;
            }

            var account = await model.FindAccountAsync();

            if (account == null)
            {
                await DisplayAlert(null, "Клиент с указанным ИНН не найден", "Закрыть");
                Inn.Focus();
                return;
            }

            AccountStore.SaveAccount(account);

            MessagingCenter.Send(this, AccountChangedMessage);

            await Navigation.PopAsync();
        }

        private void ClearButton_OnClicked(object sender, EventArgs e)
        {
            var model = BindingContext as ManagerInfoViewModel;
            if (model == null) return;
            model.Inn = string.Empty;
            Inn.Focus();
        }

        protected override bool OnBackButtonPressed()
        {
            // Отключаем кнопку назад если нет сохраненного менеджера
            return (BindingContext as ManagerInfoViewModel).HasBackButton ? base.OnBackButtonPressed() : true;
        }
    }
}
