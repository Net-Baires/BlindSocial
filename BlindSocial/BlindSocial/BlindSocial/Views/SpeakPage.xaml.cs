using System.Linq;
using System.Threading.Tasks;
using Plugin.TextToSpeech;
using Plugin.TextToSpeech.Abstractions;
using Xamarin.Forms;

namespace BlindSocial.Views
{
    public partial class SpeakPage : ContentPage
    {
        public SpeakPage()
        {
            InitializeComponent();

            Task.Run(async() => {
				var languages = await CrossTextToSpeech.Current.GetInstalledLanguages();

				CrossLocale? selectedLanguage = languages.Where(x => x.Language == "es" && x.Country == "ES").FirstOrDefault();

				string text = "Hola mundo ! Somos el equipo Net Baires.";

				await CrossTextToSpeech.Current.Speak(text, selectedLanguage);
            });
			
        }
    }
}
