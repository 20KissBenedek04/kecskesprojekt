using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;

namespace kecskesprojekt
{
    public partial class Form1 : Form
    {
        List<Projektkecske> kecskek = new List<Projektkecske>();

        public Form1()
        {
            InitializeComponent();
            Start();

        }

        async void Start()
        {
            HttpClient client = new HttpClient();
            string url = "http://127.1.1.1:3000/allat";
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string message = await response.Content.ReadAsStringAsync();
                List<Projektkecske> data = JsonConvert.DeserializeObject<List<Projektkecske>>(message);
                listBox1.Items.Clear();
                foreach (Projektkecske item in data)
                {
                    listBox1.Items.Add($"Kecske neve: {item.nev}, kora: {item.honapos}, súlya: {item.suly}, magassága: {item.magassag}, neme: {item.nem}");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        async void buttonClick(object s, EventArgs e)
        {
            HttpClient client = new HttpClient();
            //string url = "http://127.1.1.1:3000/allat/" + id;
            var jsonObject = new
            {
                //id = this.id
            };
            string jsonString = JsonConvert.SerializeObject(jsonObject);
            StringContent data = new StringContent(jsonString, Encoding.UTF8, "application/json");
           //HttpResponseMessage response = await client.DeleteAsync(url);
            //response.EnsureSuccessStatusCode();
            this.Dispose();
        }
    }
}
