using System.Text;

namespace RoomyTestTask.Interfaces.Utils
{
    public interface IFileReader
    {
        public StringBuilder GetFileText(IFormFile file);
    }
}
