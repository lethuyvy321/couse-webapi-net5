namespace WebAPiNet6Ver2.Data
{
    public class OrderDetail
    {
        public Guid MaHh { get; set; }
        public Guid MaDh { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        public byte GiamGia { get; set; }

        //relationship
        public Order Order { get; set; }
        public HangHoa HangHoa { get; set; }
    }
}
