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
    /// Класс для описания таблицы цен на билеты
    /// </summary>
    [TableAttribute("Ticket")]
    class Ticket
    {
        /// <summary>
        /// Свойство для столбца идентификатора, первичный ключ
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Свойство для столбца цены билета
        /// </summary>
        public float Price { get; set; }
        /// <summary>
        /// Свойство для столбца идентификатором типа кресла
        /// </summary>
        public int ChairTypeId { get; set; }
        [ForeignKey("ChairTypeId")]
        public ChairType ChairType { get; set; } // свойство связки с таблицей типов кресел с первичным ключом
    }
}
