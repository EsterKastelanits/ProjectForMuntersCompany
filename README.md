URLS:
https://localhost:44322/api/Giphy/GetTrendingGifsUrls
https://localhost:44322/api/Giphy/GetSearchGifsUrls?searchInput=cats
https://localhost:44322/api/Giphy/GetTrendingGifsUrlOfSpecificDay?date=2022-12-29%2000%3A00%3A00

I implement the application in .NET Core.

(I didn't do UI because I'm more focused on the back side)

Using design pattern of dependency injection.

Safe concurrent operations - using async await.

In GiphyManager - Method for each fetch method,
(adding option to get Trending gifs Url's for specific date)

The code seperate to methods, each method is responsible for something precise, like CreateHttpRequest...
in addition, the method is generic so I can run it for all HttpRequest.

