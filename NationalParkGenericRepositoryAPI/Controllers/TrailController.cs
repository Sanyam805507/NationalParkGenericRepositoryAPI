using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NationalParkGenericRepositoryAPI.DTOs;
using NationalParkGenericRepositoryAPI.Models;
using NationalParkGenericRepositoryAPI.Repository;
using NationalParkGenericRepositoryAPI.Repository.IRepository;

namespace NationalParkGenericRepositoryAPI.Controllers
{
    [Route("api/Trail")]
    [ApiController]
    public class TrailController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;   
        public TrailController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;   
        }
        [HttpGet]
        public IActionResult GetAllTrail()
        {
            return Ok(_unitOfWork.Trail.GetAll().Select(_mapper.Map<TrailDTO>));
           
        }

        [HttpGet("{trailid:int}", Name = "GetTrail")]
        public IActionResult GetTrail(int trailid)
        {
            var trail = _unitOfWork.Trail.Get(trailid);
            if (trail == null)return NotFound();
            var trailDTO = _mapper.Map<TrailDTO>(trail);
            return Ok(trailDTO);
        }


        [HttpPost]

        public IActionResult CreateTrail([FromBody] TrailDTO trailDTO)
        {
            if (trailDTO == null)return BadRequest();

            if (!ModelState.IsValid)return BadRequest(ModelState);

            if (_unitOfWork.Trail.Exists(trailDTO.Id))
            {
                ModelState.AddModelError("", "Trail already exists.");
                return StatusCode(StatusCodes.Status409Conflict);
            }

            var trail = _mapper.Map<Trail>(trailDTO);

            if (!_unitOfWork.Trail.Create(trail))
            {
                ModelState.AddModelError("", "Something went wrong while saving the park.");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return CreatedAtRoute("GetTrail", new { trailid = trail.Id }, trail);
        }

        [HttpPut]
        public IActionResult UpdateTrail([FromBody] TrailDTO trailDTO)
        {
            if (trailDTO == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var trail = _mapper.Map<Trail>(trailDTO);

            if (!_unitOfWork.Trail.Update(trail))
            {
                ModelState.AddModelError("", "Something went wrong while updating the park.");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent(); // 204
        }


        [HttpDelete("{trailid:int}")]
        public IActionResult DeleteTrail(int trailid)
        {
            if (!_unitOfWork.Trail.Exists(trailid))
                return NotFound();

            var trail = _unitOfWork.Trail.Get(trailid);
            if (trail== null)
                return NotFound();

            if (!_unitOfWork.Trail.Delete(trail))
            {
                ModelState.AddModelError("", "Something went wrong while deleting the park.");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok();
        }
    }

}
