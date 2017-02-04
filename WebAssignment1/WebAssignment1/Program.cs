using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebAssignment1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of floors");
            var floor = Console.ReadLine();
            Console.WriteLine("Enter the number of rooms");
            var rooms = Console.ReadLine();
            var PC = new Hotel(floor, rooms);
            PC.MakeNewRooms();
        }
    }
}

internal class Hotel : SystemException
{
    private string floor;
    private string rooms;
    private List<Room> r = new List<Room>();


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


    public Hotel(string floor, string rooms)
    {
        Floor = floor;
        Rooms = rooms;
    }

    //+A function to make the xml file to store data first time for the rooms
    public void MakeNewRooms()
    {
        var ab = new Room();
        var list = new List<Room>();

        for (int i = 1; i <= int.Parse(floor); i++)
        for (int j = 1; j <= int.Parse(rooms); j++)
        {
            var R = new Room();
            R.isBooked = false;
            R.floorNo = i.ToString();
            R.roomNO = j.ToString();
                //R.type="Hamza";
            if (j <= 10)
                R.type = "standard";
            if ( j>10 && j <= 20)
                R.type = "moderate";
            if (j >20 & j <= 30)
                R.type = "superior";
            if (j > 30 & j <=40)
                R.type = "j_suite";
            if (j > 40 & j <= 50)
                R.type = "suite";

            //-adding this to the list
            list.Add(R);
        }
        Console.ReadLine();

        WritetoXml(list, "c:\\Users\\hamza\\Source\\Repos\\WebProgrammingAssignment1\\WebAssignment1\\roomDetails.xml");
    }

    public string Floor
    {
        get { return floor; }

        set { floor = value; }
    }

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

internal class moderate : Room
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

internal class superior : Room
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

internal class juniorSuite : Room
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

internal class Customer
{
    //++Attributes
    private string fullName;
    private string age;
    private string gender;
    private string idCard;
    private string balance;
    private string reserveDays;
    private string floorNo;
    private string roomType;
    private string roomNumber;
    private string checkOutTime;
    private string checkInTime;
    private string timeRemaining;


    //+Constructor
    public Customer(string fullName, string age, string gender, string idCard, string balance, string reserveDays,
        string floorNo, string roomType, string roomNumber, string checkOutTime, string checkInTime,
        string timeRemaining)
    {
        FullName = fullName;
        Age = age;
        Gender = gender;
        IdCard = idCard;
        Balance = balance;
        ReserveDays = reserveDays;
        FloorNo = floorNo;
        RoomType = roomType;
        RoomNumber = roomNumber;
        CheckOutTime = checkOutTime;
        CheckInTime = checkInTime;
        TimeRemaining = timeRemaining;
    }

    //+Containers
    public string FullName
    {
        get { return FullName1; }

        set { FullName1 = value; }
    }

    public string Age
    {
        get { return Age1; }

        set { Age1 = value; }
    }

    public string Gender
    {
        get { return Gender1; }

        set { Gender1 = value; }
    }

    public string IdCard
    {
        get { return IdCard1; }

        set { IdCard1 = value; }
    }

    public string Balance
    {
        get { return Balance1; }

        set { Balance1 = value; }
    }

    public string ReserveDays
    {
        get { return ReserveDays1; }

        set { ReserveDays1 = value; }
    }

    public string FloorNo
    {
        get { return FloorNo1; }

        set { FloorNo1 = value; }
    }

    public string RoomType
    {
        get { return RoomType1; }

        set { RoomType1 = value; }
    }

    public string RoomNumber
    {
        get { return RoomNumber1; }

        set { RoomNumber1 = value; }
    }

    public string CheckOutTime
    {
        get { return CheckOutTime1; }

        set { CheckOutTime1 = value; }
    }

    public string CheckInTime
    {
        get { return CheckInTime1; }

        set { CheckInTime1 = value; }
    }

    public string TimeRemaining
    {
        get { return TimeRemaining1; }

        set { TimeRemaining1 = value; }
    }

    public string FullName1
    {
        get { return fullName; }

        set { fullName = value; }
    }

    public string Age1
    {
        get { return age; }

        set { age = value; }
    }

    public string Gender1
    {
        get { return gender; }

        set { gender = value; }
    }

    public string IdCard1
    {
        get { return idCard; }

        set { idCard = value; }
    }

    public string Balance1
    {
        get { return balance; }

        set { balance = value; }
    }

    public string ReserveDays1
    {
        get { return reserveDays; }

        set { reserveDays = value; }
    }

    public string FloorNo1
    {
        get { return floorNo; }

        set { floorNo = value; }
    }

    public string RoomType1
    {
        get { return roomType; }

        set { roomType = value; }
    }

    public string RoomNumber1
    {
        get { return roomNumber; }

        set { roomNumber = value; }
    }

    public string CheckOutTime1
    {
        get { return checkOutTime; }

        set { checkOutTime = value; }
    }

    public string CheckInTime1
    {
        get { return checkInTime; }

        set { checkInTime = value; }
    }

    public string TimeRemaining1
    {
        get { return timeRemaining; }

        set { timeRemaining = value; }
    }
}