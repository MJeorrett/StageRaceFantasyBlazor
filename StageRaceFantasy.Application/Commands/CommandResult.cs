namespace StageRaceFantasy.Application.Commands
{
    public record CommandResult<T>
    {
        public T Content { get; init; }
        public bool IsBadRequest { get; init; }
        public bool IsNotFound { get; init; }

        public CommandResult(T content)
        {
            Content = content;
        }

        public CommandResult()
        {

        }
    }

    public record CommandResult
    {
        public bool IsBadRequest { get; init; }
        public bool IsNotFound { get; init; }
    }
}
