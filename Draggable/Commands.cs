namespace Draggable;

public class Commands
{
    public record AddTodo(string Description)
    {
        public class Handler: CommandHandler<AddTodo>
        {
            public Handler(AppStore store) : base(store) { }

            TodoState State => Store.GetState<TodoState>();
            
            public override Task Handle(AddTodo command)
            {
                State.Todos.Add(new TodoItem {Description = "Hello World"});
                return Task.CompletedTask;
            }
        }
    }

    public record RemoveTodo(Guid Id)
    {
        public class Handler: CommandHandler<RemoveTodo>
        {
            public Handler(AppStore store) : base(store) {}
            TodoState State => Store.GetState<TodoState>();
            
            public override Task Handle(RemoveTodo command)
            {
                if (State.Favorite?.Id == command.Id) State.Favorite = null;
                State.Todos.RemoveAll(t => t.Id == command.Id);
                return Task.CompletedTask;
            }
        }
    }
    
    public record FavouriteTodoItem(Guid Id)
    {
        public class Handler : CommandHandler<FavouriteTodoItem>
        {
            public Handler(AppStore store):base(store) {}

            private TodoState State => Store.GetState<TodoState>();
            public override Task Handle(FavouriteTodoItem command)
            {
                State.Favorite = State.Todos.First(t => t.Id == command.Id);
                return Task.CompletedTask;
            }
        }
    }
}


