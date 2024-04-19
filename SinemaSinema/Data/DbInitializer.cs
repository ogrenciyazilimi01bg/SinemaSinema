using SinemaSinema.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SinemaSinema.Data
{
    public static class DbInitializer
    {
        private static string connectionString = "Data Source=..\\..\\Data\\SinemaSinemaDb.db;Version=3;";

        public static void InitializeDatabase()
        {
            if (!File.Exists("..\\..\\Data\\SinemaSinemaDb.db"))
            {
                SQLiteConnection.CreateFile("..\\..\\Data\\SinemaSinemaDb.db;");
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string createfilmTableQuery = @"
                        CREATE TABLE IF NOT EXISTS Film(
                            id INTEGER PRIMARY KEY NOT NULL ,
                            filmAd TEXT NOT NULL,
                            filmSuresi INTEGER NOT NULL,
                            filmTuru TEXT NOT NULL);";

                    string insertfilmQuery = @"
                        INSERT INTO Film (filmAd, filmsuresi, filmTuru) VALUES 
                        ('Kung Fu Panda 4', 94, 'Animasyon'),
                        ('Bodrum Seferi', 93, 'Komedi'),
                        ('Aşk Filmi', 125, 'Romantik'),
                        ('Rekabet', 146, 'Romantik');";

                    string createSalonTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Salon(
                        id INTEGER PRIMARY KEY NOT NULL,
                        salonAdi TEXT NOT NULL,
                        salonKapasitesi INTEGER NOT NULL);";

                    string insertSalonQuery = @"
                        INSERT INTO Salon (salonAdi, salonKapasitesi) VALUES
                        ('Deniz', 50),
                        ('Kumsal', 50),
                        ('Masal', 50),
                        ('Güneş', 50);";


                    string createSeansTableQuery = @"
                        CREATE TABLE IF NOT EXISTS Seans (
                            id INTEGER PRIMARY KEY NOT NULL,
                            seansZamani TEXT NOT NULL,
                            filmId INTEGER NOT NULL,
                            salonId INTEGER NOT NULL,

                            FOREIGN KEY (filmId) REFERENCES Film(id),
                            FOREIGN KEY (salonId) REFERENCES Salon(id));";

                    string insertSeansQuery = @"
                        INSERT INTO Seans (seansZamani, filmId, salonId) VALUES 
                        ('11:00', 1, 1),
                        ('11:00', 2, 2),
                        ('11:00', 3, 3),
                        ('11:00', 4, 4),
                        ('15:40', 1, 1),
                        ('15:40', 2, 2),
                        ('15:40', 3, 3),
                        ('15:40', 4, 4),
                        ('21:00', 1, 1),
                        ('21:00', 2, 2),
                        ('21:00', 3, 3),
                        ('21:00', 4, 4);";


                    string createbiletBilgiTableQuery = @"
                    CREATE TABLE IF NOT EXISTS BiletBilgi (
                        id INTEGER PRIMARY KEY NOT NULL,
                        musteriAd TEXT NOT NULL,
                        fiyat TEXT NOT NULL,
                        koltukNumarasi TEXT NOT NULL,
                        tarih TEXT NOT NULL,

                        filmId INTEGER NOT NULL,
                        salonId INTEGER NOT NULL,
                        seansId INTEGER NOT NULL,

                        FOREIGN KEY (filmId) REFERENCES Film(id),
                        FOREIGN KEY (salonId) REFERENCES Salon(id)
                        FOREIGN KEY (seansId) REFERENCES Seans(id));";

                    DateTime bugununTarihi = DateTime.Now;
                    string bugununTarihiFormatli = bugununTarihi.ToString("dd.MM.yy");

                    string insertBiletBilgiQuery = @"
                        INSERT INTO BiletBilgi (musteriAd, fiyat, koltukNumarasi, tarih, filmId, salonId, seansId) VALUES 
                        ('Begüm Geçer', '200','1', '" + bugununTarihiFormatli + @"', 1, 1, 1),
                        ('Begüm Geçer', '200','5', '" + bugununTarihiFormatli + @"', 1, 1, 1),
                        ('Zehra Gurur', '200','5', '" + bugununTarihiFormatli + @"', 2, 2, 6),
                        ('Gizem Güven', '200','4', '" + bugununTarihiFormatli + @"', 2, 2, 6),
                        ('Zehra Gurur', '200','18', '" + bugununTarihiFormatli + @"', 2, 2, 6),
                        ('Ece Düz', '200','14', '" + bugununTarihiFormatli + @"', 2, 2, 10),
                        ('Ece Düz', '200','18', '" + bugununTarihiFormatli + @"', 2, 2, 10),
                        ('Ece Düz', '200','25', '" + bugununTarihiFormatli + @"', 2, 2, 10),
                        ('Seçkin Burcu', '200','48', '" + bugununTarihiFormatli + @"', 2, 2, 10),
                        ('Ece Düz', '200','14', '" + bugununTarihiFormatli + @"', 4, 4, 12),
                        ('Emir Bulut', '200','18', '" + bugununTarihiFormatli + @"', 2, 2, 12),
                        ('Kerem Toprak', '200','25', '" + bugununTarihiFormatli + @"', 2, 2, 12),
                        ('Ece Düz', '200','48', '" + bugununTarihiFormatli + @"', 2, 2, 12),
                        ('Begüm Geçer', '200','7', '" + bugununTarihiFormatli + @"', 1, 1, 12);";
                        




                    using (var command = new SQLiteCommand(connection))
                    {
                        command.CommandText = createfilmTableQuery;
                        command.ExecuteNonQuery();

                        command.CommandText = insertfilmQuery;
                        command.ExecuteNonQuery();

                        command.CommandText = createSalonTableQuery;
                        command.ExecuteNonQuery();

                        command.CommandText = insertSalonQuery;
                        command.ExecuteNonQuery();


                        command.CommandText = createSeansTableQuery;
                        command.ExecuteNonQuery();

                        command.CommandText = insertSeansQuery;
                        command.ExecuteNonQuery();

                        command.CommandText = createbiletBilgiTableQuery;
                        command.ExecuteNonQuery();

                        command.CommandText = insertBiletBilgiQuery;
                        command.ExecuteNonQuery();
                    }
                }
            }

        }


    }
}