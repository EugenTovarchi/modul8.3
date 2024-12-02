using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class FolderScaner
    {
        // Валидация + удобный переход параметров в другой метод где будет рекурсия
        public static long DirectorySize(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);

            if (!Directory.Exists(path))
            {
                Console.WriteLine($"Директории {path} не существует!");
                return 0;
            }

            return (DirectoryCalculate(dir));
        }

        public static long DirectoryCalculate(DirectoryInfo dir)
        {
            long size = 0;

            try
            {
                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo file in files)

                {
                    size += file.Length;
                }

                DirectoryInfo[] subDirs = dir.GetDirectories();
                foreach (DirectoryInfo directory in subDirs)

                {
                    size += DirectoryCalculate(directory);
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

            return size;
            
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
