using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject
{
    /// <summary>
    /// Класс для описания подключения к базе данных и получения данных из таблиц
    /// </summary>
    class CinemaDataContext : DbContext
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public CinemaDataContext()
            : base("DBCinema")
        { }

        /// <summary>
        /// Свойство для работы с таблицей типов залов
        /// </summary>
        public DbSet<Hall> Halls { get; set; }
        /// <summary>
        /// Свойство для работы с таблицей мест в залах
        /// </summary>
        public DbSet<Location> Locations { get; set; }
        /// <summary>
        /// Свойство для работы с таблицей типов кресел
        /// </summary>
        public DbSet<ChairType> ChairTypes { get; set; }
        /// <summary>
        /// Свойство для работы с таблицей типов сеансов
        /// </summary>
        public DbSet<Session> Sessions { get; set; }
        /// <summary>
        /// Свойство для работы с таблицей фильмов
        /// </summary>
        public DbSet<Film> Films { get; set; }
        /// <summary>
        /// Свойство для работы с таблицей цен на билеты
        /// </summary>
        public DbSet<Ticket> Tickets { get; set; }
        /// <summary>
        /// Свойство для работы с таблицей схемы показов фильмов
        /// </summary>
        public DbSet<Schema> Schemas { get; set; }
        /// <summary>
        /// Своййство для работы с таблицей продаж билетов
        /// </summary>
        public DbSet<SalesRep> SalesReps { get; set; }

    }
}
