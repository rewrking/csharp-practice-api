namespace tutorial1.Models;

public interface IBaseModel
{
	DateTime CreatedAt { get; set; }
	DateTime UpdatedAt { get; set; }
	DateTime? DeletedAt { get; set; }
}