﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using FluentAssertions;
using FluentAssertions.Collections;

namespace Atata.Tests
{
    public static class GenericCollectionAssertionsExtensions
    {
        public static AndConstraint<GenericCollectionAssertions<T>> BeSameSequenceAs<T>(this GenericCollectionAssertions<T> assertions, IEnumerable<T> expected)
        {
            var result = assertions.BeEquivalentTo(expected);

            assertions.Subject.SequenceEqual(expected, ReferenceEqualityComparer<T>.Default).Should().BeTrue("sequence should equal");

            return result;
        }

        public static AndConstraint<GenericCollectionAssertions<T>> BeSameSequenceAs<T>(this GenericCollectionAssertions<T> assertions, IEnumerable expected)
        {
            return assertions.BeSameSequenceAs(expected.Cast<T>());
        }

        public static AndConstraint<GenericCollectionAssertions<T>> BeSameSequenceAs<T>(this GenericCollectionAssertions<T> assertions, params object[] expected)
        {
            return assertions.BeSameSequenceAs(expected.Cast<T>());
        }

        public class ReferenceEqualityComparer<T> : EqualityComparer<T>
        {
            private static IEqualityComparer<T> defaultComparer;

            public static new IEqualityComparer<T> Default
            {
                get { return defaultComparer ?? (defaultComparer = new ReferenceEqualityComparer<T>()); }
            }

            public override bool Equals(T x, T y)
            {
                return ReferenceEquals(x, y);
            }

            public override int GetHashCode(T obj)
            {
                return RuntimeHelpers.GetHashCode(obj);
            }
        }
    }
}
