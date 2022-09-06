namespace LaboBadge.Models
{
    public class UserToken
    {
        public string Token { get; set; }
        public bool IsOwner { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }
        public string  Rule { get; set; }


    }
}
