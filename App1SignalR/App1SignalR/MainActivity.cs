using Android.App;
using Android.OS;
using Microsoft.AspNet.SignalR.Client;
using System;
using Android.Widget;
using Android.Views;


namespace App1SignalR
{
    [Activity(Label = "App1SignalR", MainLauncher = true)]

    public class MainActivity : Activity
    {
        public string UserName { get; set; }
        public int BackgroungColor { get; private set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            GetInfo getinfo = new GetInfo();
            getinfo.OnGetInfoComplete += Getinfo_OnGetInfoCompleteAsync;
            getinfo.Show(FragmentManager, "GetInfo");
        }

        private async void Getinfo_OnGetInfoCompleteAsync(object sender, GetInfo.OnGetInfoCompleteEventArgs e)
        {
            UserName = e.TxtName;
            BackgroungColor = e.BackgroundColor;

            var hubConnection = new HubConnection("http://azuresignalrserver.azurewebsites.net/");
            var chatHubProxy = hubConnection.CreateHubProxy("ChatHub");

            chatHubProxy.On<string, int, string>("UpdateChatMessage", (message, color, user) =>
            {
                //UpdateChatMessage has been called from Sever  

                RunOnUiThread(() =>
                {
                    TextView txt = new TextView(this);
                    txt.Text = user + ": " + message;
                    txt.SetTextSize(Android.Util.ComplexUnitType.Sp, 20);
                    txt.SetPadding(10, 10, 10, 10);

                    switch (color)
                    {
                        case 1:
                            txt.SetTextColor(Android.Graphics.Color.Red);
                            break;
                        case 2:
                            txt.SetTextColor(Android.Graphics.Color.MediumSeaGreen);
                            break;
                        case 3:
                            txt.SetTextColor(Android.Graphics.Color.Blue);
                            break;
                        default:
                            txt.SetTextColor(Android.Graphics.Color.Black);
                            break;
                    }

                    txt.LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent)
                    {
                        TopMargin = 10,
                        BottomMargin = 10,
                        LeftMargin = 10,
                        RightMargin = 10,
                        Gravity = GravityFlags.Right
                    };

                    FindViewById<LinearLayout>(Resource.Id.llChatMessage).AddView(txt);

                });
            });

            try
            {
                await hubConnection.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            FindViewById<Button>(Resource.Id.btnSend).Click += async (o, e2) =>
            {
                var message = FindViewById<EditText>(Resource.Id.txtChat).Text;
                await chatHubProxy.Invoke("SendMessage", new object[] {
                    message, BackgroungColor, UserName });
            };
        }
    }
}

