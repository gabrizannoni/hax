namespace Hax
{
    public enum ValueState
    {
        Unknown = 0,
        UpToDate = 1,

        Reading = 10,
        ReadTimeout = 11,

        Writing = 20,
        WriteTimeout = 21,
    }
}