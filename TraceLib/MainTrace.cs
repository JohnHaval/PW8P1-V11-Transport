using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TraceLib
{
    public class MainTrace
    {
        /// <summary>
        /// Счетчик для учета ведения порядкового номера теста
        /// </summary>
        public static int Counter = 0;
        /// <summary>
        /// Накопитель информации для вывода результатов в файл (может быть README)
        /// </summary>
        public static string AllDebug = "";
        /// <summary>
        /// Фиксирование в трассировке необходимой информации по проводимому тесту
        /// </summary>
        public static void ToTrace(int[] arr, bool isOnlyTrace)//isOnlyTrace используется как идентификатор сохранения трассировки в файл
        {
            if (!isOnlyTrace) StartTest();
            TraceAndSave("Представление одномерного массива для целочисленных значений:\n\n");
            for (int i = 0; i < arr.Length; i++)
            {
                TraceAndSave($"{arr[i]} ");
            }
            TraceAndSave("\n\n");
            if (!isOnlyTrace) EndTest();
        }
        /// <summary>
        /// Фиксирование в трассировке необходимой информации по проводимому тесту
        /// </summary>
        public static void ToTrace(double[] arr, bool isOnlyTrace)
        {
            if (!isOnlyTrace) StartTest();
            TraceAndSave("Представление одномерного массива:\n\n");
            for (int i = 0; i < arr.Length; i++)
            {
                TraceAndSave($"{arr[i]} ");
            }
            TraceAndSave("\n\n");
            if (!isOnlyTrace) EndTest();
        }
        /// <summary>
        /// Фиксирование в трассировке необходимой информации по проводимому тесту
        /// </summary>
        public static void ToTrace(double[,] arr, bool isOnlyTrace)
        {
            if (!isOnlyTrace) StartTest();
            TraceAndSave("Представление двумерного массива:\n\n");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    TraceAndSave($"{arr[i, j]} ");
                }
                TraceAndSave("\n\n");
            }
            TraceAndSave("\n\n");
            if (!isOnlyTrace) EndTest();
        }
        /// <summary>
        /// Фиксирование в трассировке необходимой информации по проводимому тесту (чаще, можно использовать для классов)
        /// </summary>
        /// <param name="allAboutSomething"></param>
        public static void ToTrace(string allAboutSomething)
        {
            StartTest();
            TraceAndSave(allAboutSomething + "\n\n");//Для конца строки нужно всегда указывать \n
            EndTest();
        }
        /// <summary>
        /// Используется для сохранения из AllDebug информации в файл, с указанием пути вручную в коде. (Обычно - в конце последнего теста)
        /// </summary>
        public static void ToReadme()
        {
            #region Поставить нужный путь
            StreamWriter writer = new StreamWriter(@"E:\Совершенствование класса TraceTransfer\PW8P1-V11-Transport\PW8P1-V11-Transport\README.md");//<--
            #endregion
            for (int i = 0; i < AllDebug.Length; i++)
            {
                writer.Write(AllDebug[i]);
            }
            MDTrace.ToReadmeForTable(writer);
            writer.Close();
        }
        /// <summary>
        /// Используется для объявления начала теста
        /// </summary>
        private static void StartTest()
        {
            AllDebug += $"Test {++Counter}:\n\n";
            Debug.WriteLine("");
        }
        /// <summary>
        /// Используется для объявления окончания теста
        /// </summary>
        private static void EndTest()
        {
            AllDebug += $"Test {Counter} окончен\n\n";
            Debug.WriteLine("");
        }
        /// <summary>
        /// Используется для сохранения информации в трассировку теста и в переменную сохранения любой строчной информации
        /// без объявления о начале или завершении теста
        /// </summary>
        /// <param name="something"></param>
        private static void TraceAndSave(string something)
        {
            AllDebug += something;
            Debug.Write(something);
        }
        /// <summary>
        /// Учет дополнительной информации (используется для unit test'a чаще всего)
        /// </summary>
        /// <param name="something"></param>
        /// <param name="isAdvancedForTest"></param>
        public static void TraceAndSave(string something, bool isAdvancedForTest)
        {
            if (isAdvancedForTest)
            {
                TraceAndSave("Дополнительно:\n\n" + something + "\n\n");
            }
            else TraceAndSave(something);
        }
        public static void DataGridTraceView(DataTable table, bool isOnlyTrace)
        {
            if (!isOnlyTrace) StartTest();
            TraceAndSave("DataTable представление:\n\n");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                var row = table.Rows[i];
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    TraceAndSave($"{row[j]} ");
                }
                TraceAndSave("\n\n");
            }
            TraceAndSave("\n\n");
            if (!isOnlyTrace) EndTest();
        }
    }
}
