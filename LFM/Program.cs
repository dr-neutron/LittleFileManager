using System;
using System.ComponentModel.Design;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

class FileManager
{
   
    
    
    public void MainFileManager()
    {
        try
        {

                Console.WriteLine("Задайте путь куда вы хотите потом создать каталог ( например: C:\\example )  -  ");

                string DirectionOnePath = Console.ReadLine();
                Console.WriteLine("Задайте путь куда вы хотите потом создать каталог ( например: C:\\example )  -  ");

                string DirectionTwoPath = Console.ReadLine();

            int a = 1;
            while (a == 1)
            {
                Console.WriteLine("*********************************************");
                Console.WriteLine("    Выбирете:   ");
                Console.WriteLine("    1) Создать каталог");
                Console.WriteLine("    2) Создать файл");
                Console.WriteLine("    3) Создать подкаталог");
                Console.WriteLine("    4) Показать файлы директории");
                Console.WriteLine("    5) Показать краткую информацию");
                Console.WriteLine("    6) Копировать файлы и вставить");
                Console.WriteLine("    7) Удалить файлы");
                Console.WriteLine("    8) Выводит информацию о файле");
                Console.WriteLine("*********************************************");
                Console.WriteLine("    ВВЕДИТЕ ВЫБОР:   ");
                int MainChoise = int.Parse(Console.ReadLine());
                if (MainChoise == 1)
                {




                    // Производит создание директории по пользовательскому пути ↓
                    Console.WriteLine("Выберите какой каталог вы хотите создать ( 1) первый  2) второй )   -  ");
                    int ChoiseCreateDirectory = int.Parse(Console.ReadLine());
                    if (ChoiseCreateDirectory == 1)
                    {


                        Directory.CreateDirectory(DirectionOnePath);
                    }
                    else if (ChoiseCreateDirectory == 2)
                    {


                        Directory.CreateDirectory(DirectionTwoPath);
                    }
                    else
                    {
                        Console.WriteLine("Введите верное значение!!!");
                    }

                }
                else if (MainChoise == 2)
                {
                    
                    
                    
                        // Создание файла в FilesFolder ↓
                        Console.WriteLine("Задайте путь файла, который вы хотите создать ( например: C://example//File ) -  ");
                        var FilesFolder = Console.ReadLine();
                        File.Create(FilesFolder);

                    
                   

                }
                else if (MainChoise == 3)
                {
                    Console.WriteLine("Задайте путь подкаталога, который вы хотите создать ( например: C://example//subDirectory ) -  ");
                    var OneNameSubDirectory = Console.ReadLine();
                    DirectoryInfo directory = new DirectoryInfo(OneNameSubDirectory);
                    directory.CreateSubdirectory(OneNameSubDirectory);
                }

                else if (MainChoise == 4)
                {
                    // Показывает файлы дирекотории ↓
                    Console.WriteLine("Файлы : ");
                    string[] Files = Directory.GetFiles(DirectionOnePath);
                    foreach (string ShowFiles in Files)
                    {
                        Console.WriteLine(ShowFiles);
                    }

                    // Показывает файлы дирекотории ↓
                    Console.WriteLine("Файлы : ");
                    string[] FilesTwo = Directory.GetFiles(DirectionTwoPath);
                    foreach (string ShowFiles in FilesTwo)
                    {
                        Console.WriteLine(ShowFiles);
                    }

                    

                

                }
                
                else if (MainChoise == 5)
                {
                    // Показывает краткую информации дирекотории ↓
                    Console.WriteLine("Введите номер какого каталога, вы хотите просмотреть краткую информацию ( 1) Каталог 1   2) Каталог 2 )  -");
                    int ChoiseShortInfoDirection = int.Parse(Console.ReadLine());
                    if (ChoiseShortInfoDirection == 1)
                    {


                        DirectoryInfo Name = new DirectoryInfo(DirectionOnePath);

                        Console.WriteLine("Имя каталога  -  " + Name);


                            DirectoryInfo full_name = new DirectoryInfo(DirectionOnePath);
                            
                            Console.WriteLine("Полный путь  -  " + full_name);


                            DirectoryInfo CreationTime = new DirectoryInfo(DirectionOnePath);
                            
                            Console.WriteLine("Время создание  -  " + CreationTime);



                            



                        
                    }
                    else if (ChoiseShortInfoDirection == 2)
                    {
                        string lastFolderName = Path.GetFileName(Path.GetDirectoryName(DirectionTwoPath));

                        Console.WriteLine("Имя каталога  -  " + lastFolderName);


                        DirectoryInfo full_name = new DirectoryInfo(DirectionTwoPath);

                        Console.WriteLine("Полный путь  -  " + full_name);


                        DirectoryInfo CreationTime = new DirectoryInfo(DirectionTwoPath);

                        Console.WriteLine("Время создание  -  " + CreationTime);

                    }


                    else
                    {
                        Console.WriteLine("Выберите существующий вариант!");
                    }

                }
                else if (MainChoise == 6)
                {


                    // Производит  копирование файлов ↓
                    Console.WriteLine("Выбирете из какого каталога вы хотите скопировать файлы и вставить в другой ( 1) первый каталог  2) второй каталог )  -  ");
                    int ChooseCopyFiles = int.Parse(Console.ReadLine());
                    if (ChooseCopyFiles == 1)
                    {
                        //Создает директории коприуемых файлов
                        foreach (string dirPath in Directory.GetDirectories(DirectionOnePath, "*", SearchOption.AllDirectories))
                        {
                            Directory.CreateDirectory(dirPath.Replace(DirectionOnePath, DirectionTwoPath));
                        }

                        //Копирует файлы 
                        foreach (string newPath in Directory.GetFiles(DirectionOnePath, "*.*", SearchOption.AllDirectories))
                        {
                            File.Copy(newPath, newPath.Replace(DirectionOnePath, DirectionTwoPath), true);
                            Console.WriteLine("Коприование выполнено!!!");
                        }

                    }
                    else if (ChooseCopyFiles == 2)
                    {
                        //Создает директории коприуемых файлов
                        foreach (string dirPath in Directory.GetDirectories(DirectionTwoPath, "*", SearchOption.AllDirectories))
                        {
                            Directory.CreateDirectory(dirPath.Replace(DirectionTwoPath, DirectionOnePath));
                        }

                        //Копирует файлы 
                        foreach (string newPath in Directory.GetFiles(DirectionOnePath, "*.*", SearchOption.AllDirectories))
                        {
                            File.Copy(newPath, newPath.Replace(DirectionTwoPath, DirectionOnePath), true);
                            Console.WriteLine("Коприование выполнено!!!");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Выберите существующий вариант!");
                    }
                }
                else if (MainChoise == 7)
                {
                    // Пройзводит удаление файлов ↓
                    Console.WriteLine("Какой каталог вы хотите удалить ( 1) превый каталог  2) второй каталог )   -   ");
                    int ChoiseDeleteFiles = int.Parse(Console.ReadLine());


                    if (ChoiseDeleteFiles == 1)
                    {
                        Console.WriteLine("ВЫ УВЕРЕНЫ В УДАЛЕНИИ? ( 1) ДА 2) НЕТ )   -   ");
                        int ConfirmChoiseDeleteFiles = int.Parse(Console.ReadLine());
                        if (ConfirmChoiseDeleteFiles == 1)
                        {
                            System.IO.DirectoryInfo di = new DirectoryInfo(DirectionOnePath);
                            foreach (FileInfo file in di.GetFiles())
                            {
                                file.Delete();
                                Console.WriteLine("Удаление выполнено!!!");
                            }
                            foreach (DirectoryInfo dir in di.GetDirectories())
                            {
                                dir.Delete(true);
                                Console.WriteLine("Удаление выполнено!!!");
                            }
                            
                        }
                        else if (ConfirmChoiseDeleteFiles == 2)
                        {
                            Console.WriteLine("Удаление отменено!");
                        }
                        else
                        {
                            Console.WriteLine("Выберите существующий вариант!");
                        }
                        
                           
                        
                    }
                    else if (ChoiseDeleteFiles == 2)
                    {
                        Console.WriteLine("ВЫ УВЕРЕНЫ В УДАЛЕНИИ? ( 1) ДА 2) НЕТ )   -   ");
                        int ConfirmChoiseDeleteFiles = int.Parse(Console.ReadLine());

                        if (ConfirmChoiseDeleteFiles == 1)
                        {
                            System.IO.DirectoryInfo dir = new DirectoryInfo(DirectionTwoPath);
                            foreach (FileInfo file1 in dir.GetFiles())
                            {
                                file1.Delete();
                            }
                            foreach (DirectoryInfo dire in dir.GetDirectories())
                            {
                                dire.Delete(true);
                            }
                        }
                        else if (ConfirmChoiseDeleteFiles == 2)
                        {
                            Console.WriteLine("Удаление отменено!");
                        }
                        else
                        {
                            Console.WriteLine("Выберите существующий вариант!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Введите верное значение!!!");
                    }
                }
                else if (MainChoise == 8)
                {
                    // Выводит информацию по пути ↓
                    Console.WriteLine("Введите путь файла, которого хотите посмотреть информацию ( например: C:\\example\\subDirectory )  -  ");
                    string InfoPath = Console.ReadLine();
                    long length = new System.IO.FileInfo(InfoPath).Length;
                    Console.WriteLine($" Размер файла - {length}");
                    DateTime FileCreatedDate = File.GetCreationTime(InfoPath);
                    Console.WriteLine("Создан: " + FileCreatedDate);
                    DateTime FileLastDate = File.GetLastAccessTime(InfoPath);
                    Console.WriteLine("Изменен: " + FileLastDate);
                    bool isReadOnly = ((File.GetAttributes(InfoPath) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly);
                    bool isHidden = ((File.GetAttributes(InfoPath) & FileAttributes.Hidden) == FileAttributes.Hidden);
                    Console.WriteLine("Только для чтения  -  " + isReadOnly);
                    Console.WriteLine("Скрыт  -  " + isHidden);
                }
                else
                {
                    Console.WriteLine("Введите верное значение!!!");
                }
            }
        }
        // Ловит ошибки ↓
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Возникла Ошибка!!!");
        }
        
    }

    static void Main()
    {
        var p = new FileManager();
        p.MainFileManager();
    }








}

