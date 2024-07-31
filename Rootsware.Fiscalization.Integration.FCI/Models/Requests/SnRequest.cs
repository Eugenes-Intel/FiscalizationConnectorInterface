namespace Rootsware.Fiscalization.Integration.FCI.Models.Requests;

/// <summary>
///     A
///     model
///     for
///     parameters
///     used
///     in
///     device
///     SN
///     generation
/// </summary>
public class SnRequest
{
    public char Drive { get; set; }

    public string CompanyCode { get; set; }

    public string CompanyName { get; set; }

    public int Length { get; set; } = 0;
}