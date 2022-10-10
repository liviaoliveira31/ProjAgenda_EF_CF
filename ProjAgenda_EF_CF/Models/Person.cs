using ProjAgenda_EF_CF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAgenda_EF_CF.Models
{
    internal class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
       
        public override string ToString()
        {
            return $"Id: {this.Id}\nNome: {this.Name}\nEmail: {this.Email}\n\n";
        }

        public void inserircontato()
        {
            using (var context = new PersonContext()) //criando var context que vai criar um novo obj do personcontext
            {
                Person p = new Person();
                Telephone tp = new Telephone();
                Console.WriteLine("Insira o nome:");
                p.Name = Console.ReadLine();
                Console.WriteLine("Insira o Email");
                p.Email = Console.ReadLine();
                Console.WriteLine("Insira o Telefone residencial");
                tp.Phone = Console.ReadLine();
                Console.WriteLine("Insira o numero do celular");
                tp.Mobile = Console.ReadLine();

                context.Persons.Add(p);
                context.Telephone.Add(tp);
                context.SaveChanges();
            }
        }

        public void ImprimirTodos()
        {
            var person = new PersonContext().Persons.ToList(); 
            foreach (var item in person)
            {
                Console.WriteLine(item.ToString());
                Telephone t = new Telephone();
                Person p = new Person();
                Telephone find = new PersonContext().Telephone.FirstOrDefault(pl => p.Id == t.Id);
               Console.WriteLine(find.ToString());
            }
            Console.ReadKey();
        }
    }
}
