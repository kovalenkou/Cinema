using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CinemaProject
{
    /// <summary>
    /// Класс для работы с файлом конфигурации зала
    /// </summary>
    public static class InputHall
    {
        /// <summary>
        /// Метод считывания конфигурации залов из файлов
        /// </summary>
        /// <param name="h1">Принимает Id зала</param>
        /// <returns>Возвращает коллекцию символов, считанных из файла конфигурации зала</returns>
        public static List<string[]> InputingHall(int h1)
        {
            List<string[]> ls = new List<string[]>();
            try
            {
                string str = ".";
                if (h1 < 10)
                {
                    str = "0" + h1.ToString() + "hall.txt"; // задаем путь к файлу с конфигурацией зала,  если Id зала меньше 10
                }
                else
                {
                    str = h1.ToString() + "hall.txt"; // задаем путь к файлу с конфигурацией зала,  если Id зала равно или больше 10
                }

                String line;
                string[] words = new string[] { " " };
                using (StreamReader sr = new StreamReader(str))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Contains(" ") || line.Contains(","))
                        {
                            MessageBox.Show("Нарушена структура файла");
                            break;
                        }
                        else
                        {
                            words = line.Split(new char[] { ';', ':' }, StringSplitOptions.RemoveEmptyEntries);
                            ls.Add(words);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Невозможно считать файл! " + e.Message);
            }

            return ls;
        }
    }
}
