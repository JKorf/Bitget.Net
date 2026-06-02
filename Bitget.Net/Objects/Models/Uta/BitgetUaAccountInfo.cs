using System;
using System.Text.Json.Serialization;
using Bitget.Net.Enums;

namespace Bitget.Net.Objects.Models;

/// <summary>
/// Account info
/// </summary>
public record BitgetUaAccountInfo
{
    /// <summary>
    /// ["<c>userId</c>"] User id
    /// </summary>
    [JsonPropertyName("userId")]
    public string UserId { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>inviterId</c>"] Inviter id
    /// </summary>
    [JsonPropertyName("inviterId")]
    public string InviterId { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>parentId</c>"] Parent id
    /// </summary>
    [JsonPropertyName("parentId")]
    public string ParentId { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>channelCode</c>"] Channel code
    /// </summary>
    [JsonPropertyName("channelCode")]
    public string ChannelCode { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>channel</c>"] Channel
    /// </summary>
    [JsonPropertyName("channel")]
    public string Channel { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>ips</c>"] Ips
    /// </summary>
    [JsonPropertyName("ips")]
    public string Ips { get; set; } = string.Empty;
    /// <summary>
    /// ["<c>permType</c>"] Permission type
    /// </summary>
    [JsonPropertyName("permType")]
    public PermissionType PermissionType { get; set; }
    /// <summary>
    /// ["<c>permissions</c>"] Permissions
    /// </summary>
    [JsonPropertyName("permissions")]
    public string[] Permissions { get; set; } = [];
    /// <summary>
    /// ["<c>regisTime</c>"] Registration time
    /// </summary>
    [JsonPropertyName("regisTime")]
    public DateTime RegistrationTime { get; set; }
}

