﻿using System.Xml;

using ConfigBuilder.Entities;

namespace ConfigBuilder.Infrastructure;

public class XmlToConfigConverter : IMediaToConfigConverter
{
	public ValueTask<ConfigNode> ConvertAsync(Stream stream)
	{
		Stack<ConfigNode> stack = new Stack<ConfigNode>();

		ConfigNode rootNode = null;
		using (XmlReader reader = XmlReader.Create(stream))
		{

			while (reader.Read())
			{
				switch (reader.NodeType)
				{
					case XmlNodeType.Document:
					case XmlNodeType.DocumentFragment:
					case XmlNodeType.DocumentType:
					case XmlNodeType.XmlDeclaration:
					case XmlNodeType.Notation:
						break;
					case XmlNodeType.Comment:
						break;
					case XmlNodeType.ProcessingInstruction:
						break;
					case XmlNodeType.Whitespace:
						break;
					case XmlNodeType.SignificantWhitespace:
					case XmlNodeType.CDATA:
					case XmlNodeType.Text:
						stack.Peek().SetText(reader.Value);
						break;
					case XmlNodeType.Element:
						ConfigNode model = new ConfigNode(reader.LocalName);
						if (stack.Count == 0)
						{
							rootNode = model;
						}
						else
						{
							stack.Peek().AddChildNode(model);
						}

						if (reader.HasAttributes)
						{
							while (reader.MoveToNextAttribute())
							{
								model.AddAttribute(reader.LocalName, reader.Value);
							}

							reader.MoveToElement();
						}

						if (!reader.IsEmptyElement)
						{
							stack.Push(model);
						}

						break;
					case XmlNodeType.EndElement:
						stack.Pop();
						break;
				}
			}
		}

		//TODO: Hier kann null zurückgeliefert werden
		return ValueTask.FromResult(rootNode);
	}
}