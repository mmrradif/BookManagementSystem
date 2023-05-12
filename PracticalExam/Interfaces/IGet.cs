namespace PracticalExam.Interfaces
{
    public interface IGet<T> where T : class
    {
        Task<List<T>> GetAll();

        Task<T> GetById(int id);
    }
}
