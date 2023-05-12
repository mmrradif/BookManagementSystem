namespace PracticalExam.Interfaces
{
    public interface IAll<T>:IGet<T>,IInsert<T>,IUpdate<T>,IDelete<T>,ISaveChanges where T : class
    {
    }
}
