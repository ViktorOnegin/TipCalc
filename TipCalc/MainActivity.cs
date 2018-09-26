using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace TipCalc
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TextView tip;
        TextView tipAmount;
        TextView totalAmount;
        EditText billAmountValue;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var calculateBtn = FindViewById<Button>(Resource.Id.calculateBtn);
            var seekBar1 = FindViewById<SeekBar>(Resource.Id.seekBar1);
            tip = FindViewById<TextView>(Resource.Id.tip2);
            tipAmount = FindViewById<TextView>(Resource.Id.tipAmount2);
            totalAmount = FindViewById<TextView>(Resource.Id.totalAmount2);
            billAmountValue = FindViewById<EditText>(Resource.Id.editText);

            seekBar1.ProgressChanged += SeekBar1_ProgressChanged;
            calculateBtn.Click += CalculateBtn_Click;
        }

        private void SeekBar1_ProgressChanged(object sender,SeekBar.ProgressChangedEventArgs e)
        {
            tip.Text = e.Progress.ToString();
        }

        private void CalculateBtn_Click(object sender, System.EventArgs e)
        {
            Calculate();
        }

        private void Calculate()
        {
            //Tip Amount = bill amount * Tip / 100
            //Total Amount = bill amount + Tip amount

            float Tip = float.Parse(tip.Text) / 100;
            tipAmount.Text = (int.Parse(billAmountValue.Text) * Tip).ToString();
            totalAmount.Text = (int.Parse(billAmountValue.Text) + int.Parse(tipAmount.Text)).ToString();


        }
    }
}