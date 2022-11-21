



namespace CapstoneV4.Models.ViewModels
{

    //mark links as active
    public static class NavigationVM
    {
        public static string ActiveLink(string value, string state) => (value == state) ? "active" : "";

        public static string ActiveLink(int value, int state) => (value == state) ? "active" : "";


    }
}
