using System;

namespace cadastro
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = obterOpcaoUusario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;

                    case "2":
                        InserirSerie();
                        break;

                    case "3":
                        AtualizarSerie();
                        break;

                    case "4":
                         ExcluirSerie();
                        break;

                    case "5":
                         VisulizarSerie();
                        break;

                    case "C":
                        Console.Clear();
                        break;

                    default:

                        throw new ArgumentOutOfRangeException();

                }

                opcaoUsuario = obterOpcaoUusario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();

        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");
            var lista = repositorio.Lista();

            if (lista.Count == 0) //se a lista tiver vazia
            {
                
                Console.WriteLine("Nenhuma  série cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                if(!excluido)
                {
                Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
                }
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} = {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int entraGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da série: ");
            string entraTitulo = Console.ReadLine();

            Console.Write("Digite o ano de ínicio da série: ");
            int entraAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição: ");
            string entraDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
            genero: (Genero)entraGenero,
            titulo: entraTitulo,
            ano: entraAno,
            descricao: entraDescricao);
            repositorio.Insere(novaSerie);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o ID da série");
             int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} = {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int entraGenero = int.Parse(Console.ReadLine());
           

            Console.Write("Digite o Título da série: ");
            string entraTitulo = Console.ReadLine();

            Console.Write("Digite o ano de ínicio da série: ");
            int entraAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição: ");
            string entraDescricao = Console.ReadLine();

            Serie atualizarSerie = new Serie(id: repositorio.ProximoId(),
            genero: (Genero)entraGenero,
            titulo: entraTitulo,
            ano: entraAno,
            descricao: entraDescricao);
            repositorio.Atualiza(indiceSerie, atualizarSerie);
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Excluir(indiceSerie);
        }

        private static void VisulizarSerie()
        {
            Console.Write("Digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
        }



         private static string obterOpcaoUusario()
    {
        Console.WriteLine();
        Console.WriteLine("DIO: Séries ao seu dispor!!!!");
        Console.WriteLine("Informe a opção desejada");

        Console.WriteLine("1- Listar séries");
        Console.WriteLine("2 - Inserir nova série");
        Console.WriteLine("3 - Atualizar série");
        Console.WriteLine("4 - Excluir série");
        Console.WriteLine("5 - Visualizar série");
        Console.WriteLine("C - Limpar tela ");
        Console.WriteLine("x - Sair");
        Console.WriteLine();

        string opcaoUsuario = Console.ReadLine().ToUpper();
        Console.WriteLine();
        return opcaoUsuario;

    }

    
    }
}

