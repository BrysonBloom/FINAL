namespace FINAL.Repositories
{
    public class KeepsRepository
    {
        private readonly IDbConnection _db;
        public KeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<Keep> getKeeps()
        {
            string sql = @"SELECT * FROM Keeps";
            List<Keep> keeps = _db.Query<Keep>(sql).ToList();
            return keeps;
        }
    }
}