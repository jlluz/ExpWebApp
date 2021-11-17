using System;

using Microsoft.AspNetCore.Mvc;

namespace ExpWebApp.Controllers
{
    public class CalculateController : Controller
    {
        [HttpPost]
        public ActionResult CalcDate(DateTime myDate, int myDays)
        {
            DateTime myNewDate = CalcNewDate(myDate, myDays);

            return Content(myDate + " + " + myDays + " days = " + myNewDate.Day + "/" + myNewDate.Month + "/" + myNewDate.Year);
        }

        public DateTime CalcNewDate(DateTime myDate, int myDays)
        {
            int myDateYear = myDate.Year;
            int myDateMonth = myDate.Month;
            int myDateDay = myDate.Day;

            int myTotalDays = myDays;

            while (myTotalDays >= 365)
            {
                myDateYear += 1;

                myTotalDays -= IsLeapYear(myDateYear) ? 366 : 365;
            }

            while (myTotalDays > 0)
            {
                switch (myDateMonth)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                        if (myTotalDays >= 31)
                        {
                            CalcMonth(ref myTotalDays, ref myDateMonth, 31);
                        }
                        else
                        {
                            CalcDays(ref myTotalDays, ref myDateDay);
                            if (myDateDay > 31)
                            {
                                CalcDay(ref myDateDay, ref myDateMonth);
                            }
                        }
                        break;

                    case 12:
                        if (myTotalDays >= 31)
                        {
                            myTotalDays -= 31;
                            myDateYear += 1;
                            myDateMonth = 1;
                        }
                        else
                        {
                            CalcDays(ref myTotalDays, ref myDateDay);
                            if (myDateDay > 31)
                            {
                                myDateDay = 1;
                                myDateMonth = 1;
                                myDateYear = 1;
                            }

                        }
                        break;

                    case 2:
                        if (IsLeapYear(myDateYear))
                        {
                            if (myTotalDays >= 29)
                            {
                                CalcMonth(ref myTotalDays, ref myDateMonth, 29);
                            }
                        }
                        else if (myTotalDays >= 28)
                        {
                            CalcMonth(ref myTotalDays, ref myDateMonth, 28);
                        }
                        else
                        {
                            CalcDays(ref myTotalDays, ref myDateDay);
                            if (IsLeapYear(myDateYear))
                            {
                                if (myDateDay > 29)
                                {
                                    CalcDay(ref myDateDay, ref myDateMonth);
                                }
                            }
                            else if (myDateDay > 28)
                            {
                                CalcDay(ref myDateDay, ref myDateMonth);
                            }

                        }
                        break;

                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        if (myTotalDays >= 30)
                        {
                            CalcMonth(ref myTotalDays, ref myDateMonth, 30);
                        }
                        else
                        {
                            CalcDays(ref myTotalDays, ref myDateDay);
                            if (myDateDay > 30)
                            {
                                CalcDay(ref myDateDay, ref myDateMonth);
                            }
                        }
                        break;
                }

            }

            return new DateTime(myDateYear, myDateMonth, myDateDay);

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


        void CalcMonth(ref int myTotalDays, ref int myDateMonth, int days)
        {
            myTotalDays -= days;
            myDateMonth += 1;

        }


        void CalcDay(ref int myDateDay, ref int myDateMonth)
        {
            myDateDay = 1;
            myDateMonth += 1;

        }


        void CalcDays(ref int myTotalDays, ref int myDateDay)
        {
            myTotalDays -= 1;
            myDateDay += 1;

        }
    }
}

