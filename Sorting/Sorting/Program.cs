using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Привет, эта программа вычисляет скорость сортировки массива разными методами: ");
            Console.WriteLine(" - Пузырька \n - Выбора \n - Вставками \n - Быстрая");

            //Asking for the number of elements to sort 
            int arrSize; //number of elements in array
            Console.WriteLine("Сколько значений нужно отсортировать?");
            arrSize = Convert.ToInt32(Console.ReadLine());

            //Asking for left and right array borders
            int leftBorder, rightBorder;

            Console.WriteLine("Введите минимальное значение: ");
            leftBorder = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите максимальное значение: ");
            rightBorder = leftBorder;
            while (rightBorder <= leftBorder)
            {
                rightBorder = Convert.ToInt32(Console.ReadLine());

                if (rightBorder <= leftBorder)
                {
                    Console.WriteLine("Right border Must be bigger than left border, \n Enter the right border again!");
                }
            }

            //Creating an array of random integers within the selected range

            //creating random object
            Random rnd = new Random();
            //creating an array
            int[] randomValues1 = new int[arrSize];
            int[] randomValues2 = new int[arrSize];
            int[] randomValues3 = new int[arrSize];
            int[] randomValues4 = new int[arrSize];


            //  int rand = rnd.Next(leftBorder, rightBorder);
            for (int i = 0; i < randomValues1.Length; i++)
            {
                randomValues1[i] = rnd.Next(leftBorder, rightBorder);
                randomValues2[i] = rnd.Next(leftBorder, rightBorder);
                randomValues3[i] = rnd.Next(leftBorder, rightBorder);
                randomValues4[i] = rnd.Next(leftBorder, rightBorder);


            }
            /* - - - - */
              bubbleSort(randomValues1);
            Console.WriteLine("");

                selectionSort(randomValues2);
                Console.WriteLine("");

            insertionSort(randomValues3);
            Console.WriteLine("");



            long start = DateTime.Now.Ticks;
             double interval;
            
            quickSort(randomValues4, 0, randomValues4.Length - 1);

            long timeEnd = DateTime.Now.Ticks;
            interval = (double)(timeEnd - start) / 10000;
            Console.WriteLine("Quick sorting takes: " + interval + " ms.");
           
            
            /*
              for(int i = 0; i < randomValues.Length; i++)
              {
                  Console.Write(randomValues[i] + " ");
              }
            */
          
              
        }



        //Creating a bubble sorting method
        public static void bubbleSort(int[] array)
        {
                      
            long start = DateTime.Now.Ticks;
            double interval;
            for(int i = 0; i < array.Length; i++)
            {

                for(int j = array.Length-1; j>0; j--)
                {
                    int temp = 0;
                    if(array[j] < array[j-1]) {
                        temp = array[j];
                        array[j] = array[j - 1];
                        array[j - 1] = temp;
                    }
                }

            }
            long timeEnd = DateTime.Now.Ticks; 
            interval = (double)(timeEnd - start)/10000;
            Console.WriteLine("Bubble sorting takes: " + interval + " ms.");
        }

        //Creating a selection sorting method
        public static void selectionSort(int[] array)
        {
            long start = DateTime.Now.Ticks;
            double interval;

            for(int i = 0; i < array.Length-1; i++)
            {
                int min = i;
                for(int j = i+1; j < array.Length; j++)
                {
                    
                    if(array[j] < array[min])
                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    int temp = array[min];
                    array[min] = array[i];
                    array[i] = temp;
                }
            }

            long timeEnd = DateTime.Now.Ticks;
            interval = (Double)(timeEnd - start) / 10000;
            Console.WriteLine("Selection sorting takes: " + interval + " ms.");

        }
        //Insertion method sorting
        public static void insertionSort(int[] array)
        {
            long start = DateTime.Now.Ticks;
            double interval;

            for(int i = 1; i < array.Length; i++)
            {
                for(int j = i; j>0 && array[j-1]>array[j]; j--)
                {
                    int temp = array[j];
                    array[j] = array[j - 1];
                    array[j - 1] = temp;
                }
            }

            long timeEnd = DateTime.Now.Ticks;
            interval = (Double)(timeEnd - start) / 10000;
            Console.WriteLine("Insertion sorting takes: " + interval + " ms.");
        }
        //Quick sorting method
        public static void quickSort(int[] array, int first, int last)
        {
           // long start = DateTime.Now.Ticks;
           // double interval;

            int mid, count;
            int f = first, l = last;
            mid = array[(f + l) / 2]; //вычисление опорного элемента
            do
            {
                while (array[f] < mid) f++;
                while (array[l] > mid) l--;
                if (f <= l) //перестановка элементов
                {
                    count = array[f];
                    array[f] = array[l];
                    array[l] = count;
                    f++;
                    l--;
                }
            } while (f < l);
            if (first < l) quickSort(array, first, l);
            if (f < last) quickSort(array, f, last);

          //  long timeEnd = DateTime.Now.Ticks;
          //  interval = (Double)(timeEnd - start) / 10000;
          //  Console.WriteLine("Insertion sorting takes: " + interval + " ms.");
        }
    }
}
