using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SolarTestApp1
{
    [Serializable]
    public class Data2 : ISerializable
    {
        public Data2()
        {
            tasks = Records.Tasks;
        }
        public Data2(SerializationInfo sInfo, StreamingContext contextArg)
        {
            this.tasks = (List<Task>)sInfo.GetValue("tasks", typeof(List<Task>));
        }

        public void GetObjectData(SerializationInfo sInfo, StreamingContext contextArg)
        {
            sInfo.AddValue("tasks", this.tasks);
        }
        public List<Task> tasks = new List<Task>();
    }
    [Serializable]
    public class SerializableObject : ISerializable
    {
        private Data2 data2;
        public Data2 Data2
        {
            get { return this.data2; }
            set { this.data2 = value; }
        }
        public SerializableObject() { }
        public SerializableObject(SerializationInfo sInfo, StreamingContext contextArg)
        {
            this.data2 = (Data2)sInfo.GetValue("data2", typeof(Data2));
        }
        public void GetObjectData(SerializationInfo sInfo, StreamingContext contextArg)
        {
            sInfo.AddValue("data2", this.data2);
        }
    }
    public class MySerializer
    {
        public MySerializer() { }
        public void SerializeObject(string fileName, SerializableObject objToSerialize)
        {
            FileStream fstream = File.Open(fileName, FileMode.Create);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fstream, objToSerialize);
            fstream.Close();
        }
        public SerializableObject DeserializeObject(string fileName)
        {
            SerializableObject objToSerialize = null;
            FileStream fstream = File.Open(fileName, FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            objToSerialize = (SerializableObject)binaryFormatter.Deserialize(fstream);
            fstream.Close();
            return objToSerialize;
        }
    }
    class Files
    {
    }
}
