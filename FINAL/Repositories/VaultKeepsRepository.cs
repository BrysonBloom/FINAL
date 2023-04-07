namespace FINAL.Repositories
{
    public class VaultKeepsRepository
    {

        private readonly IDbConnection _db;

        public VaultKeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal VaultKeep createVaultKeep(VaultKeep newVaultKeep)
        {
            string sql = @"insert into vaultKeeps (vaultId, keepId, creatorId) 
            values(@vaultId, @keepId, @creatorId);
            select last_insert_id();";
            int id = _db.ExecuteScalar<int>(sql, newVaultKeep);
            newVaultKeep.Id = id;
            return newVaultKeep;
        }

        internal void deleteVaultKeep(int id)
        {
            string sql = "DELETE FROM vaultKeeps WHERE id = @id;";
            _db.Execute(sql, new { id });
        }

        internal VaultKeep getVaultKeepById(int id)
        {
            string sql = "SELECT * FROM vaultKeeps WHERE id = @id";
            VaultKeep vaultKeep = _db.Query<VaultKeep>(sql, new { id }).FirstOrDefault();
            return vaultKeep;
        }

        internal List<VaultKeep> getVaultKeepByVaultId(int id)
        {
            string sql = "SELECT * from vaultKeeps WHERE vaultId = @id";
            List<VaultKeep> vaultKeeps = _db.Query<VaultKeep>(sql, new { id }).ToList();
            return vaultKeeps;
        }
    }
}