﻿using Exodrifter.Rumor.Expressions;
using NUnit.Framework;

namespace Exodrifter.Rumor.Test.Expressions
{
	/// <summary>
	/// Ensure Literal expressions operate as expected.
	/// </summary>
	public class LiteralExpressionTest
	{
		/// <summary>
		/// Check the constructors of literal expressions.
		/// </summary>
		[Test]
		public void LiteralExpressionConstructor()
		{
			var a = new LiteralExpression(1);
			Assert.AreEqual(a.Value.GetType(), typeof(IntValue));

			var b = new LiteralExpression(1.0f);
			Assert.AreEqual(b.Value.GetType(), typeof(FloatValue));

			var c = new LiteralExpression("1");
			Assert.AreEqual(c.Value.GetType(), typeof(StringValue));
		}

		/// <summary>
		/// Check Literal expressions equality.
		/// </summary>
		[Test]
		public void LiteralExpressionEquality()
		{
			var a = new LiteralExpression(1);
			var b = new LiteralExpression(1);
			var c = new LiteralExpression(1.0f);
			var d = new LiteralExpression("1");

			Assert.AreEqual(a, a);
			Assert.AreEqual(b, b);
			Assert.AreEqual(c, c);
			Assert.AreEqual(d, d);

			Assert.AreEqual(a, b);
			Assert.AreNotEqual(a, c);
			Assert.AreNotEqual(a, d);
			Assert.AreNotEqual(c, d);
		}
	}
}
