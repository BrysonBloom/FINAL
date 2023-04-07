namespace FINAL.Services
{
    public class VaultsService
    {
        private readonly VaultsRepository _repo;
        private readonly KeepsService _keepsService;



        public VaultsService(VaultsRepository repo, KeepsService keepsService)
        {
            _repo = repo;
            _keepsService = keepsService;


        }

        internal List<Vault> getVaults(string id)
        {
            List<Vault> vaults = _repo.getVaults();

            foreach (Vault vault in vaults)
            {
                if (vault.CreatorId != id)
                {
                    if (vault.IsPrivate == true) vaults.Remove(vault);
                }
            }

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
            if (vault == null) throw new Exception("no vault exists with id " + id);
            if (vault.CreatorId != userId && vault.IsPrivate == true) throw new Exception("no vault exists with id " + id);
            return vault;
        }

        internal Vault updateVault(int id, Vault updateData)
        {
            Vault vault = _repo.getVaultById(id);
            if (vault != null && vault.CreatorId == updateData.CreatorId)
            {
                if (updateData.Name != null) vault.Name = updateData.Name;
                if (updateData.Description != null) vault.Description = updateData.Description;
                // Vault.Name = updateData.Name == null ? updateData.Name : Vault.Name;
                // Vault.Description = updateData.Description == null ? updateData.Description : Vault.Description;
                _repo.updateVault(vault);
            }
            else
            {
                throw new InvalidOperationException("Could not update Vault " + id);
            }
            return vault;
        }

        internal Vault deleteVault(int id, string userId)
        {
            Vault Vault = _repo.getVaultById(id);
            if (Vault != null && Vault.CreatorId == userId)
            {
                _repo.deleteVault(id);
            }
            else throw new Exception("Vault not deleted with id " + id);
            return Vault;
        }

        internal List<Vault> getProfileVaults(string id, string userId)
        {
            List<Vault> vaults = _repo.getProfileVaults(id);
            if (id != userId)
            {

                vaults.RemoveAll(v => v.IsPrivate == true);
                // foreach (Vault vault in vaults)
                // {
                //     if (vault.IsPrivate == true) vaults.Remove(vault);
                // }
            }
            return vaults;

        }

        // internal List<KeepWithVaultKeepId> getKeepsInVault(int id)
        // {
        //     List<VaultKeep> vaultKeeps = _vaultKeepsService.getVaultKeepsById(id);

        //     List<KeepWithVaultKeepId> keeps = _keepsService.getKeepsInVault(vaultKeeps);
        //     Vault vault = this.getVaultById(id, vaultKeeps[0].CreatorId);
        //     return keeps;
        // }
    }
}