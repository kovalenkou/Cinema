using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject
{
    /// <summary>
    /// Класс для таблицы схемы показов фильмов
    /// </summary>
    [TableAttribute("Schema")]
    class Schema
    {
        /// <summary>
        /// Свойство для идентификатора схемы, первичный ключ
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Свойство для столбца с Идентификатором зала, в котором находится кресло
        /// </summary>
        public int HallId { get; set; }
        [ForeignKey("HallId")]
        public Hall Hall { get; set; } // свойство связки с таблицей залов с первичным ключем
        /// <summary>
        /// Свойство для столбца с идентификатором Сеанса
        /// </summary>
        public int SessionId { get; set; }
        [ForeignKey("SessionId")]
        public Session Session { get; set; } // свойство связки с таблицей сеансов с первичным ключем
        /// <summary>
        /// Свойство для идентификатора фильма
        /// </summary>
        public int FilmId { get; set; }
        [ForeignKey("FilmId")]
        public Film Film { get; set; } // свойство связки с таблицей фильмов с первичным ключем
    }
}