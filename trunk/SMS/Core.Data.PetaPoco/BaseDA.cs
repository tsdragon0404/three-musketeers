namespace Core.Data.PetaPoco
{
    public abstract class BaseDA
    {
        protected readonly IConfig config;

        protected BaseDA(IConfig config)
        {
            this.config = config;
        }
    }
}