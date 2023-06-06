using System.Text;
using RoomyTestTask.Interfaces.Utils;

namespace RoomyTestTask.Utils
{
    public class FileReader : IFileReader
    {
        public StringBuilder GetFileText(IFormFile file)
        {
            StringBuilder result = new();

            using (StreamReader reader = new(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    result.AppendLine(reader.ReadLine());
            }

            return result;
        }
    }
}
