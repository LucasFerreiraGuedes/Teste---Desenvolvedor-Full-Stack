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
            try 
             {
				IEnumerable<Lancamento> lancamentos = await _context.GetAll();

				if (lancamentos == null) {
					return NotFound();
				} else {
					return Ok(lancamentos);
				}
			} catch (Exception e) {

                return BadRequest("Ocorreu um erro no servidor: "+ e.Message);
            }
           
        }

        [HttpGet("GetByDate")]
        public async Task<ActionResult<IEnumerable<Lancamento>>> GetByDate(DateTime date,int intervalo)
        {
            try {
				IEnumerable<Lancamento> lancamentos = await _context.GetByDate(date, intervalo);

				if (lancamentos == null) {
					return NotFound();
				}
                else {
					return Ok(lancamentos);
				}

			} catch (Exception e) {

				return BadRequest("Ocorreu um erro no servidor: " + e.Message);
			}

		}

        [HttpPost]
        public async Task<ActionResult<Lancamento>> Add(LancamentoDTO lancamentoDTO)
        {
            try 
             {
				Lancamento lancamento = _mapper.Map<Lancamento>(lancamentoDTO);

				Boolean response = await _context.Add(lancamento);

				if (response) 
                {
					return CreatedAtAction(null, lancamento);
				}
                else
                {
					return BadRequest();
				}
			}
            catch (Exception e) 
            {
				return BadRequest("Ocorreu um erro no servidor: " + e.Message);
			}
            
        }

		[HttpPost("NaoAvulso")]
		public async Task<ActionResult<Lancamento>> AddLancamentoNaoAvulso(LancamentoNaoAvulsoDTO lancamentoNaoAvulsoDTO)
		{
            try {

				Lancamento lancamento = _mapper.Map<Lancamento>(lancamentoNaoAvulsoDTO);

				Boolean response = await _context.Add(lancamento);

				if (response)
                {
					return CreatedAtAction(null, lancamento);
				} 
                else {
					return BadRequest();
				}
			} 
            catch (Exception e) {

				return BadRequest("Ocorreu um erro no servidor: " + e.Message);
			}
			
		}

        [HttpPatch("CancelarLancamento")]

        public async Task<ActionResult<Lancamento>> CancelarLancamento([FromBody]int id)
        {
            try
            {
                Lancamento lancamento = await _context.Cancel(id);

                if(lancamento == null)
                {
                    return NotFound();
                }
                return Ok(lancamento);
            }
            catch (Exception e)
            {

				return BadRequest("Ocorreu um erro no servidor: " + e.Message);
			}
            
        }
        [HttpPatch("AttValorData")]

        public async Task<ActionResult<Lancamento>> AttValorData(LancamentoAttValor_DataDTO lancamentoDTO)
        {
            try
            {
                Lancamento lancamento = await _context.AttValorData(lancamentoDTO.Id,lancamentoDTO.valor,lancamentoDTO.data);

                if(lancamento != null)
                {
                    return Ok(lancamento);
                }
                return NotFound();
            }
            catch (Exception e)
            {

				return BadRequest("Ocorreu um erro no servidor: " + e.Message);
			}
            
        }
	}
}
