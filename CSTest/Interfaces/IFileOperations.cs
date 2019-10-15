using System.IO;

namespace CSTest.Interfaces {
    public interface IFileOperations {
        public void saveToDb();
        public void parseXml(Stream stream);
    }
}
