using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class DataManager
    {
        private static DataContext _context;

        public DataManager(Settings settings)
        {
            if (_context == null)
            {
                var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
                var dbSettings = settings.GetDbSettings();
                optionsBuilder.UseSqlServer(dbSettings);
                _context = new DataContext(optionsBuilder.Options);
                _context.Database.Migrate();
            }
        }

        public async Task<List<TestDataEntity>> GetAllTestDataAsync()
        {
            return await _context.Data.ToListAsync();
        }

        public async Task<TestDataEntity> GetTestDataByIdAsync(int id)
        {
            return await _context.Data.FindAsync(id);
        }

        public async Task AddTestDataAsync(TestDataEntity data)
        {
            _context.Data.Add(data);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTestDataAsync(TestDataEntity data)
        {
            _context.Entry(data).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTestDataAsync(int id)
        {
            var data = await GetTestDataByIdAsync(id);
            if (data != null)
            {
                _context.Data.Remove(data);
                await _context.SaveChangesAsync();
            }
        }
    }
}
