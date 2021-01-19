using System;
using System.Collections.Generic;
using Plugin.Firebase.Auth;
using Xamarin.Forms;

namespace XamDemo.Views
{
    public partial class HomePage : ContentPage
    {
        private IFirebaseUser _firebaseUser;
        public HomePage(IFirebaseUser _fireUser)
        {
            InitializeComponent();
            this._firebaseUser = _fireUser;
            this.labelUserDetail.Text = this._firebaseUser.ToString();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
