using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.X86;
using System.Security.Claims;

namespace Program
{
    class Programm
    {
        static void Main()
        {
            Bank bank = new();
            int operation = 0;
            try
            {
                do
                {
                    Console.WriteLine("Выберите операцию:0 - выйти 1 - добавить клиента, 2 - найти клиента, 3 - провести операцию по счету, 4 - найти сотрудника");
                    operation = Convert.ToInt32(Console.ReadLine());
                    switch (operation)
                    {
                        case 1:
                            Console.WriteLine("Введите номер паспорта клиента");
                            string id = Console.ReadLine();
                            if (id = null)
                            {
                                throw new Exception("Строка не может быь пустой");
                            }
                            if (bank.GetClientByNumber(id) != null) bank.GetClientByNumber(id).Print();
                            else Console.WriteLine("Клиента с этим номером паспорта не найдено");
                            break;
                        case 2:
                            Console.WriteLine("Введите данные ФИО, номер паспорта");
                            string[] parts = Console.ReadLine().Split(' ');
                            Client cl = new(parts[0], parts[1]);
                            if (bank.GetClientByNumber(parts[1]) != null) Console.WriteLine("Клиент с этим номером паспорта уже существует");
                            else
                            {
                                bank.AddClient(cl);
                                Console.WriteLine("Клинт успешно добавлен");
                            }
                            break;
                        case 3:
                            Console.WriteLine("Введите номер паспорта клиента");
                            string id = Console.ReadLine();
                            if (id = null)
                            {
                                throw new Exception("Строка не может быь пустой");
                            }
                            if (bank.GetClientByNumber(id) != null)
                            {
                                Client client = bank.GetClientByNumber(id);
                                client.Print();
                                Console.WriteLine("Выберите операцию: 1 - пополнение счета, 2 - снятие со счета, 3 - блокировка счета, 4 - удаление счета");
                                int choise1 = Convert.ToInt32(Console.ReadLine());
                                switch (choise1)
                                {
                                    case 1:
                                        Console.WriteLine("Введите сумму");
                                        client.AddToRup(Convert.ToDouble(Console.ReadLine()));
                                        client.Print();
                                        break;
                                    case 2:
                                        Console.WriteLine("Введите сумму");
                                        double sum = Convert.ToDouble(Console.ReadLine());
                                        if (client.Rub < sum)throw new Exception("Сумма снятия не может быть больше суммы на счету");

                                        client.AddToRub(sum);
                                        client.Print();
                                        break;
                                    case 3:
                                        client.Block();
                                        Console.WriteLine("Клиент заблокирован");
                                }
                            }
                            else Console.WriteLine("Клиента с таким номером паспорта нет");
                    }
                }
                while (operation != 0);
            }
            catch (Exception ex)
            {
                Err(ex.Message);
            }
        }
        static void Err(string text)
        {
            Console.WriteLine("Ошибка");
            Console.WriteLine(text);
            Console.WriteLine("Чтобы перезапустить программу нажмите Enter");
            Console.WriteLine("Чтобы выйти нажмите любую другую клавишу");
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {

                Main();
                return;
            }
            else
            {
                Environment.Exit(0);
            }

        }
        static void End()
        {
            Console.WriteLine("Чтобы перезапустить программу нажмите Enter");
            Console.WriteLine("Чтобы выйти нажмите любую другую клавишу");
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {

                Main();
                return;
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
    public class Employee : Person
    {
        public override string Name { get; init; }
        public override string Id { get; init; }
        public int PhoneNumber { get; init; }
        public string Position { get; init; }

        public Employee(string name, string number, int phoneNumber, string position)
        {
            Name = name;
            Id = number;
            PhoneNumber = phoneNumber;
            Position = position;
        }
        public void Print()
        {
            Console.WriteLine("{0,30}{1,10}{2,10}{3,15}", Name, Id, PhoneNumber, Position);
        }
    }
    public class Client : Person
    {
        public override string Name { get; init; }
        public override string Id { get; init; }
        public double Rub { get; private set; }
        public bool Blocked { get; private set; }
        public Client(string name, string passportNumber)
        {
            Name = name;
            Id = passportNumber;
        }
        public void AddToRub(double value)
        {
            if (!Blocked) Rub += value;
        }
        public void Block()
        {
            Blocked = true;
        }
        public void Print()
        {
            Console.WriteLine("{0,30}{1,10}{2,10}", Name, Id, Rub + " рублей");
        }

    }
    public abstract class Person
    {
        public abstract string Name { get; init; }
        public abstract string Id { get; init; }
    }
    public class Bank
    {
        private readonly List<Client> clients = new();
        private readonly List<Employee> employees = new();
        public bool AddClient(Client client)
        {
            if (GetClientByNumber(client.Id) != null)
            {
                return false;
            }
            else
            {
                clients.Add(client);
                return true;
            }
        }
        public void RemovePerson(Client client)
        {
            clients.Remove(client);
        }
        public bool AddClient(Employee employee)
        {
            if (GetEmployeeByNumber(employee.Id) != null)
            {
                return false;
            }
            else
            {
                employees.Add(employee);
                return true;
            }
        }
        public void RemovePerson(Employee employee)
        {
            employees.Remove(employee);
        }
        public Employee? GetEmployeeByName(string name)
        {
            return employees.Find(x => x.Name == name);
        }
        public Employee? GetEmployeeByNumber(string number)
        {
            return employees.Find(x => x.Id == number);
        }
        public Client? GetClientByName(string name)
        {
            return clients.Find(x => x.Name == name);
        }
        public Client? GetClientByNumber(string number)
        {
            return clients.Find(x => x.Id == number);
        }
    }
}