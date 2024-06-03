namespace EbookAPI.BussinessLogic.DTOs
{
    public class PublisherDto
    {
        public int PubId { get; set; }
        public string PublisherName { get; set; } = null!;
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }

    }
}
