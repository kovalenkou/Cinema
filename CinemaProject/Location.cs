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
    /// Класс для описания таблицы мест в залах
    /// </summary>
    [TableAttribute("Location")]
    class Location
    {
        /// <summary>
        /// Свойство для столбца идентификатора, первичный ключ
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Свойство для столбца с номером ряда
        /// </summary>
        public int RowNumber { get; set; }
        /// <summary>
        /// Свойство для столбца с номером места в ряду
        /// </summary>
        public int LocNumber { get; set; }
        /// <summary>
        /// Свойство для столбца с Идентификатором зала, в котором находится кресло
        /// </summary>
        public int HallId { get; set; }
        [ForeignKey("HallId")]
        public Hall Hall { get; set; } // свойство связки с таблицей залов с первичным ключем
        /// <summary>
        /// Свойство для столбца с идентификатором типа кресла
        /// </summary>
        public int ChairTypeId { get; set; }
        [ForeignKey("ChairTypeId")]
        public ChairType ChairType { get; set; } // свойство связки с таблицей типов кресел с первичным ключем
        /// <summary>
        /// Свойство для столбца наличия кресла/активности
        /// </summary>
        public int Active { get; set; }
    }
}
