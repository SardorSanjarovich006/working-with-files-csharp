using WorkingWithFileExcel.Aplication.Services;
using WorkingWithFileExcel.Domain.Models;
using WorkingWithFileExcel.Infrastucture.Data;

class Program
{
    static void Main(string[] args)
    {
        ExcelContext context = new ExcelContext();

        ExternalAttendanceService service = new ExternalAttendanceService(context);
        StudentService studentService = new StudentService();

       
        while (true)
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("     ZOOM ATTENDANCE BOSHQARUV MENYUSI");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Barcha qatnashuvchilarni ko‘rish");
            Console.WriteLine("2. Ism bo‘yicha qidirish");
            Console.WriteLine("3. Email bo‘yicha qidirish");
            Console.WriteLine("4. Faqat mehmonlarni ko‘rish (Host)");
            Console.WriteLine("5. Kutish zalida bo‘lganlarni ko‘rish");
            Console.WriteLine("6. Eng ko‘p qatnashganlarni ko‘rish (Top 5)");
            Console.WriteLine("7. Qatnashuvchilar sonini ko‘rish");
            Console.WriteLine("8. Id bo'yicha qidirish");
            Console.WriteLine("9. ID bo'yicha o'chirish");
            Console.WriteLine("10. Student qo'shish");
            Console.WriteLine("11. Yangilangan jadvalni chiqarish");
            Console.WriteLine("0. Dasturdan chiqish");
            Console.WriteLine("----------------------------------------");
            Console.Write("Tanlovingizni kiriting: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ShowList(service.GetAll());
                    break;

                case "2":
                    Console.Write("Ism kiriting: ");
                    string name = Console.ReadLine();
                    var byName = service.GetByName(name);
                    ShowSingle(byName);
                    break;

                case "3":
                    Console.Write("Email kiriting: ");
                    string email = Console.ReadLine();
                    var byEmail = service.GetByEmail(email);
                    ShowSingle(byEmail);
                    break;

                case "4":
                    ShowList(service.GetGuests());
                    break;

                case "5":
                    ShowList(service.GetWaitingRoom());
                    break;

                case "6":
                    ShowList(service.GetMostActive());
                    break;

                case "7":
                    Console.WriteLine($"Jami qatnashuvchilar soni: {service.GetCount()}");
                   Console.ReadKey();
                    break;
                case "8":
                    Console.Write("ID (Code) kiriting: ");
                    string id = Console.ReadLine();
                    var byId = studentService.GetByCode(id);
                    if(byId.Count>0)
                    {
                        ShowList(byId);

                    }
                    else
                    {
                        Console.WriteLine("Ma'lumot topilmadi !");
                        Console.WriteLine("\nDavom ettirish uchun tugma bosing...");
                        Console.ReadKey();
                    }

                    break;

                case "9":
                    Console.Write("ID (Code) kiriting: ");
                    string delId = Console.ReadLine();
                    studentService.DeleteById(delId);
                    Console.WriteLine("Student o'chirildi...");
                    break;

                case "10":
                    ExternalAttendance exat=new ExternalAttendance();
                    Console.WriteLine("Ism familya code ni kiriting");
                    exat.FullNameWithCode= Console.ReadLine();
                    Console.WriteLine("Email kiriting:");
                    exat.Email= Console.ReadLine();
                    studentService.AddStudent(exat);
                    Console.WriteLine("Student muvaffaqiyatli qo'shildi. Davom ettirish uchun xohlagan tugmani bosing...");
                    break;

                case "11":
                    ShowList(service.GetAll());
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Noto‘g‘ri tanlov!");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void ShowList(List<ExternalAttendance> list)
    { 
        foreach (var item in list)
        {
            Console.WriteLine($"{item.FullNameWithCode} | {item.Email} | {item.Duration} min | EnterDate:{item.EnterDate}  | ExitDate:{item.ExitDate} | Host:{item.IsHost} |  Waiting:{item.IsWaiting}");
        }
        Console.WriteLine("\nDavom ettirish uchun tugma bosing...");
        Console.ReadKey();
    }

    static void ShowSingle(ExternalAttendance? item)
    {

        if (item == null)
        {
            Console.WriteLine("Ma'lumot topilmadi !");
        }
        else
        {
            Console.WriteLine($"Ism: {item.FullNameWithCode}");
            Console.WriteLine($"Email: {item.Email}");
            Console.WriteLine($"Kirish: {item.EnterDate}");
            Console.WriteLine($"Chiqish: {item.ExitDate}");
            Console.WriteLine($"Davomiylik: {item.Duration} min");
            Console.WriteLine($"Host: {item.IsHost}");
            Console.WriteLine($"Waiting: {item.IsWaiting}");
        }

        Console.WriteLine("\nDavom ettirish uchun tugma bosing...");
        Console.ReadKey();
    }
}
