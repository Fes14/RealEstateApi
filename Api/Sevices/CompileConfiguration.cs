namespace Api.Sevices
{
    public class CompileConfiguration
    {
        /// <summary>
        /// Return path to appsettings
        /// </summary>
        /// <returns></returns>
        public string GetConfiguration()
        {
#if DEBUG
            return "appsettings.Development.json";
#endif

#if RELEASE
            return "appsettings.Production.json"
#endif

        }
    }
}
