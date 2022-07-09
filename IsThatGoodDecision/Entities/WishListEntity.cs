namespace IsThatGoodDecision.Entities
{
    public class WishListEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }

        public Guid UserId { get; set; }
        public UserEntity User { get; set; }

        public ICollection<ProductEntity> Products { get; set; }

    }
}
