//Bai 3
//Các thí sinh dự thi đại học bao gồm các thí sinh thi khối A, thí sinh thi khối B, thí sinh thi khối C

//+ Các thí sinh cần quản lý các thuộc tính: Số báo danh, họ tên, địa chỉ, ưu tiên.
//+ Thí sinh thi khối A thi các môn: Toán, lý, hoá
//+ Thí sinh thi khối B thi các môn: Toán, Hoá, Sinh
//+ Thí sinh thi khối C thi các môn: Văn, Sử, Địa
//1. Xây dựng các lớp để quản lý các thí sinh sao cho sử dụng lại được nhiều nhất.
//2. Xây dựng lớp TuyenSinh cài đặt các phương thức thực hiện các nhiệm vụ sau:
//-Nhập thông tin về các thí sinh dự thi
//- Hiển thị thông tin về các thí sinh đã trúng tuyển (Giả sử điểm chuẩn cho khối A: 15,điểm chuẩn khối B: 16, điểm chuẩn khối C: 13,5).
//-Tìm kiếm các thí sinh theo số báo danh
// Kết thúc chương trình.
// Tìm kiếm tài liệu theo loại
//- Xóa tài liệu theo mã tài liệu
using System;
using System.Collections.Generic;

// Lop cha
class ThiSinh
{
    public string SoBaoDanh { get; set; }
    public string HoTen { get; set; }
    public string DiaChi { get; set; }
    public double UuTien { get; set; }

    public virtual void Nhap()
    {
        Console.Write("So bao danh: ");
        SoBaoDanh = Console.ReadLine();
        Console.Write("Ho ten: ");
        HoTen = Console.ReadLine();
        Console.Write("Dia chi: ");
        DiaChi = Console.ReadLine();
        Console.Write("Diem uu tien: ");
        UuTien = double.Parse(Console.ReadLine());
    }

    public virtual void HienThi()
    {
        Console.WriteLine($"SBD: {SoBaoDanh}, Ten: {HoTen}, Dia chi: {DiaChi}, Uu tien: {UuTien}");
    }

    public virtual double TongDiem() => 0;
}

// Khoi A: Toan, Ly, Hoa
class KhoiA : ThiSinh
{
    public double Toan, Ly, Hoa;

    public override void Nhap()
    {
        base.Nhap();
        Console.Write("Diem Toan: ");
        Toan = double.Parse(Console.ReadLine());
        Console.Write("Diem Ly: ");
        Ly = double.Parse(Console.ReadLine());
        Console.Write("Diem Hoa: ");
        Hoa = double.Parse(Console.ReadLine());
    }

    public override void HienThi()
    {
        base.HienThi();
        Console.WriteLine($"Khoi A - Toan: {Toan}, Ly: {Ly}, Hoa: {Hoa}, Tong: {TongDiem()}");
    }

    public override double TongDiem()
    {
        return Toan + Ly + Hoa + UuTien;
    }
}

// Khoi B: Toan, Hoa, Sinh
class KhoiB : ThiSinh
{
    public double Toan, Hoa, Sinh;

    public override void Nhap()
    {
        base.Nhap();
        Console.Write("Diem Toan: ");
        Toan = double.Parse(Console.ReadLine());
        Console.Write("Diem Hoa: ");
        Hoa = double.Parse(Console.ReadLine());
        Console.Write("Diem Sinh: ");
        Sinh = double.Parse(Console.ReadLine());
    }

    public override void HienThi()
    {
        base.HienThi();
        Console.WriteLine($"Khoi B - Toan: {Toan}, Hoa: {Hoa}, Sinh: {Sinh}, Tong: {TongDiem()}");
    }

    public override double TongDiem()
    {
        return Toan + Hoa + Sinh + UuTien;
    }
}

// Khoi C: Van, Su, Dia
class KhoiC : ThiSinh
{
    public double Van, Su, Dia;

    public override void Nhap()
    {
        base.Nhap();
        Console.Write("Diem Van: ");
        Van = double.Parse(Console.ReadLine());
        Console.Write("Diem Su: ");
        Su = double.Parse(Console.ReadLine());
        Console.Write("Diem Dia: ");
        Dia = double.Parse(Console.ReadLine());
    }

    public override void HienThi()
    {
        base.HienThi();
        Console.WriteLine($"Khoi C - Van: {Van}, Su: {Su}, Dia: {Dia}, Tong: {TongDiem()}");
    }

    public override double TongDiem()
    {
        return Van + Su + Dia + UuTien;
    }
}

// Lop quan ly
class TuyenSinh
{
    private List<ThiSinh> danhSach = new List<ThiSinh>();

    public void NhapThiSinh()
    {
        Console.WriteLine("Chon khoi thi (1: Khoi A, 2: Khoi B, 3: Khoi C): ");
        int loai = int.Parse(Console.ReadLine());
        ThiSinh ts;

        switch (loai)
        {
            case 1:
                ts = new KhoiA();
                break;
            case 2:
                ts = new KhoiB();
                break;
            case 3:
                ts = new KhoiC();
                break;
            default:
                Console.WriteLine("Lua chon khong hop le.");
                return;
        }

        ts.Nhap();
        danhSach.Add(ts);
    }

    public void HienThiTrungTuyen()
    {
        foreach (var ts in danhSach)
        {
            if ((ts is KhoiA && ts.TongDiem() >= 15) ||
                (ts is KhoiB && ts.TongDiem() >= 16) ||
                (ts is KhoiC && ts.TongDiem() >= 13.5))
            {
                ts.HienThi();
                Console.WriteLine("-------------------");
            }
        }
    }

    public void TimTheoSBD()
    {
        Console.Write("Nhap so bao danh can tim: ");
        string sbd = Console.ReadLine();
        foreach (var ts in danhSach)
        {
            if (ts.SoBaoDanh == sbd)
            {
                ts.HienThi();
                return;
            }
        }
        Console.WriteLine("Khong tim thay thi sinh co so bao danh nay.");
    }
}

// Main Program
class Program
{
    static void Main()
    {
        TuyenSinh ts = new TuyenSinh();
        int chon;

        do
        {
            
            Console.WriteLine("1. Nhap thi sinh");
            Console.WriteLine("2. Hien thi thi sinh trung tuyen");
            Console.WriteLine("3. Tim theo so bao danh");
            Console.WriteLine("4. Thoat");
            
            chon = int.Parse(Console.ReadLine());

            switch (chon)
            {
                case 1:
                    ts.NhapThiSinh();
                    break;
                case 2:
                    ts.HienThiTrungTuyen();
                    break;
                case 3:
                    ts.TimTheoSBD();
                    break;
                case 4:
                    Console.WriteLine("Ket thuc chuong trinh.");
                    break;
                default:
                    Console.WriteLine("Lua chon khong hop le.");
                    break;
            }

        } while (chon != 4);
    }
}


