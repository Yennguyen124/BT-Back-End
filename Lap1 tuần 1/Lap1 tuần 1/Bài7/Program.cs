using System;
Console.WriteLine("Nhap 1  nam : ");
int nam = Convert.ToInt32(Console.ReadLine());
// kiem tra nam nhuan
if (nam % 4 == 0 && nam % 100 != 0 || nam % 400 == 0)
{
    Console.WriteLine(nam + " la nam nhuan");
}
else
{
    Console.WriteLine(nam + " khong phai la nam nhuan");
}