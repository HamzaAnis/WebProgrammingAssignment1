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
                WriteLine("6:Find the customers: ");
                WriteLine("7:Exit\n");

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
                        List<string> r_And_f = new List<string>();
                        WriteLine("1:Customer is new ");
                        WriteLine("2:Customer is old");
                        Write("\nEnter your choice: ");
                        string ch = ReadLine();
                        if (ch == "1")
                        {
                            string id = PC.CDataBase.AddCustomer();
                            r_And_f = PC.CDataBase.Reserve(id);
                        }

                        else
                        {
                            WriteLine("Enter your id No");
                            var id = ReadLine();
                            PC.CDataBase.Reserve(id);
                        }
                        //this will chane the status of the respective room
                        PC.reserveRoom(r_And_f);
                        break;
                    }
                    case "5":
                    {
                        PC.FindRoom();
                        break;
                    }
                    case "6":
                    {
                        PC.CDataBase.ShowCustomers();
//                        WriteLine("\nEnter the id of the customer: ");
//                        string id = ReadLine();
//                        PC.CDataBase.Reserve(id);
                        break;
                    }
                    case "7":
                    {
                        Application.Exit();
                        break;
                    }
                }
                WriteLine("\n\n");
            }
        }
    }


//!+Hotel Class Main
    public class Hotel : SystemException
    {
        public string floor;
        public string rooms;
        public List<Room> RoomDataBase = new List<Room>();
        public CustomerData CDataBase = new CustomerData();


        public Hotel(string floor, string rooms)
        {
            Floor = floor;
            Rooms = rooms;
        }

        public Hotel()
        {
            //On every start read the hotel data
            ReadRoomData();
            //The data of the customers are read in the constructor of the CustomerData
            //Read the Customer Database
//        CDataBase.ReadData();
        }

        //reading data of the rooms
        public void ReadRoomData()
        {
            RoomDataBase =
                ReadFromXml(
                    "c:\\Users\\hamza\\Source\\Repos\\WebProgrammingAssignment1\\WebAssignment1\\roomDetails.xml");
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
            WritetoXml(list,
                "c:\\Users\\hamza\\Source\\Repos\\WebProgrammingAssignment1\\WebAssignment1\\roomDetails.xml");
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
                    foreach (var room in RoomDataBase)
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
//                WriteLine("Index is {0}", index);
                    WriteLine("The floor number {0} with room no {1} " +
                              "is {2}", this.RoomDataBase[index].floorNo, this.RoomDataBase[index].roomNO,
                        this.RoomDataBase[index].type);
                    if (!this.RoomDataBase[index].isBooked)
                    {
                        WriteLine("Status: Not Reserved ");
                    }
                    else
                    {
                        WriteLine("Status: Reserved");
                    }

                    break;
                }
            }
        }

        public void reserveRoom(List<string> a)
        {
            int num = int.Parse(a[0]);
            num--;
            int num1 = int.Parse(a[1]);
            num1--;
            int index = 0;
            index = num * int.Parse(this.Floor) + num1;

            var tempToChange = RoomDataBase[index];
            tempToChange.isBooked = true;
            //will write all the data of the rooms in the file
            WritetoXml(RoomDataBase, "c:\\Users\\hamza\\Source\\Repos\\WebProgrammingAssignment1\\WebAssignment1\\roomDetails.xml");
        }

        public static void WritetoXml(List<Room> rooms, string filePath)
        {
            var xls = new XmlSerializer(typeof(List<Room>));
            TextWriter tw = new StreamWriter(filePath);
            xls.Serialize(tw, rooms);
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
        private readonly Dictionary<string, Customer> CData = new Dictionary<string, Customer>();

        //+On every start of the project the data of the customers will be loaded
        public CustomerData()
        {
            List<Customer> c = ReadData();
            foreach (var entry in c)
            {
                CData.Add(entry.IdCard, entry);
            }
        }


        public string AddCustomer()
        {
            //--this will be added in the dictionary
            var temp = new Customer();
            Write("Enter name : ");
            temp.FullName = Console.ReadLine();
            Write("\nEnter age: ");
            temp.Age = ReadLine();
            Write("\nEnter Gender: ");
            temp.Gender = ReadLine();
            Write("\nEnter ID Card no: ");
            temp.IdCard = ReadLine();
            Write("\nEnter balance in Rs: ");
            temp.Balance = ReadLine();
            temp.CheckInTime = DateTime.Now;
            if (temp.ReserveDays != null)
                temp.CheckOutTime = temp.CheckInTime.AddHours(int.Parse(temp.ReserveDays) * 24);
            //-the checkout time will be from the checking in time + number of days to reserve

            if (!CData.ContainsKey(temp.IdCard))
                CData.Add(temp.IdCard, temp);
            else WriteLine("Customer with this Id already exists ");

            WriteCustomer();
            return temp.IdCard;
        }


        //-It will reserve the room for a person
        public List<string> Reserve(string id)
        {
            List<string> reserveData = new List<string>();
            if (CData.ContainsKey(id))
            {
                var details = CData[id];
                WriteLine("Name is {0}", details.FullName);
                WriteLine("Age is {0}", details.Age);
                WriteLine("Id Card No is {0}", details.IdCard);
                WriteLine("Balance is {0}", details.Balance);
                WriteLine("Total days to reserve is {0}", details.ReserveDays);
                WriteLine("Room floor is {0}", details.FloorNo);
                WriteLine("Room type is {0}", details.RoomType);
                WriteLine("Room Number is {0}", details.RoomNumber);
                WriteLine("Check in time is {0}", details.CheckInTime);
                WriteLine("Checkout time is {0}", details.CheckOutTime);

                double hours = (details.CheckOutTime - details.CheckInTime).TotalHours;
                if (hours > 0)
                {
                    int days = (int) hours / 24;
                    double hrRemaing = hours - days * 24;
                    WriteLine("Total time remaining is {0} days and {1} hours ", days, hrRemaing);
                }


                //-The process of reserving a room
                Write("\nEnter the number of days to reserve: ");
                details.ReserveDays = ReadLine();

                //initializing the check out time
                if (details.ReserveDays != null)
                    details.CheckOutTime = details.CheckInTime.AddHours(int.Parse(details.ReserveDays) * 24);

                Write("\nEnter Floor no: ");
                details.FloorNo = ReadLine();
                //Room types
                Write("\nSelect Room type: ");
                WriteLine("\n1:Standard ");
                WriteLine("\n2:Moderate ");
                WriteLine("\n3:Superior ");
                WriteLine("\n4:Junior Suite ");
                WriteLine("\n5:Suite ");
                string choice = ReadLine();
                if (choice == "1")
                    details.RoomType = "Standard";
                if (choice == "2")
                    details.RoomType = "Moderate";
                if (choice == "3")
                    details.RoomType = "Superior";
                if (choice == "4")
                    details.RoomType = "Junior Suite";
                if (choice == "5")
                    details.RoomType = "Suite";


                //to display 
                Write("\nEnter Room no: ");
                WriteLine("The rooms available are: ");
                details.RoomNumber = ReadLine();

                //storing the data
                reserveData.Add(details.FloorNo);
                reserveData.Add(details.RoomNumber);
            }
            else
                WriteLine("\n\tDetails not found ");

            WriteCustomer(); // will add the customer
            return reserveData;
        }

        //-Helping function to show all the customers
        public void ShowCustomers()
        {
            foreach (var entry in CData)
            {
                var details = entry.Value;
                WriteLine("Name is {0}", details.FullName);
                WriteLine("Age is {0}", details.Age);
                WriteLine("Id Card No is {0}", details.IdCard);
                WriteLine("Balance is {0}", details.Balance);
                WriteLine("Total days to reserve is {0}", details.ReserveDays);
                WriteLine("Room floor is {0}", details.FloorNo);
                WriteLine("Room type is {0}", details.RoomType);
                WriteLine("Room Number is {0}", details.RoomNumber);
                WriteLine("Check in time is {0}", details.CheckInTime);
                WriteLine("Checkout time is {0}", details.CheckOutTime);
                double hours = (details.CheckOutTime - DateTime.Now).TotalHours;
                if (hours > 0)
                {
                    int days = (int) hours / 24;
                    int hrRemaing = (int) hours - days * 24;
//                int minutes = days*24*60-hrRemaing*2
                    WriteLine("Total time remaining is {0} days and {1} hours ", days, hrRemaing);
                }
                else
                {
                    WriteLine("The reservation period is ended ");
                }
                WriteLine("\n");
            }
        }

        //Add the details of the customer to the xml file
        public void WriteCustomer()
        {
            var xls = new XmlSerializer(typeof(List<Customer>));
            TextWriter tw =
                new StreamWriter(
                    "c:\\Users\\hamza\\Source\\Repos\\WebProgrammingAssignment1\\WebAssignment1\\Customer_Details.xml");

            List<Customer> temp = new List<Customer>();
            foreach (var entry in CData)
            {
                temp.Add(entry.Value);
            }
            xls.Serialize(tw, temp);

            tw.Close();
        }

        //It reads the data from the xml to the objects
        public List<Customer> ReadData()
        {
            var deserializer = new XmlSerializer(typeof(List<Customer>));
            TextReader tr =
                new StreamReader(
                    "c:\\Users\\hamza\\Source\\Repos\\WebProgrammingAssignment1\\WebAssignment1\\Customer_Details.xml");
            List<Customer> temp = (List<Customer>) deserializer.Deserialize(tr);
            tr.Close();

            return temp;
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
        private string fullName;
        private string age;
        private string gender;
        private string idCard;
        private string balance;
        private string reserveDays;
        private string floorNo;
        private string roomType;
        private string roomNumber;
        private DateTime checkInTime;
        private DateTime checkOutTime;
        private DateTime timeRemaining;

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

        public DateTime CheckInTime
        {
            get { return checkInTime; }

            set { checkInTime = value; }
        }

        public DateTime CheckOutTime
        {
            get { return checkOutTime; }

            set { checkOutTime = value; }
        }

        public DateTime TimeRemaining
        {
            get { return timeRemaining; }

            set { timeRemaining = value; }
        }

        public Customer()
        {
        }
    }
}