# Xamarin.Forms Firebase PhoneAuth

Basic phone number authentication demo using Firebase.

*e.g. +9170XXXXXXXX phone number should contain country code (+91 is for India)*

# Dependency

#### Nuget [Plugin.Firebase](https://www.nuget.org/packages/Plugin.Firebase/)

> Install-Package Plugin.Firebase

# Configuration

After installing the mentioned plugin we need to initialize the plugin in respective platform as mentioned below.

#### For Android

In MainActivity.cs

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            CrossFirebase.Initialize(this, savedInstanceState, CreateCrossFirebaseSettings());//Initializing plugin
            HandleIntent(Intent);
            LoadApplication(new App());
        }

        private static CrossFirebaseSettings CreateCrossFirebaseSettings()
        {
            return new CrossFirebaseSettings(
                isAnalyticsEnabled:true,
                isAuthEnabled:true,
                isCloudMessagingEnabled:true,
                isDynamicLinksEnabled: true,
                isFirestoreEnabled: true,
                isFunctionsEnabled: true,
                isRemoteConfigEnabled: true,
                isStorageEnabled: true
                //facebookId: "", //Facebook client id
                //facebookAppName: "", // App Name over facebook
                //googleRequestIdToken: ""
                );
        }

#### For Android

In AppDelegate.cs

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            CrossFirebase.Initialize(app, options, CreateCrossFirebaseSettings());
            LoadApplication(new App());
            return base.FinishedLaunching(app, options);
        }

        private CrossFirebaseSettings CreateCrossFirebaseSettings()
        {
            return new CrossFirebaseSettings(
               isAnalyticsEnabled: true,
               isAuthEnabled: true,
               isCloudMessagingEnabled: true,
               isDynamicLinksEnabled: true,
               isFirestoreEnabled: true,
               isFunctionsEnabled: true,
               isRemoteConfigEnabled: true,
               isStorageEnabled: true
               //facebookId: "",//set facebook id created for app
               //facebookAppName: "",//app name
               //googleRequestIdToken: "" //set google request id
               );
        }

# Note

Add GoogleService-Info.plist(for iOS) and google-services.json(for Android)and set their build action.

### For iOS

*GoogleService-Info.plist* in your ProjectName.iOS project and set Bundle Action *BundleResource*

### For Android

Add *google-services.json* to the app project and set the Build Action to *GoogleServicesJson*
