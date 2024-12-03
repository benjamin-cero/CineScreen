namespace FIT_Api_Example.Modul2_IspitOcjene.ViewModels
{
    public class PrijavaIspitaGetNeprijavljeniResponse
    {
        public int IspitId { get; set; } 
        public string PredmetNaziv { get; set; }
        public string PredmetSifra { get; set; }
        public DateTime DatumVrijemeIspita{ get; set; }
        public string Komentar { get; set; }
        public int PredmetID { get; set; }
    }
}
