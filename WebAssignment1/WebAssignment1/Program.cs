using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAssignment1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Hotel PC = new Hotel("5", "10");
            PC.initializeRooms();
            
        }
    }
}

//+Testing
class Hotel
{
    private string floor;
    private string rooms;
    List< Room> r=new List<Room>();


    public Hotel(string floor, string rooms)
    {
        this.Floor = floor;
        this.Rooms = rooms;
    }

    public void initializeRooms()
    {
        Console.WriteLine("Welcome to the Hotel Management System");
        Console.WriteLine("Enter the room Details");
        Console.WriteLine("Enter the floor Number");
        string floor = Console.ReadLine();
        Console.WriteLine("Enter the room Number");
        string roomNo = Console.ReadLine();
    }

    public string Floor
    {
        get
        {
            return floor;
        }

        set
        {
            floor = value;
        }
    }

    public string Rooms
    {
        get
        {
            return rooms;
        }

        set
        {
            rooms = value;
        }
    }
}

class Room
{
    private bool isBooked;
    private string roomNO;
    private string type;

    public Room(bool isBooked, string roomNO, string type)
    {
        this.IsBooked = isBooked;
        this.RoomNO = roomNO;
        this.Type = type;
    }

    public bool IsBooked
    {
        get { return IsBooked1; }

        set { IsBooked1 = value; }
    }

    public string RoomNO
    {
        get { return RoomNO1; }

        set { RoomNO1 = value; }
    }

    public string Type
    {
        get { return Type1; }

        set { Type1 = value; }
    }

    public bool IsBooked1
    {
        get { return isBooked; }

        set { isBooked = value; }
    }

    public string RoomNO1
    {
        get { return roomNO; }

        set { roomNO = value; }
    }

    public string Type1
    {
        get { return type; }

        set { type = value; }
    }
}

class standard : Room
{
    private int price;

    //+Will call the super constructor 
    public standard(bool isBooked, string roomNo, string type) : base(isBooked, roomNo, type)
    {
        this.Price = 300;
    }

    public int Price
    {
        get { return price; }

        set { price = value; }
    }
}

class moderate : Room
{
    private int price;

    //+Will call the super constructor 
    public moderate(bool isBooked, string roomNo, string type) : base(isBooked, roomNo, type)
    {
        this.Price = 500;
    }

    public int Price
    {
        get { return price; }

        set { price = value; }
    }
}

class superior : Room
{
    private int price;

    //+Will call the super constructor 
    public superior(bool isBooked, string roomNo, string type) : base(isBooked, roomNo, type)
    {
        this.Price = 1000;
    }

    public int Price
    {
        get { return price; }

        set { price = value; }
    }
}

class juniorSuite : Room
{
    private int price;

    //+Will call the super constructor 
    public juniorSuite(bool isBooked, string roomNo, string type) : base(isBooked, roomNo, type)
    {
        this.Price = 1000;
    }

    public int Price
    {
        get { return price; }

        set { price = value; }
    }
}

class suite : Room
{
    private int price;

    //+Will call the super constructor 
    public suite(bool isBooked, string roomNo, string type) : base(isBooked, roomNo, type)
    {
        this.Price = 5000;
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

