using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Data;

namespace TraceLib
{
    public static class MDTrace
    {
        /// <summary>
        /// Можно использовать для хранения тестовых результатов (для составления будущей таблицы)
        /// </summary>
        public static List<bool> TestResults { get; set; } = new List<bool>();//--------------------Нумерация зависит от кол-ва проводимых тестов
        /// <summary>
        /// Используется для идентификации желания программиста в конце файла добавлять результаты тестов
        /// </summary>
        public static bool IsNeedTable { get; set; } = true;//Можно убрать true, если не требуется таблица в конце файла

        /// <summary>
        /// Добавление заголовка в README (чаще используется на старте работы)
        /// </summary>
        /// <param name="header"></param>
        public static void GiveHeaderToReadme(string header)
        {
            MainTrace.AllDebug += "# " + header;
            MainTrace.AllDebug += "\n\n";
        }
        /// <summary>
        /// Добавление номеров строк последовательности к строкам
        /// </summary>
        /// <param name="info"></param>
        public static void GiveNumberStrings(string[] info)
        {
            for (int i = 1; i <= info.Length; i++)
            {
                MainTrace.AllDebug += i + "." + " " + info.GetValue(i - 1);
                MainTrace.AllDebug += "\n";
            }
            MainTrace.AllDebug += "\n\n";
        }
        /// <summary>
        /// Добавление точек перед каждой строкой (для README)
        /// </summary>
        /// <param name="info"></param>
        public static void GivePointStrings(string[] info)
        {
            for (int i = 1; i <= info.Length; i++)
            {
                MainTrace.AllDebug += "*" + " " + info.GetValue(i - 1);
                MainTrace.AllDebug += "\n";
            }
            MainTrace.AllDebug += "\n\n";
        }
        /// <summary>
        /// Создание таблицы для README
        /// </summary>
        /// <param name="headers"></param>
        /// <param name="values"></param>
        public static string GiveStringsToTable(string[] headers, string[] values)
        {
            string tempTable = "";
            for (int i = 0; i < headers.Length; i++)
            {
                tempTable += headers.GetValue(i) + "|";
            }
            tempTable += "\n";
            for (int i = 0; i < headers.Length; i++)
            {
                tempTable += "-|";
            }
            tempTable += "\n";
            for (int i = 0; i < values.Length; i++)
            {
                tempTable += values.GetValue(i) + "|";
                if ((i + 1) % headers.Length == 0 && i != 0) tempTable += "\n";
            }
            tempTable += "\n\n";
            return tempTable;
        }
        /// <summary>
        /// Добавление горизонтального разделителя для заголовка
        /// </summary>
        public static void GiveHorizontalSeparator()
        {
            MainTrace.AllDebug += "----------------------------------";
            MainTrace.AllDebug += "\n\n";//В конце всегда 2 \n для отделение пустым параграфом
        }        
        public static void ToReadmeForTable(StreamWriter writer)
        {
            if (IsNeedTable)
            {
                string[] headers = new string[2];
                headers.SetValue("Тест №", 0);
                headers.SetValue("Результат", 1);
                var textResults = new List<string>();
                for (int i = 0; i < TestResults.Count; i++)
                {
                    textResults.Add("Тест №" + (i + 1));
                    if (TestResults[i] == true) textResults.Add("Успешно");
                    else textResults.Add("Не успешно");
                }
                writer.Write(GiveStringsToTable(headers, textResults.ToArray()));
            }
        }
    }
}
