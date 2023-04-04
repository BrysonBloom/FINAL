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
            if (keep != null && keep.CreatorId == userId){
                _repo.deleteKeep(id);
            }else throw new Exception("Keep not deleted with id " + id);
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

        internal Keep updateKeep(int id, Keep updateData)
        {
            Keep keep = _repo.getKeepById(id);
            if (keep != null && keep.CreatorId == updateData.CreatorId)
            {
                if (updateData.Name != null)keep.Name = updateData.Name;
                if (updateData.Description != null)keep.Description = updateData.Description;
                // keep.Name = updateData.Name == null ? updateData.Name : keep.Name;
                // keep.Description = updateData.Description == null ? updateData.Description : keep.Description;
                _repo.updateKeep(keep);
            }else {
                throw new InvalidOperationException("Could not update keep " + id);
            }
            return keep;
        }
    }
}