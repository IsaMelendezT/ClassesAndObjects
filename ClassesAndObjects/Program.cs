using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClassesAndObjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Circle[] circles = new Circle[3];

            for(int i = 0; i < 3; i++) 
            {
                Console.WriteLine("Please enter the x origin of the circle #{0}: ", i+1);
                double x = double.Parse(Console.ReadLine());
                Console.WriteLine("Please enter the y origin of the circle #{0}: ", i+1);
                double y = double.Parse(Console.ReadLine());
                Console.WriteLine("Please enter the radius of the circle #{0}: ", i+1);
                double radius = double.Parse(Console.ReadLine());
                circles[i] = new Circle(new Point(x, y), radius);
            }

            Console.WriteLine("Point to check if is inside any of the circles: ");
            Console.WriteLine();

            Console.WriteLine("Please enter the x coordinate of a point to check if it is inside the circle:");
            double xPoint = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the y coordinate of a point to check if it is inside the circle:");
            double yPoint = double.Parse(Console.ReadLine());

            Point checkPoint = new Point(xPoint, yPoint);

            Console.WriteLine("Perimetes and Areas of each circle and checked Result: ");
            Console.WriteLine();

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

    // Exercise: create a circle class which consists of a point and a radius
    // point itself is a class
    // you are supposed to create an array of circles (at least 3) by taking the point of origin and radius from the user 
    // you should print the surface and perimeter of each circle
    // and then you take an examplary point and define if this point is inside the circle or outside.
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

        public double Perimeter() 
        {
            return 2 * Math.PI * this.radius;
        }

        public double Area()
        {
            return Math.PI * this.radius * this.radius;
        }

        public bool IsInside(Point point)
        {
            double distance = Math.Sqrt(Math.Pow(point.X - this.Point.X, 2) + Math.Pow(point.Y - this.Point.Y, 2));
            return distance <= Radius;
        }
    }
}
