using System;
using System.Collections.Generic;
//using Mi_Proyeto.Models.Cliente;

namespace Forms.Models
{
    public class DbContext{
        
        public List<Cliente> ListClientes{set;get;}

        public DbContext(){
            ListClientes = new List<Cliente>();
            fillData();
        }
        private void fillData(){
            for(int i=0; i < 20; i++ ){
            Cliente cli = new Cliente();
            cli.Id = i;
            cli.Nombre = "Sarah "+i;
            cli.Email = "sarah@sorftweb.com";
            cli.Telefono = i+420;
            cli.Sexo="Femenino";
            ListClientes.Add(cli);
            }
        }
    }
}