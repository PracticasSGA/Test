using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Test.Resources;
namespace Test
{
	public partial class MainPage : ContentPage
	{
        private Button btnSaludar;
        private Entry txtNombres;
        private MainPage self;
		public MainPage()
		{
			InitializeComponent();
            this.setElements();
            this.setListeners();
		}

        private void setElements()
        {
            this.self = this;
            this.btnSaludar = this.FindByName<Button>("btnSaludar_XAML");
            this.txtNombres = this.FindByName<Entry>("txtNombres_XAML");
        }

        private void setListeners()
        {
            this.btnSaludar.Clicked += this.btnSaludar_Click;
        }

        private void btnSaludar_Click(object sender, EventArgs e)
        {

            String response = Request.post(new Dictionary<string, string> { { "nombre", this.txtNombres.Text } } );
            DisplayAlert("Alerta", response , "OK");
        }
	}
}
