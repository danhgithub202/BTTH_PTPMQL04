namespace PhatTrienPMQL2425K2.Models
{
    public class BMIModel
    {
        public double ChieuCao { get; set; } // Đơn vị: mét
        public double CanNang { get; set; }  // Đơn vị: kg

        public double TinhBMI()
        {
            return CanNang / (ChieuCao * ChieuCao);
        }
    }
}
