
//Bài 9: Để quản lý các biên lai thu tiền điện, người ta cần các thông tin như sau:
//-Với mỗi biên lai, có các thông tin sau: thông tin về hộ sử dụng điện, chỉ số cũ, chỉ số
//mới, số tiền phải trả của mỗi hộ sử dụng điện
//- Các thông tin riêng của mỗi hộ sử dụng điện gồm: Họ tên chủ hộ, số nhà, mã số công
//tơ của hộ dân sử dụng điện.
//1. Hãy xây dựng lớp KhachHang để lưu trữ các thông tin riêng của mỗi hộ sử dụng điện.
//2. Xây dựng lớp BienLai để quản lý việc sử dụng và thanh toán tiền điện của các hộ dân.
//3. Xây dựng các phương thức nhập, và hiển thị thông tin riêng của mỗi hộ sử dụng điện.
//4. Cài đặt chương trình thực hiện các công việc sau:
//+Nhập vào các thông tin cho N hộ sử dụng điện
//+ Hiển thị thông tin về các biên lai đã nhập
//+ Tính tiền điện phải trả cho mỗi hộ dân, nếu giả sử rằng tiền phải trả được tính theo
//công thức sau:
//Số điện Giá tiền
//Dưới 50 số 1250 vnđ/1 số
//Từ 50 đến dưới 100 số 1500 vnđ/1 số
//Từ 100 số trở lên 2000 vnđ/1 số\
using System;
using System.Collections.Generic;

class KhachHang
{
    public string HoTenChuHo { get; set; }
    public string SoNha { get; set; }
    public string MaCongTo { get; set; }

    public virtual void Nhap()
    {
        Console.Write("Nhap ho ten chu ho: ");
        HoTenChuHo = Console.ReadLine();
        Console.Write("Nhap so nha: ");
        SoNha = Console.ReadLine();
        Console.Write("Nhap ma cong to: ");
        MaCongTo = Console.ReadLine();
    }

    public virtual void HienThi()
    {
        Console.WriteLine($"Ho ten: {HoTenChuHo}, So nha: {SoNha}, Ma cong to: {MaCongTo}");
    }
}

class BienLai : KhachHang
{
    public int ChiSoCu { get; set; }
    public int ChiSoMoi { get; set; }

    public int SoDienTieuThu
    {
        get { return ChiSoMoi - ChiSoCu; }
    }

    public double TinhTien()
    {
        int so = SoDienTieuThu;
        double tien = 0;
        if (so <= 50)
            tien = so * 1250;
        else if (so < 100)
            tien = 50 * 1250 + (so - 50) * 1500;
        else
            tien = 50 * 1250 + 50 * 1500 + (so - 100) * 2000;
        return tien;
    }

    public override void Nhap()
    {
        base.Nhap();
        Console.Write("Nhap chi so cu: ");
        ChiSoCu = int.Parse(Console.ReadLine());
        Console.Write("Nhap chi so moi: ");
        ChiSoMoi = int.Parse(Console.ReadLine());
    }

    public override void HienThi()
    {
        base.HienThi();
        Console.WriteLine($"Chi so cu: {ChiSoCu}, Chi so moi: {ChiSoMoi}, So dien: {SoDienTieuThu}, Tien phai tra: {TinhTien()} VND");
    }
}

class Program
{
    static void Main()
    {
        List<BienLai> danhSach = new List<BienLai>();
        Console.Write("Nhap so ho su dung dien: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nNhap thong tin ho thu {i + 1}:");
            BienLai bl = new BienLai();
            bl.Nhap();
            danhSach.Add(bl);
        }

        Console.WriteLine("\n--- Danh sach bien lai da nhap ---");
        foreach (var bl in danhSach)
        {
            bl.HienThi();
            Console.WriteLine("--------------------------");
        }

        Console.WriteLine("Nhan phim bat ky de thoat...");
        Console.ReadKey();
    }
}
