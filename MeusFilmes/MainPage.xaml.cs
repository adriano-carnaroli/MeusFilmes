using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MeusFilmes.Servico;
using MeusFilmes.Servico.Modelo;

namespace MeusFilmes
{
    public partial class MainPage : ContentPage
    {
        private Boolean iniciou = false;
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (!iniciou)
            {
                listView.ItemsSource = await ServicoFilmes.BuscarFilmes();
                iniciou = true;
            }
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            var detailPage = new FilmeDetalhe();
            detailPage.BindingContext = e.SelectedItem as Filme;

            listView.SelectedItem = null;

            Navigation.PushAsync(detailPage);
        }

        void OnSelection(object sender, EventArgs e)
        {
            CheckBox isCheckedOrNot = (CheckBox)sender;
            var selectedFilme = isCheckedOrNot.BindingContext as Filme;
            App.Database.SaveItemAsync(selectedFilme);
    }
    }
}
