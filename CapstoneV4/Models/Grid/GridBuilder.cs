using CapstoneV4.Models.DTOs;
using CapstoneV4.Models.ExtensionMethods;

namespace CapstoneV4.Models.Grid
{
    public class GridBuilder
    {
        private const string RouteKey = "currentroute";
        public RouteDictionary Routes { get; set; }
        public ISession Session { get; set; }

        public GridBuilder(ISession session)
        {
            Session = session;
            Routes = Session.GetObj<RouteDictionary>(RouteKey) ?? new RouteDictionary();
        }

        //generic sorting and filtering options
        public GridBuilder(ISession session, GridDTO griddto, string defaultSortField)
        {
            Session = session;
            Routes = new RouteDictionary();
            Routes.PageNumber = griddto.PageNumber;
            Routes.PageSize = griddto.PageSize;
            Routes.SortField = griddto.SortField ?? defaultSortField;
            Routes.SortDirection = griddto.SortDirection;

            SaveRouteEvent();
        }

        //saves route during session
        public void SaveRouteEvent() => Session.SetObj<RouteDictionary>(RouteKey, Routes);

        //calculates total pages
        public int GetPageAmt(int count)
        {
            int size = Routes.PageSize;
            return (count + size - 1) / size;
        }

        //will be initialized with all the new values per session
        public RouteDictionary CurrentRoute => Routes;
    }
}
