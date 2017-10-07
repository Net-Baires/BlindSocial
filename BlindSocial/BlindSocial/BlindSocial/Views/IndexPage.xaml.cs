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

        void OnTapGestureRecognizerTapped(object sender, EventArgs args) {
            App.Current.MainPage = new SpeakPage();
        }
    }
}
