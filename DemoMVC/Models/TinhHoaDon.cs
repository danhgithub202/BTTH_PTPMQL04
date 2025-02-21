namespace DemoMVC.Models
{
    public class TinhHoaDonModel
    {
        public int SoLuong { get; set; }
        public double DonGia { get; set; }

        public double TinhTongTien()
        {
            return SoLuong * DonGia;
        }
    }
}
