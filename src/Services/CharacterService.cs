using tutorial1.ViewModels;
using tutorial1.ResponseUtils;
using tutorial1.Models;

namespace tutorial1.Services;

public class CharacterService : IService<CharacterModel>
{
	private static int nextId = 0;
	private static List<CharacterModel> characters = new()
	{
		new CharacterModel{ Id = nextId++, Name = "Frodo", Class = RPGClass.Knight },
		new CharacterModel{ Id = nextId++, Name = "Sam", Class = RPGClass.Cleric }
	};


	public async Task<CharacterModel> CreateOne(CharacterModel newItem)
	{
		newItem.Id = nextId++;
		characters.Add(newItem);
		return newItem;
	}

	public async Task<List<CharacterModel>> ReadAll()
	{
		return characters;
	}

	public async Task<CharacterModel> ReadOne(int id)
	{
		var character = characters.FirstOrDefault(character => character.Id == id);
		if (character != null)
			return character;

		throw new ApiException(StatusCode.NotFound, "Character not found");
	}
}