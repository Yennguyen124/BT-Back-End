//Để quản lý các hộ dân trong một khu phố, người ta quản lý các thông tin như sau:
//-Với mỗi hộ dân, có các thuộc tính:
//+Số thành viên trong hộ (số người)
//+ Số nhà của hộ dân đó (số nhà được gắn cho mỗi hộ dân)
//+ Thông tin về mỗi cá nhân trong hộ gia đình.
//- Với mỗi cá nhân, người ta quản lý các thông tin như: số chứng minh nhân dân, họ và
//tên, tuổi, năm sinh, nghề nghiệp.
//1. Hãy xây dựng lớp Nguoi để quản lý thông tin về mỗi cá nhân.
//2. Xây dựng lớp KhuPho để quản lý thông tin về các hộ gia đình.
//3. Viết các phương thức nhập, hiển thị thông tin cho mỗi hộ gia đình.
//4. Cài đặt chương trình thực hiện các công việc sau:
//-Nhập vào một dãy gồm n hộ dân (n - nhập từ bàn phím).

using System;
using System.Collections.Generic;

// Lop Nguoi
class Nguoi
{
    public string CMND { get; set; }
    public string HoTen { get; set; }
    public int Tuoi { get; set; }
    public int NamSinh { get; set; }
    public string NgheNghiep { get; set; }

    public void Nhap()
    {
        Console.Write("Nhap ho ten: ");
        HoTen = Console.ReadLine();
        Console.Write("Nhap so CMND: ");
        CMND = Console.ReadLine();
        Console.Write("Nhap tuoi: ");
        Tuoi = int.Parse(Console.ReadLine());
        Console.Write("Nhap nam sinh: ");
        NamSinh = int.Parse(Console.ReadLine());
        Console.Write("Nhap nghe nghiep: ");
        NgheNghiep = Console.ReadLine();
    }

    public void HienThi()
    {
        Console.WriteLine($"Ho ten: {HoTen}, CMND: {CMND}, Tuoi: {Tuoi}, Nam sinh: {NamSinh}, Nghe nghiep: {NgheNghiep}");
    }
}

// Lop HoGiaDinh
class HoGiaDinh
{
    public int SoThanhVien { get; set; }
    public string SoNha { get; set; }
    public List<Nguoi> ThanhVien = new List<Nguoi>();

    public void Nhap()
    {
        Console.Write("Nhap so nha: ");
        SoNha = Console.ReadLine();
        Console.Write("Nhap so thanh vien: ");
        SoThanhVien = int.Parse(Console.ReadLine());

        for (int i = 0; i < SoThanhVien; i++)
        {
            Console.WriteLine($"--- Nhap thong tin nguoi thu {i + 1} ---");
            Nguoi n = new Nguoi();
            n.Nhap();
            ThanhVien.Add(n);
        }
    }

    public void HienThi()
    {
        Console.WriteLine($"\nSo nha: {SoNha}, So thanh vien: {SoThanhVien}");
        foreach (var n in ThanhVien)
        {
            n.HienThi();
        }
    }
}

// Lop KhuPho
class KhuPho
{
    public List<HoGiaDinh> DanhSachHo = new List<HoGiaDinh>();

    public void NhapDanhSach()
    {
        Console.Write("Nhap so ho dan trong khu pho: ");
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\n=== Nhap ho dan thu {i + 1} ===");
            HoGiaDinh ho = new HoGiaDinh();
            ho.Nhap();
            DanhSachHo.Add(ho);
        }
    }

    public void HienThiDanhSach()
    {
        Console.WriteLine("\n=== Danh sach ho dan trong khu pho ===");
        foreach (var ho in DanhSachHo)
        {
            ho.HienThi();
            Console.WriteLine("-----------------------");
        }
    }
}

// Main
class Program
{
    static void Main()
    {
        KhuPho kp = new KhuPho();
        kp.NhapDanhSach();
        kp.HienThiDanhSach();
    }
}

