using System.Xml;

class Dogs
{
    public static List<Dog> DogList = new List<Dog>();

    public static void Add(Dog d)
    {
        DogList.Add(d);
    }

    public static void Show()
    {
        foreach (Dog d in DogList)
        {
            d.PrintToConsole();
        }
    }
}

class Dog
{
    public string DogName { get; private set; }
    public int DogWeight { get; private set; }
    public string DogColor { get; private set; }

    public Dog(string dogName, int dogWeight, string dogColor)
    {
        DogName = dogName;
        DogWeight = dogWeight;
        DogColor = dogColor;
    }

    public void PrintToConsole()
    {
        Console.WriteLine($"Кличка:{DogName}");
        Console.WriteLine($"Вага:{DogWeight} кг");
        Console.WriteLine($"Колiр:{DogColor}");
    }
}
class Program
{
    static void Main(string[] args)
    {
        XmlDocument xml = new XmlDocument();
        xml.Load(@"D:\xmlfile1.xml");

        foreach (XmlNode node in xml.DocumentElement.ChildNodes)
        {
            string dogName = node["dogName"].InnerText;
            int dogWeight = Int32.Parse(node["dogWeight"].InnerText);
            string dogColor = node["dogColor"].InnerText;

            Dogs.Add(new Dog(dogName, dogWeight, dogColor));
        }

        Dogs.Show();
    }
}