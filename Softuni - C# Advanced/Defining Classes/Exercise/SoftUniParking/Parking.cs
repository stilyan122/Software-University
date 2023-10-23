using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;
        public Parking(int capacity)
        {
            this.Cars = new List<Car>(capacity);
            this.capacity = capacity;
        }
        public List<Car> Cars { get; set; }
        public string AddCar(Car car)
        {
            if (Cars.Find(x=>x.RegistrationNumber==car.RegistrationNumber)!=default)
            {
                return "Car with that registration number, already exists!";
            }
            else if (Cars.Count+1>capacity)
            {
                return "Parking is full!";
            }
            else
            {
                Cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }
        public string RemoveCar(string registrationNumber)
        {
            if (Cars.Find(x => x.RegistrationNumber == registrationNumber) == default)
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                for (int i = 0; i < Cars.Count; i++)
                {
                    if (Cars[i].RegistrationNumber==registrationNumber)
                    {
                        Cars.RemoveAt(i);
                        break;
                    }
                }
                return $"Successfully removed {registrationNumber}";
            }
        }
        public Car GetCar(string registrationNumber)
        {
            return Cars.Find(x => x.RegistrationNumber == registrationNumber);
        }
        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var number in registrationNumbers)
            {
                for (int i = 0; i < Cars.Count; i++)
                {
                    if (Cars[i].RegistrationNumber==number)
                    {
                        Cars.RemoveAt(i);
                        i--;
                    }
                }
            }
        }
        public int Count {
            get
            {
                return Cars.Count;
            }
        }
    }
}
