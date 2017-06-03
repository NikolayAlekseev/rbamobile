namespace Rbauto.Models
{
    public class ContactItem : BaseDataObject
    {
        public string Name { get; set; }
        public string Phones { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Schedule { get; set; }
        public string MapUrl { get; set; }
        public string MapDescription { get; set; }
    }
}
