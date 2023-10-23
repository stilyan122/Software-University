using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreBoxes
{
    class StoreBoxes
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split();
            List<Box> boxes = new List<Box>();
            while (command[0]!="end")
            {
                string serialNumber = command[0];
                string itemName = command[1];
                double itemQuantity = double.Parse(command[2]);
                decimal itemPrice = decimal.Parse(command[3]);
                Item item = new Item(itemName, itemPrice);
                decimal price = (decimal)((decimal)itemQuantity * item.Price);
                Box box = new Box(serialNumber, item, itemQuantity,price);
                boxes.Add(box);
                command = Console.ReadLine().Split();
            }
            boxes = boxes.OrderByDescending(x => x.Price).ToList();
            foreach (var box in boxes)
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.Quantity}");
                Console.WriteLine($"-- ${box.Price:f2}");
            }
        }
    }
    public class Item
    {
        private string name;
        private decimal price;
        public Item(string name,decimal price)
        {
            this.Name = name;
            this.Price = price;
        }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    public class Box
    {
        private string serialNumber;
        private Item item;
        private double quantity;
        private decimal price;
        public Box(string serialNumber,Item item,double quantity,decimal price)
        {
            this.SerialNumber = serialNumber;
            this.Item = item;
            this.Quantity = quantity;
            this.Price = price;
        }
        public string SerialNumber { get; set; }
        public Item Item { get; set; }
        public double Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
