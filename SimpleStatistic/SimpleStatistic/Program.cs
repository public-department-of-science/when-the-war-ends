//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace SimpleStatistic
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            List<int> dateRange = new List<int>()
//            {
//                90,100,110,120,130,
//            };

//            List<int> people = new List<int>()
//            {
//                29300, // 90
//                31050, // 100
//                32500, // 110
//                34500, // 120
//                36200, // 130
//            };
//            Console.WriteLine("\n\nPeople AVG");
//            var temp = AvgBy10DaysWholeRange(people, dateRange);
//            foreach (var item in temp)
//            {
//                Console.Write(item.ToString("0.00") + " ; ");
//            }

//            List<int> peopleWithInjured = new List<int>()
//            {
//                87900, // 90
//                93150, // 100
//                97500, // 110
//                103500, // 120
//                108600, // 130
//            };

//            Console.WriteLine("\n\nPeople as injured AVG");
//            temp = AvgBy10DaysWholeRange(peopleWithInjured, dateRange);
//            foreach (var item in temp)
//            {
//                Console.Write(item.ToString("0.00") + " ; ");
//            }

//            List<int> tanks = new List<int>()
//            {
//                1302, // 90
//                1376, // 100
//                1434, // 110
//                1507, // 120
//                1589, // 130
//            };

//            Console.WriteLine("\n\nTanks AVG");
//            temp = AvgBy10DaysWholeRange(tanks, dateRange);
//            foreach (var item in temp)
//            {
//                Console.Write(item.ToString("0.00") + " ; ");
//            }

//            List<int> bmp = new List<int>()
//            {
//                3194, // 90
//                3379, // 100
//                3503, // 110
//                3637, // 120
//                3754, // 130
//            };

//            Console.WriteLine("\n\nBMP AVG");
//            temp = AvgBy10DaysWholeRange(bmp, dateRange);
//            foreach (var item in temp)
//            {
//                Console.Write(item.ToString("0.00") + " ; ");
//            }

//            var deltasPeople = CalculateDeltaWithPrevious10Days(people, dateRange);
//            Console.WriteLine("\n\nDeltas People");
//            for (int i = 0, j = 1; i < deltasPeople.Count; i++, j++)
//            {
//                Console.Write(dateRange[j].ToString() + " - " + dateRange[i].ToString() + "=");
//                Console.Write(deltasPeople[i].ToString("0.00") + " ; ");
//            }

//            var deltasPeopleInjured = CalculateDeltaWithPrevious10Days(peopleWithInjured, dateRange);
//            Console.WriteLine("\n\nDeltas People");
//            for (int i = 0, j = 1; i < deltasPeopleInjured.Count; i++, j++)
//            {
//                Console.Write(dateRange[j].ToString() + " - " + dateRange[i].ToString() + "=");
//                Console.Write(deltasPeopleInjured[i].ToString("0.00") + " ; ");
//            }

//            var deltasTanks = CalculateDeltaWithPrevious10Days(tanks, dateRange);
//            Console.WriteLine("\n\nDeltas Tanks");
//            for (int i = 0, j = 1; i < deltasTanks.Count; i++, j++)
//            {
//                Console.Write(dateRange[j].ToString() + " - " + dateRange[i].ToString() + "=");
//                Console.Write(deltasTanks[i].ToString("0.00") + " ; ");
//            }

//            var deltasBmp = CalculateDeltaWithPrevious10Days(bmp, dateRange);
//            Console.WriteLine("\n\nDeltas BMP");
//            for (int i = 0, j = 1; i < deltasBmp.Count; i++, j++)
//            {
//                Console.Write(dateRange[j].ToString() + " - " + dateRange[i].ToString() + "=");
//                Console.Write(deltasBmp[i].ToString("0.00") + " ; ");
//            }

//            Console.WriteLine("\n\nPer day people (last 10 days avg from the delta)");
//            List<double> peoplePerDay = AvgPerLast10Days(deltasPeople);
//            for (int i = 0, j = 1; i < peoplePerDay.Count; i++, j++)
//            {
//                Console.Write(peoplePerDay[i].ToString("0.00") + " ; ");
//            }

//            Console.WriteLine("\n\nPer day people with injured (last 10 days avg from the delta)");
//            List<double> peopleWithInjuredPerDay = AvgPerLast10Days(deltasPeopleInjured);
//            for (int i = 0, j = 1; i < peoplePerDay.Count; i++, j++)
//            {
//                Console.Write(peopleWithInjuredPerDay[i].ToString("0.00") + " ; ");
//            }

//            Console.WriteLine("\n\nPer day Tanks (last 10 days avg from the delta)");
//            List<double> tanksPerDay = AvgPerLast10Days(deltasTanks);
//            for (int i = 0, j = 1; i < peoplePerDay.Count; i++, j++)
//            {
//                Console.Write(tanksPerDay[i].ToString("0.00") + " ; ");
//            }

//            Console.WriteLine("\nPer day BMP (last 10 days avg from the delta)");
//            List<double> bmpPerDay = AvgPerLast10Days(deltasBmp);
//            for (int i = 0, j = 1; i < peoplePerDay.Count; i++, j++)
//            {
//                Console.Write(bmpPerDay[i].ToString("0.00") + " ; ");
//            }

//            int peopleMax = 300_000;
//            int tanksMax = 3_300;
//            int bmpMax = 13_760;

//            int[] percentages = new[] { 50, 70, 100 };

//            var peopleEnds = Get50_70_100Lost(peopleMax, peoplePerDay.Last(), people.Last());
//            Console.WriteLine("\n\nPeople ends as dead");
//            for (int i = 0; i < peopleEnds.Count; i++)
//            {
//                Console.WriteLine("To " + percentages[i].ToString() + "% = " + peopleEnds[i].ToString("0.00") + " ");
//            }

//            var peopleEndsAsInjuredAndDead = Get50_70_100Lost(peopleMax, peopleWithInjuredPerDay.Last(), peopleWithInjured.Last());
//            Console.WriteLine("\n\nPeople ends as dead + injured");
//            for (int i = 0; i < peopleEndsAsInjuredAndDead.Count; i++)
//            {
//                Console.WriteLine("To " + percentages[i].ToString() + "% = " + peopleEndsAsInjuredAndDead[i].ToString("0.00") + " ");
//            }

//            var tanksEnds = Get50_70_100Lost(tanksMax, tanksPerDay.Last(), tanks.Last());
//            Console.WriteLine("\n\nTanks ends");
//            for (int i = 0; i < tanksEnds.Count; i++)
//            {
//                Console.WriteLine("To " + percentages[i].ToString() + "% = " + tanksEnds[i].ToString("0.00") + " ");
//            }

//            var bmpEnds = Get50_70_100Lost(bmpMax, bmpPerDay.Last(), bmp.Last());
//            Console.WriteLine("\n\nBmp ends");
//            for (int i = 0; i < bmpEnds.Count; i++)
//            {
//                Console.WriteLine("To " + percentages[i].ToString() + "% = " + bmpEnds[i].ToString("0.00") + " ");
//            }
//        }

//        private static List<double> Get50_70_100Lost(int total, double avgValue, int currentLoses)
//        {
//            List<double> resourcesEnds = new List<double>();
//            var value50Perc = (total * 0.5 - currentLoses) / avgValue;
//            var value70Perc = (total * 0.7 - currentLoses) / avgValue;
//            var value100Perc = (total * 1.0 - currentLoses) / avgValue;

//            resourcesEnds.Add(value50Perc);
//            resourcesEnds.Add(value70Perc);
//            resourcesEnds.Add(value100Perc);
//            return resourcesEnds;
//        }

//        private static List<double> AvgPerLast10Days(List<int> deltas)
//        {
//            var res = new List<double>();
//            for (int i = 0; i < deltas.Count; i++)
//            {
//                res.Add(deltas[i] / 10);
//            }
//            return res;
//        }

//        private static List<int> CalculateDeltaWithPrevious10Days(List<int> data, List<int> dateRange)
//        {
//            List<int> deltas = new List<int>();
//            for (int i = 1; i < data.Count; i++)
//            {
//                deltas.Add(data[i] - data[i - 1]);
//            }
//            return deltas;
//        }

//        private static List<double> AvgBy10DaysWholeRange(List<int> data, List<int> dateRange)
//        {
//            var avgBy10Days = new List<double>();

//            int count = data.Count;
//            for (int i = 0; i < count; i++)
//            {
//                avgBy10Days.Add((double)data[i] / dateRange[i]);
//            }
//            return avgBy10Days;
//        }


//        enum Type
//        {
//            People,
//            Tanks,
//            BMP,
//        }
//    }
//}
