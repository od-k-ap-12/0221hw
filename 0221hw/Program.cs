using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0221hw
{
    delegate string RGBRainbow(string color);
    delegate int ArrayInt(int[] arr);
    delegate void ArrayVoid(int[] arr);
    delegate bool StringCheck(string str,string word);
    class Program
    {
        static void Main(string[] args)
        {

            #region 1
            RGBRainbow getRGB = delegate (string color)
            {
                string[] colors = new string[] { "Red", "Orange", "Yellow", "Green", "Light Blue", "Blue", "Purple" };
                string[] RGBs = new string[] { "255, 0 , 0", "255, 127, 0", "255, 255, 0", "0, 255, 0", "0, 0, 255", "75, 0, 130", "148, 0, 211" };
                for(int i=0;i<colors.Length;i++)
                {
                    if (colors[i] == color)
                    {
                        return RGBs[i];
                    }
                }
                return "Not found";
            };
            Console.WriteLine(getRGB("Red"));
            #endregion

            #region 2
            Backpack bp = new Backpack("color", "brand", "fabric", 2000, 3000);
            bp.ev += new ObjEv(bp.AddObject);
            bp.AddObjCall();

            #endregion

            #region 3
            int[] arr = new int[] { -8, 2, 7, 14, 56, -6, 49, 8, 14, -10 };
            ArrayInt MultipleOf7 = (int[] array) =>
            {
                int count = 0;
                foreach (int i in array)
                {
                    if (i % 7 != 0)
                    {
                        count++;
                    }
                }
                return count;
            };
            Console.WriteLine(MultipleOf7(arr));

            #endregion

            #region 4
            ArrayInt PositiveNum = (int[] array) =>
            {
                int count = 0;
                foreach (int i in array)
                {
                    if (i > 0)
                    {
                        count++;
                    }
                }
                return count;
            };
            Console.WriteLine(PositiveNum(arr));
            #endregion

            #region 5
            ArrayVoid UniqueNegativeNum = (int[] array) =>
            {
                Array.Sort(array);
                for(int i = 0; i < array.Length-1; i++)
                {
                    if (array[i + 1] != array[i] && array[i] < 0)
                    {
                        Console.WriteLine(array[i]);
                    }
                }
            };
            UniqueNegativeNum(arr);
            #endregion

            #region 6
            StringCheck ifContains = (string str, string word) => str.Contains(word);
            Console.WriteLine(ifContains("Sample string", "Sample"));
            #endregion


        }
    }
}
