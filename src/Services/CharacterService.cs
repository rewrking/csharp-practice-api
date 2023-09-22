using tutorial1.ViewModels;
using tutorial1.ResponseUtils;
using tutorial1.Models;
using tutorial1.Data;
using Microsoft.EntityFrameworkCore;

namespace tutorial1.Services;

public class CharacterService : IService<CharacterModel, Character>
{
	// private static int nextId = 0;
	// private static List<CharacterModel> characters = new()
	// {
	// 	new CharacterModel{ Id = nextId++, Name = "Frodo", Class = RPGClass.Knight },
	// 	new CharacterModel{ Id = nextId++, Name = "Sam", Class = RPGClass.Cleric }
	// };

	private readonly DataContext context;

	public CharacterService(DataContext context)
	{
		this.context = context;
	}


	public async Task<CharacterModel> CreateOne(Character newItem)
	{
		CharacterModel item = new();
		// item.Id = nextId++;
		item.CreatedAt = DateTime.Now;
		item.UpdatedAt = DateTime.Now;
		item.Update(newItem);
		var result = await context.Characters.AddAsync(item);
		return result.Entity;
	}

	public async Task<List<CharacterModel>> ReadAll()
	{
		return await context.Characters.ToListAsync();
	}

	public async Task<CharacterModel> ReadOne(int id)
	{
		var item = await context.Characters.FirstOrDefaultAsync(character => character.Id == id);
		if (item == null)
			throw new ApiException(StatusCode.NotFound, $"{typeof(Character).Name} with id of '{id}` not found");

		return item;
	}

	public async Task<CharacterModel> UpdateOne(int id, Character newItem)
	{
		var item = await context.Characters.FirstOrDefaultAsync(character => character.Id == id);
		if (item == null)
			throw new ApiException(StatusCode.NotFound, $"{typeof(Character).Name} with id of '{id}` not found");


		item.Update(newItem);
		item.UpdatedAt = DateTime.Now;
		var result = context.Characters.Update(item);
		await context.SaveChangesAsync();
		return result.Entity;
	}

	public async Task<bool> DeleteOne(int id)
	{
		var item = await context.Characters.FirstOrDefaultAsync(character => character.Id == id);
		if (item == null)
			return false;

		item.DeletedAt = DateTime.Now;
		context.Characters.Remove(item);
		await context.SaveChangesAsync();
		return true;
	}
}