//Bài 12: Xây dựng lớp MaTran có các thuộc tính riêng như sau:
//+Số dòng, số cột của ma trận
//+ Một mảng hai chiều để lưu trữ các phần tử của ma trận Hãy:
//1.Xây dựng các hàm tạo : MaTran(), maTran(int n, int m); (Toán tử tạo lập thứ hai để tạo ra
//ma trận có n dòng và m cột)
//2. Xây dựng các phương thức: Nhập vào và hiển thị một ma trận
//3. Xây dựng các phương thức tính tổng, hiệu và tích, thương của hai ma trận
//4. Cài đặt chương trình thực hiện : Nhập vào hai ma trận A và B cùng cấp, sau đó hỏi người
//dùng muốn thực hiện tác vụ nào:
//a) Tính tổng hai ma trận;
//b) Tính tích hai ma trận;
//c) Tính hiệu hai ma trận;
//d) Tính thương hai ma trận
//Hiển thị kết quả ra màn hình.
using System;

class MaTran
{
    public int SoDong { get; set; }
    public int SoCot { get; set; }
    public double[,] PhanTu;

    // Constructor không đối số
    public MaTran()
    {
        SoDong = 0;
        SoCot = 0;
    }

    // Constructor có đối số
    public MaTran(int n, int m)
    {
        SoDong = n;
        SoCot = m;
        PhanTu = new double[n, m];
    }

    // Nhập ma trận
    public void Nhap()
    {
        Console.Write("Nhap so dong: ");
        SoDong = int.Parse(Console.ReadLine());
        Console.Write("Nhap so cot: ");
        SoCot = int.Parse(Console.ReadLine());
        PhanTu = new double[SoDong, SoCot];

        for (int i = 0; i < SoDong; i++)
        {
            for (int j = 0; j < SoCot; j++)
            {
                Console.Write($"Phan tu [{i},{j}]: ");
                PhanTu[i, j] = double.Parse(Console.ReadLine());
            }
        }
    }

    // Hiển thị ma trận
    public void HienThi()
    {
        for (int i = 0; i < SoDong; i++)
        {
            for (int j = 0; j < SoCot; j++)
            {
                Console.Write(PhanTu[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    // Tính tổng
    public MaTran Cong(MaTran b)
    {
        if (SoDong != b.SoDong || SoCot != b.SoCot)
            return null;

        MaTran kq = new MaTran(SoDong, SoCot);
        for (int i = 0; i < SoDong; i++)
        {
            for (int j = 0; j < SoCot; j++)
            {
                kq.PhanTu[i, j] = PhanTu[i, j] + b.PhanTu[i, j];
            }
        }
        return kq;
    }

    // Tính hiệu
    public MaTran Tru(MaTran b)
    {
        if (SoDong != b.SoDong || SoCot != b.SoCot)
            return null;

        MaTran kq = new MaTran(SoDong, SoCot);
        for (int i = 0; i < SoDong; i++)
        {
            for (int j = 0; j < SoCot; j++)
            {
                kq.PhanTu[i, j] = PhanTu[i, j] - b.PhanTu[i, j];
            }
        }
        return kq;
    }

    // Tính tích
    public MaTran Nhan(MaTran b)
    {
        if (SoCot != b.SoDong)
            return null;

        MaTran kq = new MaTran(SoDong, b.SoCot);
        for (int i = 0; i < SoDong; i++)
        {
            for (int j = 0; j < b.SoCot; j++)
            {
                for (int k = 0; k < SoCot; k++)
                {
                    kq.PhanTu[i, j] += PhanTu[i, k] * b.PhanTu[k, j];
                }
            }
        }
        return kq;
    }

    // Tính "thương" - chia từng phần tử (giả định cùng cấp)
    public MaTran Thuong(MaTran b)
    {
        if (SoDong != b.SoDong || SoCot != b.SoCot)
            return null;

        MaTran kq = new MaTran(SoDong, SoCot);
        for (int i = 0; i < SoDong; i++)
        {
            for (int j = 0; j < SoCot; j++)
            {
                if (b.PhanTu[i, j] == 0)
                    kq.PhanTu[i, j] = 0;
                else
                    kq.PhanTu[i, j] = PhanTu[i, j] / b.PhanTu[i, j];
            }
        }
        return kq;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Nhap ma tran A:");
        MaTran A = new MaTran();
        A.Nhap();

        Console.WriteLine("Nhap ma tran B:");
        MaTran B = new MaTran();
        B.Nhap();

        while (true)
        {
            Console.WriteLine("\n===== MENU =====");
            Console.WriteLine("a) Tinh tong hai ma tran");
            Console.WriteLine("b) Tinh tich hai ma tran");
            Console.WriteLine("c) Tinh hieu hai ma tran");
            Console.WriteLine("d) Tinh thuong hai ma tran");
            Console.WriteLine("e) Thoat");
            Console.Write("Chon: ");
            string chon = Console.ReadLine().ToLower();

            MaTran kq;

            switch (chon)
            {
                case "a":
                    kq = A.Cong(B);
                    if (kq != null)
                    {
                        Console.WriteLine("Tong A + B:");
                        kq.HienThi();
                    }
                    else Console.WriteLine("Khong cong duoc do khac kich thuoc.");
                    break;
                case "b":
                    kq = A.Nhan(B);
                    if (kq != null)
                    {
                        Console.WriteLine("Tich A x B:");
                        kq.HienThi();
                    }
                    else Console.WriteLine("Khong nhan duoc do so cot A != so dong B.");
                    break;
                case "c":
                    kq = A.Tru(B);
                    if (kq != null)
                    {
                        Console.WriteLine("Hieu A - B:");
                        kq.HienThi();
                    }
                    else Console.WriteLine("Khong tru duoc do khac kich thuoc.");
                    break;
                case "d":
                    kq = A.Thuong(B);
                    if (kq != null)
                    {
                        Console.WriteLine("Thuong A / B:");
                        kq.HienThi();
                    }
                    else Console.WriteLine("Khong chia duoc do khac kich thuoc.");
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
