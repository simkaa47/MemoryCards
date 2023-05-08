using MemoryCards.Persistance.Models;
using Microsoft.EntityFrameworkCore;

namespace MemoryCards.Persistance.Services
{
    public class ApplicationContext:DbContext
    {
        #region Tables
        public DbSet<GameCommonSettings> GameCommonSettingses { get; set; }
        #endregion

        #region Constructors

        //parameterless constructor must be above the others,
        //as it seems that EF Tools migrator just takes the .First() of them

        /// <summary>
        /// Constructor for creating migrations
        /// </summary>
        public ApplicationContext()
        {
            File = Path.Combine("../", "UsedByMigratorOnly1.db3");
            Initialize();
        }

        /// <summary>
		/// Constructor for mobile app
		/// </summary>
		/// <param name="filenameWithPath"></param>
		public ApplicationContext(string filenameWithPath)
        {
            File = filenameWithPath;
            Initialize();
        }

        void Initialize()
        {
            if (!Initialized)
            {
                Initialized = true;

                SQLitePCL.Batteries_V2.Init();

                Database.Migrate();
            }
        }

        public static string File { get; protected set; }
        public static bool Initialized { get; protected set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite($"Filename={File}");
        }

        public void Reload()
        {
            Database.CloseConnection();
            Database.OpenConnection();
        }

    }
}
