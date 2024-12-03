namespace FIT_Api_Example.Modul2_IspitOcjene.ViewModels
{
    public class IspitUpdateRequest
    {
       // public int PredmetId { get; set; }//necemo dozvoliti izmjenu predmeta
        public DateTime Satnica { get; set; }
        public string Komentar { get; set; }
        public int IspitId { get; set; }
    }
}
