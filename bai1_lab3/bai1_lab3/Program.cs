//Bài 1: Viết chương trình nhập vào tên và tuổi, sau đó in ra màn hình thông báo "Xin chào [tên], bạn[tuổi] tuổi!".

//?? Toán tử hợp nhất null
using System;

int? x = null;
int y = x ?? 100; //Nếu x là null thì y sẽ là giá trị 100
Console.WriteLine(y);

//khai báo biến
string? ten;
int tuoi;
//nhập dữ liệu từ bàn phím
Console.Write("Nhap ten: ");
ten = Console.ReadLine();
Console.Write("Nhap tuoi: ");
tuoi = int.Parse(Console.ReadLine() ?? "0");
//Xuất ra màn hình
//Console.WriteLine("Xin chào " + ten + ", bạn "tuoi+" tuổi");
Console.WriteLine($"Xin chao {ten}, ban {tuoi} tuoi"); //chuỗi nội suy