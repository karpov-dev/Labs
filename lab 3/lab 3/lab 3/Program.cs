using System;
using System.Security.Cryptography.X509Certificates;

namespace lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            while ( !exit )
            {
                #region Menu
                Console.WriteLine("Menu");
                Console.WriteLine("Select exercise");
                Console.WriteLine("1 - Exercise 1");
                Console.WriteLine("2 - Exercise 2");
                Console.WriteLine("3 - Exercise 3");
                Console.WriteLine("\n0- Exit");
                #endregion

                #region Select Point
                Console.Write("Select: ");
                string selectedExercise = Console.ReadLine();
                Console.Clear();
                #endregion

                switch ( selectedExercise )
                {
                    #region Exercise 1
                    case "1":
                        {
                            int k, n;

                            Console.Write("K: ");
                            k = Convert.ToInt32(Console.ReadLine());

                            Console.Write("N: ");
                            n = Convert.ToInt32(Console.ReadLine());

                            int[][] array = GetArray(k, n);
                            for(int i = 1; i < k; i++ )
                            {
                                array[i] = MergeSorting.MergeProcedure(array[i], array[i - 1]);
                            }

                            Console.Write("Result: ");
                            foreach ( int num in array[k - 1] )
                            {
                                Console.Write(num + " ");
                            }
                            break;
                        }
                    #endregion

                    #region Exercise 2
                    case "2":
                        {
                            string[] array = { "run", "go", "also", "going", "hello", "yes", "hi", "the", "too", "12", "23", "1"};
                            Console.Write("Before sorting: ");
                            ShowArray(array);

                            MergeSorting.MergeSortString(array, 0, array.Length - 1);

                            Console.Write("After sorting: ");
                            ShowArray(array);

                            break;
                        }
                    #endregion

                    #region Exercise 3
                    case "3":
                        {
                            int elements, maxValue, minValue;
                            Console.Write("Elements: ");
                            elements = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Min Value: ");
                            minValue = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Max Value: ");
                            maxValue = Convert.ToInt32(Console.ReadLine());

                            int[] array = GetRandomArray(elements, minValue, maxValue);

                            Console.Write("Before: ");
                            ShowIntArray(array);
                            array = RearangeSorting.Rearrange(array, RearangeSorting.CountKeysLess(RearangeSorting.CountKeysEqual(array, elements, maxValue), maxValue), elements);
                            Console.Write("After: ");
                            ShowIntArray(array);

                            break;
                        }
                    #endregion

                    #region App exit
                    case "0":
                        {
                            exit = true;
                            break;
                        }
                    #endregion

                    #region Command not found
                    default:
                        {
                            Console.WriteLine("Not found");
                            break;
                        }
                    #endregion
                }
                Console.ReadKey();
                Console.Clear();
            }

            #region Methods
            void ShowArray(string[] array)
            {
                foreach(string element in array )
                {
                    Console.Write(element + " ");
                }
                Console.WriteLine();
            }
            void ShowIntArray(int[] array)
            {
                foreach(int element in array )
                {
                    Console.Write(element + " ");
                }
                Console.WriteLine();
            }
            int[][] GetArray(int k, int n)
            {
                int[][] array = new int[k][];
                for(int i = 0; i < k; i++ )
                {
                    array[i] = new int[n];
                    for(int j = 0; j < n; j++ )
                    {
                        array[i][j] = j + 1;
                    }
                }
                return array;
            }
            int[] GetRandomArray(int size, int min, int max)
            {
                Random random = new Random();
                int[] array = new int[size];
                for ( int i = 0; i < size; i++ )
                {
                    array[i] = random.Next(min, max);
                }
                return array;
            }
            #endregion

        }
    }
}
