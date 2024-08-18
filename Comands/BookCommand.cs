using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookManagement.BLL;
using BookManagement.Models;

namespace BookManagement.Comands
{
    public class BookCommand
    {
        private readonly BookService _livroService;

        public BookCommand(BookService livroService)
        {
            _livroService = livroService;
        }

        void ExibirMenu()
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
        public void Executar()
        {


            while (true)
            {
                ExibirMenu();
                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Clear();
                        Console.Write("Título: ");
                        var titulo = Console.ReadLine();
                        Console.Clear();
                        Console.Write("Autor: ");
                        var autor = Console.ReadLine();
                        Console.Clear();
                        Console.Write("ISBN: ");
                        var isbn = Console.ReadLine();
                        Console.Clear();
                        Console.Write("Ano de Publicação: ");
                        var ano = int.Parse(Console.ReadLine());

                        var livro = new Book(titulo, autor, isbn, ano);

                        _livroService.AddBook(livro);
                        Console.WriteLine("Livro cadastrado com sucesso!");
                        break;

                    case "2":
                        var livros = _livroService.GetAllBooks();
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        if (livros.Count == 0)
                        {
                            Console.WriteLine("Nenhum livro cadastrado.");
                        }
                        else
                        {
                            foreach (var l in livros)
                            {
                                Console.WriteLine($"Id: {l.Id}, Título: {l.Title}, Autor: {l.Author}, ISBN: {l.ISBN}, Ano: {l.PublishYear}");
                            }
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Pressione qualquer tecla para continuar...");
                            Console.ReadKey();
                        }
                        break;

                    case "3":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("Digite o Id do livro: ");
                        var idConsulta = int.Parse(Console.ReadLine());
                        var livroConsultado = _livroService.GetBookById(idConsulta);
                        if (livroConsultado != null)
                        {
                            Console.WriteLine($"Id: {livroConsultado.Id}, Título: {livroConsultado.Title}, Autor: {livroConsultado.Author}, ISBN: {livroConsultado.ISBN}, Ano: {livroConsultado.PublishYear}");
                            Console.ForegroundColor = ConsoleColor.Yellow;

                            Console.WriteLine("Pressione qualquer tecla para continuar...");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Livro não encontrado.");
                        }
                        break;

                    case "4":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("Digite o Id do livro a ser removido: ");
                        var idRemocao = int.Parse(Console.ReadLine());
                        _livroService.RemoveBook(idRemocao);
                        Console.WriteLine("Livro removido com sucesso.");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
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