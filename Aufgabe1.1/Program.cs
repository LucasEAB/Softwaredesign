using System;

namespace Aufgabe1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            var b = args[1];
            double d = Convert.ToDouble(b);

            switch (args[0])
            {
                case "c":
                    getCubeInfo(d);
                    break;
                case "k":
                    getSphereInfo(d);
                    break;
                case "o":
                    getOctahedronInfo(d);
                    break;

                default:
                    Console.WriteLine("Wähle c, k oder o");
                    break;
            }
        }

        //Cube
        public static double getCubeSurface(double edgelength)
        {
            return Math.Round(6 * (edgelength * edgelength), 2);
        }
        public static double getCubeVolume(double edgelength)
        {
            return Math.Round(edgelength * edgelength * edgelength, 2);
        }
        public static void getCubeInfo(double edgelength)
        {
            Console.WriteLine("Würfel:  A = " + getCubeSurface(edgelength) + "  |  V = " + getCubeVolume(edgelength));
        }

        //Kugel 
        public static double getSphereSurface(double diameter)
        {
            return Math.Round(Math.PI * (diameter * diameter), 2);
        }
        public static double getSphereVolume(double diameter)
        {
            return Math.Round((Math.PI * (diameter * diameter * diameter)) / 6, 2);
        }
        public static void getSphereInfo(double diameter)
        {
            Console.WriteLine("Kugel:  A = " + getSphereSurface(diameter) + "  |  V = " + getSphereVolume(diameter));
        }

        //Oktaeder
        public static double getOctahedronSurface(double diameter)
        {
            return Math.Round(2 * Math.Sqrt(3) * (diameter * diameter), 2);
        }
        public static double getOctahedronVolume(double diameter)
        {
            return Math.Round(Math.Sqrt(2) * (diameter * diameter * diameter) / 3, 2);
        }
        public static void getOctahedronInfo(double diameter)
        {
            Console.WriteLine("Oktaeder:  A = " + getOctahedronSurface(diameter) + "  |  V = " + getOctahedronVolume(diameter));
        }
    }
}