//this model class is essentially a 'helper' class that 
//will help create prefixes in slugs/route that will
//specify the respective filter (class, price, day)


namespace CapstoneV4.Models.Grid
{
    public static class FilterPrefix
    {
        public const string Topic = "topic-";
        public const string Tuition = "tuition-";
        public const string ProgramType = "prgm-";
    }
}
