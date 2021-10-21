using AutoMapper;
using filmesApi2.Controllers.Models;
using filmesApi2.Data;
using filmesApi2.Data.DTOs;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace filmesApi2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {

        // criando um forma de acessar a informação e criando uma informação do banco de dados

        private FilmeContext _context;
        private IMapper _mapper;

        // iniciando a propriedade acima por construtor

        public FilmeController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        /* Agora não precisa do código abaixo, poque o Banco está fazendo o ID automaticamente

         private static List<Filme> filmes = new List<Filme>();
         private static int id = 1;*/


        [HttpPost] // criar um padrão novo, add um novo filme
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDTO filmeDto)
        {
            //filme.Id = id++;
            //filmes.Add(filme);

            Filme filme = _mapper.Map<Filme>(filmeDto);   
                           
            _context.Filmes.Add(filme);
            _context.SaveChanges();// por meio desse comando salva os dados no banco de dados.
            return CreatedAtAction(nameof(RecuperarFilmePorId), new { Id = filme.Id }, filme);
        }

        // recuperando um lista de filmes
        // por meio daqui recupera todos os filmes.
        
        [HttpGet]
        public IActionResult RecuperaFilme()
        {
            return Ok(_context.Filmes);
        }

        // recuperar filme por id

        [HttpGet("{id}")]

        public IActionResult RecuperarFilmePorId(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filmes => filmes.Id == id);
            if (filme != null)
            {
                ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);
                return Ok(filmeDto);
            }
            return NotFound();

        }

        /* uma forma mais interessante que essa, pois irei colocar notFound ou ok caso encontre o fime
         */

        /*
         public Filme RecuperarFilmes(int id)
        {
            return filmes.FirstOrDefault(filmes => filmes.Id == id);

            // essa forma é mais complicada existe uma forma mais simples que está escrita acima
            /*   foreach(Filme filme in filmes)
               {
                   if(filme.Id==id)
                   {
                       return filme;
                   }
                   }*/

        //atulizar os filmes na base de banco de dados

                [HttpPut("{id}")]

                public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme != null)
            {
                return NotFound();
            }
            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();
            return NoContent();

        }

        // criando opção de delete filmes
        [HttpDelete]
        public IActionResult DeletaFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme != null)
            {
                return NotFound();
            }
            _context.Remove(filme);
            _context.SaveChanges();
            return NoContent();

        }

        }

    }

 
