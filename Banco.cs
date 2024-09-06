using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LH_Pets 
{
   
   public class Banco 
   {
     
     public Banco()
     {
        try
        {
            SqlConnetcionStringBuilder builder = new SqlConnetcionStringBuilder(
                "Intregated Security = true;" +
                "Server=" +
                "DataBase=vendas;" +
                "Trusted_Connection=true;"
            );
            
            using (SqlConnetcion conn = new SqlConnetcion(builder.ConnectionString))
            {
              string sql = "SELECT * FROM tblclientes";
              using (SqlCommand cmd = new SqlCommand(sql, conn))
              {
                conn.Open();
                using (SqlDataReader tabela = cmd.ExecuteReader())
                {
                   while (tabela.Read())
                   {
                     lista.Add(new CLiente(){
                        cpf_cnpj = tabela ["cpf_cnpj"].ToString(),
                        nome = tabela ["nome"].ToString(),
                        endereco = tabela ["endereco"].ToString(),
                        rg_ie = tabela ["rg_ie"].ToString(),
                        tipo = Convert.ToChar(tabela["tipo"]),
                        valor = (float) Convert.ToDecimal(tabela["valor"]),
                        valor_imposto = (float) Convert.ToDecimal(tabela["valor_imposto"]),
                        total = (float) Convert.ToDecimal(tabela["total"]),      
                     });
                   }
                }

                
              }
            }

        }

        catch (Exception ex)
        {
              
            Console.WriteLine(ex.ToString());
        
        }
     }

     private List<Cliente> lista = new List<Cliente>();

     public List<Cliente> GetLista()
     {
        return lista;
     }
     
      public string GetListaString() 
      {
        string enviar = "<!DCOCTYPE html>\n<html>\n<head>\n<meta charset='utf-8'/>\n" +
                        "<title>Cadastro de Cliente</title>\n" +
                        "<style><table {border-spacing: 0; border-collapse: collapse;} th, td{border: 1px solid b;}>" +
                        "</head>\n<body>" +
                        "<h1>Lista de Cliente</h1>" +
                        "<table><thead><tr>" +
                        "<th>CPF/CNPJ</th>" +
                        "<th>Nome</th>" +
                        "<th>Endereço</th>" +
                        "<th>RG/IE</th>" +
                        "<th>Tipo</th>" +
                        "<th>Valor</th>" +
                        "<th>Valor Imposto</th>" +
                        "<th>Total</th>" +
                    "</thead><tbody>";

        foreach (Cliente cli in GetLista ())
           {
              enviar += "<ctr>" + 
                      $"<td>{cli.cpf_cnpj}</td>" +
                      $"<td>{cli.nome}</td>" +
                      $"<td>{cli.endereco}</td>" +
                      $"<td>{cli.rg_ie}</td>" +    
                      $"<td>{cli.tipo}</td>" +
                      $"<td>{cli.valor.ToString("C")}</td>" +
                      $"<td>{cli.valor_imposto.ToString("C")}</td>" +
                      $"<td>{cli.totaç.ToString("C")}</td>" +
                    "<c/tr>";
            
           }

            enviar += "</tbody><table><body></html>";
            return enviar; 

        } 

     }

}