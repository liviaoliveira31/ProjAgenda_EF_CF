using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAgenda_EF_CF.Models
{
    internal class Telephone
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }

        public override string ToString()
        {
            return $"Telefone: {this.Phone}\nCelular: {this.Mobile}";
        }
    }
}
