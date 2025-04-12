//Bài 8: Thư viện của trường đại học Đại Nam có nhu cầu cần quản lý việc mượn sách. Sinh
//viên đăng ký và tham gia mượn sách thông qua các thẻ mượn mà thư viện đã thiết kế.
//- Với mỗi thẻ mượn, có các thông tin sau: số phiếu mượn, ngày mượn, hạn trả, số hiệu
//sách, và các thông tin riêng về mỗi sinh viên đó.
//- Các thông tin riêng về mỗi sinh viên đó bao gồm: Họ tên, năm sinh, lớp, mã số sinh
//viên.
//1. Hãy xây dựng lớp SinhVien để quản lý các thông tin riêng về mỗi sinh viên.
//2. Xây dựng lớp TheMuon để quản lý việc mượn sách của mỗi độc giả.
//3. Xây dựng các phương thức để nhập và hiện thị các thông tin riêng cho mỗi sinh viên .
//4. Nhập vào một danh sách các sinh viên, sau đó thực hiện các công việc sau:
//-Tìm kiếm thông tin về sinh viên theo mã số sinh viên;
//-Hiển thị thông tin về các sinh viên đã đến hạn trả sách theo ngày hiện tại;
//-Thoát khỏi chương trình.
using System;
using System.Collections.Generic;

class SinhVien
{
    public string HoTen { get; set; }
    public int NamSinh { get; set; }
    public string Lop { get; set; }
    public string MaSV { get; set; }

    public virtual void Nhap()
    {
        Console.Write("Nhap ho ten: ");
        HoTen = Console.ReadLine();
        Console.Write("Nhap nam sinh: ");
        NamSinh = int.Parse(Console.ReadLine());
        Console.Write("Nhap lop: ");
        Lop = Console.ReadLine();
        Console.Write("Nhap ma so sinh vien: ");
        MaSV = Console.ReadLine();
    }

    public virtual void HienThi()
    {
        Console.WriteLine($"Ho ten: {HoTen}, Nam sinh: {NamSinh}, Lop: {Lop}, MaSV: {MaSV}");
    }
}

class TheMuon
{
    public string SoPhieuMuon { get; set; }
    public DateTime NgayMuon { get; set; }
    public DateTime HanTra { get; set; }
    public string SoHieuSach { get; set; }
    public SinhVien SV { get; set; }

    public void Nhap()
    {
        Console.Write("Nhap so phieu muon: ");
        SoPhieuMuon = Console.ReadLine();
        Console.Write("Nhap ngay muon (dd/MM/yyyy): ");
        NgayMuon = DateTime.Parse(Console.ReadLine());
        Console.Write("Nhap han tra (dd/MM/yyyy): ");
        HanTra = DateTime.Parse(Console.ReadLine());
        Console.Write("Nhap so hieu sach: ");
        SoHieuSach = Console.ReadLine();

        SV = new SinhVien();
        SV.Nhap();
    }

    public void HienThi()
    {
        Console.WriteLine($"\nSo phieu muon: {SoPhieuMuon}, Ngay muon: {NgayMuon:dd/MM/yyyy}, Han tra: {HanTra:dd/MM/yyyy}, So hieu sach: {SoHieuSach}");
        SV.HienThi();
    }
}

class Program
{
    static void Main()
    {
        List<TheMuon> danhSach = new List<TheMuon>();

        while (true)
        {
            Console.WriteLine("\n1. Nhap the muon");
            Console.WriteLine("2. Hien thi tat ca");
            Console.WriteLine("3. Tim theo ma sinh vien");
            Console.WriteLine("4. Hien thi sinh vien den han tra sach");
            Console.WriteLine("5. Thoat");
            Console.Write("Chon: ");
            int chon = int.Parse(Console.ReadLine());

            switch (chon)
            {
                case 1:
                    Console.Write("Nhap so luong the muon: ");
                    int n = int.Parse(Console.ReadLine());
                    for (int i = 0; i < n; i++)
                    {
                        Console.WriteLine($"\nNhap the muon thu {i + 1}:");
                        TheMuon tm = new TheMuon();
                        tm.Nhap();
                        danhSach.Add(tm);
                    }
                    break;
                case 2:
                    foreach (var tm in danhSach)
                        tm.HienThi();
                    break;
                case 3:
                    Console.Write("Nhap ma sinh vien can tim: ");
                    string ma = Console.ReadLine();
                    foreach (var tm in danhSach)
                        if (tm.SV.MaSV.Equals(ma))
                            tm.HienThi();
                    break;
                case 4:
                    Console.WriteLine("\nNhung sinh vien den han tra sach:");
                    DateTime now = DateTime.Now;
                    foreach (var tm in danhSach)
                        if (tm.HanTra.Date <= now.Date)
                            tm.HienThi();
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Chon sai. Vui long chon lai.");
                    break;
            }
        }
    }
}
