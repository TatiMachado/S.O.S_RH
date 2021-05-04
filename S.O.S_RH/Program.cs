using S.O.S_RH.Classes;
using S.O.S_RH;
using System;
using System.Collections.Generic;
using System.Linq;

namespace S.O.S_RH
{
    class Program
    {
        static VagaRepositorio Vagarepo = new VagaRepositorio();
        static List<Empresa> listaEmpresas = new List<Empresa>();
        static List<Candidato> listaCandidatos = new List<Candidato>();
        
        static string CPFOuCNPJ;

        static void Main(string[] args)
        { 
            PopulaCandidatos();
            PopulaEmpresas();

            listaCandidatos.ToString();
            Console.ReadKey();

            string opcaoUsuario = ObterOpcaoUsuario();

            if (opcaoUsuario.Substring(0, 1) == "c") //MENU CANDIDATO
                MenuCandidato(opcaoUsuario);  //passa só o nº da funcionalidade
            else //MENU EMPRESA
                MenuEmpresa(opcaoUsuario);  //passa só o nº da funcionalidade

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void Limpartela()
        {
            Console.WriteLine("<<<TECLE ENTER>>>");
            Console.ReadKey();
            Console.Clear();
        }

        private static string MenuEmpresa(string opcao)
        { 
            while (opcao!= "ex")
            {
                switch (opcao)
                {
                    case "e1":
                        CadastrarVaga();
                        break;
                    case "e2":
                        AlterarVaga();
                        break;
                    case "e3":
                        ListarVagasEmpresa();
                        break;
                    case "ec":
                        Console.Clear();
                        break;
                    default:
                        {
                            if (opcao.Substring(0, 1) == "c")
                            {
                                MenuCandidato(opcao);
                                break;
                            }
                            else
                                throw new ArgumentOutOfRangeException();
                        }
                }
                opcao = ObterOpcaoUsuario();

                Console.WriteLine();
            }

            return opcao;
        }

        private static string MenuCandidato(string opcao)
        {

            while (opcao.ToUpper() != "cx")
            {
                switch (opcao)
                {
                    case "c1":
                        Candidatar();
                        break;
                    case "c2":
                        ListarVagasCandidato();
                        break;
                    case "c3":
                        PesquisarVaga();
                        break;
                    case "c4":
                        ListarTodasVagas();
                        break;
                    case "cc":
                        Console.Clear();
                        break;
                    default:
                        {
                            if (opcao.Substring(0, 1) == "c")
                            {
                                MenuEmpresa(opcao);
                                break;
                            }
                            else
                                throw new ArgumentOutOfRangeException();
                        }
                }
                opcao = ObterOpcaoUsuario();

                Console.WriteLine();
            }

            return opcao;
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("S.O.S  RH!!");
            Console.Write("Informe o seu perfil (C)andidato ou (E)mpresa:");
            string perfil = Console.ReadLine();

            if (perfil == "e") //EMPRESA
            {
                Console.Write("Informe o CNPJ:");
                CPFOuCNPJ = Console.ReadLine();

                Console.WriteLine("GERENCIAMENTO DE VAGAS");
                Console.WriteLine("1- Cadastrar Vaga");
                Console.WriteLine("2- Alterar Vaga");
                Console.WriteLine("3- Listar Vagas");
            }
            else //CANDIDATO
            {
                Console.Write("Informe o CPF:");
                CPFOuCNPJ = Console.ReadLine();

                Console.WriteLine("OFERTAS DE VAGAS");
                Console.WriteLine("1- Candidatar-se");
                Console.WriteLine("2- Minhas Vagas");
                Console.WriteLine("3- Pesquisar Vaga");
                Console.WriteLine("4- Visualizar Todas Vagas");
            }
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();


            Console.WriteLine("Informa a opção desejada:");
            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();

            return perfil + opcaoUsuario;
        }


        //MÉTODOS EMPRESA
        private static void ListarVagasEmpresa()
        {
            Console.WriteLine("VAGAS DE SUA EMPRESA");

            var lista = Vagarepo.ListarVagasPorEmpresa(CPFOuCNPJ);

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma vaga Cadastrada.");
                Limpartela();
                return;
            }

            foreach (var vaga in lista)
            {
                Console.WriteLine("#ID {0} - {1} - {2} - {3} - {4}", vaga.Id, vaga.Descricao, vaga.Salario, vaga.StatusVaga, vaga.Empresa);
            }
        }

        private static void CadastrarVaga()
        {
            Console.WriteLine("**INCLUSÃO DE VAGA**");
            Console.WriteLine("Digite a Descrição da Vaga: ");
            string descricao = Console.ReadLine();

            Console.WriteLine("Digite o Salário da Vaga: ");
            double salario = double.Parse(Console.ReadLine());

            //buscar a empresa
            Empresa empresa = listaEmpresas.FirstOrDefault(c => c.CNPJ == CPFOuCNPJ);

            Vaga vagaCriada = new Vaga(id: Vagarepo.ProximoId(),
                                        statusVaga: StatusVaga.Aberta,
                                        descricao: descricao,
                                        salario: salario,
                                        candidato: null,
                                        empresa: empresa);

            Vagarepo.Insere(vagaCriada);
        }

        private static void AlterarVaga()
        {
            Console.WriteLine("**ALTERAÇÃO DE VAGA**");
            Console.WriteLine("Digite o id da Vaga: ");
            int idVagaAtual = int.Parse(Console.ReadLine());

            Vaga vaga = Vagarepo.RetornaVagaPorId(idVagaAtual);

            if (vaga == null)
            {
                Console.WriteLine("Vaga não localizada.");
                Limpartela();
                return;
            }

            foreach (int i in Enum.GetValues(typeof(StatusVaga)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(StatusVaga), i));
            }

            Console.WriteLine("Digite o status atual da vaga dentre as opções acima: ");
            int status = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Vaga: ");
            string descricao = Console.ReadLine();


            Console.WriteLine("Digite o Salário da Vaga: ");
            double salario = double.Parse(Console.ReadLine());

            //buscar a empresa
            Empresa empresa = listaEmpresas.FirstOrDefault(c => c.CNPJ == CPFOuCNPJ);

            Vaga vagaAtualizada = new Vaga(id: idVagaAtual,
                                        statusVaga: (StatusVaga)status,
                                        descricao: descricao,
                                        salario: salario,
                                        candidato: null,
                                        empresa: empresa);

            Vagarepo.Atualiza(idVagaAtual, vagaAtualizada);
        }


        //MÉTODOS CANDIDATO
        private static void ListarTodasVagas()
        {
            Console.WriteLine("OFERTAS DE VAGAS");
            var lista = Vagarepo.ListarTodasVagas();

            if (lista == null)
            {
                Console.WriteLine("Nenhuma vaga Cadastrada.");
                Limpartela();
                return;
            }

            foreach (var vaga in lista)
            {
                Console.WriteLine("#ID {0} - {1} - {2} - {3}", vaga.Id, vaga.Descricao, vaga.Salario, vaga.StatusVaga);
            }

            Limpartela();
        }

        private static void ListarVagasCandidato()
        {
            
            Console.WriteLine("VAGAS ESCOLHIDAS");
            var lista = Vagarepo.ListarVagasPorCandidato(CPFOuCNPJ);



            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma vaga Cadastrada.");
                Limpartela();
                return;
            }

            foreach (var vaga in lista)
            {
                Console.WriteLine("#ID {0} - {1} - {2} - {3}", vaga.Id, vaga.Descricao, vaga.Salario, vaga.StatusVaga);
            }
            Limpartela();
        }

        private static void PesquisarVaga()
        {
            Console.WriteLine("PESQUISA DE VAGA");
            Console.WriteLine("Digite o id da Vaga: ");
            int idVagaAtual = int.Parse(Console.ReadLine());

            Vaga vaga = Vagarepo.RetornaVagaPorId(idVagaAtual);

            if (vaga== null)
            {
                Console.WriteLine("Vaga não localizada.");
                Limpartela();
                return;
            }

            Console.WriteLine("**DADOS DA VAGA**");
            Console.WriteLine("Descrição: " + vaga.Descricao);
            Console.WriteLine("Salário..: " + vaga.Salario);
            Console.WriteLine("Empresa..: " + vaga.Empresa);
            Console.WriteLine("Status..: " + vaga.StatusVaga);

            Limpartela();
        }

        private static void Candidatar()
        {
            Console.WriteLine("CANDIDATAR-SE A VAGA");
            Console.WriteLine("Digite o id da Vaga: ");
            int idVagaAtual = int.Parse(Console.ReadLine());

            Vaga vaga = Vagarepo.RetornaVagaPorId(idVagaAtual);

            if (vaga == null)
            {
                Console.WriteLine("Vaga não localizada.");
                Limpartela();
                return;
            }

            Console.WriteLine("Descrição: " + vaga.Descricao);
            Console.WriteLine("Salário..: " + vaga.Salario);
            Console.WriteLine("Empresa..: " + vaga.Empresa);
            Console.WriteLine("Status..: " + vaga.StatusVaga);


            if (vaga.StatusVaga == (StatusVaga)1)
            {
                //buscar o candidato
                Candidato candidato = listaCandidatos.FirstOrDefault(c => c.CPF == CPFOuCNPJ);


                Vaga vagaAtualizada = new Vaga(id: idVagaAtual,
                                            statusVaga: StatusVaga.Preenchida,
                                            descricao: vaga.Descricao,
                                            salario: vaga.Salario,
                                            candidato: candidato,
                                            empresa: vaga.Empresa);

                Vagarepo.Atualiza(idVagaAtual, vagaAtualizada);

                Console.WriteLine("Realizado a candidatura para a vaga escolhida com sucesso.");
            }
            else
            {

                Console.WriteLine("Vaga está: " + vaga.StatusVaga + " impossível candidatar-se.");
                return;
            }
        }


        //MÉTODOS AUXILIARES

        private static void PopulaEmpresas()
        {
            Empresa e1 = new Empresa(1, "Avenida", 22, "Pátria Nova", "Prédio", "Novo Hamburgo", "RS", "93459949", "empresa1@gmail.com", "94444-5969", "12.556.202/0001-01", "Vitor e Martin Marketing ME");

            Empresa e2 = new Empresa(2, "Rua Presidente Vargas", 4545, "Jardim Nova", "Apto", "São Leopoldo", "RS", "94444449", "empresa2@gmail.com", "94444-5000", "22.284.152/0001-04", "Guilherme e Nelson Pizzaria Delivery ME");

            listaEmpresas.Add(e1);
            listaEmpresas.Add(e2);
        }

        private static void PopulaCandidatos()
        {
            Candidato c1 = new Candidato(1, "Avenida", 22, "Centro", "Casa", "Porto Alegre", "RS", "93459949", "candidato1@gmail.com", "98794-5969", "456.333.443-33", "Candidato1", new DateTime(2000, 4, 17));

            Candidato c2 = new Candidato(2, "Rua", 33, "Parque Olímpica", "Apto", "Canoas", "RS", "93459949", "candidato2@gmail.com", "99999-5969", "456.333.999-44", "Candidato2", new DateTime(2001, 8, 17));

            listaCandidatos.Add(c1);
            listaCandidatos.Add(c2);
        }
    }
}
