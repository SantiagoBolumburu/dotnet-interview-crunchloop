namespace TodoApi.Models
{
    public class TodoItem
    {
        public enum State
        {
            todo,
            doing,
            donde
        }

        public long Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required State CurrentState { get; set; }
        public required TodoList TodoList { get; set; }
    }
}
