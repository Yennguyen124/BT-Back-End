// Bài 1//
//?? Toán tử hợp nhất null
using System;

int? x = null;
int y = x ?? 100; //Nếu x là null thì y sẽ là giá trị 100
Console.WriteLine(y);

//khai báo biến
string? ten;
int tuoi;
//nhập dữ liệu từ bàn phím
Console.Write("Nhập tên: ");
ten = Console.ReadLine();
Console.Write("Nhập tuổi: ");
tuoi = int.Parse(Console.ReadLine() ?? "0");
//Xuất ra màn hình
//Console.WriteLine("Xin chào " + ten + ", bạn "tuoi+" tuổi");
Console.WriteLine($"Xin chào {ten}, bạn {tuoi} tuổi"); //chuỗi nội suy
