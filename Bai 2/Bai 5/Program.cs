//Bài 5: Để quản lý khách hàng đến thuê phòng của một khách sạn, người ta cần quản lý những
//thông tin sau:
//-Số ngày trọ, loại phòng trọ, giá phòng, và các thông tin cá nhân về mỗi khách trọ.
//- Với mỗi cá nhân, người ta cần quản lý các thông tin : Họ và tên, năm sinh, số chứng
//minh thư nhân dân.
//1. Hãy xây dựng lớp Nguoi để quản lý thông tin cá nhân về mỗi cá nhân.
//2. Xây dựng lớp KhachSan để quản lý các thông tin về khách thuê phòng.
//3. Viết các phương thức : nhập, hiển thị các thông tin về mỗi khách thuê phòng.
//4. Cài đặt chương trình thực hiện các công việc sau:
//-Nhập vào một dãy gồm n khách trọ ( n - nhập từ bàn phím)
//- Hiển thị ra màn hình thông tin về các cá nhân hiện đang trọ ở khách sạn đó.
//- Tìm kiếm thông tin về những khách thuê phòng theo họ và tên.
//- Tính tiền cho khách hàng khi thanh toán trả phòng
//- Thoát khỏi chương trình.
using System;
using System.Collections.Generic;

class Nguoi
{
    public string HoTen { get; set; }
    public int NamSinh { get; set; }
    public string SoChungMinh { get; set; }

    // Nhap thong tin ca nhan
    public void NhapThongTin()
    {
        Console.Write("Ho va ten: ");
        HoTen = Console.ReadLine();
        Console.Write("Nam sinh: ");
        NamSinh = int.Parse(Console.ReadLine());
        Console.Write("So chung minh thu nhan dan: ");
        SoChungMinh = Console.ReadLine();
    }

    // Hien thi thong tin ca nhan
    public void HienThiThongTin()
    {
        Console.WriteLine($"Ho va ten: {HoTen}, Nam sinh: {NamSinh}, So CMND: {SoChungMinh}");
    }
}

class KhachSan
{
    public Nguoi Khach { get; set; }
    public int SoNgayTro { get; set; }
    public string LoaiPhong { get; set; }
    public double GiaPhong { get; set; }

    // Nhap thong tin khach thue phong
    public void NhapThongTin()
    {
        Khach = new Nguoi();
        Khach.NhapThongTin();
        Console.Write("So ngay tro: ");
        SoNgayTro = int.Parse(Console.ReadLine());
        Console.Write("Loai phong (Standard / Deluxe / Suite): ");
        LoaiPhong = Console.ReadLine();

        // Xac dinh gia phong theo loai phong
        switch (LoaiPhong.ToLower())
        {
            case "standard":
                GiaPhong = 500000;
                break;
            case "deluxe":
                GiaPhong = 800000;
                break;
            case "suite":
                GiaPhong = 1200000;
                break;
            default:
                Console.WriteLine("Loai phong khong hop le, mac dinh chon phong Standard.");
                GiaPhong = 500000;
                break;
        }
    }

    // Hien thi thong tin khach thue phong
    public void HienThiThongTin()
    {
        Khach.HienThiThongTin();
        Console.WriteLine($"So ngay tro: {SoNgayTro}, Loai phong: {LoaiPhong}, Gia phong: {GiaPhong} VND");
    }

    // Tinh tien phong khi thanh toan
    public double TinhTien()
    {
        return SoNgayTro * GiaPhong;
    }
}

class Program
{
    static void Main()
    {
        List<KhachSan> danhSachKhach = new List<KhachSan>();

        while (true)
        {
            Console.WriteLine("Chon chuc nang:");
            Console.WriteLine("1. Nhap thong tin khach tro");
            Console.WriteLine("2. Hien thi thong tin khach tro");
            Console.WriteLine("3. Tim kiem khach tro theo ho ten");
            Console.WriteLine("4. Tinh tien phong");
            Console.WriteLine("5. Thoat");
            Console.Write("Lua chon: ");
            int chon = int.Parse(Console.ReadLine());

            switch (chon)
            {
                case 1:
                    Console.Write("Nhap so khach tro: ");
                    int n = int.Parse(Console.ReadLine());
                    for (int i = 0; i < n; i++)
                    {
                        KhachSan khach = new KhachSan();
                        khach.NhapThongTin();
                        danhSachKhach.Add(khach);
                    }
                    break;

                case 2:
                    Console.WriteLine("Thong tin khach tro:");
                    foreach (var khach in danhSachKhach)
                    {
                        khach.HienThiThongTin();
                        Console.WriteLine("---------------");
                    }
                    break;

                case 3:
                    Console.Write("Nhap ho va ten can tim: ");
                    string hoTen = Console.ReadLine();
                    bool timThay = false;
                    foreach (var khach in danhSachKhach)
                    {
                        if (khach.Khach.HoTen.Contains(hoTen, StringComparison.OrdinalIgnoreCase))
                        {
                            khach.HienThiThongTin();
                            timThay = true;
                        }
                    }
                    if (!timThay)
                    {
                        Console.WriteLine("Khong tim thay khach tro voi ten nay.");
                    }
                    break;

                case 4:
                    Console.Write("Nhap ho va ten khach can tinh tien: ");
                    hoTen = Console.ReadLine();
                    bool timThayTien = false;
                    foreach (var khach in danhSachKhach)
                    {
                        if (khach.Khach.HoTen.Contains(hoTen, StringComparison.OrdinalIgnoreCase))
                        {
                            double tien = khach.TinhTien();
                            Console.WriteLine($"Tien phong cua khach {khach.Khach.HoTen}: {tien} VND");
                            timThayTien = true;
                        }
                    }
                    if (!timThayTien)
                    {
                        Console.WriteLine("Khong tim thay khach tro voi ten nay.");
                    }
                    break;

                case 5:
                    Console.WriteLine("Thoat khoi chuong trinh.");
                    return;

                default:
                    Console.WriteLine("Lua chon khong hop le. Vui long thu lai.");
                    break;
            }
        }
    }
}
