using System;

void TimSoLonThuHai()
{
    Console.Write("Nhap so phan tu n: ");
    int n = int.Parse(Console.ReadLine());

    if (n < 2)
    {
        Console.WriteLine("Mang phai co it nhat 2 phan tu.");
        return;
    }

    int[] arr = new int[n];

    for (int i = 0; i < n; i++)
    {
        Console.Write("Nhap phan tu thu " + (i + 1) + ": ");
        arr[i] = int.Parse(Console.ReadLine());
    }

    int max1 = int.MinValue, max2 = int.MinValue;

    for (int i = 0; i < n; i++)
    {
        if (arr[i] > max1)
        {
            max2 = max1;
            max1 = arr[i];
        }
        else if (arr[i] > max2 && arr[i] < max1)
        {
            max2 = arr[i];
        }
    }

    if (max2 == int.MinValue)
    {
        Console.WriteLine("Khong co so lon thu hai.");
    }
    else
    {
        Console.WriteLine("So lon thu hai la: " + max2);
    }
}

TimSoLonThuHai();

