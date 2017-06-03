using Rbauto.ViewModels;
using Xamarin.Forms;

namespace Rbauto.Views
{
    public partial class ContactDetailPage : ContentPage
    {
        ContactDetailViewModel viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public ContactDetailPage()
        {
            InitializeComponent();
        }

        public ContactDetailPage(ContactDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
    }
}
