using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetBase.Modeles
{
    public class Produit
    {
        #region attributs
        private int id;
        private string nomProduit;
        #endregion

        #region Constructeurs
        public Produit(int id, string nomProduit)
        {
            this.id = id;
            this.nomProduit = nomProduit;
        }

        #endregion

        #region Getters/setters
        [JsonProperty("id")]
        public int Id { get => id; set => id = value; }
        [JsonProperty("nomProduit")]
        public string NomProduit { get => nomProduit; set => nomProduit = value; }

        #endregion

        #region Methodes
        #endregion
    }
}
