//Bài 14: Lớp PhanSo có các thuộc tính riêng gồm: tuSo, mauSo, Hãy:
//1.Xây dựng các toán tử tạo lập : PhanSo(), PhanSo(int tu, int mau)
//2.Xây dựng các phương thức:
//+Nhập vào một phân số
//+ Hiển thị một phân số
//+ Rút gọn một phân số
//+ Cộng hai phân số
//+ Trừ hai phân số
//+ Chia hai phân số
//3. Cài đặt chương trình thực hiện: Nhập vào hai phân số A và B, sau đó tính thực hiện các yêu
//cầu của người dùng rồi hiển thị kết quả ra màn hình.
using System;

class PhanSo
{
    public int TuSo { get; set; }
    public int MauSo { get; set; }

    // Toán tử tạo lập mặc định
    public PhanSo() { }

    // Toán tử tạo lập với tử số và mẫu số
    public PhanSo(int tu, int mau)
    {
        TuSo = tu;
        MauSo = mau;
    }

    // Phương thức nhập phân số
    public void Nhap()
    {
        Console.Write("Nhap tu so: ");
        TuSo = int.Parse(Console.ReadLine());
        Console.Write("Nhap mau so: ");
        MauSo = int.Parse(Console.ReadLine());

        // Kiểm tra nếu mẫu số là 0, yêu cầu nhập lại
        while (MauSo == 0)
        {
            Console.WriteLine("Mau so khong duoc bang 0. Nhap lai mau so: ");
            MauSo = int.Parse(Console.ReadLine());
        }
    }

    // Phương thức hiển thị phân số
    public void In()
    {
        Console.WriteLine($"{TuSo}/{MauSo}");
    }

    // Phương thức rút gọn phân số
    public void RutGon()
    {
        int ucln = UCLN(TuSo, MauSo);
        TuSo /= ucln;
        MauSo /= ucln;
    }

    // Phương thức tính UCLN (ước chung lớn nhất)
    private int UCLN(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    // Phương thức cộng hai phân số
    public PhanSo Cộng(PhanSo ps)
    {
        int tu = TuSo * ps.MauSo + MauSo * ps.TuSo;
        int mau = MauSo * ps.MauSo;
        PhanSo result = new PhanSo(tu, mau);
        result.RutGon();
        return result;
    }

    // Phương thức trừ hai phân số
    public PhanSo Trừ(PhanSo ps)
    {
        int tu = TuSo * ps.MauSo - MauSo * ps.TuSo;
        int mau = MauSo * ps.MauSo;
        PhanSo result = new PhanSo(tu, mau);
        result.RutGon();
        return result;
    }

    // Phương thức chia hai phân số
    public PhanSo Chia(PhanSo ps)
    {
        if (ps.TuSo == 0)
        {
            throw new Exception("Không thể chia cho phân số có tử số bằng 0");
        }
        int tu = TuSo * ps.MauSo;
        int mau = MauSo * ps.TuSo;
        PhanSo result = new PhanSo(tu, mau);
        result.RutGon();
        return result;
    }
}

class Program
{
    static void Main()
    {
        // Nhập phân số A và B
        PhanSo A = new PhanSo();
        Console.WriteLine("Nhap phan so A:");
        A.Nhap();
        A.RutGon();

        PhanSo B = new PhanSo();
        Console.WriteLine("Nhap phan so B:");
        B.Nhap();
        B.RutGon();

        // Chương trình thực hiện các yêu cầu
        Console.WriteLine("\nChon tac vu:");
        Console.WriteLine("1. Cong hai phan so");
        Console.WriteLine("2. Tru hai phan so");
        Console.WriteLine("3. Chia hai phan so");
        Console.Write("Nhap lua chon: ");
        int luaChon = int.Parse(Console.ReadLine());

        PhanSo result = null;

        switch (luaChon)
        {
            case 1:
                result = A.Cộng(B);
                Console.WriteLine($"Ket qua: {A.TuSo}/{A.MauSo} + {B.TuSo}/{B.MauSo} = {result.TuSo}/{result.MauSo}");
                break;

            case 2:
                result = A.Trừ(B);
                Console.WriteLine($"Ket qua: {A.TuSo}/{A.MauSo} - {B.TuSo}/{B.MauSo} = {result.TuSo}/{result.MauSo}");
                break;

            case 3:
                try
                {
                    result = A.Chia(B);
                    Console.WriteLine($"Ket qua: {A.TuSo}/{A.MauSo} / {B.TuSo}/{B.MauSo} = {result.TuSo}/{result.MauSo}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                break;

            default:
                Console.WriteLine("Lua chon khong hop le");
                break;
        }
    }
}
