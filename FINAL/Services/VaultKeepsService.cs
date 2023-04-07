namespace FINAL.Services
{
    public class VaultKeepsService
    {
        private readonly VaultKeepsRepository _repo;
        private readonly KeepsService _keepsService;
        private readonly VaultsService _vaultsService;
        public VaultKeepsService(VaultKeepsRepository vaultKeepsRepository, KeepsService keepsService, VaultsService vaultsService)
        {
            _repo = vaultKeepsRepository;
            _keepsService = keepsService;
            _vaultsService = vaultsService;
        }

        internal VaultKeep createVaultKeep(VaultKeep newVaultKeep)
        {
            Vault vault = _vaultsService.getVaultById(newVaultKeep.VaultId, newVaultKeep.CreatorId);
            if (vault.CreatorId != newVaultKeep.CreatorId)
            {
                throw new Exception("this is not your Vault");
            }
            VaultKeep vaultKeep = _repo.createVaultKeep(newVaultKeep);
            _keepsService.incrementKeepKept(vaultKeep.KeepId, true);
            return vaultKeep;
        }

        internal VaultKeep deleteVaultKeep(int id, string userId)
        {
            VaultKeep VaultKeep = _repo.getVaultKeepById(id);
            if (VaultKeep.CreatorId == userId)
            {
                _repo.deleteVaultKeep(id);
            }
            else throw new Exception("VaultKeep not deleted with id " + id);
            return VaultKeep;
        }

        internal List<VaultKeep> getVaultKeepsById(int id)
        {
            List<VaultKeep> vaultKeeps = _repo.getVaultKeepByVaultId(id);
            if (vaultKeeps == null)
            {
                throw new InvalidOperationException("VaultKeep does not exist");
            }
            return vaultKeeps;

        }
        internal List<KeepWithVaultKeepId> getKeepsInVault(int id, string userId)
        {
            List<VaultKeep> vaultKeeps = this.getVaultKeepsById(id);


            List<KeepWithVaultKeepId> keeps = _keepsService.getKeepsInVault(vaultKeeps);
            // if (keeps.Count > 0)
            // {
            string ownerId = "";
            if (vaultKeeps.Count > 0)
            {
                ownerId = vaultKeeps.First().CreatorId;
            }
            else
            {
                ownerId = "";

            }
            Vault vault = _vaultsService.getVaultById(id, userId);
            return keeps;
            // }

            // throw new InvalidOperationException("Could not find vault");

        }
    }
}