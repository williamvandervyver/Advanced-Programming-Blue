//Task 1
LinearSearch<int> ls = new LinearSearch<int>();
int result = ls.Search(new int[] {4, 6, 8, 10}, 8);
Console.WriteLine(result);

//Task 2
BinarySearch<int> ls2 = new BinarySearch<int>();
int result2 = ls2.Search(new int[] {4, 6, 8, 10}, 8);
Console.WriteLine(result2);


class LinearSearch<T> where T : IComparable<T>
{
    public int Search(T[] arr, T key)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i].Equals(key))
                return i;
        }
        return -1;
    }
}

class BinarySearch<T> where T : IComparable<T>
{
    public int Search(T[] arr, T key)
    {
        int left = 0, right = arr.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int comparison = arr[mid].CompareTo(key);

            if (comparison == 0) return mid;
            if (comparison < 0) left = mid + 1;
            else right = mid - 1;
        }

        return -1;
    }
}

//1..10 | ForEach-Object { Measure-Command { dotnet run } | Tee-Object -Variable times; "" }; $times | Measure-Object -Property TotalMilliseconds -Average -Minimum -Maximum
//Above Command Line for testing benchmark 10 times