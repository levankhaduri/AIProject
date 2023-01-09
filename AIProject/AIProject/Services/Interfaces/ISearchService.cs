namespace AIProject.Services.Interfaces
{
    public interface ISearchService
    {
        public Task<string> GetImage(string search);
    }
}
