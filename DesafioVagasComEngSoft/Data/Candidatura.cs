using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioVagasComEngSoft
{
    public class Candidatura
    {
        [Key]
        public int CanditaturaId { get; set; }
        public int id_pessoa { get; set; }
        public int id_vaga { get; set; }

        [ForeignKey("id_vaga")]
        public virtual Vaga vaga { get; set; }

        [ForeignKey("id_pessoa")]
        public virtual Pessoa pessoa { get; set; }

        public DateTime dataCandidatura { get; set; }

        public RequestResponse InsertDb()
        {
            var response = new RequestResponse();
            try
            {
                using (var db = new DesafioDbContext())
                {
                    this.dataCandidatura = DateTime.Now;
                    if (db.CheckIfCandidaturaValid(this))
                    {
                        db.Candidatura.Add(this);
                        db.SaveChanges();
                        response.message = "Candidatura cadastrado com successo";
                        response.message += " com Id: ";
                        response.message += this.CanditaturaId;
                        response.dateInsertion = this.dataCandidatura.ToLongDateString();
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

