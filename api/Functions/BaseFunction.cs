namespace api {
    public abstract class BaseFunction 
    {
        protected PostcardExchangeContext Context;

        public BaseFunction(PostcardExchangeContext context) {
            Context = context;
            context.Database.EnsureCreated();
        }
    }
}