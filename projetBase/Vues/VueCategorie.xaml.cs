using projetBase.Modeles;
using projetBase.Services;
using System.Collections.ObjectModel;


namespace projetBase.Vues;

public partial class VueCategorie : ContentPage
{
    private readonly Apis _apiServices = new Apis();
    public ObservableCollection<CategorieParent> CP { get; set; } = new ObservableCollection<CategorieParent>();
    public VueCategorie()
    {
		InitializeComponent();
		BindingContext = this;

        this.GetCategories();
	}

    private async Task GetCategories()
    {

        // Appelle l’API
        var result = await _apiServices.GetAllAsync<CategorieParent>("api/mobile/categories");

        // On vide éventuellement la liste puis on l’alimente
        CP.Clear();
        if (result != null)
        {
            foreach (var item in result)
            {
                CP.Add(item);
            }
        }
    }
}