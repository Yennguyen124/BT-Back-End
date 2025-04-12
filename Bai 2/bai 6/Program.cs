//Bài 6: Để quản lý hồ sơ học sinh của trường THPT, người ta cần quản lý những thông tin như
//sau:
//-Các thông tin về : lớp, khoá học, kỳ học, và các thông tin cá nhân của mỗi học sinh.
//- Với mỗi học sinh, các thông tin cá nhân cần quản lý gồm có: Họ và tên, tuổi, năm
//sinh, quê quán, giới tính.
//1. Hãy xây dựng lớp Nguoi để quản lý các thông tin cá nhân của mỗi học sinh.
//2. Xây dựng lớp HSHocSinh (hồ sơ học sinh) để lý các thông tin về mỗi học sinh.
//3. Xây dựng các phương thức : nhập, hiển thị các thông tin về hồ sơ cá nhân của mỗi học sinh.
//4. Cài đặt chương trình thực hiện các công việc sau:
//-Nhập vào một danh sách gồm n học sinh ( n- nhập từ bàn phím)
//- Hiển thị ra màn hình tất cả những học sinh nữ và sinh năm 1985.
//- Tìm kiếm học sinh theo quê quán.
//- Thoát khỏi chương trình.
using System;
using System.Collections.Generic;

class Nguoi
{
    public string HoTen { get; set; }
    public int Tuoi { get; set; }
    public int NamSinh { get; set; }
    public string QueQuan { get; set; }
    public string GioiTinh { get; set; }

    // Nhap thong tin ca nhan
    public void NhapThongTin()
    {
        Console.Write("Ho va ten: ");
        HoTen = Console.ReadLine();
        Console.Write("Tuoi: ");
        Tuoi = int.Parse(Console.ReadLine());
        Console.Write("Nam sinh: ");
        NamSinh = int.Parse(Console.ReadLine());
        Console.Write("Que quan: ");
        QueQuan = Console.ReadLine();
        Console.Write("Gioi tinh (Nam/Nu): ");
        GioiTinh = Console.ReadLine();
    }

    // Hien thi thong tin ca nhan
    public void HienThiThongTin()
    {
        Console.WriteLine($"Ho va ten: {HoTen}, Tuoi: {Tuoi}, Nam sinh: {NamSinh}, Que quan: {QueQuan}, Gioi tinh: {GioiTinh}");
    }
}

class HSHocSinh
{
    public string Lop { get; set; }
    public string KhoaHoc { get; set; }
    public string KyHoc { get; set; }
    public Nguoi HocSinh { get; set; }

    // Nhap thong tin ho so hoc sinh
    public void NhapThongTin()
    {
        HocSinh = new Nguoi();
        HocSinh.NhapThongTin();
        Console.Write("Lop: ");
        Lop = Console.ReadLine();
        Console.Write("Khoa hoc: ");
        KhoaHoc = Console.ReadLine();
        Console.Write("Ky hoc: ");
        KyHoc = Console.ReadLine();
    }

    // Hien thi thong tin ho so hoc sinh
    public void HienThiThongTin()
    {
        HocSinh.HienThiThongTin();
        Console.WriteLine($"Lop: {Lop}, Khoa hoc: {KhoaHoc}, Ky hoc: {KyHoc}");
    }
}

class Program
{
    static void Main()
    {
        List<HSHocSinh> danhSachHocSinh = new List<HSHocSinh>();

        while (true)
        {
            Console.WriteLine("Chon chuc nang:");
            Console.WriteLine("1. Nhap thong tin hoc sinh");
            Console.WriteLine("2. Hien thi thong tin hoc sinh nu va sinh nam 1985");
            Console.WriteLine("3. Tim kiem hoc sinh theo que quan");
            Console.WriteLine("4. Thoat");
            Console.Write("Lua chon: ");
            int chon = int.Parse(Console.ReadLine());

            switch (chon)
            {
                case 1:
                    Console.Write("Nhap so hoc sinh: ");
                    int n = int.Parse(Console.ReadLine());
                    for (int i = 0; i < n; i++)
                    {
                        HSHocSinh hocSinh = new HSHocSinh();
                        hocSinh.NhapThongTin();
                        danhSachHocSinh.Add(hocSinh);
                    }
                    break;

                case 2:
                    Console.WriteLine("Thong tin hoc sinh nu va sinh nam 1985:");
                    foreach (var hs in danhSachHocSinh)
                    {
                        if (hs.HocSinh.GioiTinh.ToLower() == "nu" && hs.HocSinh.NamSinh == 1985)
                        {
                            hs.HienThiThongTin();
                            Console.WriteLine("---------------");
                        }
                    }
                    break;

                case 3:
                    Console.Write("Nhap que quan can tim: ");
                    string queQuan = Console.ReadLine();
                    bool timThay = false;
                    foreach (var hs in danhSachHocSinh)
                    {
                        if (hs.HocSinh.QueQuan.Contains(queQuan, StringComparison.OrdinalIgnoreCase))
                        {
                            hs.HienThiThongTin();
                            timThay = true;
                        }
                    }
                    if (!timThay)
                    {
                        Console.WriteLine("Khong tim thay hoc sinh voi que quan nay.");
                    }
                    break;

                case 4:
                    Console.WriteLine("Thoat khoi chuong trinh.");
                    return;

                default:
                    Console.WriteLine("Lua chon khong hop le. Vui long thu lai.");
                    break;
            }
        }
    }
}
