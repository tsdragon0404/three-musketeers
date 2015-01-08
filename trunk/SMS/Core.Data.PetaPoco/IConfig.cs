namespace Core.Data.PetaPoco
{
    public interface IConfig
    {
        string ConnectionString { get; set; }
        string DbProvider { get; set; }
    }
}