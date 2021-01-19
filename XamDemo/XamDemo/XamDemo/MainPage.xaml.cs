using System;
using Plugin.Firebase.Auth;
using Plugin.Firebase.Common;
using Xamarin.Forms;
using XamDemo.Views;

namespace XamDemo
{
    public partial class MainPage : ContentPage
    {
        private readonly Lazy<IFirebaseAuth> _firebaseAuth;
        private IFirebaseAuth _fireAuth;
        public MainPage()
        {
            InitializeComponent();
            _firebaseAuth = new Lazy<IFirebaseAuth>(CreateFirebaseAuth);
        }
        private static IFirebaseAuth CreateFirebaseAuth() =>
            CrossFirebaseAuth.Current;
        async void ClickMe(System.Object sender, System.EventArgs e)
        {
            try
            {
                _fireAuth = _firebaseAuth.Value;
                await _fireAuth.VerifyPhoneNumberAsync(phoneEntry.Text);
                await Navigation.PushAsync(new OTPVerifyPage(_fireAuth));
            }
            catch (FirebaseException ex)
            {
                await DisplayAlert("Error", ex.Message, "Okay");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Okay");
            }
        }
    }
}
