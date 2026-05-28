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

        public Storage_Medium()
        {
            Name = "";
            Model = "";
            Item_Name = "";
            Capacity = 0;
            Quantity = 0;
        }

        public Storage_Medium(string name, string model, string item_name, int capacity, int quantity)
        {
            Name = name;
            Model = model;
            Item_Name = item_name;
            Capacity = capacity;
            Quantity = quantity;
        }

        public virtual void Print(ILog obj)
        {
            if (Name != null && Model != null && Item_Name != null)
            {
                obj.Print([Item_Name, " ", Name, " ", Model, " Capacity: ", Capacity.ToString(), " Quantity: ", Quantity.ToString()]);
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
            : base()
        {
            USB_Speed = 0;
        }

        public FlashMemory(string name, string model, string item_name, int capacity, int usb_speed, int quantity)
            : base(name, model, item_name, capacity, quantity)
        {
            USB_Speed = usb_speed;
        }
        public override void Print(ILog obj)
        {
            if (Name != null && Model != null && Item_Name != null)
            {
                obj.Print([Item_Name, " ", Name, " ", Model, " Capacity: ", Capacity.ToString(), " Quantity: ", Quantity.ToString(), " USB Speed: ", USB_Speed.ToString()]);
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
            : base()
        {
            Write_Speed = 0;
        }

        public DVD_Disc(string name, string model, string item_name, int capacity, double write_speed, int quantity)
            : base(name, model, item_name, capacity, quantity)
        {
            Write_Speed = write_speed;
        }

        public override void Print(ILog obj)
        {
            if (Name != null && Model != null && Item_Name != null)
            {
                obj.Print([Item_Name, " ", Name, " ", Model, " Capacity: ", Capacity.ToString(), " Quantity: ", Quantity.ToString(), " Write Speed: ", Write_Speed.ToString()]);
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
            : base()
        {
            Spindle_Speed = 0;
        }

        public Removable_HDD(string name, string model, string item_name, int capacity, int spindle_speed, int quantity)
            : base(name, model, item_name, capacity, quantity)
        {
            Spindle_Speed = spindle_speed;
        }

        public override void Print(ILog obj)
        {
            if (Name != null && Model != null && Item_Name != null)
            {
                obj.Print([Item_Name, " ", Name, " ", Model, " Capacity: ", Capacity.ToString(), " Quantity: ", Quantity.ToString(), " Spindle Speed: ", Spindle_Speed.ToString()]);
            }
        }
    }
}
