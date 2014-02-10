using CommonLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Budgie.DialogIn
{
	class PickAndDropDialogInputItem : IDialogInputItem
	{
		private MetamorphAction action;
		private string objectID = String.Empty;
		private string informationID = String.Empty;
		private int slotID = -1;

		public PickAndDropDialogInputItem(MetamorphAction action, string objectID, string informationID = "", int slotID = -1)
		{
			this.action = action;
			this.objectID = objectID;
			this.informationID = informationID;
			this.slotID = slotID;
		}

		public XElement XRepresentation
		{
			get
			{
				XElement xPickAndDrop = new XElement("pickAndDrop");

				switch (action)
				{
					case MetamorphAction.Pick:
						xPickAndDrop.Add(new XElement( "pick",
							new XElement("abstractInformation",
								new XAttribute("objectID", objectID),		
								new XAttribute("informationID", informationID)),
							new XAttribute("slotID", slotID)));
						break;
					case MetamorphAction.Drop:
						xPickAndDrop.Add(new XElement("drop",
							new XElement("abstractInformation",
								new XAttribute("objectID", objectID),
								new XAttribute("informationID", informationID))));
						break;
					case MetamorphAction.Select:
						xPickAndDrop.Add(new XElement("select",
							new XAttribute("slotID", slotID)));
						break;
					case MetamorphAction.Deselect:
						xPickAndDrop.Add(new XElement("deselect",
							new XAttribute("slotID", slotID)));
						break;
					case MetamorphAction.ClearSlot:
						xPickAndDrop.Add(new XElement("clearSlot",
							new XAttribute("slotID", slotID)));
						break;
					case MetamorphAction.ClearUiComponent:
						xPickAndDrop.Add(new XElement("clearUiComponent",
							new XAttribute("objectID", objectID)));
						break;
				}

				return xPickAndDrop;
			}
		}
		
	}
}
