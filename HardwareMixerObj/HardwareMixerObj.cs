using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
namespace HardwareMixerObj
{

    //PC PROGRAM DATA

    [Serializable]
    public class PCData
    {
        public List<ProgramData> Programs;
        public DefaultDevice defaultDevice;   
    }
    [Serializable]
    public class DefaultDevice
    {
        public string Name;
        public Bitmap Icon;
        public int Volume;
        public bool IsMute;
        
    }
    [Serializable]
    public class ProgramData
    {
        public Bitmap Icon;
        public string Name;
        public int PID;
        public int Volume;
        public bool IsMute;
        public bool Null;
    }


    //RASPBERRY PI PROGRAM DATA
    [Serializable]
    public class RPIDefaultDevice
    {
        public int Volume;
        public bool IsMute;
        public bool ChangeDevice;
        public bool Changed;
    }
    [Serializable]
    public class RPIProgramData
    {
        public int PID;
        public int Volume;
        public bool IsMute;
        public bool ChangeDevice;
        public bool Changed;
        public bool Null;
    }
   
    [Serializable]
    public class RPIData
    {
        public List<RPIProgramData> Programs;
        public RPIDefaultDevice DefaultDevice;
    }
    

}
namespace SerializeData
{
    public class Serialize
    {
        public static byte[] SerializeToByteArray(object request)
        {
            byte[] result;
            BinaryFormatter serializer = new BinaryFormatter();
            using (MemoryStream memStream = new MemoryStream(new byte[512], 0, 512, true, true))
            {
                memStream.Seek(0, SeekOrigin.Begin);
                serializer.Serialize(memStream, request);
                result = memStream.GetBuffer();
            }
            return result;
        }
        public static T DeserializeFromByteArray<T>(byte[] buffer)
        {
            BinaryFormatter deserializer = new BinaryFormatter();
            using (MemoryStream memStream = new MemoryStream(buffer))
            {
                memStream.Seek(0, SeekOrigin.Begin);
                object newobj = deserializer.Deserialize(memStream);
                return (T)newobj;
            }
        }
    }
}