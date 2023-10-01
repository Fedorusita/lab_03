using System;

namespace lab_03_1
{
    public struct Vector
    {
        private int x;
        private int y;
        private int z;
        public Vector(int x = 0, int y = 0, int z = 0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public int X
        {
            get { return x; }
            set { x =  value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public int Z
        {
            get { return z; }
            set { z = value; }
        }
        public static Vector operator +(Vector v1, Vector v2)
        {
            int sumX = v1.X + v2.X;
            int sumY = v1.Y + v2.Y;
            int sumZ = v1.Z + v2.Z;
            return new Vector(sumX, sumY, sumZ);
        }
        public static Vector operator *(Vector v1, Vector v2)
        {
            int prvX = v1.X * v2.X;
            int prvY = v1.Y * v2.Y;
            int prvZ = v1.Z * v2.Z;
            return new Vector(prvX, prvY, prvZ);
        }
        public static Vector operator *(Vector v1, int a)
        {
            int prvX = v1.X * a;
            int prvY = v1.Y * a;
            int prvZ = v1.Z * a;
            return new Vector(prvX, prvY, prvZ);
        }
        public static bool operator ==(Vector v1, Vector v2)
        {
            return Math.Sqrt(v1.X * v1.X + v1.Y * v1.Y) == Math.Sqrt(v2.X * v2.X + v2.Y * v2.Y);
        }

        public static bool operator !=(Vector v1, Vector v2)
        {
            return !(v1 == v2);
        }
       
    }


    struct lab_03_1
    {
        
        public static void Main(string[] args)
        {
            Vector v1 = new Vector(3, 5, 10);
            Vector v2 = new Vector(2, 7, -4);
            int a = 2;
            Vector sum = v1 + v2;
            Vector prv = v1 * v2;
            Vector prv_int = v1 * a;

            Console.WriteLine($"Сложение двух векторов!  \n ({sum.X}, {sum.Y}, {sum.Z})"); // Output: (5, 12, 6)
            Console.WriteLine($"Умножение двух векторов!  \n ({prv.X}, {prv.Y}, {prv.Z})"); // Output: (6, 35, -40)
            Console.WriteLine($"Умножение вектора на число!  \n ({prv_int.X}, {prv_int.Y}, {prv_int.Z})"); // Output: (6, 10, 20)

            if (v1 == v2)
            {
                Console.WriteLine("Векторы равны");
            }
            else
            {
                Console.WriteLine("Векторы неравны");
            }
        }
    }
}