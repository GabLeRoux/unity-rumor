﻿using Exodrifter.Rumor.Engine;
using Exodrifter.Rumor.Util;
using System;
using System.Runtime.Serialization;

namespace Exodrifter.Rumor.Expressions
{
	/// <summary>
	/// Represents an expression that is a literal.
	/// </summary>
	[Serializable]
	public class LiteralExpression : Expression, ISerializable
	{
		/// <summary>
		/// The value of this literal.
		/// </summary>
		public Value Value { get { return value; } }
		private readonly Value value;

		public LiteralExpression(int num)
		{
			value = new IntValue(num);
		}

		public LiteralExpression(float num)
		{
			value = new FloatValue(num);
		}

		public LiteralExpression(string str)
		{
			value = new StringValue(str);
		}

		public LiteralExpression(bool b)
		{
			value = new BoolValue(b);
		}

		public override Value Evaluate(Scope scope)
		{
			return value;
		}

		public override string ToString()
		{
			if (value != null)
				return value.ToString();
			return "";
		}

		#region Equality

		public override bool Equals(object obj)
		{
			var other = obj as LiteralExpression;
			if (other == null) {
				return false;
			}
			return other.value == value;
		}

		public bool Equals(LiteralExpression other)
		{
			if (other == null) {
				return false;
			}
			return other.value == value;
		}

		public override int GetHashCode()
		{
			return value.GetHashCode();
		}

		#endregion

		#region Serialization

		public LiteralExpression
			(SerializationInfo info, StreamingContext context)
		{
			value = info.GetValue<Value>("value");
		}

		void ISerializable.GetObjectData
			(SerializationInfo info, StreamingContext context)
		{
			info.AddValue<Value>("value", value);
		}

		#endregion
	}
}