using System;

class Program
{
    static int TernarySearch(int[] arr, int left, int right, int key)
    {
        if (left > right)
            return -1;

        int mid1 = left + (right - left) / 3;
        int mid2 = right - (right - left) / 3;

        if (arr[mid1] == key)
            return mid1;

        if (arr[mid2] == key)
            return mid2;

        if (key < arr[mid1])
            return TernarySearch(arr, left, mid1 - 1, key);

        if (key > arr[mid2])
            return TernarySearch(arr, mid2 + 1, right, key);

        return TernarySearch(arr, mid1 + 1, mid2 - 1, key);
    }

    static void Main()
    {
        int[] arr = {1,3,8,15,29,33,46,60,71,92};

        Console.WriteLine(TernarySearch(arr, 0, arr.Length - 1, 46));
    }
}