namespace IsThatGoodDecision.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid WishListId { get; set; }
        public WishListEntity WishList { get; set; }

    }
}
