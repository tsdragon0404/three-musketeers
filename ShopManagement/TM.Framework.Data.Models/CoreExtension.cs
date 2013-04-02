using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace TM.Framework.Data.Models
{
    /// <summary>
    /// A class holds all implementation of extension methods that would be use across system.
    /// </summary>
    /// <remarks>
    /// This class has violated SRP, but it's reasonable. Not necessary to split into many specific extension classes.
    /// While adding more methods, remember to put them in according regions.
    /// </remarks>
    public static class CoreExtension
    {
        #region Collection extension
        /// <summary>
        /// Applies the specified action to each item in the collection.
        /// </summary>
        /// <typeparam name="TElement">The element type</typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <param name="action">The action.</param>
        public static void Apply<TElement>(this IEnumerable<TElement> enumerable, Action<TElement> action)
        {
            foreach (var item in enumerable)
            {
                action(item);
            }
        }

        /// <summary>
        /// Ares the equal.
        /// </summary>
        /// <typeparam name="TElement">The type of the element.</typeparam>
        /// <param name="enumerable1">The enumerable1.</param>
        /// <param name="enumerable2">The enumerable2.</param>
        /// <returns></returns>
        public static bool AreEqual<TElement>(this IEnumerable<TElement> enumerable1, IEnumerable<TElement> enumerable2)
        {
            return enumerable1.Count() == enumerable2.Count() && !enumerable1.Except(enumerable2).Any();
        }

        #endregion

        #region String extension
        /// <summary>
        /// Removes the special character (%,_,[)
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string RemoveSpecialCharacter(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

			value = value.Replace("[", "[[]");
            value = value.Replace("%", "[%]");
            value = value.Replace("_", "[_]");

            return value;
        }

        /// <summary>
        /// Determines whether [is null or empty] [the specified value].
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if [is null or empty] [the specified value]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// Equals the ignore case.
        /// </summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns></returns>
        public static bool EqualIgnoreCase(this string value1, string value2)
        {
            return value1.Equals(value2, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Joins the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="separator">The separator.</param>
        /// <returns></returns>
        public static string Join(this IEnumerable<string> source, string separator)
        {
            if (source == null || string.IsNullOrEmpty(separator))
                return string.Empty;

            source = source.Distinct().ToList();
            return string.Join(separator, source);
        }
        #endregion

        #region Reflection extension

        /// <summary>
        /// Gets the attributes.
        /// </summary>
        /// <typeparam name="T">The attribute type.</typeparam>
        /// <param name="member">The member.</param>
        /// <param name="inherit">if set to <c>true</c> [inherit].</param>
        /// <returns>The attributes.</returns>
        public static IEnumerable<T> GetAttributes<T>(this MemberInfo member, bool inherit)
        {
            return Attribute.GetCustomAttributes(member, inherit).OfType<T>();
        }

        /// <summary>
        /// Gets the member info represented by an expression.
        /// </summary>
        /// <param name="expression">The member expression.</param>
        /// <returns>The member info represeted by the expression.</returns>
        public static MemberInfo GetMemberInfo(this Expression expression)
        {
            var lambda = (LambdaExpression)expression;

            MemberExpression memberExpression;
            if (lambda.Body is UnaryExpression)
            {
                var unaryExpression = (UnaryExpression)lambda.Body;
                memberExpression = (MemberExpression)unaryExpression.Operand;
            }
            else memberExpression = (MemberExpression)lambda.Body;

            return memberExpression.Member;
        }


        /// <summary>
        /// Gets the value by property case insensitive.
        /// </summary>
        /// <typeparam name="T">The T</typeparam>
        /// <param name="target">The target.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        public static T GetValueByPropertyCaseInsensitive<T>(this object target, string propertyName)
        {
            var properties = target.GetType().GetProperty(propertyName);

            return (T)properties.GetValue(target, null);
        }

        /// <summary>
        /// Sets the property value.
        /// </summary>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="target">The target.</param>
        /// <param name="newValue">The new value.</param>
        /// <param name="propertyName">Name of the property.</param>
        public static void SetPropertyValue<TProperty>(this object target, TProperty newValue, string propertyName)
        {
            var propertyInfo = target.GetType().GetProperty(
                                                propertyName,
                                                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (propertyInfo == null)
                new ArgumentOutOfRangeException("propertyName");

            if (propertyInfo != null) propertyInfo.SetValue(target, newValue, null);
        }
        #endregion

        #region Lambda Expression extension
        /// <summary>
        /// Or operator for composite expression.
        /// </summary>
        /// <typeparam name="T">Data type where expression is executed against</typeparam>
        /// <param name="expr1">Left expression</param>
        /// <param name="expr2">Right expression</param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1,
                                                            Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters);
            return Expression.Lambda<Func<T, bool>>
                  (Expression.OrElse(expr1.Body, invokedExpr), expr1.Parameters);
        }

        /// <summary>
        /// And operation for composite expression.
        /// </summary>
        /// <typeparam name="T">Data type where expression is executed against</typeparam>
        /// <param name="expr1">Left expression</param>
        /// <param name="expr2">Right expression</param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1,
                                                             Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters);
            return Expression.Lambda<Func<T, bool>>
                  (Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);
        }

        /// <summary>
        /// Not operation for composite expression.
        /// </summary>
        /// <typeparam name="T">Data type where expression is executed against</typeparam>
        /// <param name="expr">The expression.</param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> Not<T>(this Expression<Func<T, bool>> expr)
        {
            return Expression.Lambda<Func<T, bool>>
                  (Expression.Not(expr.Body), expr.Parameters);
        }
        #endregion

        #region object extension

        /// <summary>
        /// Toes the specified obj.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The obj.</param>
        /// <returns></returns>
        public static T To<T>(this object obj)
        {
            return (T)Convert.ChangeType(obj, typeof(T));
        }
        #endregion

        #region double extension
        /// <summary>
        /// Convert a double value to radian value
        /// </summary>
        /// <param name="val">Double value</param>
        /// <returns>Radian value</returns>
        public static double ToRadians(this double val)
        {
            return (Math.PI / 180) * val;
        }
        #endregion
    }
}
