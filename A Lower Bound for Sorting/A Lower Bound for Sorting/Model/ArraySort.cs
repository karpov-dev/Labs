using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace A_Lower_Bound_for_Sorting.Model
{
    public static class ArraySort
    {
        //сортировка подсчётом.
        //очень медленная. Когда запустите со стандартными значениями 
        //будет считать долговато
        public static int[] CountingSort(int[] array, int maxValue)
        {
            //делаем массив на максимальный размер числа, которое может быть у нас в массиве
            //т.е в будущем будет по одной ячейке на каждое из чисел.
            int[] count = new int[maxValue];

            //отсортированый массив.
            int[] sorted = new int[array.Length];

            //проходим по всему массиву. Считываем значение нашего массива. 
            //потом в ячейку массива count под номером считанного значения нашего исходного
            //массива добавляем +1.
            for ( int i = 0; i < array.Length; i++ )
                count[array[i]]++;

            //складываем i значение массива count с предыдущим 
            //необходимо будет для поиска позиции, в которую нужно будет поставить элемент из данного для
            //сортировки массива в сортированый массив.
            for ( int i = 1; i < count.Length; i++ )
                count[i] = count[i] + count[i - 1];

            //сортировка массива
            for ( int i = array.Length - 1; i >= 0; i-- )
            {
                //берем значение нашего массива
                int value = array[i];
                
                //при помощи подготовленного заранее массива count находим позицию 
                //в которую необходимо поставить элемент.
                //отнимаем -1, т.к массивы нумеруются с нуля.
                int position = count[value] - 1;

                //собственно записываем значение в найденную позицию.
                sorted[position] = value;

                //отнимаем -1 для того, чтобы если найдётся элемент с таким же значением
                //поставить его слева от уже записанного в массив элемента.
                //например у нас есть две тройки. Первая тройка, например, попадёт в ячейку под номером 
                //четыре, а вторая тогда, попадет в ячейку под номером три.
                count[value]--;
            }

            //естественно, возвращаем отсортированный массив.
            return sorted;
        }

        //сортировка вставками.
        public static int[] InsertionSort(int[] array)
        {
            //пробегаемся по всему массиву.
            for ( var i = 1; i < array.Length; i++ )
            {
                var key = array[i]; //содержит значение массива в i ячейке. Необходимо для последующего сравнения
                var j = i; //содержит значение, с которого необходимо будет начинать сразвнимать.

                //если наш key (значение массива в i ячейке) меньше значение, которое находится левее
                //тогда меняем местами key и левый элемент.
                //напрмер 2 1 0 => 1 2 0 => 1 0 2 => 0 1 2.
                while ( ( j > 1 ) && ( array[j - 1] > key ) )
                {
                    //меняем местами
                    Swap(ref array[j - 1], ref array[j]); //метод обмена элементов (ref - передаем значение по ссылке)
                    j--; //для проверки следующего левого элемента (т.к. мы уже сместились).
                }
                
                array[j] = key;
            }
            //возвращаем отсортированный массив.
            return array;
        }

        //сортировка слиянеем
        public static int[] MergeSort(int[] array)
        {
            return MergeSort(array, 0, array.Length - 1);
        }


        private static int[] MergeSort(int[] array, int lowIndex, int highIndex)
        {
            if ( lowIndex < highIndex )
            {
                var middleIndex = ( lowIndex + highIndex ) / 2;

                //рекурсивно разбиваем массив на подмассивы
                MergeSort(array, lowIndex, middleIndex);
                MergeSort(array, middleIndex + 1, highIndex);

                //когда уже они будут очень маленькие (максимум 2 элемента), сортируем эти два элемента
                Merge(array, lowIndex, middleIndex, highIndex);
            }

            return array;
        }

        private static void Merge(int[] array, int lowIndex, int middleIndex, int highIndex)
        {
            var left = lowIndex; //левый индекс.
            var right = middleIndex + 1; //правый индекс.

            //временный массив, в который мы записываем отсортированные значения.
            var tempArray = new int[highIndex - lowIndex + 1]; 
            var index = 0; //начальный индекс для временного массива.

            while ( ( left <= middleIndex ) && ( right <= highIndex ) )
            {
                //находим меньший элемент и записываем его в начало.
                if ( array[left] < array[right] )
                {
                    tempArray[index] = array[left];
                    left++;
                }
                else
                {
                    tempArray[index] = array[right];
                    right++;
                }

                //первый элемент мы нашли, поэтому смещаем индекс временного массива.
                index++;
            }

            //в следующих двух циклах мы ищем правый элемент массива 
            //если сдвинули левую границу - зайдем в этот цикл.
            for ( int i = left; i <= middleIndex; i++ )
            {
                tempArray[index] = array[i];
                index++;
            }

            //если правую, то в этот.
            for ( int i = right; i <= highIndex; i++ )
            {
                tempArray[index] = array[i];
                index++;
            }

            //записываем в наш исходный массив.
            for ( int i = 0; i < tempArray.Length; i++ )
            {
                array[lowIndex + i] = tempArray[i];
            }
        }

        //метод обмена элементов
        private static void Swap(ref int e1, ref int e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
        }


        //Я отсортированые массивы не выводил - перевод из int в string занимал много времени, из-за этого на графике 
        //происходил полный хаос. Отсортированные массивы можно посмотреть через debug (точкой останова) 
    }
}
