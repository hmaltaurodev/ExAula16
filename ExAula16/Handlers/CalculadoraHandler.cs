using ExAula16.Domain;
using ExAula16.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ExAula16.Handlers
{
    public class CalculadoraHandler
    {
        public IActionResult Handle(Parametros parametros)
        {
            try
            {
                if (parametros.Num2 == 0)
                    throw new DivideByZeroException();

                if (parametros.Operacao == TipoOperacao.Somar)
                {
                    double soma = parametros.Num1 + parametros.Num2;
                    return new OkObjectResult(soma);
                }

                if (parametros.Operacao == TipoOperacao.Subtrair)
                {
                    double subtracao = parametros.Num1 - parametros.Num2;
                    return new OkObjectResult(subtracao);
                }

                if (parametros.Operacao == TipoOperacao.Multiplicar)
                {
                    double multiplicacao = parametros.Num1 * parametros.Num2;
                    return new OkObjectResult(multiplicacao);
                }

                if (parametros.Operacao == TipoOperacao.Dividir)
                {
                    double divisao = parametros.Num1 / parametros.Num2;
                    return new OkObjectResult(divisao);
                }

                throw new ArgumentException("É obrigatório informar a operação!");
            }
            catch (DivideByZeroException ex)
            {
                return new ObjectResult($"Divisão por zero: {ex.Message}")
                    { StatusCode = 500 };
            }
            catch (OverflowException ex)
            {
                return new ObjectResult($"Limite de resultado: {ex.Message}")
                    { StatusCode = 500 };
            }
            catch (ArithmeticException ex)
            {
                return new ObjectResult($"Erro de calculo: {ex.Message}")
                    { StatusCode = 500 };
            }
            catch (Exception ex)
            {
                return new ObjectResult($"Erro geral: {ex.Message}")
                    { StatusCode = 500 };
            }
        }
    }
}
