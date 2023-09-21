using tutorial1.ViewModels;

namespace tutorial1.Models;

/// <summary>
/// Character Model database representation
/// </summary>
public class CharacterModel : Character, IBaseModel<Character>
{
	public int Id { get; set; } = -1;

	public DateTime CreatedAt { get; set; } = new();
	public DateTime UpdatedAt { get; set; } = new();
	public DateTime? DeletedAt { get; set; }

	public bool Update(Character item)
	{
		Name = item.Name ?? Name;
		HitPoints = item.HitPoints;
		Strength = item.Strength;
		Defense = item.Defense;
		Intelligence = item.Intelligence;
		Class = item.Class;

		return true;
	}
}