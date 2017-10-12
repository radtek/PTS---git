using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание
{
    public class Address
    {
        public static List<Accessory> accessory = new List<Accessory>();
        public static List<Accessory> work = new List<Accessory>();
        public static List<Accessory> home = new List<Accessory>();

        public static string Data(string param)
        {
            if (param == "accessory")
                return string.Format("{0}{1}{2}{3}{4}{5}{6}{7}", accessory[0].country, accessory[0].region, accessory[0].city, accessory[0].street, accessory[0].home, accessory[0].housing, accessory[0].part, accessory[0].room);
            else if (param == "work")
                return string.Format("{0}{1}{2}{3}{4}{5}{6}{7}", work[0].country, work[0].region, work[0].city, work[0].street, work[0].home, work[0].housing, work[0].part, work[0].room);
            else if (param == "home")
                return string.Format("{0}{1}{2}{3}{4}{5}{6}{7}", home[0].country, home[0].region, home[0].city, home[0].street, home[0].home, home[0].housing, home[0].part, home[0].room);
            else
                return string.Empty;
        }

        public class Accessory
        {
            public string Country { get; set; }
            public string Region { get; set; }
            public string City { get; set; }
            public string Street { get; set; }
            public string Home { get; set; }
            public string Housing { get; set; }
            public string Part { get; set; }
            public string Room { get; set; }

            public string country
            {
                get
                {
                    if (Country == string.Empty)
                        return string.Empty;
                    else
                        return Country;
                }
            }
            public string region
            {
                get
                {
                    if (Region == string.Empty)
                        return string.Empty;
                    else
                        return ", " + Region;
                }
            }
            public string city
            {
                get
                {
                    if (City == string.Empty)
                        return string.Empty;
                    else
                        return ", г. " + City;
                }
            }
            public string street
            {
                get
                {
                    if (Street == string.Empty)
                        return string.Empty;
                    else
                        return ", ул. " + Street;
                }
            }
            public string home
            {
                get
                {
                    if (Home == string.Empty)
                        return string.Empty;
                    else
                        return ", д. " + Home;
                }
            }
            public string housing
            {
                get
                {
                    if (Housing == string.Empty)
                        return string.Empty;
                    else
                        return ", корп. " + Housing;
                }
            }
            public string part
            {
                get
                {
                    if (Part == string.Empty)
                        return string.Empty;
                    else
                        return ", стр. " + Part;
                }
            }
            public string room
            {
                get
                {
                    if (Room == string.Empty)
                        return string.Empty;
                    else
                        return ", кв. " + Room;
                }
            }
        }
    }
}
