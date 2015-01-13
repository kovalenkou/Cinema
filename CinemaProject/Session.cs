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
    /// Класс для работы с таблицей сеансов
    /// </summary>
    [TableAttribute("Session")]
    class Session
    {
        /// <summary>
        /// Свойство для столбца идентификатора сеанса, первичный ключ
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Свойство для столбца наименования сеанса
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Свойство для столбца с временем начала сеанса
        /// </summary>
        public DateTime TimeStart { get; set; }
        /// <summary>
        /// Свойство для столбца с временем окончания сеанса
        /// </summary>
        public DateTime TimeEnd { get; set; }

    }
}
