using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova_Martin_2periodo
{
    class Cliente
    {
        public String Nome { get; set; }
        public DateTime Data { get; set; }
        public float Nota { get; set; }

        public Cliente(string Nome, DateTime Data, float Nota)
        {
            this.Nome = Nome;
            this.Data = Data;
            this.Nota = Nota;
        }

        public void Editar(string Nome, DateTime Data, float Nota)
        {
            this.Nome = Nome;
            this.Data = Data;
            this.Nota = Nota;
        }
    }
}
