namespace StageRaceFantasy.Application.Common.Mediatr
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

        public static CommandResult<T> Success<T>(T content)
        {
            return new CommandResult<T>(content);
        }

        public static CommandResult Success()
        {
            return new CommandResult();
        }

        public static CommandResult<T> BadRequest<T>()
        {
            return new CommandResult<T>()
            {
                IsBadRequest = true,
            };
        }

        public static CommandResult BadRequest()
        {
            return new CommandResult()
            {
                IsBadRequest = true,
            };
        }

        public static CommandResult<T> NotFound<T>()
        {
            return new CommandResult<T>()
            {
                IsNotFound = true,
            };
        }

        public static CommandResult NotFound()
        {
            return new CommandResult()
            {
                IsNotFound = true,
            };
        }
    }
}
