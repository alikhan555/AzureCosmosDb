using Microsoft.Azure.Cosmos;

namespace CosmosDb.SqlApi
{
    public class SqlApiHandler<T> where T : class
    {
        private CosmosClient _client;

        public SqlApiHandler(string connectionString)
        {
            _client = new CosmosClient(connectionString);    
        }

        public async Task CreateDatabaseIfNotExistsAsync(string databaseName)
        {
            await _client.CreateDatabaseIfNotExistsAsync(databaseName);
        }

        public async Task CreateContainerIfNotExistsAsync(string databaseName, string containerName, string partitionKeyPath)
        {
            Database database = _client.GetDatabase(databaseName);
            await database.CreateContainerIfNotExistsAsync(containerName, partitionKeyPath);
        }

        public async Task DeleteContainerAsync(string databaseName, string containerName, string id)
        {
            Database database = _client.GetDatabase(databaseName);
            Container container = database.GetContainer(containerName);
            await container.DeleteContainerAsync();
        }

        public async Task CreateItemAsync(string databaseName, string containerName, T item, string partitionKeyValue)
        {
            Database database = _client.GetDatabase(databaseName);
            Container container = database.GetContainer(containerName);
            await container.CreateItemAsync<T>(item, new PartitionKey(partitionKeyValue));
        }

        public async Task CreateBulkItemAsync(string databaseName, string containerName, List<T> items, string partitionKeyPropertyName)
        {
            Database database = _client.GetDatabase(databaseName);
            Container container = database.GetContainer(containerName);
            await Task.WhenAll(items.Select(x => container.CreateItemAsync<T>(x, new PartitionKey(items.First().GetType().GetProperty(partitionKeyPropertyName)?.GetValue(x)?.ToString() ?? string.Empty))));
        }

        public async Task DeleteItemAsync(string databaseName, string containerName, string id, string partitionKeyValue)
        {
            Database database = _client.GetDatabase(databaseName);
            Container container = database.GetContainer(containerName);
            await container.DeleteItemAsync<T>(id, new PartitionKey(partitionKeyValue));
        }

        public async Task<List<T>> QueryItems(string databaseName, string containerName, string query)
        {
            Database database = _client.GetDatabase(databaseName);
            Container container = database.GetContainer(containerName);

            QueryDefinition queryDefinition = new QueryDefinition(query);
            FeedIterator<T> feedIterator = container.GetItemQueryIterator<T>(queryDefinition);

            List<T> allItems = new();

            while (feedIterator.HasMoreResults)
            {
                FeedResponse<T> items = await feedIterator.ReadNextAsync();
                allItems.AddRange(items.ToList());
            }

            return allItems;
        }

        public async Task<T> ReadItemAsync(string databaseName, string containerName, string id, string partitionKey)
        {
            Database database = _client.GetDatabase(databaseName);
            Container container = database.GetContainer(containerName);
            T item = await container.ReadItemAsync<T>(id, new PartitionKey(partitionKey));
            return item;
        }

        public async Task UpdateItemAsync(string databaseName, string containerName, string id, string partitionKey, T item)
        {
            Database database = _client.GetDatabase(databaseName);
            Container container = database.GetContainer(containerName);
            await container.ReplaceItemAsync<T>(item, id, new PartitionKey(partitionKey));
        }
    }
}
