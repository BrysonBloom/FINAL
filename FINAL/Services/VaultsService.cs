namespace FINAL.Services
{
    public class VaultsService
    {
        private readonly VaultsRepository _repo;

        public VaultsService(VaultsRepository repo)
        {
            _repo = repo;
        }

        internal List<Vault> getVaults()
        {
            List<Vault> vaults = _repo.getVaults();
            return vaults;
        }

        internal Vault createVault(Vault vaultData, Profile userData)
        {
            Vault vault = _repo.createVault(vaultData);
            vault.Creator = userData;
            return vault;
        }

        internal Vault getVaultById(int id, string userId)
        {
            Vault vault = _repo.getVaultById(id);
            if (vault == null) throw new Exception("no keep exists with id " + id);
            return vault;
        }

        internal Vault updateVault(int id, Vault updateData)
        {
            Vault vault = _repo.getVaultById(id);
            if (vault != null && vault.CreatorId == updateData.CreatorId)
            {
                if (updateData.Name != null)vault.Name = updateData.Name;
                if (updateData.Description != null)vault.Description = updateData.Description;
                // Vault.Name = updateData.Name == null ? updateData.Name : Vault.Name;
                // Vault.Description = updateData.Description == null ? updateData.Description : Vault.Description;
                _repo.updateVault(vault);
            }else {
                throw new InvalidOperationException("Could not update Vault " + id);
            }
            return vault;
        }

        internal Vault deleteVault(int id, string userId)
        {
            Vault Vault = _repo.getVaultById(id);
            if (Vault != null && Vault.CreatorId == userId){
                _repo.deleteVault(id);
            }else throw new Exception("Vault not deleted with id " + id);
            return Vault;
        }
    }
}