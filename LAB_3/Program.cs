using System;
using System.Collections.Generic;
using System.Xml;

class Staff
{
    public string Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string NickName { get; private set; }
    public int Salary { get; private set; }

    public Staff(string id, string firstname, string lastname, string nickname, int salary)
    {
        Id = id;
        FirstName = firstname;
        LastName = lastname;
        NickName = nickname;
        Salary = salary;
    }

    public void PrintToConsole()
    {
        Console.WriteLine($"Робiтник:{Id}");
        Console.WriteLine($"IМ’Я:{FirstName}");
        Console.WriteLine($"Фамiлiя:{LastName}");
        Console.WriteLine($"НiкНейм:{NickName}");
        Console.WriteLine($"Зарплата:{Salary}");
    }
}

class Company
{
    public static List<Staff> StaffList = new List<Staff>();

    public static void Add(Staff s)
    {
        StaffList.Add(s);
    }

    public static void Show()
    {
        foreach (Staff i in StaffList)
        {
            i.PrintToConsole();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        XmlDocument xml = new XmlDocument();
        xml.Load(@"D:\xmlfile.xml");

        foreach (XmlNode node in xml.DocumentElement.ChildNodes)
        {
            string id = node.Attributes[0].InnerText;
            string firstname = node["firstname"].InnerText;
            string lastname = node["lastname"].InnerText;
            string nickname = node["nickname"].InnerText;
            int salary = Int32.Parse(node["salary"].InnerText);

            Company.Add(new Staff(id, firstname, lastname, nickname, salary));
        }

        Company.Show();
    }
}
