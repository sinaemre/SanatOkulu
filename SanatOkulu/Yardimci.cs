using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanatOkulu
{
    public static class Yardimci
    {
        public static string ResimKaydet(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return null;
            }
            FileInfo fi = new FileInfo(path);
            string uzantı = fi.Extension;
            string yeniDosyaAd = Guid.NewGuid().ToString() + uzantı;
            string resimlerDizini = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            string kaydetDizini = Path.Combine(resimlerDizini, "Sanat Okulu");
            string kaydetYol = Path.Combine(kaydetDizini, yeniDosyaAd);

            if (!Directory.Exists(kaydetDizini))
            {
                Directory.CreateDirectory(kaydetDizini);
            }

            File.Copy(path, kaydetYol);

            return yeniDosyaAd;
        }

        public static Image ResimGetir(string filename)
        {
            if (string.IsNullOrEmpty(filename))
                return null;

            string resimlerDizini = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            string resimYolu = Path.Combine(resimlerDizini, "Sanat Okulu", filename);
            return Image.FromFile(resimYolu);
        }

        //public static Image ResmiGuncelle(string path)
        //{
            
        //}
    }
}
