using tutorial1.ViewModels;
using tutorial1.ResponseUtils;
using tutorial1.Models;

namespace tutorial1.Services;

public class CharacterService : IService<CharacterModel, Character>
{
	private static int nextId = 0;
	private static List<CharacterModel> characters = new()
	{
		new CharacterModel{ Id = nextId++, Name = "Frodo", Class = RPGClass.Knight },
		new CharacterModel{ Id = nextId++, Name = "Sam", Class = RPGClass.Cleric }
	};


	public async Task<CharacterModel> CreateOne(Character newItem)
	{
		CharacterModel item = new();
		item.Id = nextId++;
		item.CreatedAt = new(DateTime.Now.Ticks);
		item.UpdatedAt = new(DateTime.Now.Ticks);
		item.Update(newItem);
		characters.Add(item);
		return item;
	}

	public async Task<List<CharacterModel>> ReadAll()
	{
		return characters;
	}

	public async Task<CharacterModel> ReadOne(int id)
	{
		var item = characters.FirstOrDefault(character => character.Id == id);
		if (item != null)
			return item;

		throw new ApiException(StatusCode.NotFound, "Character not found");
	}

	public async Task<CharacterModel> UpdateOne(int id, Character newItem)
	{
		var item = await ReadOne(id);
		item.Update(newItem);
		item.UpdatedAt = new(DateTime.Now.Ticks);
		return item;
	}

	public async Task<bool> DeleteOne(int id)
	{
		var item = characters.FirstOrDefault(character => character.Id == id);
		if (item == null)
			return false;

		item.DeletedAt = new(DateTime.Now.Ticks);
		characters.Remove(item);
		return true;
	}
}