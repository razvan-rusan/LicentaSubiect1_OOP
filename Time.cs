using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace SubiectLicenta1
{
    class Time()
    {
        int ore = 0, minute = 0, secunde = 0;

        public Time(int ore, int minute, int secunde) : this()
        {
            this.ore = ore;
            this.minute = minute;
            this.secunde = secunde;

            if (!Valideaza())
                throw new ArgumentException("Invalid!");
        }

        private bool Valideaza() => 
            ore >= 0 && ore < 24 && 
            minute >= 0 && minute < 60 && 
            secunde >= 0 && secunde < 60;

        public static bool operator==(Time t1, Time t2) =>
            t1.ore == t2.ore &&
            t1.minute == t2.minute &&
            t1.secunde == t2.secunde;

        public static bool operator!=(Time t1, Time t2) => !(t1 == t2);

        public static bool operator<(Time t1, Time t2) {
            if (t1.ore < t2.ore) return true; //12 < 13
            else if (t1.ore == t2.ore) //13:40:XX ? 13:40:YY
            {
                if (t1.minute < t2.minute) return true; //13:40 < 13:41
                else if (t1.minute > t2.minute) return false; //13:41 > 13:40
                else //13:40:XX ? 13:40:YY
                {
                    if (t1.secunde < t2.secunde) return true; //13:40:40 < 13:40:41
                    else return false; //13:40:40 < 13:40:41 
                }
            }
            return false; //14 > 13
        }

        public static bool operator>(Time t1, Time t2) => t2 < t1;

        public static bool operator<=(Time t1, Time t2) => t1 < t2 || t1 == t2;

        public static bool operator>=(Time t1, Time t2) => t1 < t2 || t1 == t2;

        public static Time operator+(Time t1, Time t2)
        {
            int ore = t1.ore + t2.ore;
            int minute = t1.minute + t2.minute;
            int secunde = t1.secunde + t2.secunde;
            if (secunde >= 60)
            {
                while (secunde >= 60) {
                    secunde -= 60;
                    minute++;
                }
            }
            if (minute >= 60)
            {
                while (minute >= 60)
                {
                    minute -= 60;
                    ore++;
                }
            }
            return new(ore, minute, secunde);
        }

        public override string ToString() => $"[ore: {ore}, minute: {minute}, secunde: {secunde}]";
    }
}
