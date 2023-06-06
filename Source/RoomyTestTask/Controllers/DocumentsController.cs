using Microsoft.AspNetCore.Mvc;
using RoomyTestTask.Interfaces.Services;
using RoomyTestTask.Interfaces.Utils;

namespace RoomyTestTask.Controllers
{
    [Route("api/documents")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentService _documentService;
        private readonly ICookiesHelper _cookiesHelper;

        public DocumentsController(IDocumentService documentService, ICookiesHelper cookiesHelper)
        {
            _documentService = documentService;
            _cookiesHelper = cookiesHelper;
        }

        /// <summary>
        /// Loads document with payments data and stores it in database.
        /// </summary>
        /// <param name="postedDocument">Downloadable file</param>
        /// <remarks>
        /// Data format must be in UserId -- Surname -- Name -- ContractNumber -- WriteOffAmount format
        /// </remarks>
        /// <returns>Id of created document</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostDocument(IFormFile postedDocument)
        {
            try
            {
                Guid documentId = await _documentService.PostDocumentAsync(postedDocument);
                _cookiesHelper.SetDocumentIdCookie(documentId);

                return Created(nameof(PostDocument), documentId);
            }
            catch (InvalidDataException ex)
            {
                return BadRequest($"Document data exception. {ex.Message}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
