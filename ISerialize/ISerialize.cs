using System.Collections;

namespace ISerialize
{
    public interface ISerialize
    {
        void Save<T>(ref T list);
        void Load<T>(ref T list);
    }
}
