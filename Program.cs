using System;
using System.Collections.Generic;

namespace Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            var FordFiestaFactory = new FordFiestaFactory();
            var FordFiesta = FordFiestaFactory.CreateCar("Blue");
            Console.WriteLine("Brand: {0} \nModel: {1} \nColor: {2}", FordFiesta.Make, FordFiesta.Model, FordFiesta.Color);
            Console.WriteLine();
            List<ICreateCars> Cars = new List<ICreateCars>();
            Cars.Add(new FordFiestaFactory());
            Cars.Add(new BMWX5Factory());

            foreach (var Car in Cars)
            {
                var ProductCar = Car.CreateCar("Red");
                Console.WriteLine("Brand: {0} \nModel: {1} \nColor: {2}", ProductCar.Make, ProductCar.Model, ProductCar.Color);
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
    public abstract class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string EngineSize { get; set; }
        public string Color { get; set; }
    }

    public class FordFiesta : Car
    {
        public FordFiesta()
        {
            Make = "Ford";
            Model = "Fiesta";
            EngineSize = "1.1";
        }
    }
    public class BMWX5 : Car
    {
        public BMWX5()
        {
            Make = "BMW";
            Model = "X5";
            EngineSize = "2.1";
        }
    }
    public interface ICreateCars
    {
        Car CreateCar(string color);
    }
    class FordFiestaFactory : ICreateCars
    {
        public Car CreateCar(string color)
        {
            return new FordFiesta() { Color = color };
        }
    }
    class BMWX5Factory : ICreateCars
    {
        public Car CreateCar(string color)
        {
            return new BMWX5() { Color = color };
        }
    }
}