using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAssignment1
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Customer
    {
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

        public Customer(string fullName, string age, string gender, string idCard, string balance, string reserveDays, string floorNo, string roomType, string roomNumber, string checkOutTime, string checkInTime, string timeRemaining)
        {
            this.fullName = fullName;
            this.age = age;
            this.gender = gender;
            this.idCard = idCard;
            this.balance = balance;
            this.reserveDays = reserveDays;
            this.floorNo = floorNo;
            this.roomType = roomType;
            this.roomNumber = roomNumber;
            this.checkOutTime = checkOutTime;
            this.checkInTime = checkInTime;
            this.timeRemaining = timeRemaining;
        }

    }
}
