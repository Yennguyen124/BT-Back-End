//Bài 10: Để xử lý các văn bản, người ta xây dựng lớp VanBan có thuộc tính riêng là một xâu
//ký tự. Hãy:
//1.Xây dựng các hàm tạo không có và có đối số như sau: VanBan(), VanBan(String st).
//2.Xây dựng phương thức đếm số từ của một xâu.
//3. Xây dựng phương thức đếm số ký tự H (không phân biệt chữ thường, chữ hoa) của xâu.
//4. Chuẩn hoá một xâu theo tiêu chuẩn (Ở đầu và cuối của xâu không có ký tự trống, ở giữa
//xâu không có hai ký tự trắng liền nhau).
//5. Xây dựng một menu hỏi người sử dụng muốn thực hiện công việc gì (đếm từ, đếm số kí tự
//H hãy chuẩn hóa sâu). Sau đó hiển thị kết quả ra màn hình.
using System;
using System.Text.RegularExpressions;

class VanBan
{
    public string NoiDung { get; set; }

    // Constructor không đối số
    public VanBan()
    {
        NoiDung = "";
    }

    // Constructor có đối số
    public VanBan(string st)
    {
        NoiDung = st;
    }

    // Đếm số từ trong xâu
    public int DemSoTu()
    {
        if (string.IsNullOrWhiteSpace(NoiDung))
            return 0;

        // Loại bỏ khoảng trắng thừa và tách theo khoảng trắng
        string[] tu = NoiDung.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        return tu.Length;
    }

    // Đếm số ký tự H hoặc h trong xâu
    public int DemSoKyTuH()
    {
        int dem = 0;
        foreach (char c in NoiDung)
        {
            if (char.ToLower(c) == 'h')
                dem++;
        }
        return dem;
    }

    // Chuẩn hóa xâu: xóa khoảng trắng dư ở đầu/cuối và giữa
    public string ChuanHoa()
    {
        // Loại bỏ khoảng trắng ở đầu/cuối, sau đó thay các chuỗi nhiều khoảng trắng thành 1 khoảng trắng
        return Regex.Replace(NoiDung.Trim(), @"\s+", " ");
    }

    public void HienThi()
    {
        Console.WriteLine($"Van ban hien tai: \"{NoiDung}\"");
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Nhap xau van ban: ");
        string st = Console.ReadLine();

        VanBan vb = new VanBan(st);

        while (true)
        {
            Console.WriteLine("\n===== MENU =====");
            Console.WriteLine("1. Dem so tu");
            Console.WriteLine("2. Dem so ky tu 'H' hoac 'h'");
            Console.WriteLine("3. Chuan hoa xau");
            Console.WriteLine("4. Hien thi van ban");
            Console.WriteLine("5. Thoat");
            Console.Write("Chon chuc nang: ");
            string chon = Console.ReadLine();

            switch (chon)
            {
                case "1":
                    Console.WriteLine($"So tu trong xau: {vb.DemSoTu()}");
                    break;
                case "2":
                    Console.WriteLine($"So ky tu 'H' hoac 'h': {vb.DemSoKyTuH()}");
                    break;
                case "3":
                    vb.NoiDung = vb.ChuanHoa();
                    Console.WriteLine("Xau da duoc chuan hoa.");
                    break;
                case "4":
                    vb.HienThi();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Lua chon khong hop le.");
                    break;
            }
        }
    }
}
