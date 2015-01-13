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
    /// Класс для описания таблицы залов
    /// </summary>
    [TableAttribute("Hall")]
    class Hall
    {
        /// <summary>
        /// Свойство для столбца идентификатора, первичный ключ
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Свойство для столбца наименования зала
        /// </summary>
        public string Name { get; set; }

    }
}
