namespace _01.Microsystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Microsystems : IMicrosystem
    {
        private Dictionary<int, Computer> computers
            = new Dictionary<int, Computer>();

        public void CreateComputer(Computer computer)
        {
            if (computers.ContainsKey(computer.Number))
            {
                throw new ArgumentException();
            }
            computers.Add(computer.Number, computer);
        }

        public bool Contains(int number)
        {
            return computers.ContainsKey(number);
        }

        public int Count()
        {
            return this.computers.Count;
        }

        public Computer GetComputer(int number)
        {
            try
            {
                return computers[number];
            }
            catch (Exception)
            {
                throw new ArgumentException();
            }
        }

        public void Remove(int number)
        {
            bool removedSucc = this.computers.Remove(number);
            if (removedSucc == false)
            {
                throw new ArgumentException();
            }
        }

        public void RemoveWithBrand(Brand brand)
        {
            var computersWithBrand = this.computers
               .Values.Where(x => x.Brand == brand);

            if (computersWithBrand.Count() == 0)
            {
                throw new ArgumentException();
            }
            foreach (var item in computersWithBrand.ToList())
            {
                this.computers.Remove(item.Number);
            }
        }

        public void UpgradeRam(int ram, int number)
        {
            try
            {
                var computer = this.computers[number];
                if (ram > computer.RAM)
                {
                    computer.RAM = ram;
                }
            }
            catch (Exception)
            {
                throw new ArgumentException();
            }
        }

        public IEnumerable<Computer> GetAllFromBrand(Brand brand)
        {
            return this.computers.Values
                .Where(x => x.Brand == brand)
                .OrderByDescending(x => x.Price);
        }

        public IEnumerable<Computer> GetAllWithScreenSize(double 
            screenSize)
        {
            return this.computers.Values
                .Where(x => x.ScreenSize == screenSize)
                .OrderByDescending(x => x.Number);
        }

        public IEnumerable<Computer> GetAllWithColor(string color)
        {
            return this.computers.Values
                .Where(x => x.Color == color)
                .OrderByDescending(x => x.Price);
        }

        public IEnumerable<Computer> GetInRangePrice(double 
            minPrice, double maxPrice)
        {
            return this.computers.Values
                .Where(x => x.Price >= 
                minPrice && x.Price <= maxPrice)
                .OrderByDescending(x => x.Price);
        }
    }
}
