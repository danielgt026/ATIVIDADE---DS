﻿using System;

class Program
{
    static Boolean on = true;

    static Boolean DetalharData()
    {
        Console.Write("Digite uma data no formato DD/MM/AAAA \n");
        string dataStr = Console.ReadLine();

        if (DateTime.TryParseExact(dataStr, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime data))
        {
            string diaDaSemana = data.ToString("dddd");
            string nomeMes = data.ToString("MMMM");
            Console.WriteLine($"/============================");
            Console.WriteLine($"| Dia da semana: {diaDaSemana}");
            Console.WriteLine($"| Mês: {nomeMes}.");
            Console.WriteLine($"\\============================");

            // if (data.DayOfWeek == DayOfWeek.Sunday)
            // {
                string horaAtual = DateTime.Now.ToString("HH:mm");
                Console.WriteLine($"Hora atual: {horaAtual}\n");
            // }
        }
        else
        {
            Console.WriteLine("Data inválida. Por favor, digite novamente.");
            return true;
        }
        return false;
    }

    static Boolean CalcularDescontoINSS()
    {
        Console.Write("Digite o valor do salário: ");
        double salario;
        if (!double.TryParse(Console.ReadLine(), out salario))
        {
            Console.WriteLine("Valor inválido. Por favor, digite novamente.");
            return true;
        }

        double inss = 0;

        if (salario <= 1212)
        {
            inss = salario * 0.075;
        }
        else if (salario <= 2427.35)
        {
            inss = salario * 0.09;
        }
        else if (salario <= 3641.03)
        {
            inss = salario * 0.12;
        }
        else
        {
            inss = salario * 0.14;
        }

        double salarioDescontado = salario - inss;
        Console.WriteLine($"Valor do INSS a ser pago: R$ {inss:F2}");
        Console.WriteLine($"Salário líquido após desconto do INSS: R$ {salarioDescontado:F2}\n");
        return false;
    }

    static void Main(string[] args)
    {

        while(on) {
            Console.WriteLine("\nEscolha uma opção:");
            Console.WriteLine("1. Detalhar Data");
            Console.WriteLine("2. Calcular Desconto INSS");
            Console.WriteLine("3. Sair\n");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    on = DetalharData();
                    break;
                case "2":
                    on = CalcularDescontoINSS();
                    break;
                case "3":
                    Console.WriteLine("Saindo do programa.");
                    on = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
}
