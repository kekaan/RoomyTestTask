using RoomyTestTask.Interfaces.Utils;

namespace RoomyTestTask.Utils
{
    public class CookiesHelper : ICookiesHelper
    {
        private const string DocumentCookieKey = "DocumentId";

        readonly IHttpContextAccessor _httpContextAccessor;

        public CookiesHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void SetDocumentIdCookie(Guid documentId)
        {
            CookieOptions cookieOptions = new()
            {
                Expires = DateTime.Now.AddDays(1),
                Path = "/"
            };

            _httpContextAccessor.HttpContext?.Response.Cookies.Append(DocumentCookieKey, documentId.ToString(), cookieOptions);
        }

        public Guid? GetDocumentIdCookie()
        {
            string? documentId = null;
            _httpContextAccessor.HttpContext?.Request.Cookies.TryGetValue(DocumentCookieKey, out documentId);

            return documentId is not null ? new Guid(documentId) : null;
        }
    }
}
