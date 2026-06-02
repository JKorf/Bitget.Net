using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums.Uta;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// Withdrawal address book
/// </summary>
public record BitgetUaAddressBook
{
    /// <summary>
    /// ["<c>addressList</c>"] Addresses
    /// </summary>
    [JsonPropertyName("addressList")]
    public BitgetUaAddressBookEntry[] Addresses { get; set; } = [];
    /// <summary>
    /// ["<c>cursor</c>"] Cursor
    /// </summary>
    [JsonPropertyName("cursor")]
    public string Cursor { get; set; } = string.Empty;
}

/// <summary>
/// Book entry
/// </summary>
public record BitgetUaAddressBookEntry
{
    /// <summary>
    /// ["<c>coin</c>"] Asset
    /// </summary>
    [JsonPropertyName("coin")]
    public string Asset { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>chain</c>"] Network
    /// </summary>
    [JsonPropertyName("chain")]
    public string Network { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>address</c>"] Address
    /// </summary>
    [JsonPropertyName("address")]
    public string Address { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>countryCode</c>"] Country code
    /// </summary>
    [JsonPropertyName("countryCode")]
    public string? CountryCode { get; set; }
    /// <summary>
    /// ["<c>label</c>"] Label
    /// </summary>
    [JsonPropertyName("label")]
    public string Label { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>memo</c>"] Memo
    /// </summary>
    [JsonPropertyName("memo")]
    public string? Memo { get; set; }
    /// <summary>
    /// ["<c>type</c>"] Type
    /// </summary>
    [JsonPropertyName("type")]
    public AddressBookType Type { get; set; }
    /// <summary>
    /// ["<c>internalType</c>"] Internal type
    /// </summary>
    [JsonPropertyName("internalType")]
    public string? InternalType { get; set; }
    /// <summary>
    /// ["<c>createdTime</c>"] Create time
    /// </summary>
    [JsonPropertyName("createdTime")]
    public DateTime CreateTime { get; set; }
}

