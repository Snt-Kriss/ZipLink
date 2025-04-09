namespace ZipLink.Client.Data.ViewModel
{
    //Only properties we use to the view
    public class GetUrlVM
    {
        public int Id { get; set; }
        public string OriginalLink { get; set; }
        public string ShortLink { get; set; }
        public int NumberOfClicks { get; set; }
        public int? UserId { get; set; }
    }
}
