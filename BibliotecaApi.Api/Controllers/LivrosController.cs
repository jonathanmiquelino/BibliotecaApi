using BibliotecaApi.Application.Livros.Commands.CriarLivro;
using BibliotecaApi.Application.Livros.Commands.AtualizarLivroById;
using BibliotecaApi.Application.Livros.Commands.DeletarLivroById;
using BibliotecaApi.Application.Livros.Queries.ObterLivroById;
using BibliotecaApi.Application.Livros.Queries.ObterTodosLivros;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaApi.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class LivrosController : ControllerBase
{
    private readonly IMediator _mediator;

    public LivrosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CriarLivro([FromBody] CriarLivroCommand command)
    {
        var idLivro = await _mediator.Send(command);
        
        return Created($"/livros/{idLivro}", new { id = idLivro });
    }

    [HttpGet]
    public async Task<IActionResult> ObterTodos([FromQuery] ObterTodosLivrosQuery request)
    {
        var livros = await _mediator.Send(request);
        return Ok(livros);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterLivroById(int id)
    {
        var query = new ObterLivroByIdQuery { Id = id };
        var livro = await _mediator.Send(query);
        if (livro == null)
            return NotFound();
        return Ok(livro);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarLivroById(int id, [FromBody] AtualizarLivroByIdCommand command)
    {
        command.Id = id;
        var livro = await _mediator.Send(command);
        return Ok(livro);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarLivroById(int id)
    {
        var command = new DeletarLivroByIdCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
  
}