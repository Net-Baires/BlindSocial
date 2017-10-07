using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BlindSocial.Views
{
    public partial class IndexPage : ContentPage
    {
        public IndexPage()
        {
            InitializeComponent();
        }

        async void OnTapGestureRecognizerTapped(object sender, EventArgs args) {
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                Directory = "Sample",
                Name = "test.jpg"
            });

            if (file == null)
                return;

            DisplayAlert("File Location", file.Path, "OK");

            image.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });

            //App.Current.MainPage = new SpeakPage();
        }
    }
}
