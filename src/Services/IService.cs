using tutorial1.Models;

namespace tutorial1.Services;

public interface IService<Model, ViewModel>
 	where ViewModel : class
	where Model : class, ViewModel, IBaseModel<ViewModel>, new()
{
	Task<Model> CreateOne(ViewModel newItem);
	Task<List<Model>> ReadAll();
	Task<Model> ReadOne(int id);
	Task<Model> UpdateOne(int id, ViewModel newItem);
	Task<bool> DeleteOne(int id);
}