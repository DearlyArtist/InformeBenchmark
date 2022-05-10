using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AlgoritmosOrdenado;
using System.Linq;

namespace AlgoritmosOrdenado
{
    public class ArraySort
    {
        public int[] array;
        public int[] arrayIncreasing;
        public int[] arrayDecreasing;

        public ArraySort(int elements, Random random)
        {
            array = new int[elements];
            arrayIncreasing = new int[elements];
            arrayDecreasing = new int[elements];
            for (int i = 0; i < elements; i++)
            {
                array[i] = random.Next();
            }
            Array.Copy(array, arrayIncreasing, elements);
            Array.Sort(arrayIncreasing);

            Array.Copy(arrayIncreasing, arrayDecreasing, elements);
            Array.Reverse(arrayDecreasing);
        }

        public void Benchmark(Action<int[]> function)
        {
            int[] temp = new int[array.Length];
            Array.Copy(array, temp, array.Length);
            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine(function.Method.Name);

            stopwatch.Start();
            function(temp);
            stopwatch.Stop();
            Console.WriteLine("Random: " + stopwatch.ElapsedMilliseconds + "ms " + stopwatch.ElapsedTicks + "ticks");
            stopwatch.Reset();

            stopwatch.Start();
            function(temp);
            stopwatch.Stop();
            Console.WriteLine("Increasing: " + stopwatch.ElapsedMilliseconds + "ms " + stopwatch.ElapsedTicks + "ticks");
            stopwatch.Reset();

            Array.Reverse(temp);
            stopwatch.Start();
            function(temp);
            stopwatch.Stop();
            Console.WriteLine("Decreasing: " + stopwatch.ElapsedMilliseconds + "ms " + stopwatch.ElapsedTicks + "ticks");
        }

        public void BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if(arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }
        public void BubbleSortEarlyExit(int[] arr)
        {
            bool isOrdered = true;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                isOrdered = true;
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if(arr[j] > arr[j + 1])
                    {
                        isOrdered = false;
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
                if (isOrdered)
                    return;
            }
        }
        public void QuickSort(int[] arr)
        {
            QuickSort(arr, 0, arr.Length - 1);
        }
        public void QuickSort(int[] arr, int left, int right)
        {
            if(left < right)
            {
                int pivot = QuickSortIndex(arr, left, right);
                QuickSort(arr, left, pivot);
                QuickSort(arr, pivot + 1, right);
            }
        }
        public int QuickSortIndex(int[] arr, int left, int right)
        {
            int pivot = arr[(left + right) / 2];

            while (true)
            {
                while(arr[left] < pivot)
                {
                    left++;
                }
                while(arr[right] > pivot)
                {
                    right--;
                }
                if(right <= left)
                {
                    return right;
                }
                else
                {
                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                    right--;left++;
                }
            }
        }
        public void CustomSort1(int[] arr)
        {
            static List<int> BucketSort1(params int[] x)
            {
                List<int> result = new List<int>();
                int numOfBuckets = 10;

                List<int>[] buckets = new List<int>[numOfBuckets];
                for (int i = 0; i < numOfBuckets; i++)
                {
                    buckets[i] = new List<int>();
                }

                for (int i = 0; 9 < x.Length; i++)
                {
                    int buckitChoice = (x[i] / numOfBuckets);
                    buckets[buckitChoice].Add(x[i]);
                }

                for (int i = 0; i < numOfBuckets; i++)
                {
                    int[] temp = BubbleSortList(buckets[i]);
                    result.AddRange(temp);
                }

                return result;
            }

            static int[] BubbleSortList(List<int> input)
            {
                for (int i = 0; i < input.Count; i++)
                {
                    for (int j = 0; j < input.Count; j++)
                    {
                        if (input[i] < input[j])
                        {
                            int temp = input[i];
                            input[i] = input[j];
                            input[j] = temp;
                        }
                    }
                }
                return input.ToArray();
            }
        }
        public void CustomSort2(int[] arr)
        {
            static void heapSort(int[] arr, int n)
            {
                for (int i = n / 2 - 1; i >= 0; i--)
                {
                    heapify(arr, n, i);
                }
                for (int i = n - 1; i >= 0; i--)
                {
                    int temp = arr[0];
                    arr[0] = arr[1];
                    arr[1] = temp;
                    heapify(arr, i, 0);
                }
            }

            static void heapify(int[] arr, int n, int i)
            {
                int largest = i;
                int left = 2 * i + 1;
                int right = 2 * i + 2;
                if (left < n && arr[left] > arr[largest])
                {
                    largest = left;
                }
                if (right < n && arr[right] > arr[largest])
                {
                    largest = right;
                }
                if (largest != i)
                {
                    int swap = arr[i];
                    arr[i] = arr[largest];
                    arr[largest] = swap;
                    heapify(arr, n, largest);
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many numbers do you want?");
            int elements = int.Parse(Console.ReadLine());
            Console.WriteLine("What seed do you want to use?");
            int seed = int.Parse(Console.ReadLine());
            Random random = new Random(seed);
            ArraySort arraySort = new ArraySort(elements, random);

            //arraySort.Benchmark(arraySort.BubbleSort);
            arraySort.Benchmark(arraySort.BubbleSortEarlyExit);
            arraySort.Benchmark(arraySort.QuickSort);
            arraySort.Benchmark(arraySort.CustomSort1);
            arraySort.Benchmark(arraySort.CustomSort2);

        }
    }
}
