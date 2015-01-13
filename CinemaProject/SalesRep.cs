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
    /// Класс для описания таблицы продажи билетов
    /// </summary>
    [TableAttribute("SalesRep")]
    class SalesRep
    {
        /// <summary>
        /// Свойство для столбца идентификатора, первичный ключ
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Свойство для столбца Даты билета
        /// </summary>
        public DateTime DateSale { get; set; }
        /// <summary>
        /// Свойство для столбца с идентификатором сеанса
        /// </summary>
        public int SessionId { get; set; }
        [ForeignKey("SessionId")]
        public Session Session { get; set; } // свойство связки с таблицей Сеансов с первичным ключем
        /// <summary>
        /// Свойство для столбца с идентификатором зала, в котором продан билет
        /// </summary>
        public int HallId { get; set; }
        [ForeignKey("HallId")]
        public Hall Hall { get; set; } // свойство связки с таблицей залов с первичным ключем
        /// <summary>
        /// Свойство для столбца с номером ряда
        /// </summary>
        public int RowNumber { get; set; }
        /// <summary>
        /// Свойство для столбца с номером места в ряду
        /// </summary>
        public int LocNumber { get; set; }
        /// <summary>
        /// Свойство для столбца полученных денег за билет
        /// </summary>
        public float Cash { get; set; }
    }
}
