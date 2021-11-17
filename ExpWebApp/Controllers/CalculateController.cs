using System;

using Microsoft.AspNetCore.Mvc;

namespace ExpWebApp.Controllers
{
    public class CalculateController : Controller
    {
        [HttpPost]
        public ActionResult CalcDate(DateTime MyDate, int MyDays)
        {
            DateTime myNewDate = CalcNewDate(MyDate, MyDays);

            return Content(MyDate + " + " + MyDays + " days = " + myNewDate.Day + "/" + myNewDate.Month + "/" + myNewDate.Year);
        }

        public DateTime CalcNewDate(DateTime MyDate, int MyDays)
        {
            int MyDateYear = MyDate.Year;
            int MyDateMonth = MyDate.Month;
            int MyDateDay = MyDate.Day;

            int myTotalDays = MyDays;

            while (myTotalDays >= 365)
            {
                MyDateYear += 1;

                myTotalDays -= IsLeapYear(MyDateYear) ? 366 : 365;
            }

            while (myTotalDays > 0)
            {
                switch (MyDateMonth)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                        if (myTotalDays >= 31)
                        {
                            CalcMonth(ref myTotalDays, ref MyDateMonth, 31);
                        }
                        else
                        {
                            CalcDays(ref myTotalDays, ref MyDateDay);
                            if (MyDateDay > 31)
                            {
                                CalcDay(ref MyDateDay, ref MyDateMonth);
                            }
                        }
                        break;

                    case 12:
                        if (myTotalDays >= 31)
                        {
                            myTotalDays -= 31;
                            MyDateYear += 1;
                            MyDateMonth = 1;
                        }
                        else
                        {
                            CalcDays(ref myTotalDays, ref MyDateDay);
                            if (MyDateDay > 31)
                            {
                                MyDateDay = 1;
                                MyDateMonth = 1;
                                MyDateYear = 1;
                            }

                        }
                        break;

                    case 2:
                        if (IsLeapYear(MyDateYear))
                        {
                            if (myTotalDays >= 29)
                            {
                                CalcMonth(ref myTotalDays, ref MyDateMonth, 29);
                            }
                        }
                        else if (myTotalDays >= 28)
                        {
                            CalcMonth(ref myTotalDays, ref MyDateMonth, 28);
                        }
                        else
                        {
                            CalcDays(ref myTotalDays, ref MyDateDay);
                            if (IsLeapYear(MyDateYear))
                            {
                                if (MyDateDay > 29)
                                {
                                    CalcDay(ref MyDateDay, ref MyDateMonth);
                                }
                            }
                            else if (MyDateDay > 28)
                            {
                                CalcDay(ref MyDateDay, ref MyDateMonth);
                            }

                        }
                        break;

                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        if (myTotalDays >= 30)
                        {
                            CalcMonth(ref myTotalDays, ref MyDateMonth, 30);
                        }
                        else
                        {
                            CalcDays(ref myTotalDays, ref MyDateDay);
                            if (MyDateDay > 30)
                            {
                                CalcDay(ref MyDateDay, ref MyDateMonth);
                            }
                        }
                        break;
                }

            }

            return new DateTime(MyDateYear, MyDateMonth, MyDateDay);

        }

        public static bool IsLeapYear(int year)
        {
            bool result = false;

            if (year > 0 && year <= 9999)
            {
                result = year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
            }

            return result;

        }


        void CalcMonth(ref int myTotalDays, ref int MyDateMonth, int days)
        {
            myTotalDays -= days;
            MyDateMonth += 1;

        }


        void CalcDay(ref int MyDateDay, ref int MyDateMonth)
        {
            MyDateDay = 1;
            MyDateMonth += 1;

        }


        void CalcDays(ref int myTotalDays, ref int MyDateDay)
        {
            myTotalDays -= 1;
            MyDateDay += 1;

        }
    }
}

