using System;

void DemSoAmDuong()
{
    Console.Write("Nhap so phan tu n: ");
    int n = int.Parse(Console.ReadLine());

    int[] arr = new int[n];
    int soAm = 0, soDuong = 0;

    for (int i = 0; i < n; i++)
    {
        Console.Write("Nhap phan tu thu " + (i + 1) + ": ");
        arr[i] = int.Parse(Console.ReadLine());

        if (arr[i] > 0)
        {
            soDuong++;
        }
        else if (arr[i] < 0)
        {
            soAm++;
        }
    }

    Console.WriteLine("So luong so duong: " + soDuong);
    Console.WriteLine("So luong so am: " + soAm);
}

DemSoAmDuong();

