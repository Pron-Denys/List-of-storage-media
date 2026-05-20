namespace PriceList
{
    using ISerialize;
    using Storage_Medium;
    using System.Collections;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Soap;
    using System.Runtime.Serialization.Json;
    using System.Xml.Serialization;

    [Serializable]
    [DataContract]
    public class PriceList
    {
        [DataMember]
        List<Storage_Medium>? storage_media;
        
        public PriceList()
        {
            storage_media = new List<Storage_Medium>();
        }

        public void Add()
        {
            Console.Write("0 - додати DVD диск\n1 - додати знімний HDD\n2 - додати Flash-пам'ять" +
                "\nОберіть: ");
            string? value = Console.ReadLine();
            int choice = 0;
            if (value != null)
                choice = int.Parse(value);
            Console.Write("Введіть найменування: ");
            string? Item_Name = Console.ReadLine();
            Console.Write("Введіть назву виробника: ");
            string? Name = Console.ReadLine();
            Console.Write("Введіть модель: ");
            string? Model = Console.ReadLine();
            Console.Write("Введіть кількість: ");
            string? temp_Quantity = Console.ReadLine();
            int Quantity = 0;
            if (temp_Quantity != null)
                Quantity = int.Parse(temp_Quantity);
            Console.Write("Введіть ємніть носія: ");
            string? temp_Capacity = Console.ReadLine();
            int Capacity = 0;
            if (temp_Capacity != null)
                Capacity = int.Parse(temp_Capacity);
            if (Name != null && Model != null && Item_Name != null)
            {
                switch (choice)
                {
                    case 0:
                        Console.Write("Введіть швидкість запису (МБ/c): ");
                        string? temp_Write_Speed = Console.ReadLine();
                        double Write_Speed = 0;
                        if (temp_Write_Speed != null)
                            Write_Speed = double.Parse(temp_Write_Speed);
                        DVD_Disc dvd_disc = new(Name, Model, Item_Name, Capacity, Write_Speed, Quantity);
                        storage_media?.Add(dvd_disc);
                        break;
                    case 1:
                        Console.Write("Введіть швидкість обертання шпинделя (об/хв): ");
                        string? temp_Spindle_Speed = Console.ReadLine();
                        int Spindle_Speed = 0;
                        if (temp_Spindle_Speed != null)
                            Spindle_Speed = int.Parse(temp_Spindle_Speed);
                        Removable_HDD removable_hdd = new(Name, Model, Item_Name, Capacity, Spindle_Speed, Quantity);
                        storage_media?.Add(removable_hdd);
                        break;
                    case 2:
                        Console.Write("Введіть швидкість USB (біт/c): ");
                        string? temp_USB_Speed = Console.ReadLine();
                        int USB_Speed = 0;
                        if (temp_USB_Speed != null)
                            USB_Speed = int.Parse(temp_USB_Speed);
                        FlashMemory flashmemory = new(Name, Model, Item_Name, Capacity, USB_Speed, Quantity);
                        storage_media?.Add(flashmemory);
                        break;
                }
            }
        }

        public void Remove()
        {
            Console.Write("0 - Назва виробника\n1 - Назва моделі\n2 - Ємність носія\nОберіть критерій: ");
            string? value = Console.ReadLine();
            int choice = 0;
            if (value != null)
                choice = int.Parse(value);
            List<Storage_Medium> temp_storage_media = new List<Storage_Medium>();
            if (storage_media != null)
            {
                switch (choice)
                {
                    case 0:
                        Console.Write("Введіть назву виробника: ");
                        string? Name = Console.ReadLine();
                        foreach (var storage_medium in storage_media)
                        {
                            if (storage_medium.Name == Name)
                                continue;
                            temp_storage_media.Add(storage_medium);
                        }
                        break;
                    case 1:
                        Console.Write("Введіть назву моделі: ");
                        string? Model = Console.ReadLine();
                        foreach (var storage_medium in storage_media)
                        {
                            if (storage_medium.Model == Model)
                                continue;
                            temp_storage_media.Add(storage_medium);
                        }
                        break;
                    case 2:
                        Console.Write("Введіть ємність носія: ");
                        string? temp_Capacity = Console.ReadLine();
                        int Capacity = 0;
                        if (temp_Capacity != null)
                            Capacity = int.Parse(temp_Capacity);
                        foreach (var storage_medium in storage_media)
                        {
                            if (storage_medium.Capacity == Capacity)
                                continue;
                            temp_storage_media.Add(storage_medium);
                        }
                        break;
                }
                storage_media = temp_storage_media;
            }
        }

        public void Search()
        {
            Console.Write("0 - Назва виробника\n1 - Назва моделі\n2 - Ємність носія\n" +
                "3 - Найменування\nОберіть критерій: ");
            string? value = Console.ReadLine();
            int choice = 0;
            if (value != null)
                choice = int.Parse(value);
            if (storage_media != null)
            {
                switch (choice)
                {
                    case 0:
                        Console.Write("Введіть назву виробника: ");
                        string? Name = Console.ReadLine();
                        foreach (var storage_medium in storage_media)
                        {
                            if (storage_medium.Name == Name)
                                storage_medium.Print();
                        }
                        break;
                    case 1:
                        Console.Write("Введіть модель: ");
                        string? Model = Console.ReadLine();
                        foreach (var storage_medium in storage_media)
                        {
                            if (storage_medium.Model == Model)
                                storage_medium.Print();
                        }
                        break;
                    case 2:
                        Console.Write("Введіть ємність: ");
                        string? temp_Capacity = Console.ReadLine();
                        int Capacity = 0;
                        if (temp_Capacity != null)
                            Capacity = int.Parse(temp_Capacity);
                        foreach (var storage_medium in storage_media)
                        {
                            if (storage_medium.Capacity == Capacity)
                                storage_medium.Print();
                        }
                        break;
                    case 3:
                        Console.Write("Введіть найменування: ");
                        string? Item_Name = Console.ReadLine();
                        foreach (var storage_medium in storage_media)
                        {
                            if (storage_medium.Item_Name == Item_Name)
                                storage_medium.Print();
                        }
                        break;
                }
            }
        }

        public void Edit()
        {
            Console.Write("Введіть назву виробника: ");
            string? Name = Console.ReadLine();
            Console.Write("Введіть модель: ");
            string? Model = Console.ReadLine();
            List<Storage_Medium> temp_storage_media = new List<Storage_Medium>();
            if (storage_media != null)
            {
                Console.Write("0 - змінити назву виробника\n1 - змінити назву моделі\n2 - змінити ємність носія\n" +
                                    "3 - змінити найменування\n4 - змінити швидкість USB (біт/c)\n5 - змінити кількість\n" +
                                    "6 - змінити швидкість обертання шпинделя\n7 - змінити швидкість запису\nОберіть: ");
                string? value = Console.ReadLine();
                int choice = 0;
                if (value != null)
                    choice = int.Parse(value);
                var obj = storage_media[0];
                switch (choice)
                {
                    case 0:
                        Console.Write("Введіть назву: ");
                        string? Edited_Name = Console.ReadLine();
                        foreach (var storage_medium in storage_media)
                        {
                            if (storage_medium.Name == Name && storage_medium.Model == Model)
                            {
                                obj = storage_medium;
                                obj.Name = Edited_Name;
                                temp_storage_media.Add(obj);
                                continue;
                            }
                            temp_storage_media.Add(storage_medium);
                        }
                        break;
                    case 1:
                        Console.Write("Введіть модель: ");
                        string? Edited_Model = Console.ReadLine();
                        foreach (var storage_medium in storage_media)
                        {
                            if (storage_medium.Name == Name && storage_medium.Model == Model)
                            {
                                obj = storage_medium;
                                obj.Model = Edited_Model;
                                temp_storage_media.Add(obj);
                                continue;
                            }
                            temp_storage_media.Add(storage_medium);
                        }
                        break;
                    case 2:
                        Console.Write("Введіть ємніть носія: ");
                        string? temp_Edited_Capacity = Console.ReadLine();
                        int Edited_Capacity = 0;
                        if (temp_Edited_Capacity != null)
                            Edited_Capacity = int.Parse(temp_Edited_Capacity);
                        foreach (var storage_medium in storage_media)
                        {
                            if (storage_medium.Name == Name && storage_medium.Model == Model)
                            {
                                obj = storage_medium;
                                obj.Capacity = Edited_Capacity;
                                temp_storage_media.Add(obj);
                                continue;
                            }
                            temp_storage_media.Add(storage_medium);
                        }
                        break;
                    case 3:
                        Console.Write("Введіть найменування: ");
                        string? Edited_Item_Name = Console.ReadLine();
                        foreach (var storage_medium in storage_media)
                        {
                            if (storage_medium.Name == Name && storage_medium.Model == Model)
                            {
                                obj = storage_medium;
                                obj.Item_Name = Edited_Item_Name;
                                temp_storage_media.Add(obj);
                                continue;
                            }
                            temp_storage_media.Add(storage_medium);
                        }
                        break;
                    case 4:
                        Console.Write("Введіть швидкість USB (біт/c): ");
                        string? temp_Edited_USBspeed = Console.ReadLine();
                        int Edited_USBspeed = 0;
                        if (temp_Edited_USBspeed != null)
                            Edited_USBspeed = int.Parse(temp_Edited_USBspeed);
                        foreach (var storage_medium in storage_media)
                        {
                            if (storage_medium.Name == Name && storage_medium.Model == Model)
                            {
                                if (storage_medium is FlashMemory)
                                {
                                    FlashMemory flashmemory = (FlashMemory)storage_medium;
                                    flashmemory.USB_Speed = Edited_USBspeed;
                                    temp_storage_media.Add(flashmemory);
                                }
                                continue;
                            }
                            temp_storage_media.Add(storage_medium);
                        }
                        break;
                    case 5:
                        Console.Write("Введіть кількіть: ");
                        string? temp_Quantity = Console.ReadLine();
                        int Edited_Quantity = 0;
                        if (temp_Quantity != null)
                            Edited_Quantity = int.Parse(temp_Quantity);
                        foreach (var storage_medium in storage_media)
                        {
                            if (storage_medium.Name == Name && storage_medium.Model == Model)
                            {
                                obj = storage_medium;
                                obj.Quantity = Edited_Quantity;
                                temp_storage_media.Add(obj);
                                continue;
                            }
                            temp_storage_media.Add(storage_medium);
                        }
                        break;
                    case 6:
                        Console.Write("Введіть швидкість обертання шпинделя (об/хв): ");
                        string? temp_Spindle_Speed = Console.ReadLine();
                        int Spindle_Speed = 0;
                        if (temp_Spindle_Speed != null)
                            Spindle_Speed = int.Parse(temp_Spindle_Speed);
                        foreach (var storage_medium in storage_media)
                        {
                            if (storage_medium.Name == Name && storage_medium.Model == Model)
                            {
                                if (storage_medium is Removable_HDD)
                                {
                                    Removable_HDD removeble_hdd = (Removable_HDD)storage_medium;
                                    removeble_hdd.Spindle_Speed = Spindle_Speed;
                                    temp_storage_media.Add(removeble_hdd);
                                }
                                continue;
                            }
                            temp_storage_media.Add(storage_medium);
                        }
                        break;
                    case 7:
                        Console.Write("Введіть швидкість запису (МБ/c): ");
                        string? temp_Write_Speed = Console.ReadLine();
                        double Write_Speed = 0;
                        if (temp_Write_Speed != null)
                            Write_Speed = double.Parse(temp_Write_Speed);
                        foreach (var storage_medium in storage_media)
                        {
                            if (storage_medium.Name == Name && storage_medium.Model == Model)
                            {
                                if (storage_medium is DVD_Disc)
                                {
                                    DVD_Disc dvd_disc = (DVD_Disc)storage_medium;
                                    dvd_disc.Write_Speed = Write_Speed;
                                    temp_storage_media.Add(dvd_disc);
                                }
                                continue;
                            }
                            temp_storage_media.Add(storage_medium);
                        }
                        break;
                    default:
                        storage_media = temp_storage_media;
                        break;
                }
            }
        }

        class SoapSerialize : ISerialize
        {
            public void Save<T>(ref T list)
            {
                FileStream stream = new("Soap.xml", FileMode.Create);
                SoapFormatter soap = new();
                soap.Serialize(stream, list);
                stream.Close();
            }

            public void Load<T>(ref T list)
            {
                FileStream stream = new("Soap.xml", FileMode.Open);
                SoapFormatter soap = new();
                list = (T)soap.Deserialize(stream);
                stream.Close();
            }
        }

        class JSONSerialize : ISerialize
        {
            public void Save<T>(ref T list)
            {
                FileStream stream = new("Storage Media.json", FileMode.Create);
                DataContractJsonSerializer formatter = new(typeof(T));
                formatter.WriteObject(stream, list);
                stream.Close();
            }

            public void Load<T>(ref T list)
            {
                FileStream stream = new("Storage Media.json", FileMode.Open);
                DataContractJsonSerializer formatter = new(typeof(T));
                object? temp = formatter.ReadObject(stream);
                if (temp is T)
                    list = (T)temp;
                stream.Close();
            }
        }

        class XMLSerialize : ISerialize
        {
            public void Save<T>(ref T list)
            {
                FileStream stream = new("Storage Media.xml", FileMode.Create);
                XmlSerializer formatter = new XmlSerializer(typeof(T));
                formatter.Serialize(stream, list);
                stream.Close();
            }

            public void Load<T>(ref T list)
            {
                FileStream stream = new("Storage Media.xml", FileMode.Open);
                XmlSerializer formatter = new XmlSerializer(typeof(T));
                object? temp = formatter.Deserialize(stream);
                if (temp is T)
                    list = (T)temp;
                stream.Close();
            }
        }

        public void Save()
        {
            Console.Write("0 - зберегти XML\n1 - зберегти JSON\n2 - зберегти SOAP\nОберіть: ");
            string? temp_choice = Console.ReadLine();
            int choice = 0;
            if (temp_choice != null)
                choice = int.Parse(temp_choice);
            if (storage_media != null)
            {
                switch (choice)
                {
                    case 0:
                        XMLSerialize soap = new();
                        soap.Save(ref storage_media);
                        break;
                    case 1:
                        JSONSerialize json_serializer = new();
                        json_serializer.Save(ref storage_media);
                        break;
                    case 2:
                        SoapSerialize soap_serialize = new();
                        soap_serialize.Save(ref storage_media);
                        break;
                }
            }
        }

        public void Load()
        {
            Console.Write("0 - завантажити XML\n1 - завантажити JSON\n2 - завантажити SOAP\nОберіть: ");
            string? temp_choice = Console.ReadLine();
            int choice = 0;
            if (temp_choice != null)
                choice = int.Parse(temp_choice);
            switch(choice)
            {
                case 0:
                    XMLSerialize soap = new();
                    soap.Load(ref storage_media);
                    break;
                case 1:
                    JSONSerialize json_serializer = new();
                    json_serializer.Load(ref storage_media);
                    break;
                case 2:
                    SoapSerialize soap_serialize = new();
                    soap_serialize.Load(ref storage_media);
                    break;
            }
        }

        public void Show()
        {
            if (storage_media != null)
            {
                Console.Clear();
                Console.Write("\n\t\t+---- Список носіїв інформвції ----+\n\n");
                foreach (var storage_medium in storage_media)
                    storage_medium.Print(1);
            }
        }
    }
}
