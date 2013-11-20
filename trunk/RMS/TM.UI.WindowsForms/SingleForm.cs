namespace TM.UI.WindowsForms
{
    /// <summary>
    /// Base class for forms that usually keep 1 Model
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public class SingleForm<TEntity> : BaseForm
    {
        #region Properties

        protected TEntity Model { get; set; } 

        #endregion
    }
}