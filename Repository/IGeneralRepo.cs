public interface IGeneralRepo
{
    Task CreatePollAsync(Poll poll);
    Task<Organizer> CreateOrganizerAsync(Organizer org);
    Task<IEnumerable<Organizer>> GetOrganizersAsync();
}
