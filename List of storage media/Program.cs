using System.Text;
namespace User
{
    using PriceList;
    using XMLSerialize;
    using JSONSerialize;
    using SoapSerialize;
    using ISerialize;
    using ConsoleLog;
    using FileLog;
    using ILog;
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
                    pricelist.Show();
                    Console.Write("\n\t\t+------ List Of Storage Media ------+\n\n0 | додати носій\t1 | видалити носій\t2 | завершити роботу\n" +
                        "3 | змінити носій\t4 | знайти носій\n\nОберіть: ");
                    int choice = int.Parse(Console.ReadLine()!);    
                    switch(choice)
                    {
                        case 0:
                            pricelist.Add();
                            break;
                        case 1:
                            pricelist.Remove();
                            break;
                        case 2:
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
                            end = true;
                            break;
                        case 3:
                            pricelist.Edit();
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
                            pricelist.Search(log);
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
