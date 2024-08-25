


using BookManagement.BLL;
using BookManagement.Commands;
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
        .AddSingleton<IRepository<Loan>, LoanRepository>()
        .AddTransient<LoanService>()
        .AddTransient<BookCommand>()
        .AddTransient<UserCommand>()
        .AddTransient<LoanCommand>()
        .BuildServiceProvider();

      var _bookCommand = serviceProvider.GetService<BookCommand>();
      var _userCommand = serviceProvider.GetService<UserCommand>();
      var _loanCommand = serviceProvider.GetService<LoanCommand>();

      void ShowMenu()
      {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("1. 📚 Menu Livro");
        Console.WriteLine("2. 🙋 Menu Usuário");
        Console.WriteLine("3. 🏦 Menu Empréstimo");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("5. 🔚 Sair");
      }
      var continueLoop = true;
      while (continueLoop)
      {
        ShowMenu();
        var option = Console.ReadLine();

        switch (option)
        {
          case "1":
            _bookCommand?.Run();
            break;
          case "2":
            _userCommand?.Run();
            break;
          case "3":
            _loanCommand?.Run();
            return;
          case "5":
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            continueLoop = false;
            return;
          default:
            Console.WriteLine("Opção inválida.");
            break;
        }
      }


    }
  }
}