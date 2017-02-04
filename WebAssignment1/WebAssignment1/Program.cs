using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using static System.Console;

namespace WebAssignment1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Initialize();
        }

        public static void Initialize()
        {
            var PC = new Hotel()
            {
                Floor = "5",
                Rooms = "50"
            };


            while(true)
            {
                //+Menu
                WriteLine("\t\t\t\t\t***********************");
                WriteLine("\t\t\t\t\tHotel Management system ");
                WriteLine("1:Re-initialize the rooms");             //--done
                WriteLine("2:Re-initialize the Customers");
                WriteLine("3:Reserve a Room");
                WriteLine("4:Checkout");
                WriteLine("5:Exit\n");

                string choice = ReadLine();

                switch (choice)
                {
                    case "1":
                    {
                        //Use when to reinitialize the data
                        Write("\n\tEnter the number of floors: ");
                        var floor = ReadLine();
                        Write("\tEnter the number of rooms: ");
                        var rooms = ReadLine();
                        PC.floor = floor;
                        PC.Rooms = rooms;
                        PC.MakeNewRooms();
                        break;
                    }
                    case "2":
                    {
                        break;
                    }
                    case "3":
                    {
                        WriteLine("1:Customer is new ");
                        WriteLine("Customer is old");
                        Write("\nEnter your choice: ");
                        string ch = ReadLine();
                        break;
                    }
                    case "5":
                        Application.Exit();
                        break;
                }
                WriteLine("\n\n");
            }
        }
    }
}

//!+Hotel Class Main
public class Hotel : SystemException
{
    public string floor;
    public string rooms;
    public List<Room> r = new List<Room>();
    public List<Customer> C = new List<Customer>();


    public Hotel(string floor, string rooms)
    {
        Floor = floor;
        Rooms = rooms;
    }

    public Hotel()
    {
    }

    public void ReadRoomData()
    {

    }

    //+A function to make the .xml file  and to store data first time for the rooms
    public void MakeNewRooms()
    {
        var ab = new Room();
        var list = new List<Room>();
        WriteLine("pc data is {0} {1}", floor, rooms);


        for (var i = 1; i <= int.Parse(floor); i++)
        for (var j = 1; j <= int.Parse(rooms); j++)
        {
            var R = new Room();
            R.isBooked = false;
            R.floorNo = i.ToString();
            R.roomNO = j.ToString();
            //R.type="Hamza";
            if (j <= 10)
                R.type = "standard";
            if (j > 10 && j <= 20)
                R.type = "moderate";
            if ((j > 20) & (j <= 30))
                R.type = "superior";
            if ((j > 30) & (j <= 40))
                R.type = "j_suite";
            if ((j > 40) & (j <= 50))
                R.type = "suite";

            //-adding this to the list
            list.Add(R);
        }
        WriteLine("Rooms are re initialized");
        WritetoXml(list, "c:\\Users\\hamza\\Source\\Repos\\WebProgrammingAssignment1\\WebAssignment1\\roomDetails.xml");
    }

    public static void WritetoXml(List<Room> movies, string filePath)
    {
        var xls = new XmlSerializer(typeof(List<Room>));
        TextWriter tw = new StreamWriter(filePath);
        xls.Serialize(tw, movies);
        tw.Close();
    }

    public static List<Room> ReadFromXml(string filePath)
    {
        var deserializer = new XmlSerializer(typeof(List<Room>));
        TextReader tr = new StreamReader(@filePath);
        List<Room> movie;
        movie = (List<Room>) deserializer.Deserialize(tr);
        tr.Close();

        return movie;
    }

    public string Floor { get; set; }

    public string Rooms
    {
        get { return rooms; }

        set { rooms = value; }
    }
}

public class Room
{
    public string floorNo { get; set; }
    public string roomNO { get; set; }
    public string type { get; set; }
    public bool isBooked { get; set; }


    public Room(bool isBooked, string roomNO, string type)
    {
        isBooked = isBooked;
        roomNO = roomNO;
        type = type;
    }

    public Room()
    {
    }
}

internal class standard : Room
{
    private int price;

    //+Will call the super constructor 
    public standard(bool isBooked, string roomNo, string type) : base(isBooked, roomNo, type)
    {
        Price = 300;
    }

    public int Price
    {
        get { return price; }

        set { price = value; }
    }
}

public class moderate : Room
{
    private int price;

    //+Will call the super constructor 
    public moderate(bool isBooked, string roomNo, string type) : base(isBooked, roomNo, type)
    {
        Price = 500;
    }

    public int Price
    {
        get { return price; }

        set { price = value; }
    }
}

public class superior : Room
{
    private int price;

    //+Will call the super constructor 
    public superior(bool isBooked, string roomNo, string type) : base(isBooked, roomNo, type)
    {
        Price = 1000;
    }

    public int Price
    {
        get { return price; }

        set { price = value; }
    }
}

public class juniorSuite : Room
{
    private int price;

    //+Will call the super constructor 
    public juniorSuite(bool isBooked, string roomNo, string type) : base(isBooked, roomNo, type)
    {
        Price = 1000;
    }

    public int Price
    {
        get { return price; }

        set { price = value; }
    }
}

internal class suite : Room
{
    private int price;

    //+Will call the super constructor 
    public suite(bool isBooked, string roomNo, string type) : base(isBooked, roomNo, type)
    {
        Price = 5000;
    }

    public int Price
    {
        get { return price; }

        set { price = value; }
    }
}

public class Customer
{
    //++Attributes
    private string fullName { get; set; }
    private string age { get; set; }
    private string gender { get; set; }
    private string idCard { get; set; }
    private string balance { get; set; }
    private string reserveDays { get; set; }
    private string floorNo { get; set; }
    private string roomType { get; set; }
    private string roomNumber { get; set; }
    private string checkOutTime { get; set; }
    private string checkInTime { get; set; }
    private string timeRemaining { get; set; }


    //+Constructor
    public Customer(string fullName, string age, string gender, string idCard, string balance, string reserveDays,
        string floorNo, string roomType, string roomNumber, string checkOutTime, string checkInTime,
        string timeRemaining)
    {
        fullName = fullName;
        age = age;
        gender = gender;
        idCard = idCard;
        balance = balance;
        reserveDays = reserveDays;
        floorNo = floorNo;
        roomType = roomType;
        roomNumber = roomNumber;
        checkOutTime = checkOutTime;
        checkInTime = checkInTime;
        timeRemaining = timeRemaining;
    }
}