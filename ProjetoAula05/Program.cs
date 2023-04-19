using ProjetoAula05.Entities;
using ProjetoAula05.Repositories;

Console.WriteLine("\n *** CONTROLE DE CLIENTES *** \n");

Console.WriteLine("(1) - INSERIR CLIENTE");
Console.WriteLine("(2) - ALTERAR CLIENTE");
Console.WriteLine("(3) - EXCLUIR CLIENTE");
Console.WriteLine("(4) - CONSULTAR CLIENTES");

Console.Write("\nInforme a opção desejada....: ");
var opcao = int.Parse(Console.ReadLine());

switch (opcao)
{
	case 1:
		try
		{
			Console.WriteLine("\nCADASTRO DE CLIENTE:\n");

			var cliente = new Cliente();
			cliente.Id = Guid.NewGuid();

			Console.Write("INFORME O NOME DO CLIENTE.....: ");
			cliente.Nome = Console.ReadLine();

            Console.Write("INFORME O CPF.................: ");
            cliente.Cpf = Console.ReadLine();

            Console.Write("INFORME A DATA DE NASCIMENTO..: ");
            cliente.DataNascimento = Convert.ToDateTime(Console.ReadLine());

			var clienteRepository = new ClienteRepository();
			clienteRepository.Inserir(cliente);

			Console.WriteLine("\nCLIENTE CADASTRADO COM SUCESSO!");
        }
		catch (Exception e)
		{
			Console.WriteLine("\nErro: " + e.Message);
		}
		break;
    case 2:
        try
        {
            Console.WriteLine("\nATUALIZAÇÃO DE CLIENTE:\n");

            var cliente = new Cliente();
            
            Console.Write("INFORME O ID DO CLIENTE.......: ");
            cliente.Id = Guid.Parse(Console.ReadLine());

            Console.Write("INFORME O NOME DO CLIENTE.....: ");
            cliente.Nome = Console.ReadLine();

            Console.Write("INFORME O CPF.................: ");
            cliente.Cpf = Console.ReadLine();

            Console.Write("INFORME A DATA DE NASCIMENTO..: ");
            cliente.DataNascimento = Convert.ToDateTime(Console.ReadLine());

            var clienteRepository = new ClienteRepository();
            clienteRepository.Alterar(cliente);

            Console.WriteLine("\nCLIENTE ATUALIZADO COM SUCESSO!");
        }
        catch (Exception e)
        {
            Console.WriteLine("\nErro: " + e.Message);
        }
        break;
    case 3:
        try
        {
            Console.WriteLine("\nEXCLUSÃO DE CLIENTE:\n");

            var cliente = new Cliente();

            Console.Write("INFORME O ID DO CLIENTE.......: ");
            cliente.Id = Guid.Parse(Console.ReadLine());
            
            var clienteRepository = new ClienteRepository();
            clienteRepository.Excluir(cliente);

            Console.WriteLine("\nCLIENTE EXCLUÍDO COM SUCESSO!");
        }
        catch (Exception e)
        {
            Console.WriteLine("\nErro: " + e.Message);
        }
        break;
    case 4:
        try
        {
            Console.WriteLine("\nCONSULTA DE CLIENTES:\n");

            var clienteRepository = new ClienteRepository();
            var clientes = clienteRepository.Consultar();

            foreach (var item in clientes)
            {
                Console.WriteLine($"\tID...................: {item.Id}");
                Console.WriteLine($"\tNOME.................: {item.Nome}");
                Console.WriteLine($"\tCPF..................: {item.Cpf}");
                Console.WriteLine($"\tDATA DE NASCIMENTO...: {item.DataNascimento}");             
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("\nErro: " + e.Message);
        }
        break;
    default:
		break;
}

Console.ReadKey();