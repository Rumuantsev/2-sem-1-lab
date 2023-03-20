using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace Lab4
{
    [Serializable]
    class TextClass : IOriginator
    {
        public Dictionary<string, string> Content { get; set; }
        public List<string> FileName { get; set; }

        public TextClass()
        {
            Content = new Dictionary<string, string>();
            FileName = new List<string>();
        }
        public TextClass(string Content, string FileName)
        {
            this.Content.Add(FileName, Content);
            this.FileName.Add(FileName);
        }

        public void BinarySerialization(FileStream File)
        {
            BinaryFormatter BinarySerializer = new BinaryFormatter();
            BinarySerializer.Serialize(File, this);
            File.Flush();
            File.Close();
        }

        public void BinaryDeserialization(FileStream File)
        {
            BinaryFormatter BinaryDeserializer = new BinaryFormatter();
            TextClass Deserialized = (TextClass)BinaryDeserializer.Deserialize(File);
            Content = Deserialized.Content;
            FileName = Deserialized.FileName;
            File.Close();
        }

        public void XMLSerialization(FileStream File)
        {
            XmlSerializer XMLSerializer = new XmlSerializer(this.GetType());
            XMLSerializer.Serialize(File, this);
            File.Flush();
            File.Close();
        }

        public void XMLDeserialization(FileStream File)
        {
            XmlSerializer XMLSerializer = new XmlSerializer(this.GetType()); 
            TextClass Deserialized = (TextClass)XMLSerializer.Deserialize(File);
            Content = Deserialized.Content;
            FileName = Deserialized.FileName;
            File.Close();
        }
        object IOriginator.GetMemento()
        {
            return new Memento { Content = this.Content, FileName = this.FileName };
        }

        void IOriginator.SetMemento(object Memento)
        {
            if (Memento is Memento)
            {
                var TempMemento = Memento as Memento;
                Content = TempMemento.Content;
                FileName = TempMemento.FileName;
            }
        }
    }
}
