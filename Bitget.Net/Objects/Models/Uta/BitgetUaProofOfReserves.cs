using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// Proof of reserves
/// </summary>
public record BitgetUaProofOfReserves
{
    /// <summary>
    /// ["<c>merkleRootHash</c>"] Merkle root hash
    /// </summary>
    [JsonPropertyName("merkleRootHash")]
    public string MerkleRootHash { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>totalReserveRatio</c>"] Total reserve ratio
    /// </summary>
    [JsonPropertyName("totalReserveRatio")]
    public string TotalReserveRatio { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>list</c>"] Assets
    /// </summary>
    [JsonPropertyName("list")]
    public BitgetUaProofOfReservesAsset[] Assets { get; set; } = [];
}

/// <summary>
/// Asset info
/// </summary>
public record BitgetUaProofOfReservesAsset
{
    /// <summary>
    /// ["<c>coin</c>"] Asset
    /// </summary>
    [JsonPropertyName("coin")]
    public string Asset { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>userAssets</c>"] User assets
    /// </summary>
    [JsonPropertyName("userAssets")]
    public decimal UserAssets { get; set; }
    /// <summary>
    /// ["<c>platformAssets</c>"] Platform assets
    /// </summary>
    [JsonPropertyName("platformAssets")]
    public decimal PlatformAssets { get; set; }
    /// <summary>
    /// ["<c>reserveRatio</c>"] Reserve ratio
    /// </summary>
    [JsonPropertyName("reserveRatio")]
    public string ReserveRatio { get; set; } = string.Empty;
}

