using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0221hw
{
    public delegate void ObjEv();
    class Backpack
    {
        public string color { get; set; }
        public string brand { get; set; }
        public string fabric { get; set; }
        public int weight { get; set; }
        public static int capacity { get; set; }
        static Object[] objs;
        static int objCount=0;
        static int objMaxCount = 10;
        public event ObjEv ev;
        public Backpack(string _color, string _brand, string _fabric, int _weight, int _capacity)
        {
            color = _color;
            brand = _brand;
            fabric = _fabric;
            weight = _weight;
            capacity = _capacity;
            objs = new Object[objMaxCount];
        }
        public ObjEv AddObject = delegate ()
          {
              if (objCount == objMaxCount)
              {
                  throw new Exception("Can't add no more");
              }
              else
              {
                  objs[objCount].Input();
                  if (objs[objCount].capacitytake > capacity)
                  {
                      throw new Exception("Not enough capacity to add this obj");
                  }
                  else
                  {
                      objCount++;
                      capacity -= objs[objCount].capacitytake;
                      Console.WriteLine("Object is successfully added");
                  }
              }
          };
        public void AddObjCall()
        {
            ev?.Invoke();
        }
        public void Print()
        {
            Console.WriteLine("Color: " + color + "\nBrand: " + brand+"\nFabric: "+fabric+"\nWeight: "+weight+"\nCapacity: "+capacity+"\nObjs: "+string.Join(" ",objs));
        }
        public override string ToString()
        {
            return "Color: " + color + "\nBrand: " + brand + "\nFabric: " + fabric + "\nWeight: " + weight + "\nCapacity: " + capacity + "\nObjs: " + string.Join(" ", objs);
        }
        public void Input()
        {
            Console.WriteLine("Enter color: ");
            color = Console.ReadLine();
            Console.WriteLine("Enter brand: ");
            brand = Console.ReadLine();
            Console.WriteLine("Enter fabric: ");
            fabric = Console.ReadLine();
            Console.WriteLine("Enter weight: ");
            weight = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter capacity: ");
            capacity = Convert.ToInt32(Console.ReadLine());
        }
    }
}
    struct Object
    {
        public string name { get; set; }
        public int capacitytake { get; set; }
        public Object(string _name, int _capacitytake)
        {
            name = _name;
            capacitytake = _capacitytake;
        }
        public void Print()
        {
            Console.WriteLine("Name: " + name + "\nFree space taken: " + capacitytake);
        }
        public override string ToString()
        {
            return "Name: " + name + "\nFree space taken: " + capacitytake;
        }
        public void Input()
        {
            Console.WriteLine("Enter name: ");
            name = Console.ReadLine();
            Console.WriteLine("How much free space it takes: ");
            capacitytake = Convert.ToInt32(Console.ReadLine());
        }
    }

