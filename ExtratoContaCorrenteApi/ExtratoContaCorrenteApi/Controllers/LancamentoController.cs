using AutoMapper;
using ExtratoContaCorrenteApi.DTO_s;
using ExtratoContaCorrenteApi.Models;
using ExtratoContaCorrenteApi.Repository.LancamentoRepo;
using Microsoft.AspNetCore.Mvc;

namespace ExtratoContaCorrenteApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class LancamentoController : ControllerBase
	{
        private readonly ILancamentoRepository _context;
        private readonly IMapper _mapper;
        public LancamentoController(ILancamentoRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public  async Task<ActionResult<IEnumerable<Lancamento>>> GetAll()
        {
            IEnumerable<Lancamento> lancamentos = await _context.GetAll();

            if(lancamentos == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(lancamentos);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Lancamento>> Add(LancamentoDTO lancamentoDTO)
        {
            Lancamento lancamento = _mapper.Map<Lancamento>(lancamentoDTO);

            Boolean response = await _context.Add(lancamento);

            if(response)
            {
                return CreatedAtAction(null, lancamento);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
