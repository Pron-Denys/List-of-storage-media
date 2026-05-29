using System.Text;
namespace User
{
    using ConsoleLog;
    using FileLog;
    using ILog;
    using ISerialize;
    using JSONSerialize;
    using PriceList;
    using SoapSerialize;
    using Storage_Medium;
    using XMLSerialize;

    class User
    {
        static void Main()
        {
            try
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.InputEncoding = Encoding.UTF8;
                
                PriceList pricelist = new PriceList();
                bool end = false;
                while (end == false)
                {
                    Console.Clear();
                    Console.Write("1 - завантажити з XML\n2 - завантажити з JSON\n3 - завантажити з SOAP\nОберіть: ");
                    int formatter_choice = int.Parse(Console.ReadLine()!);
                    ISerialize formatter = new XMLSerialize();
                    switch (formatter_choice)
                    {
                        case 1:
                            formatter = new XMLSerialize();
                            break;
                        case 2:
                            formatter = new JSONSerialize();
                            break;
                        case 3:
                            formatter = new SoapSerialize();
                            break;
                    }
                    pricelist.Load(formatter);
                    ConsoleLog console = new();
                    pricelist.Show(console);
                    Console.Write("\n\t\t+------ List Of Storage Media ------+\n\n0 | додати носій\t1 | видалити носій\t2 | завершити роботу\n" +
                        "3 | змінити носій\t4 | знайти носій\n\nОберіть: ");
                    int choice = int.Parse(Console.ReadLine()!);    
                    switch(choice)
                    {
                        case 0:
                            Console.Write("0 - додати DVD диск\n1 - додати знімний HDD\n2 - додати Flash-пам'ять" + "\nОберіть: ");
                            int add_choice = int.Parse(Console.ReadLine()!);
                            Console.Write("Введіть найменування: ");
                            string Item_Name = Console.ReadLine()!;
                            Console.Write("Введіть назву виробника: ");
                            string Name = Console.ReadLine()!;
                            Console.Write("Введіть модель: ");
                            string Model = Console.ReadLine()!;
                            Console.Write("Введіть кількість: ");
                            int Quantity = int.Parse(Console.ReadLine()!);
                            Console.Write("Введіть ємніть носія: ");
                            int Capacity = int.Parse(Console.ReadLine()!);
                            switch (add_choice)
                            {
                                case 0:
                                    Console.Write("Введіть швидкість запису (МБ/c): ");
                                    double Write_Speed = double.Parse(Console.ReadLine()!);
                                    DVD_Disc dvd_disc = new(Name, Model, Item_Name, Capacity, Write_Speed, Quantity);
                                    pricelist.Add(dvd_disc);
                                    break;
                                case 1:
                                    Console.Write("Введіть швидкість обертання шпинделя (об/хв): ");
                                    int Spindle_Speed = int.Parse(Console.ReadLine()!);
                                    Removable_HDD removable_hdd = new(Name, Model, Item_Name, Capacity, Spindle_Speed, Quantity);
                                    pricelist.Add(removable_hdd);
                                    break;
                                case 2:
                                    Console.Write("Введіть швидкість USB (біт/c): ");
                                    int USB_Speed = int.Parse(Console.ReadLine()!);
                                    FlashMemory flashmemory = new(Name, Model, Item_Name, Capacity, USB_Speed, Quantity);
                                    pricelist.Add(flashmemory);
                                    break;
                            }
                            break;
                        case 1:
                            Console.Write("Введіть назву виробника: ");
                            string name_storage_medium = Console.ReadLine()!;
                            Console.Write("Введіть назву моделі: ");
                            string model_storage_medium = Console.ReadLine()!;
                            pricelist.Remove(name_storage_medium, model_storage_medium);
                            break;
                        case 2:
                            end = true;
                            break;
                        case 3:
                            Console.Write("Введіть назву виробника: ");
                            name_storage_medium = Console.ReadLine()!;
                            Console.Write("Введіть назву моделі: ");
                            model_storage_medium = Console.ReadLine()!;
                            Console.Write("0 - DVD диск\n1 - знімний HDD\n2 - Flash-пам'ять" + "\nОберіть: ");
                            int edit_choice = int.Parse(Console.ReadLine()!);
                            Console.Write("Введіть нову назву виробника: ");
                            string name_edit_storage_medium = Console.ReadLine()!;
                            Console.Write("Введіть нову назву моделі: ");
                            string model_edit_storage_medium = Console.ReadLine()!;
                            Console.Write("Введіть нове найменування: ");
                            string item_name_storage_medium = Console.ReadLine()!;
                            Console.Write("Введіть нову ємність носія: ");
                            int capacity_storage_medium = int.Parse(Console.ReadLine()!);
                            Console.Write("Введіть нову кількість: ");
                            int quantity_storage_medium = int.Parse(Console.ReadLine()!);
                            switch (edit_choice)
                            {
                                case 0:
                                    Console.Write("Введіть нову швидкість запису (МБ/c): ");
                                    double Write_Speed = double.Parse(Console.ReadLine()!);
                                    DVD_Disc dvd_disc = new(name_edit_storage_medium, model_edit_storage_medium,
                                        item_name_storage_medium, capacity_storage_medium, Write_Speed, quantity_storage_medium);
                                    pricelist.Edit(dvd_disc, name_storage_medium, model_storage_medium);
                                    break;
                                case 1:
                                    Console.Write("Введіть швидкість обертання шпинделя (об/хв): ");
                                    int Spindle_Speed = int.Parse(Console.ReadLine()!);
                                    Removable_HDD removeble_hdd = new(name_edit_storage_medium, model_edit_storage_medium,
                                        item_name_storage_medium, capacity_storage_medium, Spindle_Speed, quantity_storage_medium);
                                    pricelist.Edit(removeble_hdd, name_storage_medium, model_storage_medium);
                                    break;
                                case 2:
                                    Console.Write("Введіть швидкість USB (біт/c): ");
                                    int Edited_USBspeed = int.Parse(Console.ReadLine()!);
                                    FlashMemory flashmemory = new(name_edit_storage_medium, model_edit_storage_medium,
                                        item_name_storage_medium, capacity_storage_medium, Edited_USBspeed, quantity_storage_medium);
                                    pricelist.Edit(flashmemory, name_storage_medium, model_storage_medium);
                                    break;
                            }
                            break;
                        case 4:
                            Console.Write("1 - вивести на консоль\n2 - вивести в файл\nОберіть: ");
                            choice = int.Parse(Console.ReadLine()!);
                            ILog log = new ConsoleLog();
                            switch(choice)
                            {
                                case 1:
                                    log = new ConsoleLog();
                                    break;
                                case 2:
                                    log = new FileLog();
                                    break;
                            }
                            Console.Write("Введіть назву виробника: ");
                            name_storage_medium = Console.ReadLine()!;
                            Console.Write("Введіть назву моделі: ");
                            model_storage_medium = Console.ReadLine()!;
                            pricelist.Search(log, name_storage_medium, model_storage_medium);
                            break;
                    }
                    Console.Write("1 - зберегти в XML\n2 - зберегти в JSON\n3 - зберегти в SOAP\nОберіть: ");
                    formatter_choice = int.Parse(Console.ReadLine()!);
                    formatter = new XMLSerialize();
                    switch (formatter_choice)
                    {
                        case 1:
                            formatter = new XMLSerialize();
                            break;
                        case 2:
                            formatter = new JSONSerialize();
                            break;
                        case 3:
                            formatter = new SoapSerialize();
                            break;
                    }
                    pricelist.Save(formatter);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
