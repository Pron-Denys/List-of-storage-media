namespace XMLSerialize
{
    using ISerialize;
    using System.Xml.Serialization;
    public class XMLSerialize : ISerialize
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
}
