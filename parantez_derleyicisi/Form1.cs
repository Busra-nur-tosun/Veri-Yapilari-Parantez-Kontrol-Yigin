using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parantez_derleyicisi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class yıgın
        {
            public char parantez;
           public  yıgın sonraki;
        }
        public yıgın ilk = null;
      
        
        private void button1_Click(object sender, EventArgs e)
        {
            yıgın ekle = new yıgın();
            string deger = textBox1.Text;
            char[] dizi = deger.ToCharArray();        
            char okuyucu;
            int süslü_parantez_adedi=0;
            int süslü_parantez_sayısı = 0;
            int acık_parantez_adedi = 0;
            int acık_parantez_sayısı = 0;
            int koseli_parantez_adedi = 0;
            int koseli_parantez_sayısı = 0;
            int cıkaarılan_koseli_parentez = 0;
            int cıkarılan_süslü_parantez = 0;
            int cıkarılan_acık_parantez = 0;
           
            for (int i = 0; i < dizi.Length; i++)
            {
                okuyucu = dizi[i];
                if(okuyucu=='{' )
                {
                    ekle.parantez = okuyucu;
                    ekle.sonraki = ilk;
                    ilk = ekle;
                    süslü_parantez_adedi++;
                    süslü_parantez_sayısı = süslü_parantez_sayısı + 1;
                }
                else if (okuyucu == '}')
                {
                    cıkar(ilk);
                    süslü_parantez_adedi--;
                    cıkarılan_süslü_parantez++;
                    
                }
                else if (okuyucu == '(')
                {
                    ekle.parantez = okuyucu;
                    ekle.sonraki = ilk;
                    ilk = ekle;
                    acık_parantez_adedi++;
                    acık_parantez_sayısı = acık_parantez_sayısı + 1;
                }
               else if (okuyucu == ')')
                {
                    cıkar(ilk);
                    acık_parantez_adedi--;
                    cıkarılan_acık_parantez++;
                    
                }
               else if (okuyucu == '[')
                {
                    ekle.parantez = okuyucu;
                    ekle.sonraki = ilk;
                    ilk = ekle;
                    koseli_parantez_adedi++;
                    koseli_parantez_sayısı = koseli_parantez_sayısı + 1;
                }
                if (okuyucu == ']')
                {

                    cıkar(ilk);
                    koseli_parantez_adedi--;
                    cıkaarılan_koseli_parentez++;
                    
                }
                  
                
            }
  
            if (süslü_parantez_adedi > 0)
            {
               
                int fark = süslü_parantez_sayısı - cıkarılan_süslü_parantez;
                MessageBox.Show(fark+ " adet açılan { parntezler kapatılmamıştır");
                if (fark != 0)
                {
                    cıkar(ilk);
                    textBox2.Text =textBox1.Text+ "}";
                    fark--;
                    
                }
                if (fark == 0)
                {
                    MessageBox.Show("açılan { kapatılmıştır");
                }
     
            }

            if (acık_parantez_adedi > 0)
            {
                int fark2 = acık_parantez_sayısı - cıkarılan_acık_parantez;
                MessageBox.Show(fark2 + " adet açılan ( parantez kapanmamıştır");
                if (fark2 > 0)
                {
                    cıkar(ilk);
                    textBox2.Text = textBox2.Text + ")";
                    fark2--;
                }
                if (fark2 == 0)
                {
                    MessageBox.Show("açılan ( kapatılmıştır");
                }

            }

            if (koseli_parantez_adedi > 0)
            {
                int fark3 = koseli_parantez_sayısı - cıkaarılan_koseli_parentez;
                MessageBox.Show(fark3 + " adet açılan [ parantez kapanmamıştır");
                if (fark3 > 0)
                {
                    cıkar(ilk);
                    textBox2.Text = textBox2.Text + "]";
                    fark3--;
                }
                if (fark3 == 0)
                {
                    MessageBox.Show("açılan [ kapatılmıştır");
                }

            }

            if (koseli_parantez_adedi == 0 || acık_parantez_adedi == 0 || süslü_parantez_adedi == 0)
            {
                MessageBox.Show("yığın dolmuştur");
            }

        }
        private void cıkar(yıgın ilk)
        {
            yıgın geçicı = new yıgın();
            geçicı = ilk;
            if (ilk != null)
            {
                geçicı = ilk.sonraki;
                ilk = null;
                ilk = geçicı;
            }
        }
        
    }
}
