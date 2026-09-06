namespace URLShorteningService.Models
{
    public class Url
    {
        public Guid Id {  get; set; }
        public string OriginalUrl { get; set; }
        public string ShortCode { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
