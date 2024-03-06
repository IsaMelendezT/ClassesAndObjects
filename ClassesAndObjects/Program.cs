using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

// Exercise: create a circle class which consists of a point and a radius
// point itself is a class
// you are supposed to create an array of circles (at least 3) by taking the point of origin and radius from the user 
// you should print the surface and perimeter of each circle
// and then you take an examplary point and define if this point is inside the circle or outside.

namespace ClassesAndObjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create array to store of the circles
            Circle[] circles = new Circle[3];

            // Loop to gathered data for 3 circles
            for(int i = 0; i < 3; i++) 
            {
                Console.WriteLine("Please enter the x origin of the circle #{0}: ", i+1);
                double x = double.Parse(Console.ReadLine());
                Console.WriteLine("Please enter the y origin of the circle #{0}: ", i+1);
                double y = double.Parse(Console.ReadLine());
                Console.WriteLine("Please enter the radius of the circle #{0}: ", i+1);
                double radius = double.Parse(Console.ReadLine());
                
                // Store each circle in the circles array
                circles[i] = new Circle(new Point(x, y), radius);
            }

            Console.WriteLine("Point to check if is inside any of the circles: ");
            Console.WriteLine();

            // Request from the user x and y to check if it is inside of any circle. 
            Console.WriteLine("Please enter the x coordinate of a point to check if it is inside the circle:");
            double xPoint = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the y coordinate of a point to check if it is inside the circle:");
            double yPoint = double.Parse(Console.ReadLine());

            Point checkPoint = new Point(xPoint, yPoint);

            Console.WriteLine("Perimetes and Areas of each circle and checked Result: ");
            Console.WriteLine();

            // Loop to calculate and print results
            foreach(Circle circle in circles) 
            {
                Console.WriteLine("Perimeter of circle with origin({0},{1}) and radius {2}is : {3:0.00}",circle.Point.X,circle.Point.Y,circle.Radius,circle.Perimeter());
                Console.WriteLine("Area of circle with origin({0},{1}) and radius {2}is : {3:0.00}", circle.Point.X, circle.Point.Y, circle.Radius, circle.Area());
                Console.WriteLine();


                if (circle.IsInside(checkPoint))
                {
                    Console.WriteLine("The point ({0},{1}) is inside the circle.", xPoint, yPoint);
                }
                else
                {
                    Console.WriteLine("The point ({0},{1}) is outside the circle.", xPoint, yPoint);
                }
                Console.WriteLine();
            }


        }
    }

    // Create point class to assing origin points to the circle
    class Point
    {
        private double x;
        private double y;

        // Default constructor 
        public Point() { }

        // Constructor with parameters
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double X
        {
            get { return this.x; }
            set { this.x = value; }
        }
        public double Y
        {
            get { return this.y; }
            set { this.y = value; }
        }
    }

    // Create circle class with fields point from class Point, and double radius. This class will have Perimeter, Area and IsInside methods
    class Circle
    {
        private Point point;
        private double radius;

        // Default constructor 
        public Circle() { }

        // Parameter constructor
        public Circle(Point point, double radius) 
        {
            this.point = point;
            this.radius = radius;
        }

        public Point Point
        {
            get { return this.point; }
            set { this.point = value; }
        }

        public double Radius 
        {
            get { return this.radius; }
            set { this.radius = value; }
        }

        // method to calculate the perimeter of the circle
        public double Perimeter() 
        {
            return 2 * Math.PI * this.radius;
        }
        // method to calculate the area of the circle
        public double Area()
        {
            return Math.PI * this.radius * this.radius;
        }
        // method to check if one point is inside the circle
        public bool IsInside(Point point)
        {
            double distance = Math.Sqrt(Math.Pow(point.X - this.Point.X, 2) + Math.Pow(point.Y - this.Point.Y, 2));
            return distance <= Radius;
        }
    }
}
