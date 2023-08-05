using System.IO;
using System.Text;

namespace TextEditor.BL
{
    public interface IFileManager<T>
    {
        string GetContent(T filePath);
        string GetContent(T filePath, Encoding encoding);
        void SaveContent(string content, T filePath);
        void SaveContent(string content, T filePath, Encoding encoding);
        int GetSymbolCount(string content);
        bool IsExist(T filePath);
    }
        

    public class FileManager : IFileManager<string>
    {
        private readonly Encoding _defaultEncoding = Encoding.GetEncoding(1251);
        //устанаваливаем дефолтную виндовскую кодировку
        public bool IsExist(string filePath)
        {
           bool isExist = File.Exists(filePath);
            return isExist;
        }
        public string GetContent(string filePath)
        {
            return GetContent(filePath, _defaultEncoding);
        }
        // а это перегруженный метод, который принимает ещё и кодировку, если она отличается от дефолтной
        public string GetContent(string filePath, Encoding encoding)
        {
            string content = File.ReadAllText(filePath, encoding);
            return content;
        }

        public void SaveContent(string content, string filePath)
        {
            SaveContent(content, filePath, _defaultEncoding);
        }
        public void SaveContent(string content, string filePath, Encoding encoding) 
        { 
            File.WriteAllText(filePath, content, encoding);
        }

        public int GetSymbolCount(string content)
        {
            int count = content.Length;
            return count;

        }
    }

}
