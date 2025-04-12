//Bài 11: Xây dựng lớp SoPhuc có các thuộc tính riêng gồm: phanThuc, phanAo kiểu double
//1. Xây dựng các hàm tạo như sau: SoPhuc(), SoPhuc(double a, double b)
//2.Xây dựng các phương thức:
//+Nhập vào một số phức
//+ Hiển thị một số phức
//+ Cộng hai số phức.
//+ Nhân hai số phức
//+ Chia hai số phức.
//3. Cài đặt chương trình thực hiện : Nhập vào hai số phức A và B, sau đó hỏi người dùng muốn
//thực hiện tác vụ nào:
//a) Tính tổng hai số phức;
//b) Tính hiệu hai số phức;
//c) Tính tích hai số phức;
//d) Tính thương hai số phức;
//Rồi hiển thị kết quả ra màn hình
using System;

class SoPhuc
{
    public double PhanThuc { get; set; }
    public double PhanAo { get; set; }

    // Constructor không đối số
    public SoPhuc()
    {
        PhanThuc = 0;
        PhanAo = 0;
    }

    // Constructor có đối số
    public SoPhuc(double a, double b)
    {
        PhanThuc = a;
        PhanAo = b;
    }

    // Nhập số phức
    public void Nhap()
    {
        Console.Write("Nhap phan thuc: ");
        PhanThuc = double.Parse(Console.ReadLine());
        Console.Write("Nhap phan ao: ");
        PhanAo = double.Parse(Console.ReadLine());
    }

    // Hiển thị số phức
    public void HienThi()
    {
        Console.WriteLine($"So phuc: {PhanThuc} {(PhanAo >= 0 ? "+" : "-")} {Math.Abs(PhanAo)}i");
    }

    // Cộng hai số phức
    public SoPhuc Cong(SoPhuc b)
    {
        return new SoPhuc(this.PhanThuc + b.PhanThuc, this.PhanAo + b.PhanAo);
    }

    // Trừ hai số phức
    public SoPhuc Tru(SoPhuc b)
    {
        return new SoPhuc(this.PhanThuc - b.PhanThuc, this.PhanAo - b.PhanAo);
    }

    // Nhân hai số phức
    public SoPhuc Nhan(SoPhuc b)
    {
        double thuc = this.PhanThuc * b.PhanThuc - this.PhanAo * b.PhanAo;
        double ao = this.PhanThuc * b.PhanAo + this.PhanAo * b.PhanThuc;
        return new SoPhuc(thuc, ao);
    }

    // Chia hai số phức
    public SoPhuc Chia(SoPhuc b)
    {
        double mau = b.PhanThuc * b.PhanThuc + b.PhanAo * b.PhanAo;
        double thuc = (this.PhanThuc * b.PhanThuc + this.PhanAo * b.PhanAo) / mau;
        double ao = (this.PhanAo * b.PhanThuc - this.PhanThuc * b.PhanAo) / mau;
        return new SoPhuc(thuc, ao);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Nhap so phuc A:");
        SoPhuc A = new SoPhuc();
        A.Nhap();

        Console.WriteLine("Nhap so phuc B:");
        SoPhuc B = new SoPhuc();
        B.Nhap();

        while (true)
        {
            Console.WriteLine("\n==== MENU ====");
            Console.WriteLine("a) Tinh tong hai so phuc");
            Console.WriteLine("b) Tinh hieu hai so phuc");
            Console.WriteLine("c) Tinh tich hai so phuc");
            Console.WriteLine("d) Tinh thuong hai so phuc");
            Console.WriteLine("e) Thoat");
            Console.Write("Chon thao tac: ");
            string chon = Console.ReadLine().ToLower();

            SoPhuc kq;

            switch (chon)
            {
                case "a":
                    kq = A.Cong(B);
                    Console.Write("Tong: ");
                    kq.HienThi();
                    break;
                case "b":
                    kq = A.Tru(B);
                    Console.Write("Hieu: ");
                    kq.HienThi();
                    break;
                case "c":
                    kq = A.Nhan(B);
                    Console.Write("Tich: ");
                    kq.HienThi();
                    break;
                case "d":
                    if (B.PhanThuc == 0 && B.PhanAo == 0)
                        Console.WriteLine("Khong the chia cho 0.");
                    else
                    {
                        kq = A.Chia(B);
                        Console.Write("Thuong: ");
                        kq.HienThi();
                    }
                    break;
                case "e":
                    return;
                default:
                    Console.WriteLine("Lua chon khong hop le.");
                    break;
            }
        }
    }
}
