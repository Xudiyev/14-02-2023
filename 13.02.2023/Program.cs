using System;

namespace _13._02._2023
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Course course = new Course();


            string option;
            do
            {
                Console.WriteLine("\n1. Qrup elave et");
                Console.WriteLine("2. Bütün qruplara bax");
                Console.WriteLine("3. Verilmiş point araliğindaki qruplara bax");
                Console.WriteLine("4. Verilmiş nömresi uzre qrupa bax");
                Console.WriteLine("5. Verilmiş qruplar üzre axtariş et");
                Console.WriteLine("0 .Menudan cix");

                Console.WriteLine("\nSecim edin");
                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        string no;
                        do
                        {
                            Console.WriteLine("No: ");
                             no = Console.ReadLine();
                        } while (!CheckNo(no));

                        byte avgPoint;
                        string avgPointStr;
                        do
                        {
                            Console.WriteLine("AvgPoint: ");
                            avgPointStr = Console.ReadLine(); 

                        } while (!byte.TryParse(avgPointStr,out avgPoint) || avgPoint>100  );

                        Group group = new Group()
                        {
                            No = no,
                            AvgPoint = avgPoint,
                        };
                        course.AddGroup(group);

                        break;
                    case "2":
                        foreach (Group item in course.Groups)
                        {
                            Console.WriteLine($"No: {item.No} - AvgPoint: {item.AvgPoint}");
                        }

                        break;
                    case "3":

                        byte minPoint;
                        string minPointStr;
                        do
                        {
                            Console.Write("MinPoint: ");
                            minPointStr = Console.ReadLine();

                        } while (!byte.TryParse(minPointStr,out minPoint));

                        byte maxPoint;
                        string maxPointStr;
                        do
                        {
                            Console.Write("MaxPoint: ");
                            maxPointStr = Console.ReadLine();

                        } while (!byte.TryParse(maxPointStr, out maxPoint));
                        

                        var newarr = course.GetGroupsByPointRange(minPoint, maxPoint);

                        foreach (Group item in newarr)
                        {
                            Console.WriteLine($"No: {item.No} - AvgPoint: {item.AvgPoint}");
                        }
                        break;
                    case "4":
                        Console.Write("No: ");
                        string wantedNo = Console.ReadLine();
                        var wantedGroup = course.GetGroupByNo(wantedNo);

                        if (wantedGroup == null)
                            Console.WriteLine($"{wantedNo} nomreli qrup yoxdur!");
                        else
                            Console.WriteLine($"No: {wantedGroup.No} - AvgPoint: {wantedGroup.AvgPoint}");


                        break;
                    case "5":
                        Console.Write("Search: ");
                        string search = Console.ReadLine();

                        newarr = course.Search(search);

                        foreach (var item in newarr)
                        {
                            Console.WriteLine($"No: {item.No} - AvgPoint: {item.AvgPoint}");
                        }

                        break;
                    case "0":
                        break;
                    default:
                        Console.WriteLine("Secim duzgun deil!");
                        break;



                }

            } while (option != "0");


            static bool CheckNo(string no)
            {
                if (no != null)
                {
                    if (no.Length == 4)
                    {
                        if (char.IsUpper(no[0]) && char.IsDigit(no[1]) && char.IsDigit(no[2]) && char.IsDigit(no[3]))
                            return true;


                    }

                }
                return false;
            }
        }
    }
}
