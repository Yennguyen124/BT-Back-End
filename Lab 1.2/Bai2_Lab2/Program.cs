using System;

bool LaSoNguyenTo(int n)
{
    if (n < 2) return false;
    for (int i = 2; i * i <= n; i++)
    {
        if (n % i == 0) return false;
    }
    return true;
}

void TimSoNguyenTo()
{
    Console.Write("Nahp so phan tu n: ");
    int n = int.Parse(Console.ReadLine());

    int[] arr = new int[n];
    for (int i = 0; i < n; i++)
    {
        Console.Write("Nhap phan tu thu" + (i + 1) + ": ");
        arr[i] = int.Parse(Console.ReadLine());
    }

    Console.WriteLine("Cac so nguyen to trong bang:");
    for (int i = 0; i < n; i++)
    {
        if (LaSoNguyenTo(arr[i]))
        {
            Console.WriteLine("Chi so: " + i + ", Gia tri: " + arr[i]);
        }
    }
}

TimSoNguyenTo();