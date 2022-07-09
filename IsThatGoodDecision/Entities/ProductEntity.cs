namespace IsThatGoodDecision.Entities
{
    public class ProductEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsWorthToBuy { get; set; }

        public Guid WishListId { get; set; }
        public WishListEntity WishList { get; set; }

        public ICollection<CommentEntity> Comments { get; set; }
    }
}
