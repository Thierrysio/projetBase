using projetBase.Vues;

namespace projetBase
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new VueAjoutProduitCommande();
        }
    }
}
