namespace Rootsware.Fiscalization.Integration.FCI.Models.Global;

internal class RequestResult<T> where T : class, IRequestResult
{
    /// <summary>
    ///     Transaction
    ///     result
    ///     status.
    ///     If
    ///     success
    ///     then
    ///     ==
    ///     <see
    ///         langword="true" />
    ///     else
    ///     <see
    ///         langword="false" />
    /// </summary>
    public bool Trst { get; set; }

    /// <summary>
    ///     A
    ///     generic
    ///     response
    ///     model.
    ///     Contains
    ///     the
    ///     response
    ///     data
    /// </summary>
    public T? Value { get; set; }

    /// <summary>
    ///     Optional
    ///     transactional
    ///     comment
    ///     that
    ///     contains
    ///     any
    ///     information
    ///     describing
    ///     the
    ///     result
    ///     of
    ///     the
    ///     transaction
    /// </summary>
    public string Message { get; set; }
}