using App.Repository.Entities;


namespace App.Repository.Repositories
{
    public class RemindersRepository(AppDbContext context) : GenericRepository<Reminder>(context), IRemindersRepository
    {
    }
}
