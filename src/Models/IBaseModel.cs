namespace tutorial1.Models;

/// <summary>
/// Database Model representation
/// </summary>
/// <typeparam name="ViewModel">The ViewModel (public representation) of the database model</typeparam>
public interface IBaseModel<ViewModel>
	where ViewModel : class
{
	int Id { get; set; }

	DateTime CreatedAt { get; set; }
	DateTime UpdatedAt { get; set; }
	DateTime? DeletedAt { get; set; }

	/// <summary>
	/// Update the Base model from the ViewModel
	/// </summary>
	/// <param name="item">The view model to update from</param>
	/// <returns>true if the model was updated, false if it could not be updated</returns>
	bool Update(ViewModel item);
}