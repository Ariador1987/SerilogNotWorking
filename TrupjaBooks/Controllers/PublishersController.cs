using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrupjaBooks.Data.Models.DTOs;
using TrupjaBooks.Data.Services;
using TrupjaBooks.Exceptions;

namespace TrupjaBooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly PublisherService _publishersService;
        private readonly ILogger<PublishersController> _logger;

        public PublishersController(PublisherService publishersService, ILogger<PublishersController> logger)
        {
            _publishersService = publishersService;
            _logger = logger;
        }

        [Route("get-all-publishers")]
        [HttpGet]
        // sortby ćemo proslijediti kao query parameter ne kao path parameter
        public IActionResult GetAllPublishers([FromQuery]string? sortBy, [FromQuery]string? searchString, int? pageNumber)
        {
            try
            {
                var _result = _publishersService.GetAllPublishers(sortBy, searchString, pageNumber);
                return StatusCode(200, _result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Something went wrong {ex.Message}.");
            }
            
        }

        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody]PublisherDTO publisher)
        {
            try
            {
                var newPublisher = _publishersService.AddPublisher(publisher);
                return StatusCode(201, newPublisher);
            }
            catch (PublisherNameException ex)
            {
                return BadRequest($"{ex.Message}, Publisher name: {ex.PublisherName}");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetPublisherById(int id) {

            try
            {
                _logger.LogError("CHANGED startup setting");
                _logger.LogInformation("Attempt started");
                throw new Exception("This is our ENEW NEW  LOG Test");
                var _response = _publishersService.GetPublisherById(id);

                if (_response is not null)
                {
                    return StatusCode(200, _response);
                } 
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex} fatal exception occurded");
                throw;
            }
            //throw new Exception($"This is an exception that'll be handled by middleware.");

        }

        [HttpGet("get-publisher-books-with-authors/{id}")]
        public IActionResult GetPublisherData(int id)
        {
            var _response = _publishersService.GetPublisherData(id);
            return StatusCode(200, _response);
        }
    }
}
