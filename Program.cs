using Calculadora_de_Notas_POO.Services;
using Calculadora_de_Notas_POO.Services.MateriaServices;
using Calculadora_de_Notas_POO.Repositories.MateriaRepositories;
using Calculadora_de_Notas_POO.Repositories.NotaRepositories;
using Calculadora_de_Notas_POO.Services.NotaServices;

    internal class Program
    {
        private static void Main(string[] args)
        {
            IMateriaRepository materiaRepository = new MateriaRepository();
            INotaRepository notaRepository = new NotaRepository();

            IMateriaServices materiaServices = new MateriaService(materiaRepository);
            INotaServices notaServices = new NotaService(notaRepository);

            var menuService = new MenuService(notaServices, materiaServices);
        
            menuService.runMenu();
        }
    }