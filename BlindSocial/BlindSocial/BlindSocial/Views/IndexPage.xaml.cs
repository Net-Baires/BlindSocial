using BlindSocial.Services;
using Plugin.Media;
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BlindSocial.Views
{
    public partial class IndexPage : ContentPage
    {
        ApiService apiService;

        public IndexPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();

            apiService = new ApiService("api/BlindSocial", string.Empty);
        }

        async void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        {
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                Directory = "Sample",
                Name = $"test{ DateTime.Now.Ticks }.jpg"
            });

            if (file == null)
                return;

            var s = file.GetStream();
            byte[] b;
            using (BinaryReader br = new BinaryReader(s))
            {
                b = br.ReadBytes((int)s.Length);
            }

            var text = await apiService.Analize(b);
            //App.Current.MainPage = new SpeakPage(text);

            await Navigation.PushModalAsync(new SpeakPage(text));
        }

        //static CloudBlobContainer GetContainer(ContainerType containerType)
        //{
        //    var account = CloudStorageAccount.Parse(Constants.StorageConnection);
        //    var client = account.CreateCloudBlobClient();
        //    return client.GetContainerReference(containerType.ToString().ToLower());
        //}

        //public static async Task<string> UploadFileAsync(ContainerType containerType, Stream stream)
        //{
        //    var container = GetContainer(containerType);
        //    await container.CreateIfNotExistsAsync();

        //    var name = Guid.NewGuid().ToString();
        //    var fileBlob = container.GetBlockBlobReference(name);
        //    await fileBlob.UploadFromStreamAsync(stream);

        //    return name;
        //}
    }
}
