namespace PracticalExam.Interfaces
{
    public interface IInsert<T> where T : class
    {
        Task Insert(T entity);
    }
}
