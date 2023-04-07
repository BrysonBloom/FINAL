namespace FINAL.Services
{
    public class KeepsService
    {

        private readonly KeepsRepository _repo;

        public KeepsService(KeepsRepository repo)
        {
            _repo = repo;
        }

        internal Keep createKeep(Keep keepData, Profile userData)
        {
            Keep keep = _repo.createKeep(keepData);
            keep.Creator = userData;
            return keep;
        }

        internal Keep deleteKeep(int id, string userId)
        {
            Keep keep = _repo.getKeepById(id);
            if (keep != null && keep.CreatorId == userId)
            {
                _repo.deleteKeep(id);
            }
            else throw new Exception("Keep not deleted with id " + id);
            return keep;
        }

        internal Keep getKeepById(int id, string userId)
        {
            Keep keep = _repo.getKeepById(id);
            if (keep == null) throw new Exception("no keep exists with id " + id);
            if (keep.CreatorId != userId)
            {
                keep.Views++;
                _repo.updateKeep(keep);
            }
            return keep;
        }

        internal List<Keep> getKeeps()
        {
            List<Keep> keeps = _repo.getKeeps();
            return keeps;
        }

        internal List<KeepWithVaultKeepId> getKeepsInVault(List<VaultKeep> vaultKeeps)
        {

            List<KeepWithVaultKeepId> keeps = new List<KeepWithVaultKeepId>();
            foreach (VaultKeep vaultKeep in vaultKeeps)
            {
                Keep keep = _repo.getKeepById(vaultKeep.KeepId);
                KeepWithVaultKeepId keepData = new KeepWithVaultKeepId(keep);
                keepData.VaultKeepId = vaultKeep.Id;
                keeps.Add(keepData);
            }
            return keeps;
        }

        internal List<Keep> getProfileKeeps(string id)
        {
            List<Keep> keeps = _repo.getProfileKeeps(id);
            return keeps;
        }

        internal void incrementKeepKept(int keepId, bool isAdded)
        {
            Keep keep = _repo.getKeepById(keepId);
            if (isAdded == true)
            {
                keep.Kept++;
            }
            else
            {
                keep.Kept--;
            }
            _repo.updateKeep(keep);
        }

        internal Keep updateKeep(int id, Keep updateData)
        {
            Keep keep = _repo.getKeepById(id);
            if (keep != null && keep.CreatorId == updateData.CreatorId)
            {
                if (updateData.Name != null) keep.Name = updateData.Name;
                if (updateData.Description != null) keep.Description = updateData.Description;
                // keep.Name = updateData.Name == null ? updateData.Name : keep.Name;
                // keep.Description = updateData.Description == null ? updateData.Description : keep.Description;
                _repo.updateKeep(keep);
            }
            else
            {
                throw new InvalidOperationException("Could not update keep " + id);
            }
            return keep;
        }
    }
}