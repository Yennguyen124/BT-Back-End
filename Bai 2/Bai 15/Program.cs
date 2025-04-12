//Bài 15:
//1.Hãy xây dựng lớp DaGiac gồm có các thuộc tính
//- Số cạnh của đa giác
//- Mảng các số nguyên chứa kích thước các cạnh của đa giác
//Các phương thức:
//-Tính chu vi
//- In giá trị các cạnh của đa giác.
//2. Xây dựng lớp TamGiac kế thừa từ lớp DaGiac, trong đó viết đè hàm tính chu vi và xây dựng
//thêm phương thức tính diện tích tam giác
//3. Xây dựng một ứng dụng để nhập vào một dãy gồm n tam giác rồi in ra màn hình các cạnh
//của các tam giác thỏa mãn định lý Pitago.
using System;
using System.Collections.Generic;

class DaGiac
{
    public int SoCanh { get; set; }  // Số cạnh của đa giác
    public int[] CacCanh { get; set; }  // Mảng các kích thước các cạnh

    // Toán tử tạo lập mặc định
    public DaGiac() { }

    // Toán tử tạo lập với số cạnh và mảng các cạnh
    public DaGiac(int soCanh, int[] cacCanh)
    {
        SoCanh = soCanh;
        CacCanh = cacCanh;
    }

    // Phương thức tính chu vi của đa giác
    public int TinhChuVi()
    {
        int chuVi = 0;
        foreach (var canh in CacCanh)
        {
            chuVi += canh;
        }
        return chuVi;
    }

    // Phương thức in giá trị các cạnh của đa giác
    public void InCacCanh()
    {
        Console.WriteLine("Cac canh cua da giac:");
        foreach (var canh in CacCanh)
        {
            Console.Write(canh + " ");
        }
        Console.WriteLine();
    }
}

class TamGiac : DaGiac
{
    // Toán tử tạo lập cho tam giác, kế thừa từ DaGiac
    public TamGiac(int[] cacCanh) : base(3, cacCanh) { }

    // Được đè lại để tính chu vi cho tam giác
    public new int TinhChuVi()
    {
        return base.TinhChuVi();
    }

    // Phương thức tính diện tích tam giác (theo công thức Heron)
    public double TinhDienTich()
    {
        if (CacCanh.Length != 3) throw new Exception("Cần 3 cạnh để tính diện tích tam giác");
        double a = CacCanh[0];
        double b = CacCanh[1];
        double c = CacCanh[2];
        double p = (a + b + c) / 2;  // Nửa chu vi

        // Công thức Heron để tính diện tích
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    // Kiểm tra xem tam giác có thỏa mãn định lý Pitago không (các cạnh tạo thành bộ ba Pythagoras)
    public bool KiemTraPitago()
    {
        Array.Sort(CacCanh);
        return CacCanh[0] * CacCanh[0] + CacCanh[1] * CacCanh[1] == CacCanh[2] * CacCanh[2];
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

            int[] cacCanh = new int[3];
            for (int j = 0; j < 3; j++)
            {
                Console.Write($"Nhap canh {j + 1}: ");
                cacCanh[j] = int.Parse(Console.ReadLine());
            }

            // Tạo tam giác và thêm vào danh sách
            TamGiac tamGiac = new TamGiac(cacCanh);
            danhSachTamGiac.Add(tamGiac);
        }

        // In thông tin các tam giác thỏa mãn định lý Pitago
        Console.WriteLine("\n=== Cac tam giac thoa man dinh ly Pitago ===");
        foreach (var tamGiac in danhSachTamGiac)
        {
            if (tamGiac.KiemTraPitago())
            {
                tamGiac.InCacCanh();
                Console.WriteLine($"Chu vi: {tamGiac.TinhChuVi()}");
                Console.WriteLine($"Dien tich: {tamGiac.TinhDienTich():F2}");
                Console.WriteLine();
            }
        }
    }
}

