namespace BusinessModel.Services
{
    public class RemoteUploadFileException : Exception
    {
        public RemoteUploadFileException(string message)
            : this("File could not be uploaded. \n" + message, null)
        {            
        }

        public RemoteUploadFileException(string message, Exception inner)
            : base(message, inner)
        {            
        }
    }
}
