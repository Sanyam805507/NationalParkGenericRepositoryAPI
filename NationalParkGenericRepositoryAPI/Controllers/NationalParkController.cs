using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NationalParkGenericRepositoryAPI.DTOs;
using NationalParkGenericRepositoryAPI.Models;
using NationalParkGenericRepositoryAPI.Repository.IRepository;

namespace NationalParkGenericRepositoryAPI.Controllers
{
    [Route("api/nationalPark")]
    [ApiController]
    public class NationalParkController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NationalParkController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        
        [HttpGet]
        public IActionResult GetAllNationalParks()
        {
            var parkList = _unitOfWork.NationalPark.GetAll();
            var parkDTOList = parkList.Select(park => _mapper.Map<NationalParkDTO>(park)).ToList();
            return Ok(parkDTOList);
        }

       
        [HttpGet("{nationalParkid:int}", Name = "GetNationalPark")]
        public IActionResult GetNationalPark(int nationalParkid)
        {
            var park = _unitOfWork.NationalPark.Get(nationalParkid);
            if (park == null)
                return NotFound();

            var parkDTO = _mapper.Map<NationalPark,NationalParkDTO>(park);
            return Ok(parkDTO);
        }

       
        [HttpPost]
        public IActionResult CreateNationalPark([FromBody] NationalParkDTO nationalParkDTO)
        {
            if (nationalParkDTO == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (_unitOfWork.NationalPark.Exists(nationalParkDTO.Id))
            {
                ModelState.AddModelError("", "National park already exists.");
                return StatusCode(StatusCodes.Status409Conflict);
            }

            var park = _mapper.Map<NationalPark>(nationalParkDTO);

            if (!_unitOfWork.NationalPark.Create(park))
            {
                ModelState.AddModelError("", "Something went wrong while saving the park.");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return CreatedAtRoute("GetNationalPark", new { id = park.Id }, park);
        }

        [HttpPut]
        public IActionResult UpdateNationalPark( [FromBody] NationalParkDTO nationalParkDTO)
        {
            if (nationalParkDTO == null )
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var park = _mapper.Map<NationalPark>(nationalParkDTO);

            if (!_unitOfWork.NationalPark.Update(park))
            {
                ModelState.AddModelError("", "Something went wrong while updating the park.");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent(); // 204
        }

        
        [HttpDelete("{nationalParkid:int}")]
        public IActionResult DeleteNationalPark(int nationalParkid)
        {
            if (!_unitOfWork.NationalPark.Exists(nationalParkid))
                return NotFound();

            var park = _unitOfWork.NationalPark.Get(nationalParkid);
            if (park == null)
                return NotFound();

            if (!_unitOfWork.NationalPark.Delete(park))
            {
                ModelState.AddModelError("", "Something went wrong while deleting the park.");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok();
        }
    }
}
