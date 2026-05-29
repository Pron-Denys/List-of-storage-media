namespace PriceList
{
    using ISerialize;
    using Storage_Medium;
    using ILog;
    using ConsoleLog;
    using System.Runtime.Serialization;

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

        public void Add(Storage_Medium obj)
        {
            storage_media?.Add(obj);
        }

        public void Remove(string name, string model)
        {
            List<Storage_Medium> list = new();
            if (storage_media != null)
                foreach(var storage_medium in storage_media)
                {
                    if ((storage_medium.Name != name) && (storage_medium.Model != model))
                        list.Add(storage_medium);
                }
            storage_media = list;
        }

        public void Search(ILog obj, string name, string model)
        {
            if (storage_media != null)
                foreach (var storage_medium in storage_media)
                {
                    if ((storage_medium.Name == name) && (storage_medium.Model == model))
                        storage_medium.Print(obj);
                }
        }

        public void Edit(Storage_Medium obj, string name, string model)
        {
            List<Storage_Medium> list = new();
            if (storage_media != null)
                foreach (var storage_medium in storage_media)
                {
                    if ((storage_medium.Name == name) && (storage_medium.Model == model))
                    {
                        list.Add(obj);
                        continue;
                    }
                    list.Add(storage_medium);
                }
            storage_media = list;
        }

        public void Save(ISerialize obj)
        {
            if (storage_media != null)
                obj.Save<List<Storage_Medium>>(ref storage_media);
        }

        public void Load(ISerialize obj)
        {
            obj.Load<List<Storage_Medium>?>(ref storage_media);
        }

        public void Show(ILog obj)
        {
            if (storage_media != null)
            {
                Console.Write("\n\t\t+---- Список носіїв інформації ----+\n\n");
                foreach (var storage_medium in storage_media)
                    storage_medium.Print(obj);
            }
        }
    }
}
