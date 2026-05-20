namespace Storage_Medium
{
    using ILog;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Serializable]
    [KnownType(typeof(FlashMemory))]
    [KnownType(typeof(DVD_Disc))]
    [KnownType(typeof(Removable_HDD))]
    [XmlInclude(typeof(FlashMemory))]
    [XmlInclude(typeof(DVD_Disc))]
    [XmlInclude(typeof(Removable_HDD))]
    [DataContract]
    public abstract class Storage_Medium
    {
        [DataMember]
        public string? Name { get; set; }
        [DataMember]
        public string? Model { get; set; }
        [DataMember]
        public string? Item_Name { get; set; }
        [DataMember]
        public int Capacity { get; set; }
        [DataMember]
        public int Quantity { get; set; }

        public class ConsoleLog : ILog
        {
            public void Print(string[] str)
            {
                Console.Write("\t");
                foreach (string text in str)
                    Console.Write(text);
                Console.WriteLine();
            }
        }
        public class FileLog : ILog
        {
            public void Print(string[] str)
            {
                StreamWriter fileWriter = new StreamWriter("Storage Medium.txt", true);
                foreach (string text in str)
                    fileWriter.Write(text);
                fileWriter.WriteLine();
                fileWriter.Close();
            }
        }

        public virtual void Print(int choice = 0)
        {
            if (Name != null && Model != null && Item_Name != null)
            {
                if (choice == 0)
                {
                    Console.Write("0 - Надрукувати в файл\n1 - Надрукувати в консоль\nОберіть: ");
                    string? value = Console.ReadLine();
                    if (value != null)
                        choice = int.Parse(value);
                    switch (choice)
                    {
                        case 0:
                            FileLog obj_1 = new();
                            obj_1.Print([Item_Name, " ", Name, " ", Model, " Capacity: ", Capacity.ToString(), " Quantity: ", Quantity.ToString()]);
                            break;
                        case 1:
                            ConsoleLog obj_0 = new();
                            obj_0.Print([Item_Name, " ", Name, " ", Model, " Capacity: ", Capacity.ToString(), " Quantity: ", Quantity.ToString()]);
                            break;
                    }
                }
                else
                {
                    ConsoleLog obj_0 = new();
                    obj_0.Print([Item_Name, " ", Name, " ", Model, " Capacity: ", Capacity.ToString(), " Quantity: ", Quantity.ToString()]);
                }
            }
        }
    }
    [Serializable]
    [DataContract]
    public class FlashMemory : Storage_Medium
    {
        [DataMember]
        public int USB_Speed { get; set; }

        public FlashMemory()
        {
            Name = "";
            Model = "";
            Item_Name = "";
            Capacity = 0;
            USB_Speed = 0;
            Quantity = 0;
        }

        public FlashMemory(string name, string model, string item_name, int capacity, int usb_speed, int quantity)
        {
            Name = name;
            Model = model;
            Item_Name = item_name;
            Capacity = capacity;
            USB_Speed = usb_speed;
            Quantity = quantity;
        }
        public override void Print(int choice = 0)
        {
            if (Name != null && Model != null && Item_Name != null)
            {
                if (choice == 0)
                {
                    Console.Write("0 - Надрукувати в файл\n1 - Надрукувати в консоль\nОберіть: ");
                    string? value = Console.ReadLine();
                    if (value != null)
                        choice = int.Parse(value);
                    switch (choice)
                    {
                        case 0:
                            FileLog obj_1 = new();
                            obj_1.Print([Item_Name, " ", Name, " ", Model, " Capacity: ", Capacity.ToString(), " Quantity: ", Quantity.ToString(), " USB Speed: ", USB_Speed.ToString()]);
                            break;
                        case 1:
                            ConsoleLog obj_0 = new();
                            obj_0.Print([Item_Name, " ", Name, " ", Model, " Capacity: ", Capacity.ToString(), " Quantity: ", Quantity.ToString(), " USB Speed: ", USB_Speed.ToString()]);
                            break;
                    }
                }
                else
                {
                    ConsoleLog obj_0 = new();
                    obj_0.Print([Item_Name, " ", Name, " ", Model, " Capacity: ", Capacity.ToString(), " Quantity: ", Quantity.ToString(), " USB Speed: ", USB_Speed.ToString()]);
                }
            }
        }
    }
    [Serializable]
    [DataContract]
    public class DVD_Disc : Storage_Medium
    {
        [DataMember]
        public double Write_Speed { get; set; }

        public DVD_Disc()
        {
            Name = "";
            Model = "";
            Item_Name = "";
            Capacity = 0;
            Write_Speed = 0;
            Quantity = 0;
        }

        public DVD_Disc(string name, string model, string item_name, int capacity, double write_speed, int quantity)
        {
            Name = name;
            Model = model;
            Item_Name = item_name;
            Capacity = capacity;
            Write_Speed = write_speed;
            Quantity = quantity;
        }

        public override void Print(int choice = 0)
        {
            if (Name != null && Model != null && Item_Name != null)
            {
                if (choice == 0)
                {
                    Console.Write("0 - Надрукувати в файл\n1 - Надрукувати в консоль\nОберіть: ");
                    string? value = Console.ReadLine();
                    if (value != null)
                        choice = int.Parse(value);
                    switch (choice)
                    {
                        case 0:
                            FileLog obj_1 = new();
                            obj_1.Print([Item_Name, " ", Name, " ", Model, " Capacity: ", Capacity.ToString(), " Quantity: ", Quantity.ToString(), " Write Speed: ", Write_Speed.ToString()]);
                            break;
                        case 1:
                            ConsoleLog obj_0 = new();
                            obj_0.Print([Item_Name, " ", Name, " ", Model, " Capacity: ", Capacity.ToString(), " Quantity: ", Quantity.ToString(), " Write Speed: ", Write_Speed.ToString()]);
                            break;
                    }
                }
                else
                {
                    ConsoleLog obj_0 = new();
                    obj_0.Print([Item_Name, " ", Name, " ", Model, " Capacity: ", Capacity.ToString(), " Quantity: ", Quantity.ToString(), " Write Speed: ", Write_Speed.ToString()]);
                }
            }
        }
    }

    [Serializable]
    [DataContract]
    public class Removable_HDD : Storage_Medium
    {
        [DataMember]
        public int Spindle_Speed { get; set; }

        public Removable_HDD()
        {
            Name = "";
            Model = "";
            Item_Name = "";
            Capacity = 0;
            Spindle_Speed = 0;
            Quantity = 0;
        }

        public Removable_HDD(string name, string model, string item_name, int capacity, int spindle_speed, int quantity)
        {
            Name = name;
            Model = model;
            Item_Name = item_name;
            Capacity = capacity;
            Spindle_Speed = spindle_speed;
            Quantity = quantity;
        }

        public override void Print(int choice = 0)
        {
            if (Name != null && Model != null && Item_Name != null)
            {
                if (choice == 0)
                {
                    Console.Write("0 - Надрукувати в файл\n1 - Надрукувати в консоль\nОберіть: ");
                    string? value = Console.ReadLine();
                    if (value != null)
                        choice = int.Parse(value);
                    switch (choice)
                    {
                        case 0:
                            FileLog obj_1 = new();
                            obj_1.Print([Item_Name, " ", Name, " ", Model, " Capacity: ", Capacity.ToString(), " Quantity: ", Quantity.ToString(), " Spindle Speed: ", Spindle_Speed.ToString()]);
                            break;
                        case 1:
                            ConsoleLog obj_0 = new();
                            obj_0.Print([Item_Name, " ", Name, " ", Model, " Capacity: ", Capacity.ToString(), " Quantity: ", Quantity.ToString(), " Spindle Speed: ", Spindle_Speed.ToString()]);
                            break;
                    }
                }
                else
                {
                    ConsoleLog obj_0 = new();
                    obj_0.Print([Item_Name, " ", Name, " ", Model, " Capacity: ", Capacity.ToString(), " Quantity: ", Quantity.ToString(), " Spindle Speed: ", Spindle_Speed.ToString()]);
                }
            }
        }
    }
}
