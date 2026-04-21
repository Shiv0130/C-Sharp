using VehicleSystem;

Vehicle car = new Car();
car.Accelerate(50);
Console.WriteLine(car.Move()); // Output: Car is driving


Vehicle motorcycle = new Motorcycle();
motorcycle.Accelerate(30);
Console.WriteLine(motorcycle.Move()); // Output: Motorcycle is riding