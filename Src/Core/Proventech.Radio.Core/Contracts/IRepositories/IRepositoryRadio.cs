using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proventech.Radio.Core.Contracts.IRepositories
{
    public interface IRepositoryRadio
    {
        // Get all dates from the database
        IEnumerable<DateModel> GetAllDates();

        // Get all weekdays from the database
        IEnumerable<WeekdayModel> GetAllWeekdays();

        // Get all dates asynchronously from the database
        Task<IEnumerable<DateModel>> GetAllDatesAsync();

        // Get all weekdays asynchronously from the database
        Task<IEnumerable<WeekdayModel>> GetAllWeekdaysAsync();

    }
}