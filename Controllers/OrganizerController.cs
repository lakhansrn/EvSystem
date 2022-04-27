using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class OrganizerController:ControllerBase{

IGeneralRepo repo;
public OrganizerController(IGeneralRepo repo)
{
    this.repo = repo;
}
[HttpGet("GetOrganizer")]
public async Task<ActionResult<IEnumerable<Organizer>>> GetOrganizers(){
    // IEnumerable<Organizer> organizers=null;
    var results = await repo.GetOrganizersAsync();
    return CreatedAtAction(nameof(GetOrganizers), results);
}

[HttpPut]
[ProducesResponseType(StatusCodes.Status201Created)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Organizer>> PutOrganizer(Organizer organizer){
    var result =  await repo.CreateOrganizerAsync(organizer);
        return CreatedAtAction(nameof(PutOrganizer), result);
}

}