namespace FINAL.Repositories
{
    public class KeepsRepository
    {
        private readonly IDbConnection _db;
        public KeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Keep createKeep(Keep keepData)
        {
            string sql = @"insert into keeps(
                creatorId, name, description, img
            )
            values(@creatorId, @name, @description, @img);
            select last_insert_id();";
            int id = _db.ExecuteScalar<int>(sql, keepData);
            keepData.Id = id;
            return keepData;
        }

        internal void deleteKeep(int id)
        {
            string sql = @"delete from keeps where id = @id";
            _db.Execute(sql, new { id} );
        }

        internal Keep getKeepById(int id)
        {
            string sql = @"select * from keeps join accounts creator on keeps.creatorId = creator.id where keeps.id = @id";
            Keep keep = _db.Query<Keep, Profile, Keep>(sql, (keep, creator)=> 
            {
                keep.Creator = creator;
                return keep;
            }, new {id}).FirstOrDefault();
            return keep;
        }

        internal List<Keep> getKeeps()
        {
            string sql = @"SELECT * FROM keeps join accounts creator on keeps.creatorId = creator.id";
            List<Keep> keeps = _db.Query<Keep, Profile, Keep>(sql, (keeps, creator) => 
            {
                keeps.Creator = creator;
                return keeps;
            }).ToList();
            return keeps;
        }

        internal List<Keep> getProfileKeeps(string id)
        {
            string sql = "SELECT * FROM keeps join accounts creator on keeps.creatorId = creator.id WHERE creatorId = @id";
            List<Keep> keeps = _db.Query<Keep, Profile, Keep>(sql, (keeps, creator) => 
            {
                keeps.Creator = creator;
                return keeps;
            }, new {id}).ToList();
            return keeps;
        }

        internal void updateKeep(Keep keep)
        {
            string sql = @"UPDATE keeps SET 
            name = @Name,
            description = @Description, 
            views = @Views 

            WHERE id = @Id;";
            int rows = _db.Execute(sql, keep);
            
        }
    }
}