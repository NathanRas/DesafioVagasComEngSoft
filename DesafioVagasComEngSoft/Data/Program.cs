
namespace EntityFMProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Vaga v = new Vaga()
            {
                empresa = "Empresa4",
                titulo = "Vaga1",
                descricao = "DescVaga1",
                localizacao = "F",
                nivel = 4
            };

            Pessoa p = new Pessoa()
            {
                nome = "Pessoa8",
                profissao = "Engenheiro2",
                localizacao = "B",
                nivel = 3
            };

            p.InsertDb();
            v.InsertDb();

            var cand = new Candidatura();
            cand.id_pessoa = p.pessoaId;
            cand.id_vaga = 3;

            cand.InsertDb();

            var pessoa = new CandidatureResult().Ranking(3);
        }
    }
}
