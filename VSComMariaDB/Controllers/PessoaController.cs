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

        [HttpGet("ListaAsync")]
        public async Task<List<Pessoa>> GetListaAsync()
        {
            var _dbContext = new _DbContext();

            var vLista = await _dbContext.Pessoa.ToListAsync();

            return vLista;
        }

        /// <summary>
        /// Pegar os dados de uma pessoa especifica
        /// </summary>
        /// <param name="id"> Id da pessoa </param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<Pessoa> GetPessoa(int id)
        {
            //Instancia o banco de dados
            var _dbContext = new _DbContext();

            //Selicionar a Pessoa pelo Id
            //var vPessoa = _dbContext.Pessoa
            //    .Where(p => p.Id == id)
            //    .FirstOrDefault();

            //var vPessoa = _dbContext.Pessoa.Find(id);

            var vLista = await _dbContext.Pessoa.FindAsync(id);

            //Retornar dos dados
            return vLista;
        }

        [HttpPost]
        public async Task<Pessoa> Inserir(Pessoa pessoa)
        {   
            var _DbContext = new _DbContext();

           await _DbContext.Pessoa.AddAsync(pessoa);
            await _DbContext.SaveChangesAsync();

            return pessoa;
        }

        [HttpPut]
        public async Task<Pessoa> Alterar(Pessoa pessoa)
        {
            var _dbContext = new _DbContext();

           _dbContext.Pessoa.Entry(pessoa).State = EntityState.Modified;
           await _dbContext.SaveChangesAsync();

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
