using ProjAgenda_EF_CF.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public void Pause()
        {
            Console.WriteLine("Pressione enter para continuar...");
            Console.ReadKey();
        }
        public override string ToString()
        {
            return $"Id: {this.Id}\nNome: {this.Name}\nEmail: {this.Email}";
        }

        #region INSERT
        public void InsertContact()
        {
            using (var context = new PersonContext()) //criando var context que vai criar um novo obj do personcontext
            {
                Person p = new Person();
                Telephone tp = new Telephone();
                Console.WriteLine("Insira o nome:");
                p.Name = Console.ReadLine();
                Person find = new PersonContext().Persons.FirstOrDefault(f => f.Name == p.Name);
                while (find != null) 
                {
                    Console.WriteLine("Hum... Parece que esse nome ja foi utilizado. Por favor, insira um diferente");
                    p.Name = Console.ReadLine();
                    find = new PersonContext().Persons.FirstOrDefault(f => f.Name == p.Name);
                }
                Console.WriteLine("Insira o Email");
                p.Email = Console.ReadLine();
                Console.WriteLine("Insira o Telefone residencial");
                tp.Phone = Console.ReadLine();
                Console.WriteLine("Insira o numero do celular");
                tp.Mobile = Console.ReadLine();

                context.Persons.Add(p);
                context.Telephone.Add(tp);
                context.SaveChanges();
                Console.WriteLine("Contato inserido na agenda com sucesso");
            }
            Pause();
        }
        #endregion

        #region SELECT ALL
        public void SelectAll()
        {
            Console.Clear();
            var person = new PersonContext().Persons.ToList();
            foreach (var item in person)
            {
                Console.WriteLine(item.ToString());
                Telephone t = new Telephone();
                Person p = new Person();
                Telephone achar = new PersonContext().Telephone.First(ac => ac.Id == item.Id);
                Console.WriteLine(achar.ToString());
            }
            Pause();
        }
        #endregion

        #region SELECT ONE
        public void SelectOne()
        {
            Person p = new Person();
            Telephone t = new Telephone();
            Console.WriteLine("Insira o ID do contato que deseja localizar");
            int id = int.Parse(Console.ReadLine());
            Person find = new PersonContext().Persons.FirstOrDefault(f => f.Id == id);
            if (find != null)
            {
                Console.WriteLine(find.ToString());
                Telephone achar = new PersonContext().Telephone.First(ac => ac.Id == id);
                Console.WriteLine(achar.ToString());

            }
            else

                Console.WriteLine("Contato não encontrado...");

            Pause();

        }
        #endregion

        #region UPDATE
        public void UpdateContact()
        {
            Person p = new Person();
            Telephone t = new Telephone();
            using (var context = new PersonContext())
            {
                Console.Clear();
                Console.WriteLine("Insira o ID do contato que deseja editar");
                int id = int.Parse(Console.ReadLine());
                Person find = new PersonContext().Persons.FirstOrDefault(f => f.Id == id);

                if (find != null)
                {
                    Console.WriteLine(find.ToString());
                    Telephone achar = new PersonContext().Telephone.First(ac => ac.Id == id);
                    Console.WriteLine(achar.ToString());


                    Console.WriteLine("Qual dado deseja editar:\n1-Nome\n2-Telefone Residencial\n3-Celular");
                    int opc = int.Parse(Console.ReadLine());
                    #region UPDATE NOME
                    if (opc == 1)
                    {
                        Console.WriteLine("Insira o novo nome");
                        string n = Console.ReadLine();
                        find.Name = n;
                        context.Entry(find).State = EntityState.Modified;
                        context.SaveChanges();
                        Console.WriteLine("Nome editado com sucesso!");
                        Console.WriteLine(find.ToString());
                        Console.WriteLine(achar.ToString());
                    }
                    #endregion

                    #region UPDATE TELEFONE
                    if (opc == 2)
                    {
                        Console.WriteLine("Insira o novo Telefone");
                        string tel = Console.ReadLine();
                        achar.Phone = tel;
                        context.Entry(achar).State = EntityState.Modified;
                        context.SaveChanges();
                        Console.WriteLine("Telefone editado com sucesso!");
                        Console.WriteLine(find.ToString());
                        Console.WriteLine(achar.ToString());
                    }
                    #endregion

                    #region UPDATE CELULAR
                    if (opc == 2)
                    {
                        Console.WriteLine("Insira o novo Celular");
                        string cel = Console.ReadLine();
                        achar.Mobile = cel;
                        context.Entry(achar).State = EntityState.Modified;
                        context.SaveChanges();
                        Console.WriteLine("Celular editado com sucesso!");
                        Console.WriteLine(find.ToString());
                        Console.WriteLine(achar.ToString());
                    }
                    #endregion
                }
                else
                    Console.WriteLine("Registro não encontrado");

            }
            Pause();

        }
        #endregion

        #region DELETE
        public void DeleteContact()
        {
            using (var context = new PersonContext())
            {
                Telephone t = new Telephone();
                Person p = new Person();
                Console.WriteLine("Insira o id do contato que deseja deletar");
                int id = int.Parse(Console.ReadLine());
                Person find = new PersonContext().Persons.FirstOrDefault(f => f.Id == id);

                if (find != null)
                {
                    Console.WriteLine(find.ToString());
                    Telephone achar = new PersonContext().Telephone.First(ac => ac.Id == id);
                    Console.WriteLine(achar.ToString());


                    Console.WriteLine("DESEJA DELETAR ESSE CONTATO? [S/N]");
                    string resp = Console.ReadLine().ToUpper();
                    if (resp == "S")
                    {
                        context.Entry(find).State = EntityState.Deleted;
                        context.Entry(achar).State = EntityState.Deleted;
                        context.Persons.Remove(find);
                        context.Telephone.Remove(achar);
                        context.SaveChanges();
                        Console.WriteLine("Contato deletado da sua agenda");
                    }
                    else
                        if (resp == "N")
                        Console.WriteLine("OPERAÇÃO CANCELADA");
                }
                Pause();
            }
        }

        #endregion
    }
}
