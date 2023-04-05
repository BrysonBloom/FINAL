namespace FINAL.Repositories
{
    public class ProfilesRepository
    {
        private readonly IDbConnection _db;

        public ProfilesRepository(IDbConnection db)
        {
        _db = db;
        }
        internal Profile getProfile(string id)
        {
            string sql = @"SELECT * from accounts where id = @id";
            Profile profile = _db.QueryFirstOrDefault<Profile>(sql, new { id });
            return profile;
        }
    }
}