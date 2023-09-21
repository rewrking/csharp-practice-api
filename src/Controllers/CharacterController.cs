using Microsoft.AspNetCore.Mvc;
using tutorial1.Models;
using tutorial1.ViewModels;
using tutorial1.Services;

namespace tutorial1.Controllers;

[Route("api/characters")]
public class CharacterController : BaseController<CharacterModel, Character>
{
    public CharacterController(CharacterService service) :
        base(service)
    { }
}
