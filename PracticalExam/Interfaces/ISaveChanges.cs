namespace PracticalExam.Interfaces
{
    public interface ISaveChanges:IDisposable
    {
        Task CompleteAsync();
    }
}
