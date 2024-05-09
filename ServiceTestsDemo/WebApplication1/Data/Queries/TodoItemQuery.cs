namespace WebApplication1.Data.Queries
{
    public class TodoItemQuery : BaseQuery
    {
        public int? ListId { get; set; }
        public string ItemSearch {  get; set; }

        public override bool IsEmpty()
        {
            return ListId == null &&
                   string.IsNullOrWhiteSpace(ItemSearch);
        }
    }
}