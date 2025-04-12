//Bài 2: Một thư viện cần quản lý các tài liệu bao gồm, Sách, Tạp chí, Báo
//+ Mỗi tài liệu có các thuộc tính: Mã tài liệu, Tên nhà xuất bản, Số bản phát hành.
//+ Các loại sách cần quản lý: Tên tác giả, số trang
//+ Các tạp chí cần quản lý: Số phát hành, tháng phát hành
//+ Các báo cần quản lý: ngày phát hành.
//1. Xây dựng các lớp để quản lý các loại tài liệu trên sao cho việc sử dụng lại được nhiều nhất.
//2. Xây dựng lớp QuanLyTailieu cài đặt các phương thức thực hiện các công việc sau:
//-Nhập thông tin về các tài liệu (Hỏi người dùng muốn nhập thông tin cho loại tài liệu
//- Hiển thị thông tin về các tài liệu
// Tìm kiếm tài liệu theo loại
//- Xóa tài liệu theo mã tài liệu
using System;
using System.Collections.Generic;

// Lớp cha
class TaiLieu
{
    public string MaTaiLieu { get; set; }
    public string NhaXuatBan { get; set; }
    public int SoBanPhatHanh { get; set; }

    public virtual void Nhap()
    {
        Console.Write("Ma tai lieu: ");
        MaTaiLieu = Console.ReadLine();
        Console.Write("Ten nha xuat ban: ");
        NhaXuatBan = Console.ReadLine();
        Console.Write("So ban xuat hanh: ");
        SoBanPhatHanh = int.Parse(Console.ReadLine());
    }

    public virtual void HienThi()
    {
        Console.WriteLine($"Ma TL: {MaTaiLieu}, NXB: {NhaXuatBan}, So ban: {SoBanPhatHanh}");
    }
}

// Lớp Sách
class Sach : TaiLieu
{
    public string TenTacGia { get; set; }
    public int SoTrang { get; set; }

    public override void Nhap()
    {
        base.Nhap();
        Console.Write("Ten Tac Gia: ");
        TenTacGia = Console.ReadLine();
        Console.Write("So trang: ");
        SoTrang = int.Parse(Console.ReadLine());
    }

    public override void HienThi()
    {
        base.HienThi();
        Console.WriteLine($"Tac Gia: {TenTacGia}, So trang: {SoTrang}");
    }
}

// Lớp Tạp chí
class TapChi : TaiLieu
{
    public int SoPhatHanh { get; set; }
    public int ThangPhatHanh { get; set; }

    public override void Nhap()
    {
        base.Nhap();
        Console.Write("So : ");
        SoPhatHanh = int.Parse(Console.ReadLine());
        Console.Write("Thang: ");
        ThangPhatHanh = int.Parse(Console.ReadLine());
    }

    public override void HienThi()
    {
        base.HienThi();
        Console.WriteLine($"So phat hanh: {SoPhatHanh}, Thang: {ThangPhatHanh}");
    }
}

// Lớp Báo
class Bao : TaiLieu
{
    public string NgayPhatHanh { get; set; }

    public override void Nhap()
    {
        base.Nhap();
        Console.Write("Ngay phat hanh (dd/MM/yyyy): ");
        NgayPhatHanh = Console.ReadLine();
    }

    public override void HienThi()
    {
        base.HienThi();
        Console.WriteLine($"Ngay phat hanh: {NgayPhatHanh}");
    }
}

// Quản lý tài liệu
class QuanLyTaiLieu
{
    private List<TaiLieu> danhSach = new List<TaiLieu>();

    public void NhapTaiLieu()
    {
        Console.WriteLine("Loai tai lieu (1: Sach, 2: Tap chi, 3: Bao): ");
        int loai = int.Parse(Console.ReadLine());
        TaiLieu tl;

        switch (loai)
        {
            case 1:
                tl = new Sach();
                break;
            case 2:
                tl = new TapChi();
                break;
            case 3:
                tl = new Bao();
                break;
            default:
                Console.WriteLine("Lua chon khong hop le.");
                return;
        }

        tl.Nhap();
        danhSach.Add(tl);
    }

    public void HienThiTaiLieu()
    {
        foreach (var tl in danhSach)
        {
            tl.HienThi();
            Console.WriteLine("-----------------------");
        }
    }

    public void TimKiemTheoLoai()
    {
        Console.WriteLine("Tai lieu can tim (sach/tapchi/bao): ");
        string loai = Console.ReadLine().ToLower();

        foreach (var tl in danhSach)
        {
            if ((loai == "sach" && tl is Sach) ||
                (loai == "tapchi" && tl is TapChi) ||
                (loai == "bao" && tl is Bao))
            {
                tl.HienThi();
                Console.WriteLine("-----------------------");
            }
        }
    }
}

// Main Program
class Program
{
    static void Main()
    {
        QuanLyTaiLieu qltl = new QuanLyTaiLieu();
        int chon;

        do
        {
            
            Console.WriteLine("1. Nhap Tai Lieu");
            Console.WriteLine("2. Hien thi tai lieu");
            Console.WriteLine("3. Tim kiem theo tai lieu");
            Console.WriteLine("4. Thoat");
         
            chon = int.Parse(Console.ReadLine());

            switch (chon)
            {
                case 1:
                    qltl.NhapTaiLieu();
                    break;
                case 2:
                    qltl.HienThiTaiLieu();
                    break;
                case 3:
                    qltl.TimKiemTheoLoai();
                    break;
                case 4:
                    Console.WriteLine("Thoat Chuong Trinh.");
                    break;
                default:
                    Console.WriteLine("Lua chon Chua Hop Le");
                    break;
            }

        } while (chon != 4);
    }
}
