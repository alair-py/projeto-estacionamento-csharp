using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace EstacionamentoProjeto.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoHora = 0;
        private List<string> veiculos = new List<string>();


        public Estacionamento(decimal precoInicial, decimal precoHora) {
            this.precoInicial = precoInicial;
            this.precoHora = precoHora;
        }

        public void AppendVehicles() {
            Console.WriteLine("DIGITE A PLACA DO VEÍCULO PARA CADASTRO:");

            string placa = Console.ReadLine().ToUpper();

            if(string.IsNullOrEmpty(placa)) {
                Console.WriteLine("ERRO: VALOR NULOS NÃO SÃO ACEITOS.");
            }
            else if(placa.Length != 8 && placa.Length != 7) {
                Console.WriteLine("ERRO: NÚMERO DE CARACTERES INVÁLIDO.");
            }
            else {
                placa = placa.Replace("-", "").Trim();

                var placaFormatada = new Regex("[A-Z]{3}[0-9]{1}[A-Z\0-9]{1}[0-9]{2}");

                if(placaFormatada.IsMatch(placa)) {
                    veiculos.Add(placa);
                }
                else {
                    Console.WriteLine("ERRO: PADRÃO INFORMADO INVÁLIDO.");
                }

            }
        }

        public void RemoveVehicle() {
            Console.WriteLine("DIGITE A PLACA DO VEÍCULO PARA REMOVER:");

            string placa = Console.ReadLine().ToUpper();

            if(veiculos.Any(x => x == placa)) {
                Console.WriteLine("QUANTAS HORAS FICOU ESTACIONADO:");

                decimal qtdHoras = Convert.ToDecimal(Console.ReadLine());

                veiculos.Remove(placa);

                Console.WriteLine($"VEÍCULO DE PLACA {placa} REMOVIDO COM SUCESSO! TOTAL: R${this.precoInicial + (this.precoHora * qtdHoras)}");

            }
            else {
                Console.WriteLine("DESCULPE! VEÍCULO NÃO ENCONTRADO.");
            }
        }

        public void ListVehicle() {
            if(veiculos.Any()) {
                for (int c = 0; c < veiculos.Count(); c++)
                {
                    Console.WriteLine($"VEICULO {c} - PLACA: {veiculos[c]}");
                }
            }
            else {
                Console.WriteLine("NÃO EXISTE VEÍCULOS CADASTRADOS!");
            }
        }

    }
}