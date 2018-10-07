namespace BlazorUtils.Interfaces
{
    /// <summary>
    /// Interface for Dom.
    /// </summary>
    public interface IDom
    {
        /// <summary>
        /// Get selector that was used as the parameter of _() method.
        /// </summary>
        /// <returns></returns>
        string Selector();
    }
}
