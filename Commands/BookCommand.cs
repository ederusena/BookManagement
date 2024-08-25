using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookManagement.BLL;
using BookManagement.Generics;
using BookManagement.Models;

namespace BookManagement.Commands
{
    public class BookCommand
    {
        private readonly BookService _bookService;

        public BookCommand(BookService bookService)
        {
            _bookService = bookService;
        }

        void ShowMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("1. ✅ Cadastrar Livro");
            Console.WriteLine("2. 🔎 Consultar Todos os Livros");
            Console.WriteLine("3. 🔎 Consultar Um Livro");
            Console.WriteLine("4. ❌ Remover um Livro");
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
                        var title = CaptureDataUser.GetData("Título: ", entrada => entrada);
                        var author = CaptureDataUser.GetData("Autor: ", entrada => entrada);
                        var isbn = CaptureDataUser.GetData("ISBN: ", entrada => entrada);
                        var ano = CaptureDataUser.GetData("Ano de Publicação: ", entrada => int.Parse(entrada));

                        var book = new Book(title, author, isbn, ano);

                        _bookService.AddBook(book);
                        Console.WriteLine("Livro cadastrado com sucesso!");
                        Console.WriteLine("↩️ Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case "2":
                        var books = _bookService.GetAllBooks();
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        if (books.Count == 0)
                        {
                            Console.WriteLine("Nenhum livro cadastrado.");
                        }
                        else
                        {
                            foreach (var l in books)
                            {
                                Console.WriteLine($"Id: {l.Id}, Título: {l.Title}, Autor: {l.Author}, ISBN: {l.ISBN}, Ano: {l.PublishYear}");
                            }
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("↩️ Pressione qualquer tecla para continuar...");
                            Console.ReadKey();
                        }
                        break;

                    case "3":
                        var findId = CaptureDataUser.GetData("ID do Livro: ", entrada => int.Parse(entrada));

                        var bookFound = _bookService.GetBookById(findId);
                        if (bookFound != null)
                        {
                            Console.WriteLine($"Id: {bookFound.Id}, Título: {bookFound.Title}, Autor: {bookFound.Author}, ISBN: {bookFound.ISBN}, Ano: {bookFound.PublishYear}");
                            Console.ForegroundColor = ConsoleColor.Yellow;

                            Console.WriteLine("↩️ Pressione qualquer tecla para continuar...");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Livro não encontrado.");
                        }
                        break;

                    case "4":
                        var removeIdFind = CaptureDataUser.GetData("Digite o Id do livro a ser removido: ", entrada => int.Parse(entrada));
                        _bookService.RemoveBook(removeIdFind);
                        Console.WriteLine("Livro removido com sucesso.");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("↩️ Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
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