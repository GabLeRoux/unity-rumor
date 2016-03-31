﻿using Exodrifter.Rumor.Nodes;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Exodrifter.Rumor.Engine
{
	/// <summary>
	/// Interface for storing state about the game.
	/// </summary>
	[Serializable]
	public class RumorState : ISerializable
	{
		/// <summary>
		/// Returns the current dialog.
		/// </summary>
		public string Dialog { get; private set; }

		/// <summary>
		/// Returns a list of choices.
		/// </summary>
		public List<string> Choices { get; private set; }

		/// <summary>
		/// Returns a list of nodes for each choice
		/// </summary>
		public List<List<Node>> Consequences { get; private set; }

		/// <summary>
		/// Creates a new Rumor state.
		/// </summary>
		public RumorState()
		{
			Reset();
		}

		/// <summary>
		/// Resets the state.
		/// </summary>
		public void Reset()
		{
			Dialog = "";
			Choices = new List<string>();
			Consequences = new List<List<Node>>();
		}

		/// <summary>
		/// Sets the dialog for the state.
		/// </summary>
		/// <param name="dialog">The dialog to set.</param>
		public void SetDialog(string dialog)
		{
			Dialog = dialog ?? "";
		}

		/// <summary>
		/// Adds to the dialog for the state.
		/// </summary>
		/// <param name="dialog">The dialog to add.</param>
		public void AddDialog(string dialog)
		{
			Dialog += dialog;
		}

		/// <summary>
		/// Adds a choice for the state.
		/// </summary>
		/// <param name="choice">
		/// The text for the choice.
		/// </param>
		/// <param name="nodes">
		/// The nodes to use if the choice is selected.
		/// </param>
		/// <returns>
		/// The index of the choice.
		/// </returns>
		public int AddChoice(string choice, IEnumerable<Node> nodes)
		{
			Choices.Add(choice);
			Consequences.Add(new List<Node>(nodes));
			return Choices.Count - 1;
		}

		/// <summary>
		/// Removes all current choices.
		/// </summary>
		public void ClearChoices()
		{
			Choices.Clear();
			Consequences.Clear();
		}

		#region Serialization

		public RumorState(SerializationInfo info, StreamingContext context)
		{
			Dialog = (string)info.GetValue("dialog", typeof(string));
			Choices = (List<string>)info.GetValue("choices", typeof(List<string>));
			Consequences = (List<List<Node>>)info.GetValue("consequences", typeof(List<List<Node>>));
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("dialog", Dialog, typeof(string));
			info.AddValue("choices", Choices, typeof(List<string>));
			info.AddValue("consequences", Consequences, typeof(List<List<Node>>));
		}

		#endregion
	}
}