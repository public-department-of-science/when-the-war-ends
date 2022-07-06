using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStatistic
{
    static class MinfinProgram
    {
        public static void Main()
        {
            var listedMonths = new List<string>();
            var date = DateTime.Parse("2022-02-24");
            for (int i = 0; i < DateTime.Now.Month - 1; i++)
            {
                var calculatedDiff = date.Month + i;
                var year = date.Year;
                if (calculatedDiff > 12)
                {
                    year = year + 1;
                    calculatedDiff = calculatedDiff - 12;
                }
                var preparedDate = DateTime.Parse($"{year}-{calculatedDiff}");
                listedMonths.Add($"{preparedDate.Year}-{ preparedDate.Month.ToString("00")}");
            }

            var destinationPointUrl = "https://index.minfin.com.ua/ua/russian-invading/casualties";
            var listedDestinationPointsByMonths = new List<string>();

            foreach (var month in listedMonths)
            {
                listedDestinationPointsByMonths.Add($"{destinationPointUrl}/{month}/");
            }

            foreach (var item in listedDestinationPointsByMonths)
            {
                Console.WriteLine(item);
            }

            foreach (var url in listedDestinationPointsByMonths)
            {
                var web = new HtmlWeb();
                var doc = web.Load(url);
                var dayStatistic = doc.DocumentNode.SelectNodes("/html/body/main/div/div/div[1]/div/div[1]/article/ul[2]/li");

                foreach (var item in dayStatistic.Descendants())
                {
                    var keywords = new string[] { "Taнки", "ББМ", "Гармати", "РСЗВ", "Засоби ППО", "Особовий склад" };

                    //Dictionary<int, string> keyValuePairs = new Dictionary<int, string>();
                    //foreach (var keyword in keywords)
                    //{
                    //    var index = item.InnerText.IndexOf(keyword);
                    //    if (index == -1)
                    //    {

                    //    }
                    //    keyValuePairs.Add(index, keyword);
                    //}
                }
            }
        }
    }
}