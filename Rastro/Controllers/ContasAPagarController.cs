using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rastro.API.Controllers.ViewModel.Request;
using Rastro.API.Controllers.ViewModel.Response;
using Rastro.API.Extensions;
using Rastro.Domain.DTOs.ContasAPagar;
using Rastro.Domain.Interfaces.Service;

namespace Rastro.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ContasAPagarController : ControllerBase
    {
        private readonly IContasAPagarService _contasAPagarService;

        public ContasAPagarController(IContasAPagarService contasAPagarService)
        {
            _contasAPagarService = contasAPagarService;
        }

        [HttpPost]
        public async Task<ActionResult<ContaAPagarResponseViewModel>> Create([FromBody] ContaAPagarPostViewModel viewModel)
        {
            //try
            //{
            //    var userId = User.GetUserId();
            //    if (!userId.HasValue)
            //        return Unauthorized();

            //    var createDTO = new CreateContasAPagarDTO
            //    {
            //        NomeCredor = viewModel.NomeCredor,
            //        Valor = viewModel.Valor,
            //        DataVencimento = viewModel.DataVencimento,
            //        Observacoes = viewModel.Observacoes,
            //        LembreteAtivo = viewModel.LembreteAtivo,
            //        DataLembrete = viewModel.DataLembrete,
            //        Parcelado = viewModel.Parcelado,
            //        NumeroParcelas = viewModel.NumeroParcelas,
            //        UsuarioId = userId.Value
            //    };

            //    var result = await _contasAPagarService.CreateAsync(createDTO);

            //    var response = new ContaAPagarResponseViewModel(
            //        result.Id,
            //        result.NomeCredor,
            //        result.Valor,
            //        result.DataVencimento,
            //        result.Observacoes,
            //        result.LembreteAtivo,
            //        result.DataLembrete,
            //        result.Parcelado,
            //        result.NumeroParcelas,
            //        result.ParcelaAtual,
            //        result.ValorParcela,
            //        result.ValorTotal
            //    );

            //    return Created($"api/contasapagar/{result.Id}", response);
            //}
            //catch (ValidationException ex)
            //{
            //    return BadRequest(ex.Errors);
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContaAPagarResponseViewModel>>> GetAll()
        {
            //try
            //{
            //    var userId = User.GetUserId();
            //    if (!userId.HasValue)
            //        return Unauthorized();

            //    var result = await _contasAPagarService.GetAllByUsuarioIdAsync(userId.Value);
                
            //    var response = result.Select(conta => new ContaAPagarResponseViewModel(
            //        conta.Id,
            //        conta.NomeCredor,
            //        conta.Valor,
            //        conta.DataVencimento,
            //        conta.Observacoes,
            //        conta.LembreteAtivo,
            //        conta.DataLembrete,
            //        conta.Parcelado,
            //        conta.NumeroParcelas,
            //        conta.ParcelaAtual,
            //        conta.ValorParcela,
            //        conta.ValorTotal
            //    ));

            //    return Ok(response);
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}
            throw new NotImplementedException();
        }
    }
}
