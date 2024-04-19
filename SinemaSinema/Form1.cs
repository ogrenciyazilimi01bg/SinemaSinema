using SinemaSinema.Data;
using SinemaSinema.Servisler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinemaSinema
{
    public partial class Form1 : Form
    {
        string[] secilenKoltuk;
        private static string connectionString = "Data Source=..\\..\\Data\\SinemaSinemaDb.db;Version=3;";
        Databaseservis _dbServis=new Databaseservis();
        public Form1()
        {
            InitializeComponent();
            filmListele();
            filmVeri();
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            textBox2.Text = DateTime.Now.ToString("dd.MM.yy");
            label17.Text = DateTime.Now.ToString("dd.MM.yy");

            DbInitializer.InitializeDatabase();
            FillDataGridView();
            numericUpDown1.ValueChanged += (sender, e) => Hesapla();

            int buttonNumber = 1;
            for (int i = 5; i <= 54; i++)
            {
                // Butonları bulmak için konteynerde butonları isimlerine göre arayabiliriz
                Button button = Controls.Find("button" + i, true).FirstOrDefault() as Button;
                if (button != null)
                {
                    // Her bir butona sırasıyla 1'den 50'ye kadar olan sayıları atıyoruz
                    
                    button.Text = buttonNumber.ToString();
                    button.Click += button_Click;
                    buttonNumber++;
                }
            }



        }

        private void FillDataGridView()
        {
            var biletBilgileri = _dbServis.GetbiletBilgi().Select(bilet => new
       {
           bilet.id, 
           bilet.musteriAd,
           bilet.fiyat,
           bilet.koltukNumarasi,
           bilet.tarih,
           FilmAdı = _dbServis.Getfilmler().FirstOrDefault(film => film.id == bilet.filmId)?.filmAd,
           SalonAdı = _dbServis.Getsalonlar().FirstOrDefault(salon => salon.id == bilet.salonId)?.salonAdi,
           SeansZamanı = _dbServis.Getseans().FirstOrDefault(seans => seans.id == bilet.seansId)?.seansZamani
       }).ToList();

            dataGridView1.DataSource = biletBilgileri;
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ComboBox1'den seçilen film adını alır
            string secilenFilmAd = comboBox1.SelectedItem.ToString();

            // Seçilen film bilgisini alır
            var secilenFilm = _dbServis.Getfilmler().FirstOrDefault(film => film.filmAd == secilenFilmAd);

            if (secilenFilm != null)
            {
                // Seçilen film için uygun seansları alır
                var seanslar = _dbServis.Getseans().Where(seans => seans.filmId == secilenFilm.id).ToList();

                // Seansları Combobox2'ye ekler
                comboBox2.DataSource = seanslar.Select(seans => seans.seansZamani).ToList();
            }
            KontrolEtVeRenklendir();
        }

        private int tıklamaSayısı = 0;

        private void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                if (button.BackColor == Color.FromArgb(192, 255, 192)) 
                {
                    if (tıklamaSayısı < (int)numericUpDown1.Value) // Eğer tıklama sayısı numericUpDown1'den seçilen değere eşit değilse
                    {
                        button.BackColor = Color.Orange; // Butonun rengini turuncuya çevirir
                        label27.Text += button.Text + ","; // Label'a buton numarasını ekler
                        
                        tıklamaSayısı++;
                    }
                }
                else if (button.BackColor == Color.Orange) 
                {
                    button.BackColor = Color.FromArgb(192, 255, 192); // Butonun rengini açık yeşil yapar
                    label27.Text = label27.Text.Replace(button.Text + ",", ""); // Label'dan buton numarasını kaldırır
                    tıklamaSayısı--;
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ComboBox1'den seçilen film adını alır
            string secilenFilmAd = comboBox1.SelectedItem.ToString();

            // Seçilen film bilgisini al
            var secilenFilm = _dbServis.Getfilmler().FirstOrDefault(film => film.filmAd == secilenFilmAd);

            // ComboBox2'den seçilen seans zamanını alır
            string secilenSeansZamani = comboBox2.SelectedItem.ToString();

            // Seçilen seans bilgisini alır
            var secilenSeans = _dbServis.Getseans().FirstOrDefault(seans => seans.seansZamani == secilenSeansZamani && seans.filmId == secilenFilm.id);

            if (secilenSeans != null)
            {
                // Seçilen seansın salonId'sini alır
                int salonId = secilenSeans.salonId;

                // salonId'ye göre salonAdi ve salonKapasitesi'ni bulur
                var salonBilgisi = _dbServis.Getsalonlar().FirstOrDefault(salon => salon.id == salonId);

                if (salonBilgisi != null)
                {
                    // Bulunan salonAdi'ni label16'da gösterir
                    label14.Text = salonBilgisi.salonAdi;
                    // Bulunan salonKapasitesi'ni label15'te gösterir
                    label15.Text = salonBilgisi.salonKapasitesi.ToString();

                    

                    

                }
            }

            KontrolEtVeRenklendir();
        }


        private void KontrolEtVeRenklendir()
        {
            int yesilButonSayisi = 0; // Yeşil yanan buton sayısını saklamak için bir sayaç

            // ComboBox'lardan seçilen film ve seansın ID'lerini al
            string secilenFilmAd = comboBox1.SelectedItem.ToString();
            string secilenSeansZamani = comboBox2.SelectedItem.ToString();
            var secilenFilm = _dbServis.Getfilmler().FirstOrDefault(film => film.filmAd == secilenFilmAd);
            var secilenSeans = _dbServis.Getseans().FirstOrDefault(seans => seans.seansZamani == secilenSeansZamani && seans.filmId == secilenFilm.id);

            if (secilenFilm != null && secilenSeans != null)
            {
                // Seçilen film ve seans için biletleri filtreler
                var uygunBiletler = _dbServis.GetbiletBilgi().Where(bilet => bilet.filmId == secilenFilm.id && bilet.seansId == secilenSeans.id).ToList();

                // Butonları dolaşarak koltuk numaralarını kontrol eder
                for (int i = 5; i <= 54; i++)
                {
                    Button button = Controls.Find("button" + i, true).FirstOrDefault() as Button;
                    if (button != null)
                    {
                        string koltukNumarasi = button.Text;
                        // Biletler arasında koltuk numarasını kontrol et
                        var biletVarMi = uygunBiletler.Any(bilet => bilet.koltukNumarasi == koltukNumarasi);
                        // Eğer bilet varsa, butonun rengini kırmızı yapar
                        if (biletVarMi)
                        {
                            button.BackColor = Color.Red;
                        }
                        else
                        {
                            // Eğer bilet yoksa, butonun rengini açık yeşil yapar ve yeşil buton sayısını artırır
                            button.BackColor = Color.FromArgb(192, 255, 192); // Açık yeşil renk
                            yesilButonSayisi++; // Yeşil yanan buton sayısını artır
                        }
                    }
                }
            }

            label16.Text = yesilButonSayisi.ToString(); // Yeşil yanan buton sayısını label16'ya yazar

            numericUpDown1.Minimum = 1;
            numericUpDown1.Maximum = yesilButonSayisi;
        }
        private void Hesapla()
        {
            // numericUpDown1'den seçilen değeri al
            int secilenDeger = (int)numericUpDown1.Value;

            // Hesaplama yapar
            int sonuc = secilenDeger * 200;

            label20.Text = sonuc.ToString() + " TL";
        }

        private void filmListele()
        {
           
            var filmler = _dbServis.Getfilmler();
            comboBox1.DataSource = filmler.Select(film => film.filmAd).ToList();
            comboBox1.SelectedIndex = -1;
        }

        private void filmVeri()
        {
            var filmlerB = _dbServis.Getfilmler();
            listBox1.DataSource = filmlerB.Select(film => $"{film.id}) {film.filmAd} - {film.filmTuru}-{film.filmSuresi}Dk").ToList();
        }
        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {   
           

        }




        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;

            lbSecilenFilm.Text = comboBox1.SelectedItem.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            secilenKoltuk = label27.Text.Split(',');
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                int secilenFilm = _dbServis.ReturnFilmId(lbSecilenFilm.Text);
                int secilenSeans = _dbServis.GetSeansIdByFilmAndSeansTime(secilenFilm,comboBox2.SelectedItem.ToString());
                int secilenSalon = _dbServis.GetSalonIdByFilmAndSeans(secilenFilm, comboBox2.SelectedItem.ToString());
                DateTime bugununTarihi = DateTime.Now;
                string bugununTarihiFormatli = bugununTarihi.ToString("dd.MM.yy");
                foreach (var koltuk in secilenKoltuk)
                {
                    if (koltuk != "" )
                    {
                        string insertReservationQuery = $@"
                                INSERT INTO BiletBilgi (musteriAd, fiyat, koltukNumarasi, tarih, filmId, salonId, seansId) VALUES 
                                    ('{textBox3.Text}', '200', '{koltuk}', '{bugununTarihiFormatli}' ,{secilenFilm}, {secilenSalon}, {secilenSeans})";

                        using (var command = new SQLiteCommand(insertReservationQuery, connection))
                        {
                            command.ExecuteNonQuery();
                        }

                    }
                    
                }
            }
            FillDataGridView();
            MessageBox.Show("Bilet satışı gerçekleşmiştir.");
            tabControl1.SelectedTab = tabPage1;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {   


        }


        
    }
}
