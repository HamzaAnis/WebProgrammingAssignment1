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


            while (true)
            {
                //+Menu
                WriteLine("\t\t\t\t\t***********************");
                WriteLine("\t\t\t\t\tHotel Management system ");
                WriteLine("1:Re-initialize the rooms"); //--done
                WriteLine("2:Re-initialize the Customers");
                WriteLine("3:Reserve a Room");
                WriteLine("4:Checkout");
                WriteLine("5:Check the rooms");
                WriteLine("6:Exit\n");

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
                        WriteLine("2:Customer is old");
                        Write("\nEnter your choice: ");
                        string ch = ReadLine();
                        if (ch == "1")
                            PC.CDataBase.AddCustomer();
                        else
                        {
                            WriteLine("Enter your id No");
                            var id = ReadLine();
                            PC.CDataBase.CustomerDetails(id);
                        }
                        break;
                    }
                    case "5":
                    {
                        PC.FindRoom();
                        break;
                    }
                    case "6":
                    {
                        Application.Exit();
                        break;
                    }
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
    public CustomerData CDataBase = new CustomerData();


    public Hotel(string floor, string rooms)
    {
        Floor = floor;
        Rooms = rooms;
    }

    public Hotel()
    {
        ReadRoomData();
    }

    //reading data of the rooms
    public void ReadRoomData()
    {
        r = ReadFromXml("c:\\Users\\hamza\\Source\\Repos\\WebProgrammingAssignment1\\WebAssignment1\\roomDetails.xml");
    }

    //+A function to make the .xml file  and to store data first time for the rooms
    public void MakeNewRooms()
    {
        var ab = new Room();
        var list = new List<Room>();
//        WriteLine("pc data is {0} {1}", floor, rooms);


        for (var i = 1; i <= int.Parse(floor); i++)
        for (var j = 1; j <= int.Parse(rooms); j++)
        {
            var R = new Room();
            R.isBooked = false; //--every room will be not book
            R.floorNo = i.ToString();
            R.roomNO = j.ToString();

            if (j <= 10)
                R.type = "Standard";
            if (j > 10 && j <= 20)
                R.type = "Moderate";
            if ((j > 20) & (j <= 30))
                R.type = "Superior";
            if ((j > 30) & (j <= 40))
                R.type = "Junior Suite";
            if ((j > 40) & (j <= 50))
                R.type = "Suite";

            //-adding this to the list
            list.Add(R);
        }
        WriteLine("Rooms are re initialized");
        WritetoXml(list, "c:\\Users\\hamza\\Source\\Repos\\WebProgrammingAssignment1\\WebAssignment1\\roomDetails.xml");
    }

    public void FindRoom()
    {
        WriteLine("\n\t1:To see all rooms: ");
        Write("\t2:To see specific room: ");
        string cho = ReadLine();

        switch (cho)
        {
            case "1":
            {
                foreach (var room in r)
                {
                    WriteLine(room.floorNo);
                    WriteLine(room.roomNO);
                    WriteLine(room.isBooked);
                    WriteLine(room.type);
                    WriteLine("\n\n");
                }
                break;
            }
            case "2":
            {
                Write("\n\t\tEnter the floor No: ");
                string f = ReadLine();
                Write("\t\tEnter the room No: ");
                string r = ReadLine();

                //Indexing in the list
                int num = int.Parse(f);
                num--;
                int num1 = int.Parse(r);
                num1--;
                int index = 0;
                if (num1 < int.Parse(this.Rooms))
                    index = num * int.Parse(this.Floor) + num1; //these are the floor in hotel

                //+Indexing
                WriteLine(index);
                WriteLine("Index is {0}", index);
                WriteLine("The floor number {0} with room no {1} " +
                          "is {2}", this.r[index].floorNo, this.r[index].roomNO, this.r[index].type);
                if (!this.r[index].isBooked)
                {
                    WriteLine("Staus: Not Reserved ");
                }
                else
                {
                    WriteLine("Status: Reserved");
                }

                break;
            }
        }
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
        var temp = (List<Room>) deserializer.Deserialize(tr);
        tr.Close();

        return temp;
    }

    public string Floor { get; set; }

    public string Rooms { get; set; }
}

public class CustomerData
{
    private readonly Dictionary<string, Customer> cData = new Dictionary<string, Customer>();

    public void AddCustomer()
    {
        //--this will be added in the dictionary
        var temp = new Customer();
        Write("Enter name : ");
        temp.FullName = Console.ReadLine();
        Write("\nEnter age: ");
        temp.Age = ReadLine();
        Write("\nEnter Gender: ");
        temp.Gender = ReadLine();
        Write("\nEnter ID no: ");
        temp.Id = ReadLine();
        Write("\nEnter balance in Rs: ");
        temp.Balance = ReadLine();
        Write("\nEnter Floor no: ");
        temp.FloorNo = ReadLine();
        Write("\nEnter Room type: ");
        temp.RoomType = ReadLine();
        Write("\nEnter Room no: ");
        temp.RoomNumber = ReadLine();
        cData.Add(temp.Id, temp);
    }

    public void CustomerDetails(string id)
    {
        if (cData.ContainsKey(id))
        {
            var details = cData[id];
        }
        else
            WriteLine("\n\tDetails not found ");
    }

    public void ReadData()
    {
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

public class standard : Room
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

public class suite : Room
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

    //++Attributes
    private string _timeRemaining;
    private string id;
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

    private string timeRemaining
    {
        get { return TimeRemaining; }
        set { TimeRemaining = value; }
    }

    public string Id
    {
        get { return id; }

        set { id = value; }
    }

    public string FullName
    {
        get { return fullName; }

        set { fullName = value; }
    }

    public string Age
    {
        get { return age; }

        set { age = value; }
    }

    public string Gender
    {
        get { return gender; }

        set { gender = value; }
    }

    public string IdCard
    {
        get { return idCard; }

        set { idCard = value; }
    }

    public string Balance
    {
        get { return balance; }

        set { balance = value; }
    }

    public string ReserveDays
    {
        get { return reserveDays; }

        set { reserveDays = value; }
    }

    public string FloorNo
    {
        get { return floorNo; }

        set { floorNo = value; }
    }

    public string RoomType
    {
        get { return roomType; }

        set { roomType = value; }
    }

    public string RoomNumber
    {
        get { return roomNumber; }

        set { roomNumber = value; }
    }

    public string CheckOutTime
    {
        get { return checkOutTime; }

        set { checkOutTime = value; }
    }

    public string CheckInTime
    {
        get { return checkInTime; }

        set { checkInTime = value; }
    }

    public string TimeRemaining
    {
        get { return _timeRemaining; }

        set { _timeRemaining = value; }
    }

    public Customer()
    {
    }
}