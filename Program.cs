


using BookManagement.BLL;
using BookManagement.Comands;
using BookManagement.DAL;
using BookManagement.Models;
using Microsoft.Extensions.DependencyInjection;

namespace BookManagement
{
  class Program
  {
    static void Main(string[] args)
    {
      var serviceProvider = new ServiceCollection()
        .AddSingleton<IRepository<Book>, BookRepository>()
        .AddTransient<BookService>()
        .AddSingleton<IRepository<User>, UserRepository>()
        .AddTransient<UserService>()
        .AddTransient<BookCommand>()
        .AddTransient<UserCommand>()
        .BuildServiceProvider();

      var _bookCommand = serviceProvider.GetService<BookCommand>();
      var _userCommand = serviceProvider.GetService<UserCommand>();

      void ExibirMenu()
      {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("1. 📚 Menu Livro");
        Console.WriteLine("2. 🙋 Menu Usuário");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("5. 🔚 Sair");
      }

      while (true)
      {
        ExibirMenu();
        var opcao = Console.ReadLine();

        switch (opcao)
        {
          case "1":
            _bookCommand?.Executar();
            break;
          case "2":
            _userCommand?.Executar();
            break;
          case "5":
            Console.ForegroundColor = ConsoleColor.White;
            return;

          default:
            Console.WriteLine("Opção inválida.");
            break;
        }
      }


    }
  }
}