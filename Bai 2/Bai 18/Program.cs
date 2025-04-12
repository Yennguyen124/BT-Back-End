//Bài 18:
//1.Thông tin về mỗi cá nhân bao gồm : Họ tên, giới tính, tuổi. Hãy xây dựng lớp Nguoi chứa
//các đối tượng là các cá nhân và xây dựng các phương thức:
//-Các toán tử tạo lập: Nguoi(); Nguoi(String, boolean, int);
//-Phương thức in() để in thông tin về một cá nhân
//2. Hãy xây dựng lớp CoQuan chứa thông tin về các cá nhân trong một đơn vị được dẫn xuất
//từ lớp Nguoi và có thêm các thành phần:
//-Thuộc tính kiểu String xác định đơn vị công tác (bộ môn, phòng), thuộc tính kiểu double xác
//định hệ số lương.
//- Viết đè phương thức in() ở lớp Nguoi để in thông tin về một cá nhân trong CoQuan
//- Cài đặt phương thức tinhLuong(CoQuan) để tính lương cho mỗi cá nhân trong cơ quan.
//Lương =hệ số lương x Lương cơ bản;
//Trong đó lương cơ bản là một hằng số được quy định bởi nhà nước (Lương cơ bản ở thời điểm
//hiện tại đang là 1.050.000 vnđ).
//3. Nhập vào một danh sách các cá nhân thuộc vào lớp CoQuan:
//-Hiển thị thông tin cho cá nhân có đơn vị là Phòng tài chính;
//-Tìm kiếm thông tin theo họ tên;
//-Thoát khỏi chương trình.
using System;
using System.Collections.Generic;

class Nguoi
{
    public string HoTen { get; set; }
    public bool GioiTinh { get; set; } // true: Nam, false: Nu
    public int Tuoi { get; set; }

    public Nguoi() { }

    public Nguoi(string hoTen, bool gioiTinh, int tuoi)
    {
        HoTen = hoTen;
        GioiTinh = gioiTinh;
        Tuoi = tuoi;
    }

    public virtual void In()
    {
        string gt = GioiTinh ? "Nam" : "Nu";
        Console.WriteLine($"Ho ten: {HoTen}, Gioi tinh: {gt}, Tuoi: {Tuoi}");
    }
}

class CoQuan : Nguoi
{
    public string DonVi { get; set; }
    public double HeSoLuong { get; set; }
    public const double LuongCoBan = 1050000;

    public CoQuan() { }

    public CoQuan(string hoTen, bool gioiTinh, int tuoi, string donVi, double heSoLuong)
        : base(hoTen, gioiTinh, tuoi)
    {
        DonVi = donVi;
        HeSoLuong = heSoLuong;
    }

    public override void In()
    {
        base.In();
        Console.WriteLine($"Don vi: {DonVi}, He so luong: {HeSoLuong}, Luong: {TinhLuong()} VND");
    }

    public double TinhLuong()
    {
        return HeSoLuong * LuongCoBan;
    }
}

class Program
{
    static void Main()
    {
        List<CoQuan> danhSach = new List<CoQuan>();

        while (true)
        {
            Console.WriteLine("\n=== MENU ===");
            Console.WriteLine("1. Nhap danh sach ca nhan");
            Console.WriteLine("2. Hien thi thong tin ca nhan thuoc 'Phong tai chinh'");
            Console.WriteLine("3. Tim kiem theo ho ten");
            Console.WriteLine("4. Thoat");
            Console.Write("Chon: ");
            int chon = int.Parse(Console.ReadLine());

            switch (chon)
            {
                case 1:
                    Console.Write("Nhap so luong ca nhan: ");
                    int n = int.Parse(Console.ReadLine());
                    for (int i = 0; i < n; i++)
                    {
                        Console.WriteLine($"\nCa nhan thu {i + 1}:");
                        CoQuan c = new CoQuan();
                        Console.Write("Nhap ho ten: ");
                        c.HoTen = Console.ReadLine();
                        Console.Write("Nhap gioi tinh (nam/nu): ");
                        string gt = Console.ReadLine().ToLower();
                        c.GioiTinh = gt == "nam";
                        Console.Write("Nhap tuoi: ");
                        c.Tuoi = int.Parse(Console.ReadLine());
                        Console.Write("Nhap don vi: ");
                        c.DonVi = Console.ReadLine();
                        Console.Write("Nhap he so luong: ");
                        c.HeSoLuong = double.Parse(Console.ReadLine());
                        danhSach.Add(c);
                    }
                    break;

                case 2:
                    Console.WriteLine("\n--- Cac ca nhan thuoc Phong tai chinh ---");
                    foreach (var c in danhSach)
                    {
                        if (c.DonVi.ToLower().Contains("phong tai chinh"))
                        {
                            c.In();
                        }
                    }
                    break;

                case 3:
                    Console.Write("Nhap ho ten can tim: ");
                    string tenTim = Console.ReadLine().ToLower();
                    foreach (var c in danhSach)
                    {
                        if (c.HoTen.ToLower().Contains(tenTim))
                        {
                            c.In();
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
