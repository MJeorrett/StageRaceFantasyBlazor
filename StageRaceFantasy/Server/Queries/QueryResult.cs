namespace StageRaceFantasy.Server.Queries
{
    public record QueryResult<T>
    {
        public T Content { get; init; }
        public bool IsNotFound { get; init; }

        public QueryResult(T content)
        {
            Content = content;
        }

        public QueryResult()
        {

        }
    }
}
