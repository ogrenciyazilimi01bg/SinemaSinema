using SinemaSinema.Data;
using SinemaSinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinemaSinema.Servisler
{
    internal class Databaseservis
    {

        
        AppDbContext _dbContext = new AppDbContext();
        public List<Film> Getfilmler()
          {
            return _dbContext.Film.ToList();
          }

        public List<Salon> Getsalonlar()
        {
            return _dbContext.Salon.ToList();
        }
        public List<Seans> Getseans()
        {
            return _dbContext.Seans.ToList();
        }
        public List<BiletBilgi> GetbiletBilgi()
        {
            return _dbContext.BiletBilgi.ToList();
        }
        public int ReturnFilmId(string filmAd)
        {
            var film = _dbContext.Film.FirstOrDefault(f => f.filmAd == filmAd);
            return film != null ? film.id : -1; // Eğer film bulunamazsa -1 döndürülebilir veya başka bir uygun değer
        }
        public int GetSalonIdByFilmAndSeans(int filmId, string seansZamani)
        {
            var seans = _dbContext.Seans.FirstOrDefault(f => f.filmId == filmId && f.seansZamani == seansZamani);
            if (seans != null)
            {
                return seans.salonId;
            }
            return -1; // veya başka bir varsayılan değer döndürebilirsiniz
        }
        public int GetSeansIdByFilmAndSeansTime(int filmId, string seansZamani)
        {
            var seans = _dbContext.Seans.FirstOrDefault(f => f.filmId == filmId && f.seansZamani == seansZamani);
            if (seans != null)
            {
                return seans.id;
            }
            return -1; // veya başka bir varsayılan değer döndürebilirsiniz
        }



    }
}
