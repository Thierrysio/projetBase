using projetBase.Modeles;
using projetBase.Services;

namespace projetBase.Vues;

public partial class VueCategorie : ContentPage
{
    private readonly Apis _apiServices = new Apis();

    public VueCategorie()
	{
		InitializeComponent();
		BindingContext = this;

        this.GetCategories();
	}

    private async Task GetCategories()
    {
       
        var result = await _apiServices.GetAllAsync<CategorieParent>("api/mobile/categories");
        
    }
}