using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Guild_Wars_2_Inventory_Search
{
    public partial class Form1 : Form
    {
        public String apiKey;
        public Thread thread;
        public List<ListItem> ids = new List<ListItem>();
        public System.IO.StreamReader file;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(Properties.Settings.Default.ApiKey))
            {
                Form2 form2 = new Form2(this);
                form2.Show();
                MessageBox.Show("No ApiKey was found, please enter your ApiKey.");

            }
            else
            {
                apiKey = Properties.Settings.Default.ApiKey;
                thread = new Thread(parseJson);
                thread.Start();
            }
        }

        private void parseJson()
        {
            this.Invoke(new MethodInvoker(delegate()
            {
                search.Enabled = false;
            }));

            try
            {
                addInventories();
                addBank();
                addMaterials();
            }
            catch
            {
                MessageBox.Show("The provided ApiKey is invalid or the Guild Wars 2 servers can't be reached. Change the ApiKey, or wait for the Guild Wars 2 servers to come back online and try again.");
            }

            try 
            {
                for (int i = 0; i <= ids.Count / 200; i++)
                {
                    addNames(i * 200);
                } 

                this.Invoke(new MethodInvoker(delegate()
                {
                    search.Enabled = true;
                    itemList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                }));
            }
            catch { MessageBox.Show("Test"); };
        }

        public void refreshButton_Click(object sender, EventArgs e)
        {
            if (thread == null || !thread.IsAlive)
            {
                itemList.Items.Clear();
                ids.Clear();
                thread = new Thread(parseJson);
                thread.Start();
            }
            else
                MessageBox.Show("The Items are already being loaded");
        }

        private void addNames(int from)
        {
            string query = "https://api.guildwars2.com/v2/items?ids=";
            for (int i = from; i < ids.Count - 1 && i - from <= 199; i++ )
            {
                query += ids[i].id + ",";
            }
            query = query.TrimEnd(',');
            List<Name> names = JsonConvert.DeserializeObject<List<Name>>((new WebClient()).DownloadString(query));
            for (int i = from; i < ids.Count && i - from <= 200; i++)
            {
                    
                this.Invoke(new MethodInvoker(delegate()
                {
                    try
                    {
                        string name = names.Find(p => p.id.ToString().Equals(ids[i].id)).name;
                        ids[i].name = name;
                        itemList.Items.Add(new ListViewItem(new String[] { name, ids[i].amount.ToString(), ids[i].character }));
                    }
                    catch (NullReferenceException) { }
                }));
            }

        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            Regex rgx = new Regex(".*" + search.Text + ".*", RegexOptions.IgnoreCase);
            itemList.Items.Clear();
            foreach(ListItem item in ids)
            {
                if(item.name != null && rgx.IsMatch(item.name))
                    itemList.Items.Add(new ListViewItem(new String[] { item.name, item.amount.ToString(), item.character}));
            }
        }

        private void apiButton_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.Show();
        }

        private void addInventories()
        {
            WebClient webClient = new WebClient();
            webClient.Encoding = System.Text.Encoding.UTF8;
            JArray characters = JArray.Parse(webClient.DownloadString("https://api.guildwars2.com/v2/characters?access_token=" + apiKey));

            foreach (String character in characters)
            {
                RootObject inventory = JsonConvert.DeserializeObject<RootObject>(webClient.DownloadString("https://api.guildwars2.com/v2/characters/" + character + "?access_token=" + apiKey));
                foreach (Bag bag in inventory.bags)
                {
                    if (bag != null)
                    {
                        foreach (Item item in bag.inventory)
                        {
                            try
                            {
                                ids.Add(new ListItem(item.id.ToString(), item.count, character));
                            }
                            catch { }
                        }
                    }
                }
            }
        }

        private void addBank()
        {
            WebClient webClient = new WebClient();
            JArray bankItems = JArray.Parse(webClient.DownloadString("https://api.guildwars2.com/v2/account/bank?access_token=" + apiKey));
            foreach(JToken item in bankItems)
            {
                BankItem bankItem = JsonConvert.DeserializeObject<BankItem>(item.ToString());
                try
                {
                    ids.Add(new ListItem(bankItem.id.ToString(), bankItem.count, "Bank"));
                }
                catch { }
                
            }
        }

        private void addMaterials()
        {
            WebClient webClient = new WebClient();
            JArray materials = JArray.Parse(webClient.DownloadString("https://api.guildwars2.com/v2/account/materials?access_token=" + apiKey));
            foreach (JToken item in materials)
            {
                MaterialItem material = JsonConvert.DeserializeObject<MaterialItem>(item.ToString());
                try
                {
                    if (material.count != 0)
                        ids.Add(new ListItem(material.id.ToString(), material.count, "Material Storage"));
                }
                catch { }

            }
        }
    }

    public class ListItem
    {
        public string id { get; set; }
        public string character { get; set; }
        public string name { get; set; }
        public int amount { get; set; }

        public ListItem(String id, int amount, String character)
        {
            this.id = id;
            this.character = character;
            this.amount = amount;
        }
    }

}
