using System;
using System.Collections.Generic;
using Plugin.Firebase.Auth;
using Plugin.Firebase.Common;
using Xamarin.Forms;

namespace XamDemo.Views
{
    public partial class OTPVerifyPage : ContentPage
    {
        private IFirebaseAuth _firebaseAuth;
        public OTPVerifyPage(IFirebaseAuth _fireAuth)
        {
            InitializeComponent();
            this._firebaseAuth = _fireAuth;
        }

        async void Verify_OTP(System.Object sender, System.EventArgs e)
        {
            try
            {
                //var result = await _firebaseAuth.LinkWithPhoneNumberVerificationCodeAsync(entryOTP.Text);
                
                var result = await _firebaseAuth.SignInWithPhoneNumberVerificationCodeAsync(entryOTP.Text);
                if (result != null && result.Uid != null)
                {
                    //await DisplayAlert("Success", "Firebase User Uid:" + result.Uid +", Provider:"+result.ProviderInfos, "Okay");

                    await Navigation.PushModalAsync(new HomePage(result));
                }
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
