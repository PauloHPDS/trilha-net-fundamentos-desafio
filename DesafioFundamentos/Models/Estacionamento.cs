using System.Text.RegularExpressions;
namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private string modeloPlaca = @"^.{3}-.{4}$";
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos" 
            // Feito!
            // Modelo de placa e verificação implementado
            Console.Clear();
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            Console.WriteLine("Digite no Formato: X1B-2C5Y");
            string placa = Console.ReadLine().ToUpper();
            bool repetido = false;
            if(Regex.IsMatch(placa,modeloPlaca)){
                for(int i=0;i<veiculos.Count;i++){
                    if (placa==veiculos[i]){
                        repetido = true;
                    }
                }
                if (!repetido){
                    veiculos.Add(placa);
                }else{
                    Console.WriteLine("O veiculo já se encontra no estacionamento!");
                }
                
            }else{
                Console.WriteLine("Modelo não suportado!");
            }
            Console.WriteLine("Adicionar mais um veiculo?");
            Console.WriteLine("1 - Sim \n2 - Não");
            if (Console.ReadLine()=="1"){
                AdicionarVeiculo();
            }
        }

        public void RemoverVeiculo(){
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // Feito!
            string placa = Console.ReadLine().ToUpper();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                // Feito!
                int horas= int.Parse(Console.ReadLine());
                decimal valorTotal = precoInicial+(precoPorHora*horas); 
                

                // TODO: Remover a placa digitada da lista de veículos
                // Feito!
                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }else{
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any()){
                Console.WriteLine("===============================");
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // Feito!
                foreach (var item in veiculos){
                    Console.WriteLine($"Veiculo: {item}");
                }
                Console.WriteLine("===============================");
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
