using EstacionamentoProjeto.Models;
using System.Text.RegularExpressions;

Console.OutputEncoding = System.Text.Encoding.UTF8;


Console.WriteLine("BEM VINDO!\n" + "DIGITE O VALOR INICIAL R$:");
decimal precoInicial = Convert.ToDecimal(Console.ReadLine());

Console.WriteLine("AGORA, DIGITE O VALOR DA HORA R$:");
decimal precoHora = Convert.ToDecimal(Console.ReadLine());




Estacionamento est = new Estacionamento(precoInicial, precoHora);


bool showMenu = true;

while(showMenu) {
    Console.Clear();
    Console.WriteLine("DIGITE UMA OPÇÃO:");
    Console.WriteLine("1 - CADASTRAR VEICULO");
    Console.WriteLine("2 - LISTAR VEICULO");
    Console.WriteLine("3 - REMOVER VEICULO");
    Console.WriteLine("4 - FINALIZAR");

    switch(Console.ReadLine()) {
        case "1":
            est.AppendVehicles();
            break;
        
        case "2":
            est.ListVehicle();
            break;
        
        case "3":
            est.RemoveVehicle();
            break;
        
        case "4":
            showMenu = false;
            break;

        default:
            Console.WriteLine("OPÇÃO INVÁLIDA!");
            break;
    }

    Console.WriteLine("PRESSIONE UMA TECLA PARA CONTINUAR.");
    Console.ReadLine();
}
