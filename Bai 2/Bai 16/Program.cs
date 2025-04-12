//Bài 16: Mỗi một điểm trong mặt phẳng được xác đinh duy nhất bởi hai giá trị là hoành độ và
//tung độ.
//1. Hãy xây dựng lớp Diem cùng với chứa các đối tượng điểm trong mặt phẳng và xây dựng
//phương thức sau:
//-Toán tử tạo lập
//- Phương thức in một đối tượng Diem
//- Tính khoảng cách giữa hai điểm
//2. Mỗi tam giác trong mặt phẳng được xác định bởi 3 điểm. Hãy xây dựng lớp TamGiac với 3
//thuộc tính riêng là 3 đối tượng thuộc lớp Diem và các phương thức:
//-Xây dựng các toản tử tạo lập: TamGiac(); TamGiac(Diem d1, Diem d2, Diem d3);
//-Tính diện tích tam giác
//- Tính chu vi của tam giác
//3. Nhập vào một danh sách các tam giác, đưa ra tổng chu vi và tổng diện tích của các tam giác
//vừa nhập.
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

class TamGiac
{
    public Diem D1 { get; set; }
    public Diem D2 { get; set; }
    public Diem D3 { get; set; }

    // Toán tử tạo lập mặc định
    public TamGiac() { }

    // Toán tử tạo lập có đối số
    public TamGiac(Diem d1, Diem d2, Diem d3)
    {
        D1 = d1;
        D2 = d2;
        D3 = d3;
    }

    // Tính diện tích tam giác bằng công thức Heron
    public double TinhDienTich()
    {
        double a = D1.TinhKhoangCach(D2);
        double b = D2.TinhKhoangCach(D3);
        double c = D3.TinhKhoangCach(D1);
        double p = (a + b + c) / 2;  // Nửa chu vi

        return Math.Sqrt(p * (p - a) * (p - b) * (p - c)); // Công thức Heron
    }

    // Tính chu vi tam giác
    public double TinhChuVi()
    {
        double a = D1.TinhKhoangCach(D2);
        double b = D2.TinhKhoangCach(D3);
        double c = D3.TinhKhoangCach(D1);

        return a + b + c;
    }

    // Phương thức in thông tin tam giác
    public void In()
    {
        Console.WriteLine("Diem 1: ");
        D1.In();
        Console.WriteLine("Diem 2: ");
        D2.In();
        Console.WriteLine("Diem 3: ");
        D3.In();
        Console.WriteLine($"Chu vi: {TinhChuVi():F2}, Dien tich: {TinhDienTich():F2}");
    }
}

class Program
{
    static void Main()
    {
        List<TamGiac> danhSachTamGiac = new List<TamGiac>();

        // Nhập số lượng tam giác
        Console.Write("Nhap so luong tam giac: ");
        int n = int.Parse(Console.ReadLine());

        // Nhập các tam giác
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nNhap thong tin tam giac thu {i + 1}:");

            // Nhập các điểm của tam giác
            Console.Write("Nhap hoanh do diem 1: ");
            float x1 = float.Parse(Console.ReadLine());
            Console.Write("Nhap tung do diem 1: ");
            float y1 = float.Parse(Console.ReadLine());

            Console.Write("Nhap hoanh do diem 2: ");
            float x2 = float.Parse(Console.ReadLine());
            Console.Write("Nhap tung do diem 2: ");
            float y2 = float.Parse(Console.ReadLine());

            Console.Write("Nhap hoanh do diem 3: ");
            float x3 = float.Parse(Console.ReadLine());
            Console.Write("Nhap tung do diem 3: ");
            float y3 = float.Parse(Console.ReadLine());

            // Tạo tam giác và thêm vào danh sách
            TamGiac tamGiac = new TamGiac(new Diem(x1, y1), new Diem(x2, y2), new Diem(x3, y3));
            danhSachTamGiac.Add(tamGiac);
        }

        // Hiển thị thông tin các tam giác và tính tổng chu vi, diện tích
        double tongChuVi = 0, tongDienTich = 0;

        Console.WriteLine("\n=== Danh sach cac tam giac ===");
        foreach (var tamGiac in danhSachTamGiac)
        {
            tamGiac.In();
            tongChuVi += tamGiac.TinhChuVi();
            tongDienTich += tamGiac.TinhDienTich();
        }

        // Hiển thị tổng chu vi và diện tích
        Console.WriteLine($"\nTong chu vi: {tongChuVi:F2}");
        Console.WriteLine($"Tong dien tich: {tongDienTich:F2}");
    }
}

