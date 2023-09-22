using Microsoft.AspNetCore.Mvc;
using tutorial1.Models;
using tutorial1.ResponseUtils;
using tutorial1.Services;

namespace tutorial1.Controllers;

[ApiController]
public class BaseController<Model, ViewModel> : ControllerBase
 	where ViewModel : class, new()
	where Model : ViewModel, IBaseModel<ViewModel>
{
	protected readonly IService<Model, ViewModel> service;

	public BaseController(IService<Model, ViewModel> service) : base()
	{
		this.service = service;
	}

	protected BaseResponse HandleException(ApiException err)
	{
		var errResponse = new ResponseError(RequestMethod.GET);
		errResponse.Error.Code = err.Code;
		errResponse.Error.Message = err.Message;
		return errResponse;
	}

	protected async Task<BaseResponse> WithErrorHandlers(Func<Task<BaseResponse>> func)
	{
		try
		{
			return await func();
		}
		catch (ApiException err)
		{
			return HandleException(err);
		}
		catch (Exception err)
		{
			return HandleException(new ApiException(ResponseUtils.StatusCode.InternalServerError, err.Message));
		}
	}

	[HttpGet]
	public async Task<ActionResult<ResponseArray<ViewModel>>> ReadAll()
	{
		return Ok(await WithErrorHandlers(async () =>
		{
			var response = new ResponseArray<ViewModel>(RequestMethod.GET);
			var items = await service.ReadAll();
			response.Data = new(items.ConvertAll(i => (ViewModel)i!));
			return response;
		}));
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<ResponseObject<ViewModel>>> ReadOne(int id)
	{
		return Ok(await WithErrorHandlers(async () =>
		{
			var response = new ResponseObject<ViewModel>(RequestMethod.GET);
			response.Data = await service.ReadOne(id);
			return response;
		}));
	}

	[HttpPost]
	public async Task<ActionResult<ResponseObject<ViewModel>>> CreateOne(ViewModel newItem)
	{
		return Ok(await WithErrorHandlers(async () =>
		{
			var response = new ResponseObject<ViewModel>(RequestMethod.POST);
			response.Data = await service.CreateOne(newItem);
			return response;
		}));
	}

	[HttpPut("{id}")]
	public async Task<ActionResult<ResponseObject<ViewModel>>> UpdateOne(int id, ViewModel newItem)
	{
		return Ok(await WithErrorHandlers(async () =>
		{
			var response = new ResponseObject<ViewModel>(RequestMethod.PUT);
			response.Data = await service.UpdateOne(id, newItem);
			return response;
		}));
	}

	[HttpDelete("{id}")]
	public async Task<ActionResult<ResponseObject<bool>>> DeleteOne(int id)
	{
		return Ok(await WithErrorHandlers(async () =>
		{
			var response = new ResponseObject<bool>(RequestMethod.PUT);
			response.Data = await service.DeleteOne(id);
			return response;
		}));
	}
}