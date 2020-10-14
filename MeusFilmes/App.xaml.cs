using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MeusFilmes.Servico.Database;
using MeusFilmes;

namespace MeusFilmes
{
    public partial class App : Application
    {
        private static FilmeDatabase dataBase;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.FromHex("#000000"),
                BarTextColor = Color.White,
            };
        }

        internal static FilmeDatabase Database
        {
            get
            {
                if (dataBase == null)
                {
                    dataBase = new FilmeDatabase
                        (DependencyService.Get<IFileHelper>().
                        GetLocalFilePath("FilmeSQLite.db3"));
                }
                return dataBase;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
