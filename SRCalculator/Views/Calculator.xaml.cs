using Calculater.ViewModels;
using SRCalculator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SRCalculator.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Calculator : ContentPage
    {
        CalculateViewModel _viewModel;
        List<string> InputList = new List<string>();
        int Input;
        string oparetor = string.Empty;
        int Answer;
        public int Total { get; internal set; }

        public Calculator()
        {
            InitializeComponent();
            BindingContext = _viewModel = new CalculateViewModel();
        }


        private void AnyButtonClicked(object sender, EventArgs e)
        {
            Button converted = sender as Button;

            if (converted.Text == "=" && CalcDisplay.Text == string.Empty) return;
            if (converted.Text != "=" && converted.Text != "AC") { CalcSubDisplay.Text += converted.Text; }






            if (converted.Text.Equals("AC"))
            {
                InputList.Clear();
                Input = 0;
                Answer = 0;
                CalcSubDisplay.Text = string.Empty;
                CalcDisplay.Text = string.Empty;
                oparetor = string.Empty; return;

            }
            else if (converted.Text.Equals("=") && InputList.Count() >= 2)
            {

                InputList.Add(CalcDisplay.Text);

                Answer = Convert.ToInt32(InputList[0]);

                var skipped = InputList.Skip(1).ToList();


                foreach (var item in skipped)
                {
                    if (int.TryParse(item, out int result))
                    {
                        Input = result;
                    }
                    else
                    {
                        oparetor = item;
                    }
                }


                Calculate();
                CalcDisplay.Text = Answer.ToString();
                NewItemViewModel.sum = Answer;
                Total = Answer;
                InputList.Clear();
;
                


            }
            else if (int.TryParse(converted.Text, out int result))
            {
                CalcDisplay.Text += converted.Text;
                return;


            }
            else
            {

                InputList.Add(CalcDisplay.Text);
                if (converted.Text != "=" && converted.Text != string.Empty) InputList.Add(converted.Text);
                CalcDisplay.Text = string.Empty;
                return;

            }



        }

        private void Calculate()
        {

            switch (oparetor)
            {

                case "+":
                    Answer += Input;
                    break;

                case "-":
                    Answer -= Input;
                    break;

                case "x":
                    Answer *= Input;
                    break;

                case "÷":
                    Answer /= Input;
                    break;
            }
        }

    }
}