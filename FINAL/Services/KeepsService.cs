namespace FINAL.Services
{
    public class KeepsService
    {
        
        private readonly KeepsRepository _repo;

        public KeepsService(KeepsRepository repo)
        {
            _repo = repo;
        }

        internal List<Keep> getKeeps()
        {
            List<Keep> keeps = _repo.getKeeps();
            return keeps;
        }
    }
}