namespace Rbauto.Models
{
    public class NewsItem : BaseDataObject
    {
        public string NewsDate { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string MainImageUrl { get; set; }
        public double MainImageHeight { get; set; }
        public string[] Rows { get; set; }
        public string[] AdditionalImagesUrl { get; set; }

        public NewsItem()
        {
            Rows = new string[0];
            AdditionalImagesUrl = new string[0];
        }
    }
}