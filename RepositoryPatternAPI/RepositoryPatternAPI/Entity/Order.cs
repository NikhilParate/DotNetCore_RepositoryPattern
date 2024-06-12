namespace RepositoryPatternAPI.Entity
{
    public class Order
    {
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public string Description { get; set; }

        //foreign key

        public int ProductId { get; set; }

        //navigation property

        public Product Product { get; set; }
    }
}
