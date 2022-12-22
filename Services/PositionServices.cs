using lab6.Database;
using lab6.Data;
using Microsoft.EntityFrameworkCore;

namespace lab6.Services
{
    public class PositionServices
    {
        protected readonly DbConnection _db;
        public PositionServices(DbConnection db)
        {
            _db = db;
        }

        public async Task<List<Position>> GetPositions()
        {

            return await _db.Positions.OrderBy(p => p.Name).ToListAsync();
        }

        public async Task<Position> GetPosition(int id)
        {
            return await _db.Positions.FirstAsync(p => p.Id == id);
        }

        public async Task AddPosition(Position position)
        {
            await _db.Positions.AddAsync(position);
            await _db.SaveChangesAsync();
        }

        public async Task EditPosition(Position position)
        {
            _db.Positions.Update(position);
            await _db.SaveChangesAsync();
        }

        public async Task DeletePosition(Position position)
        {
            _db.Positions.Remove(position);
            await _db.SaveChangesAsync();
        }
    }
}
