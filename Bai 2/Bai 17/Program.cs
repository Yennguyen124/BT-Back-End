//Bài 17: Mỗi một điểm trong mặt phẳng được xác đinh duy nhất bởi hai giá trị là hoành độ và
//tung độ.
//1. Hãy xây dựng lớp Diem cùng với chứa các đối tượng diểm trong mặt phẳng và xây dựng
//phương thức sau:
//-Toán tử tạo lập
//- Phương thức in một đối tượng thuộc lớp Diem
//- Tính khoảng cách giữa hai điểm
//2. Xây dựng lớp HinhTron chứa các đối tượng là các hình tròn với 2 thuộc tính là 1 đối tượng
//thuộc lớp Diem để xác định tâm của hình tròn một giá trị nguyên để xác định bán kính của
//hình tròn. Cài đặt các phương thức:
//-Xây dựng các toán tử tạo lập: HinhTron(),
//-HinhTron(Diem d, float bk)
//- Tính chu vi, diện tich hình tròn;
//-Nhập vào một danh sách các hình tròn, hiển thị thông tin về hình tròn giao với nhiều
//hình tròn khác nhất trong danh sách những hình tròn đã nh
using System;
using System.Collections.Generic;

class Diem
{
    public float X { get; set; }
    public float Y { get; set; }

    // Toán tử tạo lập mặc định
    public Diem() { }

    // Toán tử tạo lập có đối số
    public Diem(float x, float y)
    {
        X = x;
        Y = y;
    }

    // Phương thức in một đối tượng Diem
    public void In()
    {
        Console.WriteLine($"({X}, {Y})");
    }

    // Tính khoảng cách giữa hai điểm
    public double TinhKhoangCach(Diem d)
    {
        return Math.Sqrt(Math.Pow(this.X - d.X, 2) + Math.Pow(this.Y - d.Y, 2));
    }
}

class HinhTron
{
    public Diem Tam { get; set; }
    public float BanKinh { get; set; }

    // Toán tử tạo lập mặc định
    public HinhTron() { }

    // Toán tử tạo lập có đối số
    public HinhTron(Diem tam, float banKinh)
    {
        Tam = tam;
        BanKinh = banKinh;
    }

    // Phương thức in thông tin HinhTron
    public void In()
    {
        Console.Write("Tam: ");
        Tam.In();
        Console.WriteLine($"Ban kinh: {BanKinh}");
        Console.WriteLine($"Chu vi: {TinhChuVi():F2}, Dien tich: {TinhDienTich():F2}");
    }

    // Tính chu vi hình tròn
    public double TinhChuVi()
    {
        return 2 * Math.PI * BanKinh;
    }

    // Tính diện tích hình tròn
    public double TinhDienTich()
    {
        return Math.PI * BanKinh * BanKinh;
    }

    // Kiểm tra hình tròn giao nhau với hình tròn khác
    public bool GiaoNhau(HinhTron ht)
    {
        double d = Tam.TinhKhoangCach(ht.Tam);
        return d < (this.BanKinh + ht.BanKinh) && d > Math.Abs(this.BanKinh - ht.BanKinh);
    }
}

class Program
{
    static void Main()
    {
        List<HinhTron> danhSach = new List<HinhTron>();

        // Nhập số lượng hình tròn
        Console.Write("Nhap so luong hinh tron: ");
        int n = int.Parse(Console.ReadLine());

        // Nhập các hình tròn
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nNhap thong tin hinh tron thu {i + 1}:");
            Console.Write("Nhap hoanh do tam: ");
            float x = float.Parse(Console.ReadLine());
            Console.Write("Nhap tung do tam: ");
            float y = float.Parse(Console.ReadLine());
            Console.Write("Nhap ban kinh: ");
            float r = float.Parse(Console.ReadLine());

            danhSach.Add(new HinhTron(new Diem(x, y), r));
        }

        // Hiển thị thông tin các hình tròn
        Console.WriteLine("\n=== Danh sach cac hinh tron ===");
        for (int i = 0; i < danhSach.Count; i++)
        {
            Console.WriteLine($"Hinh tron thu {i + 1}:");
            danhSach[i].In();
        }

        // Tìm hình tròn giao với nhiều hình tròn khác nhất
        int maxGiao = -1;
        int viTri = -1;

        for (int i = 0; i < danhSach.Count; i++)
        {
            int dem = 0;
            for (int j = 0; j < danhSach.Count; j++)
            {
                if (i != j && danhSach[i].GiaoNhau(danhSach[j]))
                {
                    dem++;
                }
            }
            if (dem > maxGiao)
            {
                maxGiao = dem;
                viTri = i;
            }
        }

        // In thông tin hình tròn giao với nhiều hình tròn nhất
        if (viTri != -1)
        {
            Console.WriteLine($"\nHinh tron giao nhieu hinh nhat ({maxGiao} lan):");
            danhSach[viTri].In();
        }
        else
        {
            Console.WriteLine("\nKhong co hinh tron nao giao nhau.");
        }
    }
}
