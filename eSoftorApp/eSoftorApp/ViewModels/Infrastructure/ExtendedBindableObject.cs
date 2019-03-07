//  <copyright file="ExtendedBindableObject.cs" company="ESoftor">
//      Copyright (c) 2014-2015 ESoftor. All rights reserved.
//  </copyright>
//  <last-editor>谭明超</last-editor>
//  <last-date>2019/3/6 21:31:23</last-date>

namespace eSoftorApp.ViewModels.Infrastructure
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    using Xamarin.Forms;

    /// <summary>
    /// Defines the <see cref="ExtendedBindableObject" />
    /// </summary>
    public abstract class ExtendedBindableObject : BindableObject
    {
        /// <summary>
        /// The RaisePropertyChanged
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="property">The property<see cref="Expression{Func{T}}"/></param>
        public void RaisePropertyChanged<T>(Expression<Func<T>> property)
        {
            var name = GetMemberInfo(property).Name;
            OnPropertyChanged(name);
        }

        /// <summary>
        /// The GetMemberInfo
        /// </summary>
        /// <param name="expression">The expression<see cref="Expression"/></param>
        /// <returns>The <see cref="MemberInfo"/></returns>
        private MemberInfo GetMemberInfo(Expression expression)
        {
            MemberExpression operand;
            LambdaExpression lambdaExpression = (LambdaExpression)expression;
            if (lambdaExpression.Body as UnaryExpression != null)
            {
                UnaryExpression body = (UnaryExpression)lambdaExpression.Body;
                operand = (MemberExpression)body.Operand;
            }
            else
            {
                operand = (MemberExpression)lambdaExpression.Body;
            }
            return operand.Member;
        }
    }
}
