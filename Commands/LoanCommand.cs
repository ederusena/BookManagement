using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookManagement.BLL;
using BookManagement.Generics;

namespace BookManagement.Commands
{
    public class LoanCommand
    {
        private readonly LoanService _loanService;

        public LoanCommand(LoanService loanService)
        {
            _loanService = loanService;
        }

        void ShowMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("1. ✅ Adicionar empréstimo");
            Console.WriteLine("2. ❌ Remover empréstimo");
            Console.WriteLine("3. 🔎 Listar empréstimos");
            Console.WriteLine("4. 🆙Atualizar empréstimo");
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
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        var bookId = CaptureDataUser.GetData("ID do livro: ", entrada => int.Parse(entrada));
                        var userId = CaptureDataUser.GetData("ID do usuário: ", entrada => int.Parse(entrada));

                        _loanService.AddLoan(bookId, userId);
                        Console.WriteLine("Empréstimo cadastrado com sucesso!");
                        Console.WriteLine("↩️ Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case "2":
                        var loanId = CaptureDataUser.GetData("ID do Emprestimo: ", entrada => int.Parse(entrada));
                        _loanService.RemoveLoan(loanId);
                        Console.WriteLine("Empréstimo removido com sucesso!");
                        Console.WriteLine("↩️ Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Clear();
                        var loans = _loanService.GetAllLoans();
                        if (loans.Count == 0)
                        {
                            Console.WriteLine("Nenhum empréstimo cadastrado.");
                        }
                        else
                        {
                            foreach (var loan in loans)
                            {
                                Console.WriteLine(loan);
                            }
                        }
                        Console.WriteLine("↩️ Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                    // case "4":
                    //     Console.ForegroundColor = ConsoleColor.Cyan;
                    //     Console.Clear();
                    //     Console.Write("ID do empréstimo: ");
                    //     var id = int.Parse(Console.ReadLine());
                    //     Console.Clear();
                    //     Console.Write("Data de empréstimo: ");
                    //     var loanDate = DateTime.Parse(Console.ReadLine());
                    //     Console.Clear();
                    //     Console.Write("Data de devolução: ");
                    //     var returnDate = DateTime.Parse(Console.ReadLine());
                    //     _loanService.UpdateLoan(id, loanDate, returnDate);
                    //     Console.WriteLine("Empréstimo atualizado com sucesso!");
                    //     break;
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