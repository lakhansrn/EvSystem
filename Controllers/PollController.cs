using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PollController:ControllerBase{

    IGeneralRepo generalRepo;

    public PollController(IGeneralRepo generalRepo)
    {
        this.generalRepo=generalRepo;
    }

    [HttpGet]
    public IEnumerable<Poll> GetPoll()
    {
        return Enumerable.Range(1, 5).Select(index => new Poll{
            PollId = Guid.NewGuid(),
            Description = $"MyLife{index}"
        })
        .ToArray();
    }

    [HttpPut]
    public void PutPoll(Poll poll){

    }
}