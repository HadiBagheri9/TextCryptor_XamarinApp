using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using System.Text;
using static Android.Views.View;

namespace TextCryptor
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, IOnClickListener
    {
        Button btnEcrpt, btnDcrpt;
        EditText txtInpt, txtRslt;

        StringBuilder inpt = new StringBuilder("");
        StringBuilder rslt = new StringBuilder("");

        int flag = 0;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            btnEcrpt = FindViewById<Button>(Resource.Id.btnEcrpt);
            btnEcrpt.SetOnClickListener(this);
            btnDcrpt = FindViewById<Button>(Resource.Id.btnDcrpt);
            btnDcrpt.SetOnClickListener(this);

            txtInpt = FindViewById<EditText>(Resource.Id.txtInpt);
            txtRslt = FindViewById<EditText>(Resource.Id.txtRslt);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.btnEcrpt)
            {

            }
            else if (v.Id == Resource.Id.btnDcrpt)
            {

            }
        }
    }
}