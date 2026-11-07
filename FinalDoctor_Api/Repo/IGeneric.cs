namespace FinalDoctor_Api.Repo
{
    public interface IGeneric<t> where t : class
    {
        Task<IEnumerable<t>> Getall();
        Task<t?>GetById(int id);
        Task<bool>Delete(int id);
        Task Add(t entity);
        Task Update(t entity);
    }
}
