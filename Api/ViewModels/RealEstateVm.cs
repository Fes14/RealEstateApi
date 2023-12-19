namespace Api.ViewModels
{
    public class RealEstateVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Developer { get; set; }
        public string? Type { get; set; }
        public decimal Price { get; set; }
        public float Square { get; set; }
        public int RoomsCount { get; set; }
        public AddressVm Address { get; set; }
    }
}
