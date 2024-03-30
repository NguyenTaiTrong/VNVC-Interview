using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Server.DAL;
using Server.DAL.Entity;
using Server.DTO;
using Dapper;

namespace Server.Repositories
{
    public interface IBetRepository
    {
        int save(Bet bet);
        List<EventWithBetAndUser> get();
    }
    public class BetRepository : IBetRepository
    {
        readonly DatabaseContext _databaseContext;
        private IDbConnection _dbConnection;
        public BetRepository(DatabaseContext databaseContext, IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
            _databaseContext = databaseContext;
        }
        public int save(Bet bet)
        {
            var userIdParam = new SqlParameter("@user_id", bet.UserId);
            var eventIdParam = new SqlParameter("@event_id", bet.EventId);
            var betNumberParam = new SqlParameter("@bet_number", bet.BetNumber);
            var createdAtParam = new SqlParameter("@createdAt", bet.CreatedAt);
            var createdByParam = new SqlParameter("@createdBy", bet.UserId);
            var betResultParam = new SqlParameter("@betResultId", bet.BetResultId);

            return _databaseContext.Database.ExecuteSqlRaw("EXEC SaveBet @user_id, @event_id, @bet_number, @createdAt, @createdBy, @betResultId",
                userIdParam, eventIdParam, betNumberParam, createdAtParam, createdByParam, betResultParam);

        }

        public List<EventWithBetAndUser> get()
        {
            var result = _dbConnection.Query<EventWithBetAndUser>("GetEventsWithBetsAndUsers", commandType: CommandType.StoredProcedure).ToList();
            return result;
        }
    }
}