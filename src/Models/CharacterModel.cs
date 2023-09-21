using tutorial1.ViewModels;

namespace tutorial1.Models;

public class CharacterModel : Character, IBaseModel
{
	public DateTime CreatedAt { get; set; } = new();
	public DateTime UpdatedAt { get; set; } = new();
	public DateTime? DeletedAt { get; set; }
}