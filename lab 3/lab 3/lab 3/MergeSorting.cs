using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace lab_3
{
    class MergeSorting
    {
        //У меня Merge был в 4 лабалаторной, где я описал принцип работы. Оставлю просто небольшие пометки

        public static int[] MergeProcedure(int[] firstArray, int[] secondArray)
        {
            int firstArrayLength = firstArray.Length, 
                secondArrayLength = secondArray.Length,
                i = 0,
                j = 0;

            int[] ResultArray = new int[firstArrayLength + secondArrayLength],
                  ArrayA = new int[firstArrayLength + 1],
                  ArrayB = new int[secondArrayLength + 1];

            //необходимо для последней итерации
            ArrayA[firstArrayLength] = 1000000;
            ArrayB[secondArrayLength] = 1000000;

            for ( int k = 0; k < firstArrayLength; k++ )
                ArrayA[k] = firstArray[k];

            for ( int k = 0; k < secondArrayLength; k++ )
                ArrayB[k] = secondArray[k]; 

            //делаем шаг по каждому массиву. Если i элемент больше j элемента - вставляем j элемент. И наобарот
            for ( int k = 0; k < firstArrayLength + secondArrayLength; k++ )
            {
                if ( ArrayA[i] <= ArrayB[j])
                {
                    ResultArray[k] = ArrayA[i];
                    i++;
                }
                else
                {
                    ResultArray[k] = ArrayB[j];
                    j++;
                }
            }

            return ResultArray;
        }

        public static string[] MergeProcedureString(string[] array, int p, int q, int r)
        {
            //по аналогии с предыдущим методом. (строку можно представить как число из ASCII таблицы)

            int firstArrayLength = q - p + 1,
                secondArrayLength = r - q,
                i = 0,
                j = 0;

            string[] ArrayA = new string[firstArrayLength + 1],
                     ArrayB = new string[secondArrayLength + 1];

            // z - последняя буква в алфавите и у нее самый "большой" код в ASCII таблице
            ArrayA[firstArrayLength] = "zzzzzzzzzzz";
            ArrayB[secondArrayLength] = "zzzzzzzzzzz";

            for ( j = p; j <= q; j++ )
            {
                ArrayA[i] = array[j];
                i++;
            }

            i = 0;

            for ( j = q + 1; j <= r; j++ )
            {
                ArrayB[i] = array[j];
                i++;
            }

            j = i = 0;
            //точно также как и в предыдущем методе
            for ( int k = p; k <= r; k++ )
            {
                if ( ArrayA[i].CompareTo(ArrayB[j]) <= 0 )
                {
                    array[k] = ArrayA[i];
                    i++;
                }
                else
                {
                    array[k] = ArrayB[j];
                    j++;
                }
            }

            return array;
        }

        public static string[] MergeSortString(string[] array, int p, int r)
        {
            if ( p >= r )
            {
                return array;
            }
            else
            {
                int q = ( p + r ) / 2;
                MergeSortString(array, p, q);
                MergeSortString(array, q + 1, r);
                MergeProcedureString(array, p, q, r);
            }
            return array;
        }
    }
}
