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
    }

    class Hotel
    {
        

        public Hotel(int floor, int rooms)
        {
            this.floor = floor;
            this.rooms = rooms;
        }
    }

    class Room
    {
        private bool isBooked;
        private string roomNO;
        private string type;




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
}
