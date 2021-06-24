namespace dvdrental.Domain.Dtos
{
    public class InventoryForReturnDto
    {
        public int InventoryId { get; set; }
        public FilmForReturnDto Film { get; set; }
    }
}