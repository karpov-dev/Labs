using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using A_Lower_Bound_for_Sorting.Service;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace A_Lower_Bound_for_Sorting.Model
{
    class SortManager : ModelPropertyChanged
    {
        private int _step = 15000;
        private int _arraySize = 1000000;
        private int _maxValue = 100000000;
        private int _minValue = 1;
        private int[] _countingSortedArray;
        private int[] _insertionSortedArray;
        private int[] _mergeSortedArray;
        private ChartValues<ObservablePoint> _countingSortPoints;
        private ChartValues<ObservablePoint> _insertionSortPoints;
        private ChartValues<ObservablePoint> _mergeSortPoints;

        public int[] CountingSortedArray
        {
            get => _countingSortedArray;
            set
            {
                _countingSortedArray = value;
                OnPropertyChanged();
            }
        }
        public int[] InsertionSortedArray
        {
            get => _insertionSortedArray;
            set
            {
                _insertionSortedArray = value;
                OnPropertyChanged();
            }
        }
        public int[] MergeSortedArray
        {
            get => _mergeSortedArray;
            set
            {
                _mergeSortedArray = value;
                OnPropertyChanged();
            }
        }
        public int Step
        {
            get => _step;
            set
            {
                if(value > 0 && value < 2147483646 )
                {
                    _step = value;
                    OnPropertyChanged();
                }
            }
        }
        public int ArraySize
        {
            get => _arraySize;
            set
            {
                if ( value > 0 && value < 2147483646 )
                {
                    _arraySize = value;
                    OnPropertyChanged();
                }
            }
        }
        public int MaxValue
        {
            get => _maxValue;
            set
            {
                if(value > 0 && value < 2147483646)
                {
                    _maxValue = value;
                    OnPropertyChanged();
                }
            }
        }
        public int MinValue
        {
            get => _minValue;
            set
            {
                if ( value > 0 )
                {
                    _minValue = value;
                    OnPropertyChanged();
                }
            }
        }
        public ChartValues<ObservablePoint> CountingSortPoints
        {
            get => _countingSortPoints;
            set
            {
                _countingSortPoints = value;
                OnPropertyChanged();
            }
        }
        public ChartValues<ObservablePoint> InsertionSortPoints
        {
            get => _insertionSortPoints;
            set
            {
                _insertionSortPoints = value;
                OnPropertyChanged();
            }
        }
        public ChartValues<ObservablePoint> MergeSortPoints
        {
            get => _mergeSortPoints;
            set
            {
                _mergeSortPoints = value;
                OnPropertyChanged();
            }
        }

        public SortManager()
        {
            CountingSortPoints = new ChartValues<ObservablePoint>();
            InsertionSortPoints = new ChartValues<ObservablePoint>();
            MergeSortPoints = new ChartValues<ObservablePoint>();
        }

        async public void Run()
        {
            CountingSortPoints = new ChartValues<ObservablePoint>();
            InsertionSortPoints = new ChartValues<ObservablePoint>();
            MergeSortPoints = new ChartValues<ObservablePoint>();
            Task[] sortTasks = new Task[3]
            {
                new Task(() =>{
                    int loops = ArraySize / Step;
                    Stopwatch timer = new Stopwatch();
                    for ( int i = 0; i < loops; i++ )
                    {
                        int stepSize = Step * ( i + 1 );
                        int[] array = GetRandomArray(stepSize, MaxValue, MinValue);
                        timer.Start();
                        CountingSortedArray = ArraySort.CountingSort(array, MaxValue);
                        timer.Stop();
                        AddChartPoint(stepSize, timer.ElapsedMilliseconds, CountingSortPoints);
                        timer.Reset();
                    }
                }),
                new Task(() =>{
                    int loops = ArraySize / Step;
                    Stopwatch timer = new Stopwatch();
                    for ( int i = 0; i < loops; i++ )
                    {
                        int stepSize = Step * ( i + 1 );
                        int[] array = GetRandomArray(stepSize, MaxValue, MinValue);
                        timer.Start();
                        MergeSortedArray = ArraySort.MergeSort(array);
                        timer.Stop();
                        AddChartPoint(stepSize, timer.ElapsedMilliseconds, MergeSortPoints);
                        timer.Reset();
                    }
                }),
                new Task(() =>{
                    int loops = ArraySize / Step;
                    Stopwatch timer = new Stopwatch();
                    for ( int i = 0; i < loops; i++ )
                    {
                        int stepSize = Step * ( i + 1 );
                        int[] array = GetRandomArray(stepSize, MaxValue, MinValue);
                        timer.Start();
                        InsertionSortedArray = ArraySort.InsertionSort(array);
                        timer.Stop();
                        AddChartPoint(stepSize, timer.ElapsedMilliseconds, InsertionSortPoints);
                        timer.Reset();
                    }
                })
            };

            for(int i = 0; i < sortTasks.Length; i++ )
            {
                sortTasks[i].Start();
            }
        }

        private void AddChartPoint(int size, long time, ChartValues<ObservablePoint> pointsList)
        {
            pointsList.Add(new ObservablePoint(size, time));
        }

        private static int[] GetRandomArray(int size, int maxValue, int minValue)
        {
            Random random = new Random();
            int[] array = new int[size];
            for ( int i = 0; i < size; i++ )
            {
                array[i] = random.Next(minValue, maxValue); //заполняю значениями от MinValue до MaxValue
            }
            return array;
        }
    }
}
