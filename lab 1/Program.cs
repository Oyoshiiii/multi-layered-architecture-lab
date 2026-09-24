using BusinessLogic;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ViewConsole
{
    internal class Program
    {
        //удалить лист и заменить на получение с бизнес-логики
        //также с местом нахождения протеза
        //убрать сортировки, заменить группировку по частям тела и добавить по месту нахождения
        /*
        static List<string> bodyParts = new List<string>() { "Руки", "Ноги", "Спина", "Голова", "Торс" };
        static void Main(string[] args)
        {
            Logic logic = new Logic();
            List<Prosthesis> prostheses = logic.GetAllProstheses();

            int userChoice = 0;

            while (userChoice != 9)
            {
                Console.Write("[1.] Вывести все протезы\n" +
                    "[2.] Вывести протез по Id\n" +
                    "[3.] Добавить протез\n" +
                    "[4.] Изменить протез\n" +
                    "[5.] Удалить протез\n" +
                    "[6.] Группировать по расположению протезов на теле\n" +
                    "[7.] Сортировать по % потери рассудка по возрастанию\n" +
                    "[8.] Сортировать по % потери рассудка по убыванию\n" +
                    "[9.] Выход\n\n" +
                    "Ввод: ");

                while(!int.TryParse(Console.ReadLine(), out userChoice))
                {
                    Console.Write("\n\t\t!! Ошибка ввода, попробуйте снова\n\nВвод: ");
                }

                Console.Clear();

                switch(userChoice)
                {
                    case 1:
                        GetAll(prostheses);
                        break;
                    case 2:
                        GetById(prostheses);
                        break;
                    case 3:
                        Add(prostheses, logic);
                        break;
                    case 4:
                        Change(prostheses, logic);
                        break;
                    case 5:
                        Delete(prostheses, logic);
                        break;
                    case 6:
                        GroupByBodyPart(logic);
                        break;
                    case 7:
                        SortPercentOfSanityLoss(logic);
                        break;
                    case 8:
                        SortByPercentOfSanityLossDescending(logic);
                        break;
                }

                Console.WriteLine("\n\tНажмите любую клавишу, чтобы продолжить ->");
                Console.ReadKey();

                Console.Clear();
            }

            Console.WriteLine("\n\tВыход из консоли ->");
            Console.ReadKey();
        }

        static void Add(List<Prosthesis> prostheses, Logic logic)
        {
            int id = 0, percentOfSanityLoss = 0;
            string modelName, bodyPart, buffDescript, debuffDescript, origin;

            bool valid = false;

            while (!valid)
            {
                Console.Write("Введите ID: ");

                if (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("\n\t\t!! Ошибка ввода, попробуйте снова");
                    continue;
                }
                if(prostheses.Find(pr => pr.Id == id) != null)
                {
                    Console.WriteLine("\n\t\t!! Протез с таким ID уже существует, попробуйте снова");
                    continue;
                }

                valid = true;
            }

            Console.Write("Введите название модели: ");
            modelName = Console.ReadLine();

            valid = false;
            while (!valid)
            {
                Console.Write("Введите % потери рассудка от применения протеза (от 2 до 90): ");

                if (!int.TryParse(Console.ReadLine(), out percentOfSanityLoss))
                {
                    Console.WriteLine("\n\t\t!! Ошибка ввода, попробуйте снова\n");
                    continue;
                }
                if (percentOfSanityLoss < 2 || percentOfSanityLoss > 90)
                {
                    Console.WriteLine("\n\t\t!! Такого % потери рассудка не может быть у протеза, попробуйте снова\n");
                    continue;
                }

                valid = true;
            }

            int bodyPartChoice = 0;
            valid = false;
            while (!valid)
            {
                Console.WriteLine("Выберите часть тела, на которую крепится протез или которую он заменяет");
                for(int i = 0; i < bodyParts.Count; i++ )
                {
                    Console.WriteLine($"[{i + 1}.] {bodyParts[i]}");
                }
                Console.Write("Ввод: ");

                if (!int.TryParse(Console.ReadLine(), out bodyPartChoice))
                {
                    Console.WriteLine("\n\t\t!! Ошибка ввода, попробуйте снова\n");
                    continue;
                }
                if (bodyPartChoice < 1 || bodyPartChoice > 5)
                {
                    Console.WriteLine("\n\t\t!! Такого варианта ответа нет, попробуйте снова\n");
                    continue;
                }

                valid = true;
            }
            bodyPart = bodyParts[bodyPartChoice - 1];

            Console.Write("Введите описание баффов: ");
            buffDescript = Console.ReadLine();

            Console.Write("Введите описание дебаффов: ");
            debuffDescript = Console.ReadLine();

            Console.Write("Введите происхождение протеза или место/а, где его можно получить: ");
            origin = Console.ReadLine();

            logic.AddProsthesis(id, modelName, bodyPart, percentOfSanityLoss, buffDescript, debuffDescript, origin);

            Console.WriteLine("\nПротез добавлен");
        }

        static void GetAll(List<Prosthesis> prostheses)
        {
            foreach(Prosthesis prosthesis in prostheses)
            {
                GetProsthesis(prosthesis);
            }
        }

        static void GetProsthesis(Prosthesis prosthesis)
        {
            Console.WriteLine(prosthesis.Id + "\t" + prosthesis.ModelName + "\t" + prosthesis.PercentOfSanityLoss + "%\t" +
                    prosthesis.BodyPart + "\t" + prosthesis.BuffDescription + "\t" + prosthesis.DebuffDescription + "\t" + prosthesis.Origin);
        }

        static void GetById(List<Prosthesis> prostheses)
        {
            int id = 0;

            Console.Write("\nВведите ID протеза: ");

            while(!int.TryParse(Console.ReadLine(), out id))
            {
                Console.Write("\n\t\t!! Ошибка ввода, попробуйте снова\n\nВвод: ");
            }

            Prosthesis prosthesis = prostheses.Find(pr => pr.Id == id);

            if(prosthesis != null)
            {
                GetProsthesis(prosthesis);
            }
            else
            {
                Console.WriteLine("Протез с таким ID Не найден");
            }
        }

        static void Change(List<Prosthesis> prostheses, Logic logic)
        {
            int id = 0;

            GetAll(prostheses);
            Console.Write("\nВведите ID протеза, который надо изменить: ");

            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.Write("\n\t\t!! Ошибка ввода, попробуйте снова\n\nВвод: ");
            }

            Prosthesis prosthesis = prostheses.Find(pr => pr.Id == id);

            if (prosthesis != null)
            {
                int choice = 0, percentOfSanityLoss = 0;
                string modelName, bodyPart, buffDescript, debuffDescript, origin;

                bool valid = false;

                while (!valid)
                {
                    Console.Write("Изменить имя?\n[1.] Да\n[2.] Нет\nВвод: ");

                    if (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.WriteLine("\n\t\t!! Ошибка ввода, попробуйте снова\n");
                        continue;
                    }
                    if (choice < 1 || choice > 2)
                    {
                        Console.WriteLine("\n\t\t!! Такого варианта ответа нет, попробуйте снова\n");
                        continue;
                    }

                    valid = true;
                }

                if (choice == 1)
                {
                    Console.Write("Введите новое имя модели: ");
                    modelName = Console.ReadLine();
                }
                else modelName = prostheses.Find(pr => pr.Id == id).ModelName;

                valid = false;
                while (!valid)
                {
                    Console.Write("Изменить % потери рассудка?\n[1.] Да\n[2.] Нет\nВвод: ");

                    if (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.WriteLine("\n\t\t!! Ошибка ввода, попробуйте снова\n");
                        continue;
                    }
                    if (choice < 1 || choice > 2)
                    {
                        Console.WriteLine("\n\t\t!! Такого варианта ответа нет, попробуйте снова\n");
                        continue;
                    }

                    valid = true;
                }

                if(choice == 1)
                {
                    valid = false;
                    while (!valid)
                    {
                        Console.Write("Введите новый % потери рассудка (от 2 до 90): ");

                        if (!int.TryParse(Console.ReadLine(), out percentOfSanityLoss))
                        {
                            Console.WriteLine("\n\t\t!! Ошибка ввода, попробуйте снова\n");
                            continue;
                        }
                        if (percentOfSanityLoss < 2 || percentOfSanityLoss > 90)
                        {
                            Console.WriteLine("\n\t\t!! Такого % потери рассудка не может быть у протеза, попробуйте снова\n");
                            continue;
                        }

                        valid = true;
                    }
                }
                else percentOfSanityLoss = prostheses.Find(pr => pr.Id == id).PercentOfSanityLoss;

                valid = false;
                while (!valid)
                {
                    Console.Write("Изменить часть тела?\n[1.] Да\n[2.] Нет\nВвод: ");

                    if (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.WriteLine("\n\t\t!! Ошибка ввода, попробуйте снова\n");
                        continue;
                    }
                    if (choice < 1 || choice > 2)
                    {
                        Console.WriteLine("\n\t\t!! Такого варианта ответа нет, попробуйте снова\n");
                        continue;
                    }

                    valid = true;
                }

                if (choice == 1)
                {
                    valid = false;
                    while (!valid)
                    {
                        Console.WriteLine("Выберите часть тела, на которую крепится протез или которую он заменяет");
                        for (int i = 0; i < bodyParts.Count; i++)
                        {
                            Console.WriteLine($"[{i + 1}.] {bodyParts[i]}");
                        }
                        Console.Write("Ввод: ");

                        if (!int.TryParse(Console.ReadLine(), out choice))
                        {
                            Console.WriteLine("\n\t\t!! Ошибка ввода, попробуйте снова\n");
                            continue;
                        }
                        if (choice < 1 || choice > bodyParts.Count)
                        {
                            Console.WriteLine("\n\t\t!! Такого варианта ответа нет, попробуйте снова\n");
                            continue;
                        }

                        valid = true;
                    }
                    bodyPart = bodyParts[choice - 1];
                }
                else bodyPart = prostheses.Find(pr => pr.Id == id).BodyPart;

                valid = false;
                while (!valid)
                {
                    Console.Write("Изменить баффы?\n[1.] Да\n[2.] Нет\nВвод: ");

                    if (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.WriteLine("\n\t\t!! Ошибка ввода, попробуйте снова\n");
                        continue;
                    }
                    if (choice < 1 || choice > 2)
                    {
                        Console.WriteLine("\n\t\t!! Такого варианта ответа нет, попробуйте снова\n");
                        continue;
                    }

                    valid = true;
                }

                if (choice == 1)
                {
                    Console.Write("Введите новые баффы: ");
                    buffDescript = Console.ReadLine();
                }
                else buffDescript = prostheses.Find(pr => pr.Id == id).BuffDescription;

                valid = false;
                while (!valid)
                {
                    Console.Write("Изменить дебаффы?\n[1.] Да\n[2.] Нет\nВвод: ");

                    if (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.WriteLine("\n\t\t!! Ошибка ввода, попробуйте снова\n");
                        continue;
                    }
                    if (choice < 1 || choice > 2)
                    {
                        Console.WriteLine("\n\t\t!! Такого варианта ответа нет, попробуйте снова\n");
                        continue;
                    }

                    valid = true;
                }

                if (choice == 1)
                {
                    Console.Write("Введите новые дебаффы: ");
                    debuffDescript = Console.ReadLine();
                }
                else debuffDescript = prostheses.Find(pr => pr.Id == id).DebuffDescription;

                valid = false;
                while (!valid)
                {
                    Console.Write("Изменить происхождение?\n[1.] Да\n[2.] Нет\nВвод: ");

                    if (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.WriteLine("\n\t\t!! Ошибка ввода, попробуйте снова\n");
                        continue;
                    }
                    if (choice < 1 || choice > 2)
                    {
                        Console.WriteLine("\n\t\t!! Такого варианта ответа нет, попробуйте снова\n");
                        continue;
                    }

                    valid = true;
                }

                if (choice == 1)
                {
                    Console.Write("Введите новое происхождение протеза: ");
                    origin = Console.ReadLine();
                }
                else origin = prostheses.Find(pr => pr.Id == id).Origin;

                logic.ChangeProsthesis(id, modelName, bodyPart, percentOfSanityLoss, buffDescript, debuffDescript, origin);
                Console.WriteLine("Изменения протеза сохранены");
            }
            else
            {
                Console.WriteLine("Протез с таким ID Не найден");
            }
        }

        static void Delete(List<Prosthesis> prostheses, Logic logic)
        {
            int id = 0;

            GetAll(prostheses);
            Console.Write("\nВведите ID протеза, который надо удалить: ");

            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.Write("\n\t\t!! Ошибка ввода, попробуйте снова\n\nВвод: ");
            }

            Prosthesis prosthesis = prostheses.Find(pr => pr.Id == id);

            if (prosthesis != null)
            {
                logic.DeleteProsthesis(id);
                Console.WriteLine("Протез удален");
            }
            else
            {
                Console.WriteLine("Протез с таким ID Не найден");
            }
        }

        static void GroupByBodyPart(Logic logic)
        {
            bool valid = false;
            int bodyPartChoice = 0;

            while (!valid)
            {
                Console.WriteLine("Выберите часть тела, на которую крепится протез или которую он заменяет");
                for (int i = 0; i < bodyParts.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}.] {bodyParts[i]}");
                }
                Console.Write("Ввод: ");

                if (!int.TryParse(Console.ReadLine(), out bodyPartChoice))
                {
                    Console.WriteLine("\n\t\t!! Ошибка ввода, попробуйте снова\n");
                    continue;
                }
                if (bodyPartChoice < 1 || bodyPartChoice > 5)
                {
                    Console.WriteLine("\n\t\t!! Такого варианта ответа нет, попробуйте снова\n");
                    continue;
                }

                valid = true;
            }

            string bodyPart = bodyParts[bodyPartChoice - 1];
            List<Prosthesis> groupedProstheses = logic.GroupByBodyPart(bodyPart);

            GetAll(groupedProstheses);
        }

        static void SortPercentOfSanityLoss(Logic logic)
        {
            List<Prosthesis> sortedProstheses = logic.SortByPercentOfSanityLoss();
            GetAll(sortedProstheses);
        }

        static void SortByPercentOfSanityLossDescending(Logic logic)
        {
            List<Prosthesis> sortedProstheses = logic.SortByPercentOfSanityLossDescending();
            GetAll(sortedProstheses);
        }
        */
    }
}
