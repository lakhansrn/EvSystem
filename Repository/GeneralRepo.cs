using Microsoft.Azure.Cosmos;

public class GeneralRepo : IGeneralRepo
{

    private readonly IConfiguration Configuration;
    private readonly string endPointUri;
    private readonly string key;
    private readonly ILogger<GeneralRepo> logger;
    private readonly string dbName = "EvsDb";
    private CosmosClient cosmosClient;
    private Database database;

    /// <summary>
    /// Creates an instance of a general Repo for test.
    /// </summary>
    /// <param name="configuration"></param>
    public GeneralRepo(IConfiguration configuration, ILogger<GeneralRepo> logger)
    {
        Configuration = configuration;
        endPointUri = Configuration["ev_db_uri"];
        key = Configuration["ev_db_key"];
        this.logger = logger;
    }

    public async Task<Organizer> CreateOrganizerAsync(Organizer org)
    {   org.OrganizerId = Guid.NewGuid();
         using (CosmosClient client = new CosmosClient(endPointUri, key, new CosmosClientOptions() { ApplicationName = "ElectronicVotingSystem" }))
        {
            DatabaseResponse databaseResponse = await client.CreateDatabaseIfNotExistsAsync(dbName);
            Database targetDatabase = databaseResponse.Database;
            logger.LogInformation($"Database Id:\t{targetDatabase.Id}");

            var containerProperties = new ContainerProperties("Organizers", "/id");
            containerProperties.IndexingPolicy.Automatic = true;
            containerProperties.IndexingPolicy.IndexingMode = IndexingMode.Consistent;
            var containerResponse = await targetDatabase.CreateContainerIfNotExistsAsync(containerProperties);
            var orgContainer = containerResponse.Container;
            return await orgContainer.CreateItemAsync<Organizer>(org);
        }
    }

    public async Task<IEnumerable<Organizer>> GetOrganizersAsync()
    {
         using (CosmosClient client = new CosmosClient(endPointUri, key, new CosmosClientOptions() { ApplicationName = "ElectronicVotingSystem" }))
        {
            DatabaseResponse databaseResponse = await client.CreateDatabaseIfNotExistsAsync(dbName);
            Database targetDatabase = databaseResponse.Database;
            logger.LogInformation($"Database Id:\t{targetDatabase.Id}");

            var orgContainer = databaseResponse.Database.GetContainer("Organizers");

            return orgContainer.GetItemLinqQueryable<Organizer>(allowSynchronousQueryExecution:true).ToList();

        }
    }
    public async Task CreatePollAsync(Poll poll)
    {
        
    }
}