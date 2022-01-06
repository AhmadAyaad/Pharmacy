using AutoFixture;
using AutoFixture.Dsl;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ZPharmacy.Tests.Helper
{
    public static class AutoFixtureHelper
    {
        public static T GenerateFakeEntity<T>()
        {
            return CreateCustomFixture().Build<T>().OmitNavigationProperties().Create<T>();
        }
        public static T GenerateFakeEntity<T>(this IFixture fixture)
        {
            return fixture.Build<T>().OmitNavigationProperties().Create<T>();
        }
        public static IEnumerable<T> GenerateFakeEntities<T>(this IFixture fixture, int count = 3)
        {
            return fixture.Build<T>().OmitNavigationProperties().CreateMany<T>(count);
        }
        public static Fixture CreateCustomFixture()
        {
            var fixture = new Fixture();
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(behavior => fixture.Behaviors.Remove(behavior));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            return fixture;
        }
        public static IPostprocessComposer<T> OmitNavigationProperties<T>(this IPostprocessComposer<T> customizationComposer)
        {
            var excludeProperties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                              .Where(p =>
                                              p.CanWrite &&
                                              p.GetAccessors(false).Any(a => a.Name.StartsWith("set_") && a.IsPublic) &&
                                              (
                                              (typeof(IEnumerable).IsAssignableFrom(p.PropertyType) && p.PropertyType.GenericTypeArguments.Any(t => t.IsClass)) ||
                                                   (!typeof(IEnumerable).IsAssignableFrom(p.PropertyType) && p.PropertyType.IsClass)
                                              )
                                              )
                                              .ToList();
            IPostprocessComposer<T> newComposer = customizationComposer;
            foreach (var property in excludeProperties)
            {
                newComposer = newComposer.Without(GeneratePropertyNameLambdaExpression<T>(property.Name));
            }
            return newComposer;
        }
        private static Expression<Func<T, object>> GeneratePropertyNameLambdaExpression<T>(string propertyName)
        {
            var elementType = typeof(T);
            ParameterExpression parameterExpression = Expression.Parameter(elementType);
            Expression propertyExpression = Expression.PropertyOrField(parameterExpression, propertyName);
            return Expression.Lambda<Func<T, object>>(propertyExpression, parameterExpression);
        }

    }
}
