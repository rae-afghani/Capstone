using CapstoneV4.Models.Grid;

namespace CapstoneV4.Models.ViewModels
{
    public class ProgramListVM
    {
        public IEnumerable<DomainModels.Program> Programs { get; set; }
        public RouteDictionary CurrentRoute { get; set; }
        public int TotalPages { get; set; }
    }
}
