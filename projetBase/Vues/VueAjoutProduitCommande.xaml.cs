using projetBase.Modeles.PostApi;
using projetBase.Services;

namespace projetBase.Vues;

public partial class VueAjoutProduitCommande : ContentPage
{
    private readonly Apis _apiServices = new Apis();

    public VueAjoutProduitCommande()
	{
		InitializeComponent();
        BindingContext = this;
        this.AjouterUnproduit();
    }
	public async void AjouterUnproduit()
	{
        AjoutProduitCommandemobile obj = new AjoutProduitCommandemobile(16, 2, 1, 9.99) ;
        var result = await _apiServices.PostOneAsync<AjoutProduitCommandemobile>("api/mobile/AjoutProduitCommandemobile",obj);


    }
}