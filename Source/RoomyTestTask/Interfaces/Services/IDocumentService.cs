namespace RoomyTestTask.Interfaces.Services
{
    public interface IDocumentService
    {
        public Task<Guid> PostDocumentAsync(IFormFile fileData);
        public Task<Guid?> GetDocumentIdByNameAsync(string documentName);
        public Task<bool> DocumentExistsAsync(Guid documentId);
    }
}
