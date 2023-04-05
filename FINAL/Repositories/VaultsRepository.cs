namespace FINAL.Repositories
{
    public class VaultsRepository
    {

        private readonly IDbConnection _db;
        public VaultsRepository(IDbConnection db)
        {
            _db = db;
        }
        internal List<Vault> getVaults()
        {
            string sql = @"SELECT * FROM vaults join accounts creator on vaults.creatorId = creator.id";
            List<Vault> vaults = _db.Query<Vault, Profile, Vault>(sql, (vaults, creator) => 
            {
                vaults.Creator = creator;
                return vaults;
            }).ToList();
            return vaults;
        }

        internal Vault createVault(Vault vaultData)
        {
            string sql = @"insert into vaults(
                creatorId, name, description, img, isPrivate
            )
            values(@CreatorId, @Name, @Description, @Img, @IsPrivate);
            select last_insert_id();";
            int id = _db.ExecuteScalar<int>(sql, vaultData);
            vaultData.Id = id;
            return vaultData;
        }

        internal Vault getVaultById(int id)
        {
            string sql = @"select * from vaults join accounts creator on vaults.creatorId = creator.id where vaults.id = @id";
            Vault vault = _db.Query<Vault, Profile, Vault>(sql, (vault, creator)=> 
            {
                vault.Creator = creator;
                return vault;
            }, new {id}).FirstOrDefault();
            return vault;
        }

        internal void updateVault(Vault vault)
        {
            string sql = @"UPDATE vaults SET 
            name = @Name,
            description = @Description 

            WHERE id = @Id;";
            int rows = _db.Execute(sql, vault);
        }

        internal void deleteVault(int id)
        {
            string sql = @"delete from vaults where id = @id";
            _db.Execute(sql, new { id} );
        }

        internal List<Vault> getProfileVaults(string id)
        {
            string sql = "SELECT * FROM vaults join accounts creator on vaults.creatorId = creator.id WHERE creatorId = @id";
            List<Vault> Vaults = _db.Query<Vault, Profile, Vault>(sql, (Vaults, creator) => 
            {
                Vaults.Creator = creator;
                return Vaults;
            }, new {id}).ToList();
            return Vaults;
        }
    }
}