using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace w8t1
{
    class Bicycle
    {
        protected int cadence;
        protected int gear;
        protected int speed;

        public Bicycle(int cadence, int gear, int speed)
        {
            this.cadence = cadence;
            this.gear = gear;
            this.speed = speed;
        }

        public void setcadence(int cadence)
        {
            this.cadence = cadence;
        }

        public int getcadence()
        {
            return cadence;
        }
        public void setgear(int gear)
        {
            this.gear = gear;
        }
        public int getgear()
        {
            return gear;
        }

        public void speedUp(int increment)
        {
            this.speed += increment;
        }
        public void applyBrake(int decrement)
        {
            this.speed -= decrement;
        }
    }

    class MountainBike : Bicycle
    {
        protected int seatHeight;

        public MountainBike(int cadence, int gear, int speed, int seatHeight)
            : base(cadence, gear, speed)
        {
            this.seatHeight = seatHeight;
        }
        public void setseatHeight(int seatHeight)
        {
            this.seatHeight = seatHeight;
        }
        public int getseatHeight()
        {
            return seatHeight;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            MountainBike bike1 = new MountainBike(12, 34, 45, 66);
            Console.WriteLine("Candence:" + bike1.getcadence());
            Console.WriteLine("seatHeight:" + bike1.getseatHeight());
            Console.WriteLine("gear:" + bike1.getgear());
        }
    }
}