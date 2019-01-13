using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioVagasComEngSoft
{
    public class CandidatureResult
    {
        public string nome { get; set; }

        public string profissao { get; set; }
        public string localizacao { get; set; }
        public int nivel { get; set; }

        public decimal score { get; set; }

        public CandidatureResult()
        {

        }

        public CandidatureResult(Pessoa p, Vaga v)
        {
            this.nome = p.nome;
            this.localizacao = p.localizacao;
            this.profissao = p.profissao;
            this.nivel = p.nivel;
            this.score = new Logic().CalculOfScore(this.localizacao, v.localizacao, v.nivel, this.nivel);
        }

        public List<CandidatureResult> Ranking (int idVaga)
        {
            var ranking = new List<CandidatureResult>();
            using (var db = new DesafioDbContext())
            {
                List<Candidatura> listCand = db.Candidatura.Where(c => c.id_vaga == idVaga).ToList();
                var vag = db.Vaga.FirstOrDefault(p => p.vagaId == idVaga);
                foreach (var can in listCand)
                {
                    var pers = db.Pessoa.FirstOrDefault(p => p.pessoaId == can.id_pessoa);
                    var resultCand = new CandidatureResult(pers, vag);
                    ranking.Add(resultCand);
                }
            }

            return ranking.OrderByDescending(c => c.score).ToList();
        }
    }
}
