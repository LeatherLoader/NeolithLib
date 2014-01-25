//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34003
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
namespace NeolithLib.API.Events
{
	public class PostCreateDeployableEvent
	{
		public DeployableItemDataBlock DataBlock { get; set; }
		public Character Character { get; set; }
		public IInventoryItem Item { get; set; }
		public ItemRepresentation ItemRepresentation { get; set; }
		public DeployableObject DeployableItem { get; set; }
		public TransCarrier Carrier { get; set; }
		public bool WasHandled { get; set; }
		public bool Handled { get; set; }

		public PostCreateDeployableEvent (DeployableItemDataBlock dataBlock, Character character, IInventoryItem item, ItemRepresentation itemRep, DeployableObject deployable, TransCarrier carrier, bool wasHandled)
		{
			this.DataBlock = dataBlock;
			this.Character = character;
			this.Item = item;
			this.ItemRepresentation = itemRep;
			this.DeployableItem = deployable;
			this.Carrier = carrier;
			this.WasHandled = wasHandled;
			this.Handled = false;
		}
	}
}

