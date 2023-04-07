namespace FINAL.Models
{
    public class Keep
    {
        public int Id { get; set; }
        public string CreatorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public int Views { get; set; }
        public int Kept { get; set; }
        public Profile Creator { get; set; }
    }

    public class KeepWithVaultKeepId : Keep
    {
        public int VaultKeepId { get; set; }
        public KeepWithVaultKeepId(Keep k)
        {
            Id = k.Id;
            CreatorId = k.CreatorId;
            Name = k.Name;
            Description = k.Description;
            Img = k.Img;
            Views = k.Views;
            Kept = k.Kept;
            Creator = k.Creator;
        }
    }


}