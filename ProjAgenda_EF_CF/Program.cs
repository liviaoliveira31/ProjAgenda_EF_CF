using ProjAgenda_EF_CF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAgenda_EF_CF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();

            Console.WriteLine("AGENDA DE TELEFONES:");
            Console.WriteLine("1-ADICIONAR CONTATO\n2-LISTAR CONTATOS\n3-EDITAR CONTATOS\n4-BUSCAR CONTATO\n4-DELETAR CONTATO");
            int opc = int.Parse(Console.ReadLine());
            switch(opc)
            {
                case 1:
                    p.inserircontato();
                    break;

                case 2:
                    p.ImprimirTodos();
                    break;
            }
        }
    }
}
