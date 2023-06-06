namespace RoomyTestTask.Interfaces.Utils
{
    public interface ICookiesHelper
    {
        public void SetDocumentIdCookie(Guid documentId);
        public Guid? GetDocumentIdCookie();
    }
}
