using Android.App;
using Android.Widget;
using Android.OS;

namespace signalR.Droid
{
    [Activity(Label = "signalR", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            Button button = FindViewById<Button>(Resource.Id.myButton);
            TextView counter = FindViewById<TextView>(Resource.Id.textView1);
        
            //SIGNAL-R CONNECTION
            var hubConnection = new HubConnection("http://startupwork.in");

            // Create a proxy to the 'ChatHub' SignalR Hub
            var chatHubProxy = hubConnection.CreateHubProxy("notificationHub");

            // Wire up a handler for the 'UpdateChatMessage' for the server
            // to be called on our client
            chatHubProxy.On<string>("update", () => " make api call to http://startupwork.in/api/live" );
       }
    }
}

