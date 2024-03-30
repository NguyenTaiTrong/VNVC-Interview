using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Server.DAL;
using Server.DAL.Entity;

namespace Server.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAll();
        IEnumerable<User> GetOneByPhone(string phone);
        User GetOneById(int userId);
        int Save(User user);

    }
    public class UserRepository : IUserRepository
    {
        readonly DatabaseContext _databaseContext;
        public UserRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<User> GetAll()
        {
            return _databaseContext.Users.ToList();
        }

        public int Save(User user)
        {
            // _databaseContext.Users.Add(user);
            // _databaseContext.SaveChanges();
            var userNameParameter = new SqlParameter("@UserName", user.UserName);
            var phoneParameter = new SqlParameter("@Phone", user.Phone);
            var birthDayParameter = new SqlParameter("@BirthDay", user.BirthDay);
            var createdByParameter = new SqlParameter("@CreatedBy", DBNull.Value); // If createdBy is not provided
            var createdAtParam = new SqlParameter("@CreatedAt", user.CreatedAt);

            var newUser = _databaseContext.Database.ExecuteSqlRaw("EXEC SaveUser @UserName, @Phone, @BirthDay, @CreatedAt, @CreatedBy",
            userNameParameter, phoneParameter, birthDayParameter, createdAtParam, createdByParameter );
            return newUser;
        }

        public User GetOneById(int userId)
        {
            return _databaseContext.Users.Where(usr => usr.Id == userId).FirstOrDefault();
        }

        public IEnumerable<User> GetOneByPhone(string phoneNumber) {
            return _databaseContext.Users.FromSqlRaw("EXECUTE GetUserByPhoneNumber @phoneNumber ", new SqlParameter("@phoneNumber", phoneNumber));
        }
    }
}