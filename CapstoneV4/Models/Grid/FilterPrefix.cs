//this model class is essentially a 'helper' class that 
//will help create prefixes in slugs/route that will
//specify the respective filter (class, price, day)


namespace CapstoneV4.Models.Grid
{
    public static class FilterPrefix
    {
        public const string Genre = "genre-";
        public const string Price = "price-";
        public const string Author = "author-";
    }
}
