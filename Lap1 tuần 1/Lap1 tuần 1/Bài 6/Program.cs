Console.WriteLine("Nhap 1 so: ");
double soNhap = Convert.ToDouble(Console.ReadLine());


// kiem tra kq//
if (soNhap > 0)
{
    Console.WriteLine("So duong");
}
else if (soNhap < 0)
{
    Console.WriteLine("So am");
}
else
{
    Console.WriteLine("So 0");
}
