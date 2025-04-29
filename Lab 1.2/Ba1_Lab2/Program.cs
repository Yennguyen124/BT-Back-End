using System;

void TongSoChan(int n)
{
    int sum = 0;
    for (int i = 0; i <= n; i++)
    {
        if (i % 2 == 0)
        {
            sum += i;
        }
    }
    Console.WriteLine("Tong so chan tu 1 den n  " + n + " la: " + sum);
}

TongSoChan(10);
