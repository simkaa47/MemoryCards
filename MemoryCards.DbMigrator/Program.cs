using MemoryCards.Persistance.Services;

namespace MemoryCards.DbMigrator
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Migrator running..");

            using (var context = new ApplicationContext())
            {
                var all = context.GameCommonSettingses.ToList();
            }
        }
    }
}