using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookManagement.BLL;
using BookManagement.Generics;
using BookManagement.Models;

namespace BookManagement.Commands
{
    public class UserCommand
    {
        private readonly UserService _userService;

        public UserCommand(UserService userService)
        {
            _userService = userService;
        }

        void ShowMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("1. ✅ Cadastrar Usuário");
            Console.WriteLine("2. 🔎 Consultar Todos os Usuários");
            Console.WriteLine("3. 🔎 Consultar Um Usuário");
            Console.WriteLine("4. ❌ Remover um Usuário");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("5. ↩️ Voltar ao menu anterior");
        }

        public void Run()
        {
            while (true)
            {
                ShowMenu();
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        var nome = CaptureDataUser.GetData("Nome: ", entrada => entrada);
                        var email = CaptureDataUser.GetData("E-mail: ", entrada => entrada);

                        var user = new User(nome, email);

                        _userService.AddUser(user);
                        Console.WriteLine("Usuário cadastrado com sucesso!");
                        break;
                    case "2":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Clear();
                        var users = _userService.GetAllUsers();
                        if (users.Count == 0)
                        {
                            Console.WriteLine("Nenhum usuário cadastrado.");
                        }
                        else
                        {
                            foreach (var item in users)
                            {
                                Console.WriteLine($"Id: {item.Id} - Nome: {item.Name} - Email: {item.Email}");
                            }
                        }
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("↩️ Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case "3":
                        var id = CaptureDataUser.GetData("Id: ", entrada => int.Parse(entrada));
                        var userById = _userService.GetUserById(id);
                        if (userById == null)
                        {
                            Console.WriteLine("Usuário não encontrado.");
                        }
                        else
                        {
                            Console.WriteLine($"Id: {userById.Id} - Nome: {userById.Name} - Email: {userById.Email}");
                        }
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("↩️ Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case "4":
                        var idRemove = CaptureDataUser.GetData("Id: ", entrada => int.Parse(entrada));
                        _userService.RemoveUser(idRemove);
                        Console.WriteLine("Usuário removido com sucesso!");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("↩️ Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }
    }
}