using System;
using System.Collections.Generic;
using System.Text;

namespace lab_3
{
    class RearangeSorting
    {
        //это тоже было у меня в 4 лабе. Идея в том, что делаем массив размером с максимальный элемент в сортируемом массиве.
        //потом пробегаем массив, который нужно отсортировать и в большой массив (который мы сделали сами) в элемент под 
        //индексом числа в сортируемом массиве прибавляем +1. Потом на основе этих данных делаем уже отсортированный массив.
        public static int[] Rearrange(int[] array, int[] less, int n)
        {
            int[] arrayB = new int[n];
            int key,
                index;

            for ( int i = 0; i < n; i++ )
            {
                key = array[i];
                index = less[key];
                arrayB[index] = array[i];
                less[key]++;
            }

            return arrayB;
        }
        public static int[] CountKeysEqual(int[] A, int n, int m)
        {
            int[] equal = new int[m];
            for ( int i = 0; i < m; i++ ) equal[i] = 0;
            for ( int i = 0; i < n; i++ )
            {
                equal[A[i]]++;
            }
            Console.Write("Equal array: ");
            foreach ( int num in equal )
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
            return equal;
        }
        public static int[] CountKeysLess(int[] equal, int m)
        {
            int[] less = new int[m];
            for ( int i = 0; i < m; i++ ) less[i] = 0;
            for ( int i = 1; i < m; i++ )
            {
                less[i] = less[i - 1] + equal[i - 1];
            }

            return less;
        }
    }
}
