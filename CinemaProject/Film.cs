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
    /// Класс для описания таблицы фильмов
    /// </summary>
    [TableAttribute("Film")]
    class Film
    {
        /// <summary>
        /// Свойство для столбца идентификатора, первичный ключ
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Свойство для столбца наименования фильма
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Свойство для столбца даты начала показа
        /// </summary>
        public DateTime TimeStart { get; set; }
        /// <summary>
        /// Свойство для столбца даты конца показа
        /// </summary>
        public DateTime TimeEnd { get; set; }
        
    }
}
