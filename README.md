# Construction Line code challenge

The code challenge consists in the implementation of a simple search engine for shirts.

## What to do?
Shirts are in different sizes and colors. As described in the Size.cs class, there are three sizes: small, medium and large, and five different colors listed in Color.cs class.

The search specifies a range of sizes and colors in SearchOptions.cs. For example, for small, medium and red the search engine should return shirts that are either small or medium in size and are red in color. In this case, the SearchOptions should look like:

```
{
    Sizes = List<Size> {Size.Small, Size.Medium},
    Colors = List<Color> {Color.Red}
}
```

The results should include, as well as the shirts matching the search options, the total count for each search option taking into account the options that have been selected. For example, if there are two shirts, one small and red and another medium and blue, if the search options are small size and red color, the results (captured in SearchResults.cs) with total count for each option should be:
```
{
    Shirts = List<Shirt> { SmallRedShirt },
    SizeCounts = List<SizeCount> { Small(1), Medium(0), Large(0)},
    ColorCounts = List<ColorCount> { Red(1), Blue(0), Yellow(0), White(0), Black(0)}
}
```

The search engine logic sits in SearchEngine.cs and should be implemented by the candidate. Feel free to use any additional data structures, classes or libraries to prepare the data before the actual search. The initalisation of these should sit in the constructor of the search engine.

There are two tests in the test project; one simple search for red shirts out of a total of three, and another one which tests the performance of the search algorithm through 50.000 random shirts of all sizes and colors which measures how long it takes to perform the search algorithm. A reasonable implementation should not take more than a second to return the results.

## Procedure
We would like you to send us a link to a git repository that we can access with your implementation.

The whole exercise should not take more than an hour to implement.

## Performance Benchmark Test Results

5 000 000  
WITH PARALLEL  
Test fixture finished in 1781 milliseconds  
Test fixture finished in 1306 milliseconds  

WITHOUT PARALLEL  
Test fixture finished in 2431 milliseconds  
Test fixture finished in 1681 milliseconds  

500 000  
WITH PARALLEL  
Test fixture finished in 307 milliseconds  
Test fixture finished in 237 milliseconds  

WIHTOUT PARALLEL  
Test fixture finished in 286 milliseconds  
Test fixture finished in 193 milliseconds  

50 000  
WITH PARALLEL  
Test fixture finished in 112 milliseconds  
Test fixture finished in 43 milliseconds  

WITHOUT PARALLEL  
Test fixture finished in 76 milliseconds  
Test fixture finished in 20 milliseconds  