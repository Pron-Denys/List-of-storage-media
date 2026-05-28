namespace SoapSerialize
{
    using ISerialize;
    using System.Runtime.Serialization.Formatters.Soap;
    public class SoapSerialize : ISerialize
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
}
