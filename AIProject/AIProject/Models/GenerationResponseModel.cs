namespace AIProject.Models
{
    public class GenerationResponseModel
    {
        public string Created { get; set; }
        public DataClass Data { get; set; }
        public Error Error { get; set; }
    }

    public class Error
    {
        public string Code { get; set; }
        public string Message { get; set; }

    }

    public class DataClass
    {
        public string URL { get; set; }
    }
}
