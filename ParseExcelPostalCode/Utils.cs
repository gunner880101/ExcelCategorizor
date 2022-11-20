
namespace ParseExcelPostalCode
{
    public static class Utils
    {
        public static long GetCurrentTimestamp()
        {
            DateTime baseDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (long)(DateTime.Now.ToUniversalTime() - baseDate).TotalSeconds;
        }
    }
}
