//Bài 7: Khoa Công nghệ thông tin - Trường Đại Học Đại Nam cần quản lý việc thanh toán
//tiền lương cho các cán bộ giáo viên trong khoa. Để quản lý được, thì nhà quản lý cần có những
//thông tin như sau:
//-Với mỗi cán bộ giáo viên, có các thông tin chung như sau: lương cứng, thưởng, phạt,
//lương thực lĩnh
//và các thông tin cá nhân của mỗi cán bộ giáo viên
//- Các thông tin cá nhân của mỗi cán bộ giáo viên: Họ và tên, năm sinh, quê quán, số
//chứng minh thư
//nhân dân.
//1. Hãy xây dựng lớp Nguoi để quản lý các thông tin cá nhân về mỗi cán bộ giáo viên
//2. Xây dựng lớp CBGV (cán bộ giáo viên) để quản lý các thông tin chung về mỗi cán bộ giáo
//viên
//3. Xây dựng các phương thức: nhập, hiển thị các thông tin cá nhân của mỗi cán bộ giáo viên
//4. Tính lương thực lĩnh cho mỗi cán bộ nếu công thức tính lương được tính như sau:
//Lương thực lĩnh=Lương cứng + thưởng - phạt
//5. Nhập vào một danh sách các cán bộ giáo viên, thực hiện các công việc sau:
//-Tìm kiếm thông tin về cán bộ giáo viên theo quê quán;
//-Hiển thị thông tin về các cán bộ giáo viên có lương thực lĩnh trên 5 triệu đồng một
//tháng.
//- Thoát khỏi chương trình.
using System;
using System.Collections.Generic;

class Nguoi
{
    public string HoTen { get; set; }
    public int NamSinh { get; set; }
    public string QueQuan { get; set; }
    public string CMND { get; set; }

    public virtual void Nhap()
    {
        Console.Write("Nhap ho ten: ");
        HoTen = Console.ReadLine();
        Console.Write("Nhap nam sinh: ");
        NamSinh = int.Parse(Console.ReadLine());
        Console.Write("Nhap que quan: ");
        QueQuan = Console.ReadLine();
        Console.Write("Nhap so CMND: ");
        CMND = Console.ReadLine();
    }

    public virtual void HienThi()
    {
        Console.WriteLine($"Ho ten: {HoTen}, Nam sinh: {NamSinh}, Que quan: {QueQuan}, CMND: {CMND}");
    }
}

class CBGV : Nguoi
{
    public double LuongCung { get; set; }
    public double Thuong { get; set; }
    public double Phat { get; set; }
    public double LuongThucLinh
    {
        get { return LuongCung + Thuong - Phat; }
    }

    public override void Nhap()
    {
        base.Nhap();
        Console.Write("Nhap luong cung: ");
        LuongCung = double.Parse(Console.ReadLine());
        Console.Write("Nhap thuong: ");
        Thuong = double.Parse(Console.ReadLine());
        Console.Write("Nhap phat: ");
        Phat = double.Parse(Console.ReadLine());
    }

    public override void HienThi()
    {
        base.HienThi();
        Console.WriteLine($"Luong cung: {LuongCung}, Thuong: {Thuong}, Phat: {Phat}, Luong thuc linh: {LuongThucLinh}");
    }
}

class Program
{
    static void Main()
    {
        List<CBGV> ds = new List<CBGV>();
        while (true)
        {
            Console.WriteLine("\n1. Nhap can bo giao vien");
            Console.WriteLine("2. Tim theo que quan");
            Console.WriteLine("3. Hien thi Giao vien co luong > 5000000");
            Console.WriteLine("4. Thoat");
            Console.Write("Chon: ");
            int chon = int.Parse(Console.ReadLine());

            switch (chon)
            {
                case 1:
                    Console.Write("Nhap so giao vien: ");
                    int n = int.Parse(Console.ReadLine());
                    for (int i = 0; i < n; i++)
                    {
                        Console.WriteLine($"Nhap Giao vien thu {i + 1}:");
                        CBGV cb = new CBGV();
                        cb.Nhap();
                        ds.Add(cb);
                    }
                    break;
                case 2:
                    Console.Write("Nhap que quan can tim: ");
                    string que = Console.ReadLine();
                    foreach (var cb in ds)
                    {
                        if (cb.QueQuan.Contains(que))
                        {
                            cb.HienThi();
                        }
                    }
                    break;
                case 3:
                    foreach (var cb in ds)
                    {
                        if (cb.LuongThucLinh > 5000000)
                        {
                            cb.HienThi();
                        }
                    }
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Chon sai. Vui long chon lai.");
                    break;
            }
        }
    }
}
