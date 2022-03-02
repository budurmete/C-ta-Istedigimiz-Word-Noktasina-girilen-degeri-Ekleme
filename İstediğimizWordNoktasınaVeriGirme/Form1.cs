using System;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using Word = Microsoft.Office.Interop.Word;/* sağ da bulunan Çözüm gezgininde bulunan Dosya ismine sağ tıklayın 
ve ekle/Başvurlar/COM/ Microsoft Word   ; yazın ve cıkan referasının kutucuğna tik atarak tamam tuşuna basınız*/

namespace İstediğimizWordNoktasınaVeriGirme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Bul ve Değiştir Mothodu 
        private void BulVEdegistir(Word.Application wordApp, object ToFindText, object replaceWithText)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundLike = false;
            object nmatchAllforms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiactitics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;

            wordApp.Selection.Find.Execute(ref ToFindText,
                ref matchCase, ref matchWholeWord,
                ref matchWildCards, ref matchSoundLike,
                ref nmatchAllforms, ref forward,
                ref wrap, ref format, ref replaceWithText,
                ref replace, ref matchKashida,
                ref matchDiactitics, ref matchAlefHamza,
                ref matchControl);
        }

        // word Dosyası oluşturma Methodu
        private void CreateWordDocument(object filename, object SaveAs)
        {
            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myWordDoc = null;

            if (File.Exists((string)filename))
            {
                object readOnly = false;
                object isVisible = false;
                wordApp.Visible = false;

                myWordDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                                        ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing, ref missing);
                myWordDoc.Activate();

                //Bul ve Değiştir

                this.BulVEdegistir(wordApp, "<name>", txtAdSoyad.Text);
                //this.FindAndReplace(wordApp, "<firstname>", textBox2.Text);
                //this.FindAndReplace(wordApp, "<birthday>", dateTimePicker1.Value.ToShortDateString());
                //this.FindAndReplace(wordApp, "<date>", DateTime.Now.ToShortDateString());
            }
            else
            {
                MessageBox.Show("File not Found!");
            }

            //  //farklı Kaydet
            myWordDoc.SaveAs2(ref SaveAs, ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing);

            myWordDoc.Close();
            wordApp.Quit();
            MessageBox.Show("File Created!");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateWordDocument(@"C:\Users\BİLGİSAYAR\Desktop\DOSYA İSMİ\ Word Dosayası .doc", @"C:\Users\BİLGİSAYAR\Desktop\DOSYA İSMİ\ Word Dosayası .doc");

            //BİLGİSAYAR ismi yerine kendi bilgisayınızın ismini Yazın....... Uygulamınızı oluşturduğunuz Dosyanın İSmini de "DOSYA İSMİ" kISmına yazın"
            // Word Dosayası Yerinede Değişim Yapmak istediğiniz word dosyasının İSmini Yazın
            //ilk "@" olduğu yere Word şablonuzu ikinci "@" yerede yeni olan word dosyanızın adını girin 

            //ÖNEMLİ!!!!!
            //ikinci "@" olduğu konuma girdiğiniz adın ve soy ismin worde aktarılmış halini nereye kaydetmek istiyorsanız oranın konumunu yazın
        }
    }
}
