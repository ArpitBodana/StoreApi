using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StoreApi;
[Route("api/[controller]")]
[ApiController]
public class StoreController : Controller
{
    private readonly IStore storeRepository;

    public StoreController(IStore storeRepository)
    {
        this.storeRepository = storeRepository;
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddStore([FromBody] AddUpdateStoreDto storeDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var storeModel = storeDto.ToStoreFromAddUpdateStoreDto();

        storeModel = await storeRepository.AddStore(storeModel);

        var storeDTO = storeModel.ToStoreDto();

        // return Ok(storeDTO);

        return CreatedAtAction(nameof(GetStoreDetailsById), new { Id = storeDTO.Id }, storeDTO);

    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetStoresDetails([FromQuery] QueryObject query)
    {
        var allStores = await storeRepository.GetStores(query);

        var storesDto = allStores.Select(x => x.ToStoreDto());
        return Ok(storesDto);
    }

    [HttpGet]
    [Authorize]
    [Route("{Id:Guid}")]
    public async Task<IActionResult> GetStoreDetailsById([FromRoute] Guid Id)
    {
        var store = await storeRepository.GetStoreById(Id);
        if (store == null)
        {
            return NotFound();
        }
        return Ok(store.ToStoreDto());
    }
    [HttpPut]
    [Authorize]
    [Route("{Id:Guid}")]
    public async Task<IActionResult> UpdateStoreDetails([FromRoute] Guid Id, [FromBody] AddUpdateStoreDto storeDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var StoreModel = storeDto.ToStoreFromAddUpdateStoreDto();
        StoreModel = await storeRepository.UpdateStore(Id, StoreModel);
        if (StoreModel == null)
        {
            return NotFound();
        }

        var store = StoreModel.ToAddUpdateStoreDto();
        return Ok(store);
    }

    [HttpDelete]
    [Authorize]
    [Route("{Id:Guid}")]
    public async Task<IActionResult> DeleteStore([FromRoute] Guid Id)
    {
        var store = await storeRepository.DeleteStore(Id);
        if (store == null)
        {
            return NotFound();
        }
        return Ok(store.ToStoreDto());
    }
}
