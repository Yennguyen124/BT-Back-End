using System;
Console.WriteLine("Nhap 1 so nguyen duong n: ");
int n = Convert.ToInt32(Console.ReadLine());
// kiem tra so nguyen duong
if (n > 0)
{
    Console.WriteLine(n + " la so nguyen duong");
}
else
{
    Console.WriteLine(n + " khong phai la so nguyen duong");
}
// tinh giai thua//
int giaiThua = 1;
for (int i = 1; i <= n; i++)
{
    giaiThua *= i;
}
Console.WriteLine("Giai thua cua " + n + " la: " + giaiThua);