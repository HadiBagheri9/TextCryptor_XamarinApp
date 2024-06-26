using System;
using Android.OS;
using System.Text;
using Android.App;
using Android.Views;
using Android.Widget;
using Android.Runtime;
using AndroidX.AppCompat.App;

namespace TextCryptor
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, View.IOnClickListener
    {
        Button btnEcrpt, btnDcrpt;
        EditText txtInpt, txtRslt;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            btnEcrpt = FindViewById<Button>(Resource.Id.btnEcrpt);
            btnDcrpt = FindViewById<Button>(Resource.Id.btnDcrpt);

            btnEcrpt.SetOnClickListener(this);
            btnDcrpt.SetOnClickListener(this);

            txtInpt = FindViewById<EditText>(Resource.Id.txtInpt);
            txtRslt = FindViewById<EditText>(Resource.Id.txtRslt);

            txtInpt.Click += TxtInpt_Click;
        }

        private void TxtInpt_Click(object sender, EventArgs e)
        {
            txtInpt.Text = "";
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
                txtRslt.Text = Enc(txtInpt.Text, 6);
            }
            else if (v.Id == Resource.Id.btnDcrpt)
            {
                txtRslt.Text = Dc(txtInpt.Text, 6);
            }
        }

        public string Enc(string text, int layers)
        {
            byte[] encodedBytes = Encoding.UTF8.GetBytes(text);
            string encodedString = Convert.ToBase64String(encodedBytes);
            string encS = encodedString;
            byte[] encB = Encoding.UTF8.GetBytes(encS);

            for (int i = 1; i < layers; i++)
            {
                encS = Convert.ToBase64String(encB);
                encB = Encoding.UTF8.GetBytes(encS);
            }

            return encS;

        }

        public string Dc(string text, int layers)
        {
            try
            {
                string decodedString = text;
                for (int i = 0; i < layers; i++)
                {
                    decodedString = Encoding.UTF8.GetString(Convert.FromBase64String(decodedString));

                }

                return decodedString;
            }
            catch (Exception ex)
            {
                Toast.MakeText(this.ApplicationContext, ex.Message, ToastLength.Long).Show();

                return "";
            }

        }
    }
}