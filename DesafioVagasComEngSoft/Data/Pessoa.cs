using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioVagasComEngSoft
{
    public class Pessoa
    {
        [Key]
        public int pessoaId { get; set; }
        public string nome { get; set; }

        public string profissao { get; set; }
        public string localizacao { get; set; }
        public int nivel { get; set; }

        public DateTime dataInclusao { get; set; }

        public RequestResponse InsertDb()
        {
            var response = new RequestResponse();
            try
            {
                using (var db = new DesafioDbContext())
                {
                    this.dataInclusao = DateTime.Now;
                    if (db.CheckIfPessoaValid(this))
                    {
                        db.Pessoa.Add(this);
                        db.SaveChanges();
                        response.message = "Pessoa cadastrado com successo";
                        response.message += " com Id: ";
                        response.message += this.pessoaId;
                        response.dateInsertion = this.dataInclusao.ToLongDateString();
                    }
                    else
                    {
                        response.message = "Houve um erro de cadastro" + Environment.NewLine;
                        response.message += "Esse item ja existe.";
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = "Houve um erro de cadastro" + Environment.NewLine;
                response.message += ex.Message; 
            }

            return response;
        }

    }
}
