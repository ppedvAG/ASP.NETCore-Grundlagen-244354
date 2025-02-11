namespace BusinessModel.Contracts
{
    public interface IFileService
    {
        Task<string> UploadFile(string fileName, Stream stream);
    }
}