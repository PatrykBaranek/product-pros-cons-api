namespace IsThatGoodDecision.Entities
{
    public class CommentEntity
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public bool IsPros { get; set; }
        public bool IsCons { get; set; }

        public Guid ProductId { get; set; }
        public ProductEntity Product { get; set; }

    }
}
