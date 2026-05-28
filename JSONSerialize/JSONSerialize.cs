namespace JSONSerialize
{
    using ISerialize;
    using System.Runtime.Serialization.Json;
    public class JSONSerialize : ISerialize
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
}
