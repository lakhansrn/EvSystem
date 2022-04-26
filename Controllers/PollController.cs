using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PollController:ControllerBase{

    [HttpGet(Name = "GetPoll")]
    public IEnumerable<Poll> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new Poll{
            PollId = index,
            Description = $"MyLife{index}"
        })
        .ToArray();
    }
}