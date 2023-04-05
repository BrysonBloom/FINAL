namespace FINAL.Services
{
    public class ProfilesService
    {

        private readonly ProfilesRepository _repo;

        public ProfilesService(ProfilesRepository profilesRepository)
        {
            _repo = profilesRepository;
        }

        internal Profile getProfile(string id)
        {
            Profile profile = _repo.getProfile(id);
            return profile;
        }

        
    }
}