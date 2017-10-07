using System;
using System.Linq;
using System.Threading.Tasks;
using Plugin.TextToSpeech;
using Plugin.TextToSpeech.Abstractions;
using Xamarin.Forms;

namespace BlindSocial.Views
{
    public partial class SpeakPage : ContentPage
    {
        CrossLocale? selectedLanguage;


        public SpeakPage()
        {
            InitializeComponent();

            Task.Run(async() => {
				var languages = await CrossTextToSpeech.Current.GetInstalledLanguages();

				selectedLanguage = languages.Where(x => x.Language == "es" && x.Country == "ES").FirstOrDefault();

                await speakText("Hola mundo ! Somos el equipo Net Baires.");
            });
        }

        private bool tapHandled;

        void OnSingleTapGestureRecognizerTappedAsync(object sender, EventArgs args)
        {
            tapHandled = false;
            Xamarin.Forms.Device.StartTimer(new TimeSpan(0, 0, 0, 0, 300), taptimer);
        }

        async Task OnDoubleTapGestureRecognizerTapped(object sender, EventArgs args)
		{
            tapHandled = true;
            await DisplayAlert("Camara","Flash !","Click");
		}

        async Task speakText(string text) {
			await CrossTextToSpeech.Current.Speak(text, selectedLanguage);
        }

		private bool taptimer()
		{
			if (!tapHandled)
			{
				tapHandled = true;
                Task.Run(async()=>{
                    await speakText("Hola mundo ! Somos el equipo Net Baires.");
                });
			
			}
			return false;
		}
	}
}
