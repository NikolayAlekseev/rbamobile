using Rbauto.Models;

namespace Rbauto.ViewModels
{
    public class ContactDetailViewModel : BaseViewModel
    {
        public ContactItem ContactItem { get; set; }
        public ContactDetailViewModel(ContactItem contactItem = null)
        {
            Title = contactItem.Name;
            ContactItem = contactItem;
        }

        public bool MapExist => !string.IsNullOrEmpty(ContactItem.MapUrl);
    }
}