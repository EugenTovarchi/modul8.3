using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class FolderCleaner
    {
        public static long Cleaner(string path)
        {
            long deletedFileSize = 0;
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(path);

                foreach (FileInfo file in dirInfo.GetFiles())
                {
                    deletedFileSize += file.Length;
                    file.Delete();
                }
                foreach (DirectoryInfo dir in dirInfo.GetDirectories())
                {
                    // честно - нашёл это решение после поиска в инете
                    deletedFileSize += dirInfo.EnumerateFiles("*", SearchOption.AllDirectories).Sum(fi => fi.Length);
                    dir.Delete(true);
                }

            }

            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine($"Ошибка доступа {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
            }

            return deletedFileSize;
        }
    }
}
/* ЗАДАНИЕ 3
Доработайте программу из задания 1, используя ваш метод из задания 2.

При запуске программа должна:

Показать, сколько весит папка до очистки. Использовать метод из задания 2. 
Выполнить очистку.
Показать сколько файлов удалено и сколько места освобождено.
Показать, сколько папка весит после очистки.
Пример вывода:

Исходный размер папки: 7763 байт
Освобождено: 7763 байт
Текущий размер папки: 0 
*/
