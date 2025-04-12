using System;
// Nhập số cần kiểm tra
Console.Write("Nhap mot so nguyen: ");
int n = Convert.ToInt32(Console.ReadLine());

// Kiểm tra số nguyên tố
if (n <= 1)
{
    Console.WriteLine(n + " Khong phai so nguyen to.");
}
else
{
    bool isPrime = true;

    // Kiểm tra chia hết cho các số từ 2 đến căn bậc 2 của n
    for (int i = 2; i <= Math.Sqrt(n); i++)
    {
        if (n % i == 0)
        {
            isPrime = false;
            break;
        }
    }

    // In kết quả
    if (isPrime)
    {
        Console.WriteLine(n + " la so nguyen to.");
    }
    else
    {
        Console.WriteLine(n + " khong la so nguyen to .");
    }
}
