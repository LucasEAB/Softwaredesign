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
        public static double getCubeSurface(double Durchmesser)
        {
            double d = Durchmesser;
            double A = Math.Round(6 * (d * d), 2);
            return A;
        }
        public static double getCubeVolume(double Durchmesser)
        {
            double d = Durchmesser;
            double V = Math.Round(d * d * d, 2);
            return V;
        }
        public static void getCubeInfo(double Durchmesser)
        {
            Console.WriteLine("Würfel:  A = " + getCubeSurface(Durchmesser) + "  |  V = " + getCubeVolume(Durchmesser));
        }

        //Kugel 
        public static double getSphereSurface(double Durchmesser)
        {
            double d = Durchmesser;
            double A = Math.Round(Math.PI * (d * d), 2);
            return A;
        }
        public static double getSphereVolume(double Durchmesser)
        {
            double d = Durchmesser;
            double V = Math.Round((Math.PI * (d * d * d)) / 6,2);
            return V;
        }
        public static void getSphereInfo(double Durchmesser)
        {
            Console.WriteLine("Kugel:  A = " + getSphereSurface(Durchmesser) + "  |  V = " + getSphereVolume(Durchmesser));
        }

        //Oktaeder
        public static double getOctahedronSurface(double Durchmesser)
        {
            double d = Durchmesser;
            double A = Math.Round(2 * Math.Sqrt(3) * (d * d), 2);
            return A;
        }
        public static double getOctahedronVolume(double Durchmesser)
        {
            double d = Durchmesser;
            double V = Math.Round(Math.Sqrt(2) * (d * d * d) / 3, 2);
            return V;
        }
        public static void getOctahedronInfo(double Durchmesser)
        {
            Console.WriteLine("Oktaeder:  A = " + getOctahedronSurface(Durchmesser) + "  |  V = " + getOctahedronVolume(Durchmesser));
        }
    }
}