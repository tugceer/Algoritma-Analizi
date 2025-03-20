using System;

class Program
{
    static int MaxSubarraySum(int[] arr)
    {
        return Helper(arr, 0, arr.Length - 1);
    }

    static int Helper(int[] arr, int low, int high)
    {
        if (low == high)
            return arr[low];

        int mid = (low + high) / 2;

        int leftMax = Helper(arr, low, mid);
        int rightMax = Helper(arr, mid + 1, high);
        int crossMax = MaxCrossingSum(arr, low, mid, high);

        return Math.Max(leftMax, Math.Max(rightMax, crossMax));
    }

    static int MaxCrossingSum(int[] arr, int low, int mid, int high)
    {
        // Orta noktadan sola doğru maksimum toplam
        int leftSum = int.MinValue, total = 0;
        for (int i = mid; i >= low; i--)
        {
            total += arr[i];
            if (total > leftSum)
                leftSum = total;
        }

        // Orta noktadan sağa doğru maksimum toplam
        int rightSum = int.MinValue;
        total = 0;
        for (int i = mid + 1; i <= high; i++)
        {
            total += arr[i];
            if (total > rightSum)
                rightSum = total;
        }

        return leftSum + rightSum;
    }

    static void Main()
    {
        int[] arr = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
        Console.WriteLine("Maksimum Alt Dizi Toplamı: " + MaxSubarraySum(arr));

        
        Console.WriteLine("\nÇıkmak için bir tuşa bas...");
        Console.ReadKey();
    }
}
