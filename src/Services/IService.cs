namespace tutorial1.Services;

public interface IService<Model>
	where Model : class
{
	Task<Model> CreateOne(Model newItem);
	Task<List<Model>> ReadAll();
	Task<Model> ReadOne(int id);
}