using System.Linq;
using System.Collections.Generic;
using System;

namespace ConstructionLine.CodingChallenge
{
    public class SearchEngine
    {
        private readonly List<Shirt> _shirts;

        public SearchEngine(List<Shirt> shirts)
        {
            _shirts = shirts;
        }


        public SearchResults Search(SearchOptions options)
        {
            if (options == null || options.Colors == null || options.Sizes == null)
                throw new ArgumentException("SearchOptions");

            var shirtArray = _shirts.ToArray();

            var discoveredShirts = (from shirt in shirtArray.AsParallel()
                                   .WithMergeOptions(ParallelMergeOptions.NotBuffered)
                                   .WithDegreeOfParallelism(Environment.ProcessorCount)
                                    where options.Colors.Any(x => x == shirt.Color)
                                         && options.Sizes.Any(x => x == shirt.Size)
                                    select new { Shirt = shirt, shirt.Size, shirt.Color }).ToArray();

            var searchResults = new SearchResults
            {
                Shirts = discoveredShirts.Select(x => x.Shirt).ToList(),
                ColorCounts = (from discoveredShirt in discoveredShirts
                               group discoveredShirt by discoveredShirt.Color
                               into colorGroup
                               select new ColorCount { Color = colorGroup.Key, Count = colorGroup.Count() })
                               .ToList(),
                SizeCounts = (from discoveredShirt in discoveredShirts
                              group discoveredShirt by discoveredShirt.Size
                              into sizeGroup
                              select new SizeCount { Size = sizeGroup.Key, Count = sizeGroup.Count() })
                              .ToList()
            };

            foreach (var missingColor in Color.All.Where(color => !searchResults.ColorCounts.Any(x => x.Color == color)))
                searchResults.ColorCounts.Add(new ColorCount { Color = missingColor, Count = 0 });

            foreach (var missingSize in Size.All.Where(size => !searchResults.SizeCounts.Any(x => x.Size == size)))
                searchResults.SizeCounts.Add(new SizeCount { Size = missingSize, Count = 0 });

            return searchResults;
        }
    }
}