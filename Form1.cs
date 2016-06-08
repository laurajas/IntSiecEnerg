using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Menu menu= new Menu();
        private void Form1_Load(object sender, EventArgs e)
        {
            try {
                for (int i = 0; i < 2; i++)
                {
                    listBox1.Items.Add(menu.DodajPomieszczenia(new Pokoj("Pokoj " + i.ToString())).ToString());
                }
                listBox1.Items.Add(menu.DodajPomieszczenia(new Lazienka("Lazienka")));
                menu.DodajElementy("Pokoj 0", "Telewizor", 5);
                menu.DodajElementy("Pokoj 0", "Radio", 2);
                menu.DodajElementy("Pokoj 1", "Kuchenka", 15);
                menu.DodajElementy("Pokoj 1", "Zmywarka", 10);
                menu.DodajElementy("Lazienka", "Suszarka", 1);
                menu.DodajElementy("Lazienka", "Golarka", 1);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != -1 && menu.StatusElementu(listBox1.SelectedItem.ToString(), listBox2.SelectedItem.ToString(),true))
            {
                richTextBox1.AppendText(listBox1.SelectedItem.ToString()+ " wlączony element " + listBox2.SelectedItem.ToString()+ "\n");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();

            foreach (Pomieszczenie element in menu.pom)
            {
                if (listBox1.SelectedItem.ToString() == element.name)
                {
                    for (int i = 0; i < element.el.Count(); i++)
                    {
                        listBox2.Items.Add(element.el.ElementAt(i).name.ToString());
                    }
                    break;
                }
            }
         
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            foreach (Pomieszczenie element in menu.pom)
            {
                for (int i = 0; i < element.el.Count(); i++)
                {
                    if (element.el.ElementAt(i).Pobieraj == true)
                    {
                        element.el.ElementAt(i).CzasDzialania += 1;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != -1 && menu.StatusElementu(listBox1.SelectedItem.ToString(), listBox2.SelectedItem.ToString(),false))
            {
                richTextBox1.AppendText(listBox1.SelectedItem.ToString() + " wyłączony element " + listBox2.SelectedItem.ToString() + "\n");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText(menu.PodliczenieRachunku().ToString()+ "zł\n");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText("Rachunek został zapłacony. Aktualne saldo: "+menu.Zaplata().ToString() + "zł.\n");
        }

        private async void timer2_Tick(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1 && listBox2.SelectedIndex != -1)
            {
                string a = listBox1.SelectedItem.ToString();
                string b = listBox2.SelectedItem.ToString();
                try { progressBar1.Value = await Task.Run(() => menu.ZuzyieElementu(a,b)); }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }

            }
        }
    }
}
