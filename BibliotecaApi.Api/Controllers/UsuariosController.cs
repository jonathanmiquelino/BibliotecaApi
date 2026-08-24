using BibliotecaApi.Application.Livros.Commands.DeletarLivroById;
using BibliotecaApi.Application.Usuarios.Commands.AtualizarusuarioByID;
using BibliotecaApi.Application.Usuarios.Commands.CriarUsuario;
using BibliotecaApi.Application.Usuarios.Commands.DeletarUsuarioById;
using BibliotecaApi.Application.Usuarios.Queries.ObterTodosUsuarios;
using BibliotecaApi.Application.Usuarios.Queries.ObterUsuarioById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaApi.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsuariosController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<IActionResult> Criarusuario([FromBody] CriarUsuarioCommand command)
    {
        var idUsuario = await _mediator.Send(command);
        
        return Created($"/usuarios/{idUsuario}", new { id = idUsuario });
    }

    [HttpGet]
    public async Task<IActionResult> ObterTodosUsuarios([FromQuery] ObterTodosUsuariosQuery request)
    {
        var usuarios = await _mediator.Send(request);
        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterUsuarioById(int id)
    {
        var query = new ObterUsuarioByIdQuery { Id = id };
        var usuario = await _mediator.Send(query);
        if (usuario == null)
            return NotFound();
        return Ok(usuario);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarUsuariooById(int id, [FromBody] AtualizarUsuarioByIdCommand command)
    {
        command.Id = id;
        var usuario = await _mediator.Send(command);
        return Ok(usuario);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarUsuarioById(int id)
    {
        var command = new DeletarUsuarioByIdCommand() { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }

}