namespace ASP_NET_CORE_API.Models.DTO
{
    public class SocialMediaRequest
    {
        public int UserId { get; set; }
        public bool IsFacebook { get; set; }
        public bool IsWhatsApp { get; set; }
        public bool IsTwitter { get; set; }
        public string Other { get; set; }
    }
}
