namespace Assignment_6._1._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose 1-3 to pick a house."); 
            int searchHouseNumber = Convert.ToInt32(Console.ReadLine());

            var houseList = new HouseList();
            houseList.AddHouse(1, "4040 County Road", "Farmhouse");
            houseList.AddHouse(2, "4141 SE 600 Road", "Ranch");
            houseList.AddHouse(3, "4242 NW 300 Road", "Colonial");

            
            var foundHouse = houseList.FindHouse(searchHouseNumber);
            if (foundHouse != null)
            {
                Console.WriteLine($"House: {searchHouseNumber}");
                Console.WriteLine($"Address: {foundHouse.Address}");
                Console.WriteLine($"Type: {foundHouse.HouseType}");
            }
            else
            {
                Console.WriteLine($"House: {searchHouseNumber} was not found.");
            }
        }

        public class House
        {
            public House(int houseNumber, string address, string houseType)
            {
                HouseNumber = houseNumber;
                Address = address;
                HouseType = houseType;
                NextHouse = null;
            }

            public int HouseNumber { get; set; }
            public string Address { get; set; }
            public string HouseType { get; set; }
            public House NextHouse { get; set; }

        }

        public class HouseList
        {
            private House head;

            public void AddHouse(int houseNumber, string address, string houseType)
            {
                var newHouse = new House(houseNumber, address, houseType);
                if (head == null)
                {
                    head = newHouse;
                }
                else
                {
                    var currentHouse = head;
                    while (currentHouse.NextHouse != null)
                    {
                        currentHouse = currentHouse.NextHouse;
                    }
                    currentHouse.NextHouse = newHouse;
                }
            }

            public House FindHouse(int houseNumber)
            {
                var currentHouse = head;
                while (currentHouse != null)
                {
                    if (currentHouse.HouseNumber == houseNumber)
                    {
                        return currentHouse;
                    }
                    currentHouse = currentHouse.NextHouse;
                }
                return null;
            }
        }
    }
}
