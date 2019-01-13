using System.Data.Entity;
using System.Linq;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DesafioVagasComEngSoft
{
    public class DesafioDbContext : DbContext
    {
        public DbSet<Vaga> Vaga { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Candidatura>  Candidatura { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public bool CheckIfVagaValid(Vaga v)
        {
            return !Vaga.Any(o => (o.descricao == v.descricao && o.empresa == v.empresa));
        }


        public bool CheckIfPessoaValid(Pessoa p)
        {
            return !Pessoa.Any(o => (o.nome == p.nome && o.localizacao == p.localizacao));
        }


        public bool CheckIfCandidaturaValid(Candidatura c)
        {
            if (!Vaga.Any(o=>o.vagaId == c.id_vaga))
            {
                return false;
            }
            if (!Pessoa.Any(o => o.pessoaId == c.id_pessoa))
            {
                return false;
            }
            if (Candidatura.Any(o=> o.id_pessoa == c.id_pessoa  && o.id_vaga == c.id_vaga))
            {
                return false;
            }

            return true;
        }
    }
}
