using ControleBancario.Entities;

namespace ControleBancario
{
    class Program
    {
        static void Main(string[] args)
        {
        
            MenuContas menu = new MenuContas();

            menu.executar();
            
        }
    }
}
