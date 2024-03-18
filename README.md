# redis-sorted-set
Redis Sorted Sets are similar to Sets, with unique feature of values stored in Set called scores. The score is used in order to take the sorted set ordered, from the smallest to the greatest score. Just like in Sets, members are unique but scores can be repeated. Sorted Sets are ideal for storing index data in Redis, or using some of the Sorted Set commands to find out how many users have authenticated to a system, or top users using the system etc.

# redis-sorted-set with C#
You can use the StackExchange.Redis library to work with Redis in your application. Please check program.cs file regarding how you can use a sorted set to store data with scores using C#.
