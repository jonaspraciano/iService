using iService.Data;
using iService.Models;
using iService.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.VisualBasic;

namespace iService
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        private static void CreateCollaborator()
        {
            using var context = new iServiceDataContext();
            Console.WriteLine("Insira o nome do novo colaborador: ");
            string? name = Console.ReadLine();
            Console.WriteLine("Insira o número de telefone do colaborador: ");
            string? telephone = Console.ReadLine();
            Console.WriteLine("Insira a Id da função do colaborador.");
            Console.WriteLine("1 - Professor");
            Console.WriteLine("2 - Recepcionista");
            Console.WriteLine("3 - Estagiário de Professor");
            Console.WriteLine("4 - Professor Líder");
            Console.WriteLine("5 - Supervisor");
            Console.WriteLine("Digite o Id da Função ");
            int id = int.Parse(Console.ReadLine());
            var functionId = context.Functions.FirstOrDefault(x => x.Id == id);
            Console.WriteLine("Insira o salário: ");
            float salary = float.Parse(Console.ReadLine());
            Console.WriteLine("Insira o Id do setor do trabalho.");
            Console.WriteLine("1 - Musculação");
            Console.WriteLine("2 - Recepção");
            Console.WriteLine("3 - Gerência");
            Console.WriteLine("Digite o Id da Função ");
            id = int.Parse(Console.ReadLine());
            var sectorId = context.Sectors.FirstOrDefault(x => x.Id == id);
            var collaborator = new Collaborator
            {
                Name = name,
                Telephone = telephone,
                FunctionId = functionId,
                Salary = salary,
                SectorId = sectorId
            };
            context.Collaborators.Add(collaborator);
            context.SaveChanges(); 
            Menu();
        }
        // private static void CreateCollaborator(Repository<Collaborator> repository)
        // {
        //     Console.WriteLine("Insira o nome do novo colaborador: ");
        //     string? name = Console.ReadLine();
        //     Console.WriteLine("Insira o número de telefone do colaborador: ");
        //     string? telephone = Console.ReadLine();
        //     Console.WriteLine("Insira a Id da função do colaborador: ");
        //     int functionId = int.Parse(Console.ReadLine());
        //     Console.WriteLine("Insira o salário: ");
        //     float salary = float.Parse(Console.ReadLine());
        //     Console.WriteLine("Insira o Id do setor de trabalho: ");
        //     int sectorId = int.Parse(Console.ReadLine());
        //     var collaborator = new Collaborator
        //     {
        //         Name = name,
        //         Telephone = telephone,
        //         FunctionId = functionId,
        //         Salary = salary,
        //         SectorId = sectorId
        //     };
        //     repository.Create(collaborator);    
        //     Menu();
        // }
        // private static void InputFunction()
        // {
        //     Console.WriteLine("Insira a Id da função do colaborador.");
        //     Console.WriteLine("1 - Professor");
        //     Console.WriteLine("2 - Recepcionista");
        //     Console.WriteLine("3 - Estagiário de Professor");
        //     Console.WriteLine("4 - Professor Líder");
        //     Console.WriteLine("5 - Supervisor");
        //     Console.WriteLine("Digite o Id da Função ");
        //     int id = int.Parse(Console.ReadLine());
        //     using var context = new iServiceDataContext();
        //     var functionId = context.Functions.FirstOrDefault(x => x.Id == id);
        // }
        // private static void InputSector()
        // {
        //     Console.WriteLine("Insira o Id do setor do trabalho.");
        //     Console.WriteLine("1 - Musculação");
        //     Console.WriteLine("2 - Recepção");
        //     Console.WriteLine("3 - Gerência");
        //     Console.WriteLine("Digite o Id da Função ");
        //     int id = int.Parse(Console.ReadLine());
        //     using var context = new iServiceDataContext();
        //     var sectorId = context.Sectors.FirstOrDefault(x => x.Id == id);
        // }
        private static void ReadCollaborators()
        {
            using var context = new iServiceDataContext();
            var collaborattors = context
                .Collaborators
                .AsNoTracking()
                .Include(x => x.Id)
                .Include(x => x.Name)
                .Include(x => x.Telephone)
                .Include(x => x.FunctionId)
                .Include(x => x.Salary)
                .Include(x => x.SectorId)
                .ToList();
            foreach (var collaborator in collaborattors)
                Console.WriteLine();
            Menu();
        }
        private static void ReadCollaborator()
        {
            Console.WriteLine("Digite o Id do colaborador: ");
            int id = int.Parse(Console.ReadLine());
            using var context = new iServiceDataContext();
            var collaborator = context.Collaborators.FirstOrDefault(x => x.Id == id);
            // var collaborattor = context
            //     .Collaborators
            //     .AsNoTracking()
            //     .Include(x => x.Id)
            //     .Include(x => x.Name)
            //     .Include(x => x.Telephone)
            //     .Include(x => x.FunctionId)
            //     .Include(x => x.Salary)
            //     .Include(x => x.SectorId)
            //     .FirstOrDefault(option);
            Console.WriteLine($"ID: {collaborator.Id}");
            Console.WriteLine($"Nome: {collaborator.Name}");
            Console.WriteLine($"Telefone: {collaborator.Telephone}");
            Console.WriteLine($"ID da Função: {collaborator.FunctionId}");
            Console.WriteLine($"Salário: {collaborator.Salary}");
            Console.WriteLine($"ID do Setor: {collaborator.SectorId}");
            Console.WriteLine("\nDigite uma tecla para continuar.");
            Console.ReadLine();
            Menu();
        }
        private static void UpdateCollaborator()
        {
            Console.WriteLine("Digite o Id do colaborador: ");
            int id = int.Parse(Console.ReadLine());
            using var context = new iServiceDataContext();
            var collaborator = context.Collaborators.FirstOrDefault(x => x.Id == id);
            Console.WriteLine("Insira o que deve ser alterado: ");
            Console.WriteLine("1 - Nome.");
            Console.WriteLine("2 - Telefone.");
            Console.WriteLine("3 - ID da função.");
            Console.WriteLine("4 - Salário.");
            Console.WriteLine("5 - ID do setor.");
            int option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1: Console.WriteLine("Digite o novo nome.");
                   var name = Console.ReadLine();
                   collaborator.Name = name;
                   context.Update(collaborator); break;
                case 2: Console.WriteLine("Digite o novo telefone.");
                   var telephone = Console.ReadLine();
                   collaborator.Telephone = telephone;
                   context.Update(collaborator); break;
                case 3: Console.WriteLine("Digite o novo ID da função.");
                        id = int.Parse(Console.ReadLine());
                        var functionId = context.Functions.FirstOrDefault(x => x.Id == id);
                   collaborator.FunctionId = functionId;
                   context.Update(collaborator); break;
                case 4: Console.WriteLine("Digite o novo salário.");
                   var salary = float.Parse(Console.ReadLine());
                   collaborator.Salary = salary;
                   context.Update(collaborator); break;
                case 5: Console.WriteLine("Digite o novo nome.");
                   id = int.Parse(Console.ReadLine());
                   var sectorId = context.Sectors.FirstOrDefault(x => x.Id == id);
                   collaborator.SectorId = sectorId;
                   context.Update(collaborator); break;
                default:
                   Console.WriteLine("Digito inválido.");
                   Thread.Sleep(2000);
                   UpdateCollaborator(); break;
            }
            context.SaveChanges();
            Menu();               
        }
        private static void DeleteCollaborator()
        {
            Console.WriteLine("Digite o Id do colaborador: ");
            int id = int.Parse(Console.ReadLine());
            using var context = new iServiceDataContext();
            var collaborator = context.Collaborators.FirstOrDefault(x => x.Id == id);
            context.Remove(collaborator);
            context.SaveChanges();
            Menu();
        }
        static void Menu()
        {
            Console.WriteLine("Programa de gerenciamento de Colaboradores.");
            Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine("Digite a opção.");
            Console.WriteLine("1 - Adicionar um novo colaborador.");
            Console.WriteLine("2 - Procurar um colaborador já existente.");
            Console.WriteLine("3 - Atualizar um cadastro já existente.");
            Console.WriteLine("4 - Deletar um registro.");
            Console.WriteLine("5 - Sair.");
            int option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1: CreateCollaborator(); break;
                case 2: ReadCollaborator(); break;
                case 3: UpdateCollaborator(); break;
                case 4: DeleteCollaborator(); break;
                case 5: System.Environment.Exit(0); break;
                default: Console.WriteLine("Digito inválido."); Menu(); break;
            }        
        }
    }
}