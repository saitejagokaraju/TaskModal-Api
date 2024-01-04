using Microsoft.EntityFrameworkCore;
using Proventech.Radio.Core.Contracts.IRepositories;

namespace Proventech.Radio.Infrastructure.Repositories
{
    // Definition of the RepositoryRadio class, implementing IRepositoryRadio.
    public class RepositoryRadio : IRepositoryRadio
    {
        // Private field to hold an instance of the Entity Framework Core context.
        private readonly Context _context;

        // Constructor that accepts an instance of the context through dependency injection.
        public RepositoryRadio(Context context)
        {
            _context = context;
        }

        // Implementation of IRepositoryRadio method to get all dates from the database.
        public IEnumerable<DateModel> GetAllDates()
        {
            return _context.DatesTable.ToList();
        }

        // Implementation of IRepositoryRadio method to get all weekdays from the database.
        public IEnumerable<WeekdayModel> GetAllWeekdays()
        {
            return _context.WeekdaysTable.ToList();
        }

        // Implementation of IRepositoryRadio method to get all dates asynchronously from the database.
        public async Task<IEnumerable<DateModel>> GetAllDatesAsync()
        {
            return await _context.DatesTable.ToListAsync();
        }

        // Implementation of IRepositoryRadio method to get all weekdays asynchronously from the database.
        public async Task<IEnumerable<WeekdayModel>> GetAllWeekdaysAsync()
        {
            return await _context.WeekdaysTable.ToListAsync();
        }
    }
}