using System.Text;
namespace User
{
    using PriceList;
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
                    pricelist.Load();
                    pricelist.Show();
                    Console.Write("\n\t\t+------ List Of Storage Media ------+\n\n0 | додати носій\t1 | видалити носій\t2 | завершити роботу\n" +
                        "3 | змінити носій\t4 | знайти носій\n\nОберіть: ");
                    string? temp_choice = Console.ReadLine();
                    int choice = 0;
                    if (temp_choice != null)
                        choice = int.Parse(temp_choice);
                    switch(choice)
                    {
                        case 0:
                            pricelist.Add();
                            break;
                        case 1:
                            pricelist.Remove();
                            break;
                        case 2:
                            pricelist.Save();
                            end = true;
                            break;
                        case 3:
                            pricelist.Edit();
                            break;
                        case 4:
                            pricelist.Search();
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
