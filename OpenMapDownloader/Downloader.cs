using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace OpenMapDownloader
{
	public partial class Downloader : Form
	{
		private List<MapTile> mapTiles = new();
		private List<MapTile> notLoadedMapTiles = new();

		public Downloader()
		{
			InitializeComponent();
		}

		private void loadJsonBtn_Click(object sender, EventArgs e)
		{
			using var sfd = new OpenFileDialog();
			sfd.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
			sfd.FilterIndex = 1;
			sfd.Title = "Select JSON file";

			if (sfd.ShowDialog() == DialogResult.OK)
			{
				var json = File.ReadAllText(sfd.FileName);
				mapTiles = JsonSerializer.Deserialize<List<MapTile>>(json)!;
				TxtRemainingMapsToBeDownloaded.Text = mapTiles.Count.ToString();
			}
		}

		private async void startDownloadingBtn_Click(object sender, EventArgs e)
		{

			var parallelOptions = new ParallelOptions
			{
				MaxDegreeOfParallelism = Convert.ToInt32(txtMaxDegreeOfParallelism.Text)
			};

			await Parallel.ForEachAsync(
				mapTiles,
				parallelOptions,
				async (mapTile, token) =>
						{

							var url = textBox1.Text;
							url = url.Replace("{x}", mapTile.X.ToString())
								.Replace("{y}", mapTile.Y.ToString())
								.Replace("{z}", mapTile.Z.ToString());
							var uri = new Uri(url);

							var dirName = $@"Out\{mapTile.Z}\{mapTile.X}\";
							Directory.CreateDirectory(dirName);
							var fileName = $"{dirName}{mapTile.Y}.png";

							if (File.Exists(fileName))
							{
								Log(fileName + "[] Already There!");
								Invoke(new Action(delegate
								{
									TxtRemainingMapsToBeDownloaded.Text =
										(Convert.ToInt32(TxtRemainingMapsToBeDownloaded.Text) - 1).ToString();
								}));
								return;
							}

							try
							{
								using var client = new HttpClient();
								var response = await client.GetAsync(url, token);

								if (response.IsSuccessStatusCode)
								{
									await using var s = await client.GetStreamAsync(uri, token);
									await using var fs = new FileStream(fileName, FileMode.CreateNew);
									await s.CopyToAsync(fs, token);
									Log(fileName + "[] Saved");
								}
								else
								{
									throw new FileNotFoundException();
								}
							}
							catch (Exception eX)
							{
								Log(fileName + "[]" + eX.Message);
							}

							Invoke(new Action(delegate
							{
								TxtRemainingMapsToBeDownloaded.Text =
									(Convert.ToInt32(TxtRemainingMapsToBeDownloaded.Text) - 1).ToString();
							}));
						});

		}

		void Log(string message)
		{
			Invoke(new Action(delegate
			{
				richTextBox1.AppendText(message + Environment.NewLine);
			}));
		}
	}
}
