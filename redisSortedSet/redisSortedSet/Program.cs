// See https://aka.ms/new-console-template for more information

// Connect to Redis
using StackExchange.Redis;

ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("127.0.0.1:6379,ssl=false");
IDatabase db = redis.GetDatabase();

// Use current timestamp as the score
double timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

// Add items to the sorted set with scores
db.SortedSetAdd("mySortedSet", "item1", timestamp);
db.SortedSetAdd("mySortedSet", "item2", timestamp + 10);
db.SortedSetAdd("mySortedSet", "item3", timestamp + 20);

// Retrieve items from the sorted set
var items = db.SortedSetRangeByRankWithScores("mySortedSet", 0, 1, Order.Descending);
foreach(var item in items) {
    Console.WriteLine($"Item: {item.Element}, Score: {item.Score}");
}

// Update score of an item
db.SortedSetRemoveRangeByRank("mySortedSet", 0, -2); // keep only 1 element

//check again after remove
var remainingElements = db.SortedSetRangeByRankWithScores("mySortedSet", 0, 1, Order.Descending);
foreach(var item in remainingElements) {
    Console.WriteLine($"Item: {item.Element}, Score: {item.Score}");
}
Console.WriteLine("Hello, World!");
