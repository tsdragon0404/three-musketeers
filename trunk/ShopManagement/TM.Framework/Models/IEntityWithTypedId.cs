namespace TM.Framework.Models
{
    /// <summary>
    /// This serves as a base interface for <see cref="Entity"/> and
    /// <see cref="EntityWithTypedId{TIdentity}"/>. Also provides a simple means to develop your own base entity.
    /// </summary>
    public interface IEntityWithTypedId<TIdentity>
    {
        /// <summary>
        /// Gets the id.
        /// </summary>
        /// <value>The id.</value>
        TIdentity Id { get; }

        /// <summary>
        /// Determines whether this instance is transient.
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if this instance is transient; otherwise, <c>false</c>.
        /// </returns>
        bool IsTransient();
    }
}
