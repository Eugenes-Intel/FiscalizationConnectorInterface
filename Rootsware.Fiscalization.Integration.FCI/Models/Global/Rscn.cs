namespace Rootsware.Fiscalization.Integration.FCI.Models.Global;

/// <summary>
///     A
///     model
///     that
///     holds
///     constant
///     result
///     messages
///     for
///     operations,
///     processes
///     and/or
///     request.
/// </summary>
internal class Rscn
{
    /// <summary>
    ///     Internal
    ///     System
    ///     Exception.
    ///     -->
    ///     Desrialization
    ///     Error
    /// </summary>
    public const string ISE17 = "DESERIALIZATION ERROR";

    /// <summary>
    ///     Global
    ///     Handle
    ///     Failed
    ///     (GPF).
    ///     -->
    ///     Failed
    ///     to
    ///     handle
    ///     response.
    ///     Possible
    ///     reason
    ///     null
    ///     response
    ///     entity
    /// </summary>
    public const string GHF13 = "NULL CONTENT RESPONSE";

    /// <summary>
    ///     Socket
    ///     Connection
    ///     Error
    ///     (SCE).
    ///     -->
    ///     Disposed
    ///     connection
    ///     instance
    ///     error.
    ///     Possible
    ///     reasons:
    ///     an
    ///     attempt
    ///     was
    ///     made
    ///     to
    ///     access
    ///     a
    ///     an
    ///     unplanned
    ///     disposed
    ///     communication
    ///     instance.
    /// </summary>
    public const string SCE05 = "ACIE05: DISPOSED CONNECTION INSTANCE ERROR";
}