// <copyright file="ListTest.cs">Copyright ©  2017</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackCalculator;

namespace StackCalculator.Tests
{
    /// <summary>Этот класс содержит параметризованные модульные тесты для List</summary>
    [PexClass(typeof(List))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class ListTest
    {
        /// <summary>Тестовая заглушка для Add(Int32)</summary>
        [PexMethod]
        public void AddTest([PexAssumeUnderTest]List target, int value)
        {
            target.Add(value);
            // TODO: добавление проверочных утверждений в метод ListTest.AddTest(List, Int32)
        }
    }
}
