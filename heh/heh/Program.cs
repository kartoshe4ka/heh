using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;

namespace heh
{
    [Serializable]
    public class Person
    {
        
        public string Name { get; set; }
        public int Age { get; set; }

        public Person() { }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
        Person test = new Person("Давид", 19);
            BinaryFormatter form = new BinaryFormatter();
            XmlSerializer xform = new XmlSerializer(typeof(Person));
            using (FileStream xml = new FileStream("Person.xml", FileMode.OpenOrCreate))
            {
                xform.Serialize(xml, test);
            }
            using(FileStream fs = new FileStream("Person.dat", FileMode.OpenOrCreate))
            {
                form.Serialize(fs, test);
            }
            Person test2;

            using (FileStream fs = new FileStream("Person.dat", FileMode.Open))
            {
                test2 = (Person)form.Deserialize(fs);
                Console.WriteLine(test2.Name + " " + test2.Age);
            }
        }
    }
}

