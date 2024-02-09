using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VSComMariaDB.Model;

namespace VSComMariaDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        /// <summary>
        /// Pegar a lista de todas as pessoas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Pessoa> GetLista() 
        { 
            var _dbContext = new _DbContext();
            var vLista = _dbContext.Pessoa.ToList();

            return vLista;
        }

        /// <summary>
        /// Pegar os dados de uma pessoa especifica
        /// </summary>
        /// <param name="id"> Id da pessoa </param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Pessoa GetPessoa(int id)
        {
            //Instancia o banco de dados
            var _dbContext = new _DbContext();

            //Selicionar a Pessoa pelo Id
            var vPessoa = _dbContext.Pessoa
                .Where(p => p.Id == id)
                .FirstOrDefault();

            //var vPessoa = _dbContext.Pessoa.Find(id);

            //Retornar dos dados
            return vPessoa;
        }

        [HttpPost]
        public Pessoa Inserir(Pessoa pessoa)
        {   
            var _DbContext = new _DbContext();

            _DbContext.Pessoa.Add(pessoa);
            _DbContext.SaveChanges();

            return pessoa;
        }

        [HttpPut]
        public Pessoa Alterar(Pessoa pessoa)
        {
            var _dbContext = new _DbContext();

            _dbContext.Pessoa.Entry(pessoa).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return pessoa;
        }
        [HttpDelete("{id}")]
        public ActionResult Remover(int id)
        {
            //Instanciar o banco de dados
            var _DbContext = new _DbContext();

            //Localizar o registro encontrado
            var vPessoa = _DbContext.Pessoa.Find(id);

            //Remover o registro encontrado
            _DbContext.Pessoa.Remove(vPessoa);

            //Salvar alterações
            _DbContext.SaveChanges();

            return Ok();
        }
    }
}
