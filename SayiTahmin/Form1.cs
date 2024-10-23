using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SayiTahmin
{
    public partial class Form1 : Form
    {
        private int randomSayi;  
        private int deneme = 5;
        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }
        private void InitializeGame()
        {
            Random random = new Random();
            randomSayi = random.Next(1, 101);  
            deneme = 5;  
            lblMessage.Text = "1 ile 100 arasında bir sayı tahmin edin. 5 hakkınız var.";  
            txtGuess.Clear();  
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnGuess_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtGuess.Text, out int userGuess))
            {
                deneme--;  

                if (userGuess == randomSayi)
                {
                    MessageBox.Show("Tebrikler! Sayıyı doğru tahmin ettiniz!", "Başarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    InitializeGame();  // Oyun baştan başlasın
                }
                else if (userGuess > randomSayi)
                {
                    lblMessage.Text = $"Tahmininiz büyük! {deneme} hakkınız kaldı.";
                }
                else
                {
                    lblMessage.Text = $"Tahmininiz küçük! {deneme} hakkınız kaldı.";
                }

                if (deneme == 0)
                {
                    MessageBox.Show($"Üzgünüm, hakkınız doldu. Doğru sayı {randomSayi} idi.", "Başarısızlık", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    InitializeGame();  // Oyun baştan başlasın
                }
            }
            else
            {
                MessageBox.Show("Geçerli bir sayı giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
