using Microsoft.AspNetCore.Mvc;
using RoomyTestTask.Dtos;
using RoomyTestTask.Interfaces.Services;
using RoomyTestTask.Interfaces.Utils;

namespace RoomyTestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private const string SessionDocumentNotSet = "Session document is not set.";
        private const string NoSuchDocument = "This document doesn't exist.";

        private readonly IPaymentService _paymentService;
        private readonly IDocumentService _documentService;
        private readonly ICookiesHelper _cookiesHelper;

        public PaymentsController(IPaymentService paymentService, ICookiesHelper cookiesHelper, IDocumentService documentService)
        {
            _paymentService = paymentService;
            _cookiesHelper = cookiesHelper;
            _documentService = documentService;
        }

        /// <summary>
        /// Get payments by document id endpoint
        /// </summary>
        /// <remarks>
        /// Sets document as session document
        /// </remarks>
        /// <param name="documentId">Document id</param>
        /// <returns>Found payments</returns>
        [HttpGet("GetByDocumentId/{documentId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPaymentsByDocumentId(Guid documentId)
        {
            if (!await _documentService.DocumentExistsAsync(documentId))
                return BadRequest($"{NoSuchDocument} {nameof(documentId)}: {documentId}.");

            IEnumerable<PaymentDto> payments = await _paymentService.GetPaymentsByDocumentIdAsync(documentId);

            if (!payments.Any() || payments is null)
                return NoContent();

            _cookiesHelper.SetDocumentIdCookie(documentId);
            return Ok(payments);
        }

        /// <summary>
        /// Get payments by document name endpoint
        /// </summary>
        /// <remarks>
        /// Sets document as session document
        /// </remarks>
        /// <param name="documentName">Document name</param>
        /// <returns>Found payments</returns>
        [HttpGet("GetByDocumentName/{documentName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPaymentsByDocumentName(string documentName)
        {
            Guid? documentId = await _documentService.GetDocumentIdByNameAsync(documentName);

            if (!documentId.HasValue)
                return BadRequest($"{NoSuchDocument} {nameof(documentName)}: {documentName}.");

            IEnumerable<PaymentDto> payments = await _paymentService.GetPaymentsByDocumentIdAsync(documentId.Value);

            if (!payments.Any() || payments is null)
                return NoContent();

            _cookiesHelper.SetDocumentIdCookie(documentId.Value);
            return Ok(payments);
        }

        /// <summary>
        /// Get payments by user id and document name endpoint
        /// </summary>
        /// <remarks>
        /// If document name is not set, payments are searched in all documents
        /// </remarks>
        /// <param name="userId">User id</param>
        /// <param name="documentName">Document name</param>
        /// <returns>Found payments</returns>
        [HttpGet("{userId}:guid")]
        [HttpGet("{userId}:guid/{documentName?}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPaymentsByUserId(Guid userId, string? documentName = null)
        {
            Guid? documentId = null;
            if (documentName is not null)
            {
                documentId = await _documentService.GetDocumentIdByNameAsync(documentName);

                if (!documentId.HasValue)
                    return BadRequest($"{NoSuchDocument} {nameof(documentName)}: {documentName}.");
            }

            IEnumerable<PaymentDto> payments = await _paymentService.GetPaymentsByUserIdAsync(userId, documentId);

            if (!payments.Any() || payments is null)
                return NoContent();

            return Ok(payments);
        }

        /// <summary>
        /// Get payments by contract number and document name endpoint
        /// </summary>
        /// <remarks>
        /// If document name is not set, payments are searched in all documents
        /// </remarks>
        /// <param name="contractNumber">User id</param>
        /// <param name="documentName">Document name</param>
        /// <returns>Found payments</returns>
        [HttpGet("{contractNumber}")]
        [HttpGet("{contractNumber}/{documentName?}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPaymentsByContractNumber(string contractNumber, string? documentName = null)
        {
            Guid? documentId = null;
            if (documentName is not null)
            {
                documentId = await _documentService.GetDocumentIdByNameAsync(documentName);

                if (!documentId.HasValue)
                    return BadRequest($"{NoSuchDocument} {nameof(documentName)}: {documentName}.");
            }

            IEnumerable<PaymentDto> payments = await _paymentService.GetPaymentsByContractNumberAsync(contractNumber, documentId);

            if (!payments.Any() || payments is null)
                return NoContent();

            return Ok(payments);
        }

        /// <summary>
        /// Get payments by contract number endpoint
        /// </summary>
        /// <remarks>
        /// Payments are searched in session document.
        /// If session document is not set, returns 404 code
        /// </remarks>
        /// <param name="contractNumber">Contract number</param>
        /// <returns>Found payments</returns>
        [HttpGet("SessionDocument/{contractNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetPaymentsByContractNumberSession(string contractNumber)
        {
            Guid? documentId = _cookiesHelper.GetDocumentIdCookie();

            if (documentId is null)
                return Forbid(SessionDocumentNotSet);

            IEnumerable<PaymentDto> payments = await _paymentService.GetPaymentsByContractNumberAsync(contractNumber, documentId.Value);

            if (!payments.Any() || payments is null)
                return NoContent();

            return Ok(payments);
        }

        /// <summary>
        /// Get payments by user id endpoint
        /// </summary>
        /// <remarks>
        /// Payments are searched in session document.
        /// If session document is not set, returns 404 code
        /// </remarks>
        /// <param name="userId">User id</param>
        /// <returns>Found payments</returns>
        [HttpGet("SessionDocument/{userId}:guid")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetPaymentsByUserIdSession(Guid userId)
        {
            Guid? documentId = _cookiesHelper.GetDocumentIdCookie();

            if (documentId is null)
                return Forbid(SessionDocumentNotSet);

            IEnumerable<PaymentDto> payments = await _paymentService.GetPaymentsByUserIdAsync(userId, documentId.Value);

            if (!payments.Any() || payments is null)
                return NoContent();

            return Ok(payments);
        }

        /// <summary>
        /// Get payments by user id and contract number endpoint
        /// </summary>
        /// <remarks>
        /// Payments are searched in session document.
        /// If session document is not set, returns 404 code
        /// </remarks>
        /// <param name="userId">User id</param>
        /// <param name="contractNumber">Contract number</param>
        /// <returns>Found payments</returns>
        [HttpGet("SessionDocument/{userId}:guid/{contractNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetPaymentsByIdAndContractNumberSession(Guid userId, string contractNumber)
        {
            Guid? documentId = _cookiesHelper.GetDocumentIdCookie();

            if (documentId is null)
                return Forbid(SessionDocumentNotSet);

            IEnumerable<PaymentDto> payments = await _paymentService.GetPaymentsByUserIdAndContractNumberAsync(userId, contractNumber, documentId.Value);

            if (!payments.Any() || payments is null)
                return NoContent();

            return Ok(payments);
        }

        /// <summary>
        /// Delete payments by contract number endpoint
        /// </summary>
        /// <param name="contractNumber">Contract number</param>
        /// <returns>Ids of deleted payments</returns>
        [HttpDelete("DeleteByContractNumber/{contractNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeletePaymentsByContractNumber(string contractNumber)
        {
            IEnumerable<Guid> deletedPayments = await _paymentService.DeletePaymentsByContractNumberAsync(contractNumber);

            if (!deletedPayments.Any() || deletedPayments is null)
                return NoContent();

            return Ok(deletedPayments);
        }

        /// <summary>
        /// Delete payments by document name endpoint
        /// </summary>
        /// <param name="documentName">Document name</param>
        /// <returns>Ids of deleted payments</returns>
        [HttpDelete("DeleteByDocumentName/{documentName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeletePaymentsByDocumentName(string documentName)
        {
            Guid? documentId = await _documentService.GetDocumentIdByNameAsync(documentName);

            if (!documentId.HasValue)
                return BadRequest($"{NoSuchDocument} {nameof(documentName)}: {documentName}.");

            IEnumerable<Guid> deletedPayments = await _paymentService.DeletePaymentsByDocumentIdAsync(documentId.Value);

            if (!deletedPayments.Any() || deletedPayments is null)
                return NoContent();

            return Ok(deletedPayments);
        }
    }
}
