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


 0 баллов: задача решена неверно или отсутствует доступ к репозиторию.
2 балла (хорошо): написан метод и код выполняет свою функцию.
4 балла (отлично): предусмотрена обработка исключений и валидация пути.*/

using Task3;

class Program
{
    static void Main (string[] args)
    {
        string path = string.Empty;
        Console.Write("введите адрес папки: ");
        path = Console.ReadLine();

        long size = FolderScaner.DirectorySize(path);
        Console.WriteLine($"Исходный размер папки: {size} байт");
        
        long deletedFilesSize = FolderCleaner.Cleaner(path);
        Console.WriteLine($"Освобождено: {deletedFilesSize} байт");

        long curentSize = FolderScaner.DirectorySize(path);
        Console.WriteLine($"Текущий размер папки: {curentSize} байт");
    }
}

