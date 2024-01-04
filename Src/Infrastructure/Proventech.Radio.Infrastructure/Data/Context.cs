using Microsoft.EntityFrameworkCore;
using Proventech.Radio.Core.Models;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options) { }

    public DbSet<DateModel> DatesTable { get; set; }

    public DbSet<WeekdayModel> WeekdaysTable { get; set; }

    public DbSet<ModelTaskClass> ModelTasks { get; set; }

    public DbSet<Department>DepartmentTable { get; set; }
    public DbSet<UserModel> User { get; set; }


}
