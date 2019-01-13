using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DesafioVagasComEngSoft.Controllers
{
    public class DesafioApiController : ApiController
    {

        /// <summary>
        /// Method Get de Ranking por vaga
        /// </summary>
        /// <param name="id"> Id da vaga</param>
        /// <returns>Lista ordena por score de pessoas por vaga.</returns>
        [HttpGet]
        [Route("v1/vagas/{id}/candidaturas/ranking")]
        public List<CandidatureResult> Ranking(int id)
        {
            return new CandidatureResult().Ranking(id);
        }

        /// <summary>
        /// Salva os dados de um candidato
        /// </summary>
        /// <param name="p">Objeto pessoa</param>
        /// <returns>Response</returns>
        [HttpPost]
        [Route("v1/pessoas")]
        public RequestResponse SalvarPessoa([FromBody]Pessoa p)
        {
            return p.InsertDb();
        }

        /// <summary>
        /// Selva uma vaga
        /// </summary>
        /// <param name="v">objeto vaga</param>
        /// <returns><Response/returns>
        [HttpPost]
        [Route("v1/vagas")]
        public RequestResponse SalvarVaga([FromBody]Vaga v)
        {
            return v.InsertDb();
        }

        /// <summary>
        /// Salva uma candidatura
        /// </summary>
        /// <param name="c">Objeto candidatura</param>
        /// <returns>Response</returns>
        [HttpPost]
        [Route("v1/candidaturas")]
        public RequestResponse SalvarCandidatura([FromBody]Candidatura c)
        {
            return c.InsertDb();
        }
    }
}