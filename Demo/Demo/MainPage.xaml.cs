using System.ComponentModel;
using Xamarin.Forms;

namespace Demo
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        #region Attributes

        public event PropertyChangedEventHandler PropertyChanged;
        private float numberOne;
        private float numberTwo;
        private int selectedOperation;
        private float result;

        public static string[] operations =  {
            "Suma",
            "Resta",
            "Multiplicacion",
            "Division"
        };

        #endregion

        #region Properties

        public float NumberOne
        {
            get => numberOne;
            set
            {
                numberOne = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NumberOne"));
            }
        }

        public float NumberTwo
        {
            get => numberTwo;
            set
            {
                numberTwo = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NumberTwo"));
            }
        }

        public int SelectedOperation
        {
            get => selectedOperation;
            set
            {
                selectedOperation = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedOperation"));
            }
        }

        public float Result
        {
            get => result;
            set
            {
                result = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Result"));
            }
        }

        #endregion


        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        private void ExecuteOperation(object sender, System.EventArgs e)
        {
            switch (SelectedOperation) 
            {
                case 0:
                    Result = NumberOne + NumberTwo;
                    break;
                case 1:
                    Result = NumberOne - NumberTwo;
                    break;
                case 2:
                    Result = NumberOne * NumberTwo;
                    break;
                case 3:
                    if(NumberTwo == 0) 
                    {
                        Application.Current.MainPage.DisplayAlert("Division entre 0",
                            "No se puede realizar una division entre 0, por favor, cambie el denominador",
                            "Volver");
                        break;
                    }

                    Result = NumberOne / NumberTwo;
                    break;
            }
        }

        private void Reset(object sender, System.EventArgs e)
        {
            NumberOne = 0;
            NumberTwo = 0;
            SelectedOperation = 0;
            Result = 0;
        }
    }
}
