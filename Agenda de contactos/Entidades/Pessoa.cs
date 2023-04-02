using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_de_contactos.Entidades
{
    public class Pessoa
    {

        private static int NextId = 1;
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public int Fone { get; set; }
        public int Celular { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }
        public string Endereco { get; set; }
        public string Notas { get; set; }


        public Pessoa(string nome, string sobreNome, int fone, int celular, string email, string web, string endereco, string notas)
        {
            Id = NextId;
            NextId++;
            Nome = nome;
            SobreNome = sobreNome;
            Fone = fone;
            Celular = celular;
            Email = email;
            Web = web;
            Endereco = endereco;
            Notas = notas;

        }



    }
}
