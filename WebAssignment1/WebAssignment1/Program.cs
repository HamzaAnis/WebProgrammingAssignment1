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

  
        }

        void displayMenu()
        {
            Console.WriteLine("Welcome to the Hotel Management System");
            Console.WriteLine("1:");
        }

    }
}

class Hotel
{
    private int floor;
    private int rooms;


    public Hotel(int floor, int rooms)
    {
        this.floor = floor;
        this.rooms = rooms;
    }
}

class Room
{
    private bool isBooked;
    private string bool
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
        get
        {
            return isBooked;
        }

        set
        {
            isBooked = value;
        }
    }

    public string RoomNO
    {
        get
        {
            return roomNO;
        }

        set
        {
            roomNO = value;
        }
    }

    public string Type
    {
        get
        {
            return type;
        }

        set
        {
            type = value;
        }
    }
}

class standard : Room
{
    private int price;

    //+Will call the super constructor 
    public standard( bool isBooked, string roomNo, string type) : base(isBooked, roomNo, type)
    {
        this.price = 300;
    }
}

class moderate : Room
{
    private int price;

    //+Will call the super constructor 
    public moderate( bool isBooked, string roomNo, string type) : base(isBooked, roomNo, type)
    {
        this.price = 500;
    }
}
class superior : Room
{
    private int price;

    //+Will call the super constructor 
    public superior( bool isBooked, string roomNo, string type) : base(isBooked, roomNo, type)
    {
        this.price = 1000;
    }
}
class juniorSuite : Room
{
    private int price;

    //+Will call the super constructor 
    public juniorSuite(bool isBooked, string roomNo, string type) : base(isBooked, roomNo, type)
    {
        this.price = 1000;
    }
}
class suite : Room
{
    private int price;

    //+Will call the super constructor 
    public suite(bool isBooked, string roomNo, string type) : base(isBooked, roomNo, type)
    {
        this.price = 5000;
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
    public Customer(string fullName, string age, string gender, string idCard, string balance, string reserveDays, string floorNo, string roomType, string roomNumber, string checkOutTime, string checkInTime, string timeRemaining)
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
        get
        {
            return fullName;
        }

        set
        {
            fullName = value;
        }
    }

    public string Age
    {
        get
        {
            return age;
        }

        set
        {
            age = value;
        }
    }

    public string Gender
    {
        get
        {
            return gender;
        }

        set
        {
            gender = value;
        }
    }

    public string IdCard
    {
        get
        {
            return idCard;
        }

        set
        {
            idCard = value;
        }
    }

    public string Balance
    {
        get
        {
            return balance;
        }

        set
        {
            balance = value;
        }
    }

    public string ReserveDays
    {
        get
        {
            return reserveDays;
        }

        set
        {
            reserveDays = value;
        }
    }

    public string FloorNo
    {
        get
        {
            return floorNo;
        }

        set
        {
            floorNo = value;
        }
    }

    public string RoomType
    {
        get
        {
            return roomType;
        }

        set
        {
            roomType = value;
        }
    }

    public string RoomNumber
    {
        get
        {
            return roomNumber;
        }

        set
        {
            roomNumber = value;
        }
    }

    public string CheckOutTime
    {
        get
        {
            return checkOutTime;
        }

        set
        {
            checkOutTime = value;
        }
    }

    public string CheckInTime
    {
        get
        {
            return checkInTime;
        }

        set
        {
            checkInTime = value;
        }
    }

    public string TimeRemaining
    {
        get
        {
            return timeRemaining;
        }

        set
        {
            timeRemaining = value;
        }
    }


}

