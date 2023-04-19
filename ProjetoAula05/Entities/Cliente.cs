using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjetoAula05.Entities
{
    /// <summary>
    /// Modelo de dados para a entidade Cliente
    /// </summary>
    public class Cliente
    {
        #region Atributos

        private Guid _id;
        private string? _nome;
        private string? _cpf;
        private DateTime _dataNascimento;

        #endregion

        #region Propriedades

        public Guid Id 
        { 
            get => _id;
            set
            { 
                if (value == Guid.Empty)
                    throw new ArgumentException("O id do cliente é obrigatório.");
            
                _id = value;
            }  
        }
        public string? Nome
        { 
            get => _nome; 
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("O nome do cliente é obrigatório.");

                var regex = new Regex("^[A-Za-zÀ-Ü-à-ü\\s]{6,100}$");
                if (!regex.IsMatch(value))
                    throw new ArgumentException("Informe um nome válido de 6 a 100 caracteres.");

                _nome = value;
            } 
        }
        public string? Cpf 
        { 
            get => _cpf; 
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("O CPF do cliente é obrigatório.");

                var regex = new Regex("^[0-9]{11}$");
                if (!regex.IsMatch(value))
                    throw new ArgumentException("Informe um CPF com 11 dígitos numéricos.");
            
                _cpf = value;
            } 
        }
        public DateTime DataNascimento 
        { 
            get => _dataNascimento; 
            set
            {
                var dataAtual = DateTime.Now;
                var dataNascimento = value;

                var idade = dataAtual.Year - dataNascimento.Year;
                if (dataNascimento.DayOfYear > dataAtual.DayOfYear)
                    idade--;

                if (idade < 18)
                    throw new ArgumentException("O cliente deve ser maior de idade (18 anos).");
            
                _dataNascimento = value;
            } 
        }

        #endregion
    }
}
