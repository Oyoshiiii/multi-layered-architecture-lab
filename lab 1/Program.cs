using BusinessLogic;
using Entities;
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
        static void Main(string[] args)
        {
            Logic logic = new Logic();

            List<Prosthesis> prostheses = logic.GetAllProstheses();

            List<string> bodyParts = logic.GetBodyPartsList();
            List<string> originList = logic.GetOriginList();

            int userChoice = 0;

            while (userChoice != 10)
            {
                prostheses = logic.GetAllProstheses();

                Console.Write("[1.] Вывести все протезы\n" +
                    "[2.] Вывести протез по Id\n" +
                    "[3.] Добавить протез\n" +
                    "[4.] Изменить протез\n" +
                    "[5.] Удалить протез\n" +
                    "[6.] Группировать по расположению на теле и вывести все протезы\n" +
                    "[7.] Поиск по местам нахождения протезов\n" +
                    "[8.] Сортировать по % потери рассудка по убыванию\n" +
                    "[9.] Сортировать по % потери рассудка по возрастанию\n" +
                    "[10.] Выход\n\n" +
                    "Ввод: ");

                while(!int.TryParse(Console.ReadLine(), out userChoice))
                {
                    Console.Write("\n\t\t!! Ошибка ввода, попробуйте снова\n\nВвод: ");
                }

                Console.Clear();
                Console.Write("\x1b[3J");

                switch (userChoice)
                {
                    case 1:
                        GetAll(prostheses);
                        break;
                    case 2:
                        GetById(prostheses);
                        break;
                    case 3:
                        Add(prostheses, logic, bodyParts, originList);
                        break;
                    case 4:
                        Change(prostheses, logic, bodyParts, originList);
                        break;
                    case 5:
                        Delete(prostheses, logic);
                        break;
                    case 6:
                        GroupByAllBodyParts(logic, bodyParts);
                        break;
                    case 7:
                        FindByOrigin(logic, originList);
                        break;
                    case 8:
                        SortByPercentOfSanityLossDescending(prostheses, logic);
                        break;
                    case 9:
                        SortPercentOfSanityLoss(prostheses, logic);
                        break;
                }

                Console.WriteLine("\n\tНажмите любую клавишу, чтобы продолжить ->");
                Console.ReadKey();

                Console.Clear();
                Console.Write("\x1b[3J");
            }

            Console.WriteLine("\n\tВыход из консоли ->");
            Console.ReadKey();
        }

        /// <summary>
        /// Консольное добавление протеза
        /// </summary>
        /// <param name="prostheses">Лист протезов</param>
        /// <param name="logic">Экземпляр класса бизнес-логики <see cref="Logic"/></param>
        /// <param name="bodyParts">Лист частей тела</param>
        /// <param name="originList">Лист локаций/мест нахождения</param>
        static void Add(List<Prosthesis> prostheses, Logic logic, List<string> bodyParts, List<string> originList)
        {
            int percentOfSanityLoss = 0;
            string modelName, bodyPart, buffDescript, debuffDescript, origin;

            bool valid = false;

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
                if (bodyPartChoice < 1 || bodyPartChoice > bodyParts.Count)
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

            int originChoice = 0;
            valid = false;
            while (!valid)
            {
                Console.WriteLine("Выберите локацию/место нахождения протеза");
                for (int i = 0; i < originList.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}.] {originList[i]}");
                }
                Console.Write("Ввод: ");

                if (!int.TryParse(Console.ReadLine(), out originChoice))
                {
                    Console.WriteLine("\n\t\t!! Ошибка ввода, попробуйте снова\n");
                    continue;
                }
                if (originChoice < 1 || originChoice > originList.Count)
                {
                    Console.WriteLine("\n\t\t!! Такого варианта ответа нет, попробуйте снова\n");
                    continue;
                }

                valid = true;
            }
            origin = originList[originChoice - 1];

            logic.AddProsthesis(modelName, bodyPart, percentOfSanityLoss, buffDescript, debuffDescript, origin);

            Console.WriteLine("\nПротез добавлен");
        }

        /// <summary>
        /// Консольный вывод листа протезов
        /// </summary>
        /// <param name="prostheses">Лист протезов</param>
        static void GetAll(List<Prosthesis> prostheses)
        {
            foreach(Prosthesis prosthesis in prostheses)
            {
                GetProsthesis(prosthesis);
            }
        }

        /// <summary>
        /// Консольный вывод протеза
        /// </summary>
        /// <param name="prosthesis">Протез</param>
        static void GetProsthesis(Prosthesis prosthesis)
        {
            Console.WriteLine("\n----------------------------------------------------------\n" +
                    "ID: " + prosthesis.Id + "\nМодель: " + prosthesis.ModelName + "\n% потери рассудка: " + prosthesis.PercentOfSanityLoss + "%\nЧасть тела: " +
                    prosthesis.BodyPart + "\nБаффы: " + prosthesis.BuffDescription + "\nДебаффы: " + prosthesis.DebuffDescription + "\nЛокация/место нахождения: " + prosthesis.Origin +
                    "\n----------------------------------------------------------\n");
        }

        /// <summary>
        /// Консольный вывод протеза по ID
        /// </summary>
        /// <param name="prostheses">Протез</param>
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

        /// <summary>
        /// Консольное изменение протеза
        /// </summary>
        /// <param name="prostheses">Лист протезов</param>
        /// <param name="logic">Экземпляр класса бизнес-логики <see cref="Logic"/></param>
        /// <param name="bodyParts">Лист частей тела</param>
        /// <param name="originList">Лист локаций/мест нахождения</param>
        static void Change(List<Prosthesis> prostheses, Logic logic, List<string> bodyParts, List<string> originList)
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
                    Console.Write("Изменить локацию/место нахождения?\n[1.] Да\n[2.] Нет\nВвод: ");

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
                        Console.WriteLine("Выберите локацию/место нахождения протеза:");
                        for (int i = 0; i < originList.Count; i++)
                        {
                            Console.WriteLine($"[{i + 1}.] {originList[i]}");
                        }
                        Console.Write("Ввод: ");

                        if (!int.TryParse(Console.ReadLine(), out choice))
                        {
                            Console.WriteLine("\n\t\t!! Ошибка ввода, попробуйте снова\n");
                            continue;
                        }
                        if (choice < 1 || choice > originList.Count)
                        {
                            Console.WriteLine("\n\t\t!! Такого варианта ответа нет, попробуйте снова\n");
                            continue;
                        }

                        valid = true;
                    }
                    origin = originList[choice - 1];
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

        /// <summary>
        /// Консольное удаление протеза
        /// </summary>
        /// <param name="prostheses">Лист протезов</param>
        /// <param name="logic">Экземпляр класса бизнес-логики <see cref="Logic"/></param>
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

        /// <summary>
        /// Консольная группировка протезов по всем частям тела
        /// </summary>
        /// <param name="logic">Экземпляр класса бизнес-логики <see cref="Logic"/></param>
        /// <param name="bodyParts">Лист частей тела</param>
        static void GroupByAllBodyParts(Logic logic, List<string> bodyParts)
        {
            List<Prosthesis> groupedProstheses = logic.GroupByAllBodyParts();
            GetAll(groupedProstheses);
        }

        /// <summary>
        /// Консольный поиск протезов по конкретному месту нахождения
        /// </summary>
        /// <param name="logic">Экземпляр класса бизнес-логики <see cref="Logic"/></param>
        /// <param name="originList">Лист локаций/мест нахождения</param>
        static void FindByOrigin(Logic logic, List<string> originList)
        {
            bool valid = false;
            int originChoice = 0;

            while (!valid)
            {
                Console.WriteLine("Выберите локацию/место нахождения для вывода протезов, которые можно там найти");
                for (int i = 0; i < originList.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}.] {originList[i]}");
                }
                Console.Write("Ввод: ");

                if (!int.TryParse(Console.ReadLine(), out originChoice))
                {
                    Console.WriteLine("\n\t\t!! Ошибка ввода, попробуйте снова\n");
                    continue;
                }
                if (originChoice < 1 || originChoice > 5)
                {
                    Console.WriteLine("\n\t\t!! Такого варианта ответа нет, попробуйте снова\n");
                    continue;
                }

                valid = true;
            }

            string chosenOrigin = originList[originChoice - 1];
            List<Prosthesis> groupedProstheses = logic.GroupBySpecificOrigin(chosenOrigin);

            GetAll(groupedProstheses);
        }

        /// <summary>
        /// Консольная сортировка по возрастанию % потери рассудка
        /// </summary>
        /// <param name="prostheses">Лист протезов</param>
        /// <param name="logic">Экземпляр класса бизнес-логики <see cref="Logic"/></param>
        static void SortPercentOfSanityLoss(List<Prosthesis> prostheses, Logic logic)
        {
            List<Prosthesis> sortedProstheses = logic.SortByPercentOfSanityLoss();
            GetAll(sortedProstheses);
        }

        /// <summary>
        /// Консольная сортировка по убыванию % потери рассудка
        /// </summary>
        /// <param name="prostheses">Лист протезов</param>
        /// <param name="logic">Экземпляр класса бизнес-логики <see cref="Logic"/></param>
        static void SortByPercentOfSanityLossDescending(List<Prosthesis> prostheses, Logic logic)
        {
            List<Prosthesis> sortedProstheses = logic.SortByPercentOfSanityLossDescending();
            GetAll(sortedProstheses);
        }
    }
}
