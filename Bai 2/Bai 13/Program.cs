//Bài 13: Một công ty được giao nhiệm vụ quản lý các phương tiện giao thông gồm các loại: ô
//tô, xe máy, xe tải.
//+ mỗi loại phương tiện giao thông cần quản lý: Hãng sản xuất, năm sản xuất, giá bán
//và màu.
//+ Các ô tô cần quản lý: số chỗ ngồi, kiểu động cơ
//+ Xe máy cần quản lý: công suất
//+ Xe tải cần quản lý: trọng tải.
//1.Xây dựng các lớp XeTai, XeMay, OTo kế thừa từ lớp PTGT.
//2. Xây dựng các hàm để truy nhập, hiển thị và kiểm tra các thuộc tính của các lớp.
//3. Xây dựng lớp QLPTGT cài đặt các phương thức thực hiện các chức năng sau:
//-Nhập đăng ký phương tiện
//- Tìm phương tiện theo màu hoặc theo năm sản xuất.
//- Kết thúc chương trình.
using System;
using System.Collections.Generic;

// Lớp cơ sở PTGT (Phương tiện giao thông)
public class PTGT
{
    public string HangSanXuat { get; set; }
    public int NamSanXuat { get; set; }
    public double GiaBan { get; set; }
    public string Mau { get; set; }

    // Phương thức nhập thông tin cơ bản của phương tiện
    public virtual void Nhap()
    {
        Console.Write("Nhập hãng sản xuất: ");
        HangSanXuat = Console.ReadLine();
        Console.Write("Nhập năm sản xuất: ");
        NamSanXuat = int.Parse(Console.ReadLine());
        Console.Write("Nhập giá bán: ");
        GiaBan = double.Parse(Console.ReadLine());
        Console.Write("Nhập màu: ");
        Mau = Console.ReadLine();
    }

    // Phương thức hiển thị thông tin cơ bản của phương tiện
    public virtual void In()
    {
        Console.WriteLine($"Hãng sản xuất: {HangSanXuat}");
        Console.WriteLine($"Năm sản xuất: {NamSanXuat}");
        Console.WriteLine($"Giá bán: {GiaBan}");
        Console.WriteLine($"Màu: {Mau}");
    }
}

// Lớp OTo kế thừa từ PTGT
public class OTo : PTGT
{
    public int SoChoNgoi { get; set; }
    public string KieuDongCo { get; set; }

    public override void Nhap()
    {
        base.Nhap();
        Console.Write("Nhập số chỗ ngồi: ");
        SoChoNgoi = int.Parse(Console.ReadLine());
        Console.Write("Nhập kiểu động cơ: ");
        KieuDongCo = Console.ReadLine();
    }

    public override void In()
    {
        base.In();
        Console.WriteLine($"Số chỗ ngồi: {SoChoNgoi}");
        Console.WriteLine($"Kiểu động cơ: {KieuDongCo}");
    }
}

// Lớp XeMay kế thừa từ PTGT
public class XeMay : PTGT
{
    public int CongSuat { get; set; }

    public override void Nhap()
    {
        base.Nhap();
        Console.Write("Nhập công suất xe máy: ");
        CongSuat = int.Parse(Console.ReadLine());
    }

    public override void In()
    {
        base.In();
        Console.WriteLine($"Công suất: {CongSuat} mã lực");
    }
}

// Lớp XeTai kế thừa từ PTGT
public class XeTai : PTGT
{
    public double TrongTai { get; set; }

    public override void Nhap()
    {
        base.Nhap();
        Console.Write("Nhập trọng tải xe tải (kg): ");
        TrongTai = double.Parse(Console.ReadLine());
    }

    public override void In()
    {
        base.In();
        Console.WriteLine($"Trọng tải: {TrongTai} kg");
    }
}

// Lớp QLPTGT để quản lý các phương tiện giao thông
public class QLPTGT
{
    private List<PTGT> dsPhuongTien = new List<PTGT>();

    // Phương thức nhập đăng ký phương tiện
    public void NhapPhuongTien()
    {
        Console.WriteLine("Chọn loại phương tiện:");
        Console.WriteLine("1. Ô tô");
        Console.WriteLine("2. Xe máy");
        Console.WriteLine("3. Xe tải");
        Console.Write("Nhập lựa chọn: ");
        int luaChon = int.Parse(Console.ReadLine());

        PTGT pt = null;

        switch (luaChon)
        {
            case 1:
                pt = new OTo();
                break;
            case 2:
                pt = new XeMay();
                break;
            case 3:
                pt = new XeTai();
                break;
            default:
                Console.WriteLine("Lựa chọn không hợp lệ!");
                return;
        }

        pt.Nhap();
        dsPhuongTien.Add(pt);
        Console.WriteLine("Đăng ký phương tiện thành công!");
    }

    // Phương thức tìm phương tiện theo màu
    public void TimPhuongTienTheoMau()
    {
        Console.Write("Nhập màu cần tìm: ");
        string mau = Console.ReadLine();

        bool found = false;
        foreach (var pt in dsPhuongTien)
        {
            if (pt.Mau.ToLower() == mau.ToLower())
            {
                pt.In();
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("Không tìm thấy phương tiện có màu này.");
        }
    }

    // Phương thức tìm phương tiện theo năm sản xuất
    public void TimPhuongTienTheoNamSanXuat()
    {
        Console.Write("Nhập năm sản xuất cần tìm: ");
        int nam = int.Parse(Console.ReadLine());

        bool found = false;
        foreach (var pt in dsPhuongTien)
        {
            if (pt.NamSanXuat == nam)
            {
                pt.In();
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("Không tìm thấy phương tiện nào được sản xuất vào năm này.");
        }
    }

    // Phương thức hiển thị tất cả phương tiện
    public void InDanhSachPhuongTien()
    {
        foreach (var pt in dsPhuongTien)
        {
            pt.In();
            Console.WriteLine();
        }
    }
}

public class Program
{
    public static void Main()
    {
        QLPTGT qlptgt = new QLPTGT();
        bool chayChuongTrinh = true;

        while (chayChuongTrinh)
        {
            Console.WriteLine("Chọn chức năng:");
            Console.WriteLine("1. Nhập đăng ký phương tiện");
            Console.WriteLine("2. Tìm phương tiện theo màu");
            Console.WriteLine("3. Tìm phương tiện theo năm sản xuất");
            Console.WriteLine("4. Hiển thị tất cả phương tiện");
            Console.WriteLine("5. Kết thúc chương trình");
            Console.Write("Nhập lựa chọn: ");
            int luaChon = int.Parse(Console.ReadLine());

            switch (luaChon)
            {
                case 1:
                    qlptgt.NhapPhuongTien();
                    break;
                case 2:
                    qlptgt.TimPhuongTienTheoMau();
                    break;
                case 3:
                    qlptgt.TimPhuongTienTheoNamSanXuat();
                    break;
                case 4:
                    qlptgt.InDanhSachPhuongTien();
                    break;
                case 5:
                    chayChuongTrinh = false;
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ.");
                    break;
            }
        }
    }
}


