namespace FIT_Api_Example.Modul2_IspitOcjene.ViewModels
{
    public class IspitGetResponse
    {
        public int IdIspita { get; set; }
        public string Komnt { get; set; }
        public DateTime Satnica { get; set; }
        public int PredmetId { get; set; }
        public string PuniNaziv { get; set; }
        public string SifraPredmeta { get; set; }
        public int Bodovi { get; set; }

        public string Opis => PuniNaziv + ": " + SifraPredmeta;
    }
}
