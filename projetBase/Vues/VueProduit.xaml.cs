using projetBase.Modeles;
using projetBase.Services;

namespace projetBase.Vues;

public partial class VueProduit : ContentPage
{
    private readonly Apis _apiServices = new Apis();

    public VueProduit()
	{
		InitializeComponent();
		BindingContext = this;
        this.GetProduit();

    }

    private async void GetProduit()
    {

        Produit res = await _apiServices.GetOneAsync<Produit>("api/mobile/getProduit", new Produit(2,""));


    }
}