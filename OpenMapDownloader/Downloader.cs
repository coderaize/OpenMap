using System;
using System.Net;
using System.Net.Mime;
using System.Text.Json;

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

        private void startDownloadingBtn_Click(object sender, EventArgs e)
        {
            Parallel.ForEach(mapTiles, new ParallelOptions { MaxDegreeOfParallelism = 10 }, (mapTile) =>
            {
                try
                {

                    var url = textBox1.Text;
                    url = url.Replace("{x}", mapTile.X.ToString())
                            .Replace("{y}", mapTile.Y.ToString())
                            .Replace("{z}", mapTile.Z.ToString());
                    var uri = new Uri(url);
                    
                    var dirName = $@"Out\{mapTile.Z}\{mapTile.X}\"; 
                    Directory.CreateDirectory(dirName);
                    var fileName = mapTile.Y.ToString() + ".png";

                    var webClient = new WebClient();
                    webClient.DownloadFile(url,dirName+fileName);

                    //using var client = new HttpClient();

                    //var response = client.GetAsync(url).GetAwaiter().GetResult();
                    //if (response.IsSuccessStatusCode)
                    //{
                        
                    //    using var s = client.GetStreamAsync(uri).GetAwaiter().GetResult();
                    //    using var fs = new FileStream(dirName + fileName, FileMode.CreateNew);
                    //    s.CopyToAsync(fs);
                    //}
                    //else
                    //{
                    //    throw new FileNotFoundException();
                    //}
                }
                catch (Exception eX)
                {
                    Invoke(new Action(delegate
                    {
                        richTextBox1.AppendText(eX.Message + Environment.NewLine);
                    }));
                }

                Invoke(new Action(delegate
                {
                    TxtRemainingMapsToBeDownloaded.Text = (Convert.ToInt32(TxtRemainingMapsToBeDownloaded.Text) - 1).ToString();
                }));
            });
        }
    }
}
