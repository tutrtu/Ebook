namespace EbookWEB.Models
{
    public class BookDto
    {
        public int BookId { get; set; }
        public string Title { get; set; } = null!;
        public string? Type { get; set; }
        public int? PubId { get; set; }
        public decimal? Price { get; set; }
        public decimal? Advance { get; set; }
        public decimal? Royalty { get; set; }
        public int? YtdSales { get; set; }
        public string? Notes { get; set; }
        public DateTime? PublishedDate { get; set; }
    }
}
