using Android.App;
using System;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using System.Text;
using static Android.Views.View;
using Android.Content;
using System.Security.Cryptography;
using System.IO;

namespace TextCryptor
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, IOnClickListener
    {
        Button btnEcrpt, btnDcrpt;
        EditText txtInpt, txtRslt;

        StringBuilder inpt = new StringBuilder("");
        StringBuilder rslt = new StringBuilder("");

#pragma warning disable CS0414 // The field 'MainActivity.flag' is assigned but its value is never used
        int flag = 0;
#pragma warning restore CS0414 // The field 'MainActivity.flag' is assigned but its value is never used
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
                txtRslt.Text = Enc(txtInpt.Text);
            }
            else if (v.Id == Resource.Id.btnDcrpt)
            {
                txtRslt.Text = Dc(txtInpt.Text);
            }
        }

        public string Enc(string text)
        {
            
            
            byte[] encodedBytes = Encoding.UTF8.GetBytes(text);
            string encodedString = Convert.ToBase64String(encodedBytes);
            return encodedString;
            
            

        }

        public string Dc(string text)
        {
            try
            {
                string decodedString = Encoding.UTF8.GetString(Convert.FromBase64String(text));

                return decodedString;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }
    }
}