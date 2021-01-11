using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XAM_Crud
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Llenarpropducts();

        }

        private async void Llenarpropducts()
        {
            //ejecutar peticion http para conectar con la api rest
            HttpClient client = new HttpClient();
            string url = "https://curdproductdhh20210111111325.azurewebsites.net/api/Product";
            var res = await client.GetAsync(url);
            var json = res.Content.ReadAsStringAsync().Result;
            JavaScriptSerializer ser = new JavaScriptSerializer();
            List<Product> products = ser.Deserialize<List<Product>>(json);
            //Productmodel model = Productmodel.FromJson(json);
            //listaproducts.ItemsSource = model.Product;
            string[] Productslst = new string[products.Count];
            int i = 0;
            foreach (Product p in products)
            {
                Productslst[i] = p.Name;
                i++;
            }

            listaproducts.ItemsSource = Productslst;
        }
        private async void Agregar_clicl(object sender, EventArgs args)
        {
            Product Pd = new Product();
            Pd.Name = "Mochila1";
            Pd.Price = 3000;
            Pd.Creation = DateTime.Now;
            Pd.Modification = DateTime.Now;
            HttpClient client = new HttpClient();
            string url = "https://curdproductdhh20210111111325.azurewebsites.net/api/Product";
            String JsonP = JsonConvert.SerializeObject(Pd);
            var res = await client.PostAsync(url, new StringContent(JsonP));
            var jso = res.Content.ReadAsStringAsync().Result;
            await DisplayAlert("Resultado", jso, "OK");
            ;
        }
        private async void Elimnar_Click(object sender, EventArgs args)
        {
            HttpClient client = new HttpClient();
            string url = "https://curdproductdhh20210111111325.azurewebsites.net/api/Produc/2";
            await client.DeleteAsync(url);
        }
        private async void Actualizar_Click(object sender, EventArgs args)
        {
            Product Pd = new Product();
            Pd.Id = 3;
            Pd.Name = "Mochila1";
            Pd.Price = 3000;
            Pd.Creation = DateTime.Now;
            Pd.Modification = DateTime.Now;
            HttpClient client = new HttpClient();
            string url = "https://curdproductdhh20210111111325.azurewebsites.net/api/Product";
            String JsonP = JsonConvert.SerializeObject(Pd);
            var res = await client.PutAsync( url, new StringContent(JsonP));
            var jso = res.Content.ReadAsStringAsync().Result;
            await DisplayAlert("Resultado", jso, "OK");
        }
    }
}
