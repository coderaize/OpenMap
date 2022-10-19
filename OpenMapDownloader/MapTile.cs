using System.Text.Json.Serialization;

namespace OpenMapDownloader;

public class MapTile
{
	[JsonPropertyName("x")]
	public int X { get; set; }
	
	[JsonPropertyName("y")]
	public int Y { get; set; }
	
	[JsonPropertyName("z")]
	public int Z { get; set; }
}