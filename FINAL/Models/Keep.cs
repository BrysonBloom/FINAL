namespace FINAL.Models
{
    public class Keep
    {
        public int Id { get; set; }
        public string CreatorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public int views { get; set; }
        public int Kept { get; set; }
        public Profile creator { get; set; }
    }
}