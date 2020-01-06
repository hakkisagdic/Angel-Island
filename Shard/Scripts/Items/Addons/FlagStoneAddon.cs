/*
 *	This program is the CONFIDENTIAL and PROPRIETARY property
 *	of Tomasello Software LLC. Any unauthorized use, reproduction or
 *	transfer of this computer program is strictly prohibited.
 *
 *      Copyright (c) 2004 Tomasello Software LLC.
 *	This is an unpublished work, and is subject to limited distribution and
 *	restricted disclosure only. ALL RIGHTS RESERVED.
 *
 *			RESTRICTED RIGHTS LEGEND
 *	Use, duplication, or disclosure by the Government is subject to
 *	restrictions set forth in subparagraph (c)(1)(ii) of the Rights in
 * 	Technical Data and Computer Software clause at DFARS 252.227-7013.
 *
 *	Angel Island UO Shard	Version 1.0
 *			Release A
 *			March 25, 2004
 */

/* ChangeLog.
 *	5/15/05, Adam
 *		comment out debugging info
 *	05/14/05, erlein
 *		Added debugging of constructor.
 *    10/13/04,Darva
 *		Name fix.
 *	10/12/04,Darva
 *		Added two components, FlagstoneBase and FlagstoneRune
 *		Added confirmation gump
 *		Added logic to make player go grey after using.
 *
 *	10/6/04,Adam
 *		First time checkin
 */

/////////////////////////////////////////////////
//
// Automatically generated by the
// AddonGenerator script by Arya
//
/////////////////////////////////////////////////
using System;
using Server;
using Server.Items;
using Server.Gumps;

namespace Server.Items
{
	public class FlagStoneAddon : BaseAddon
	{
		public static int InstanceCount;

		public override BaseAddonDeed Deed
		{
			get
			{
				return new FlagStoneAddonDeed();
			}
		}

		[Constructable]
		public FlagStoneAddon()
		{
			/*AddonComponent ac = null;
			ac = new AddonComponent( 1306 );
			ac.Hue = 937;
			AddComponent( ac, 0, 0, 0 );
			ac = new AddonComponent( 3686 );
			ac.Hue = 137;
			AddComponent( ac, 0, 0, 0 );

		Using classes for components instead of implicit creation.
			*/
			AddComponent(new FlagstoneBase(), 0, 0, 0);
			AddComponent(new FlagstoneRune(), 0, 0, 0);

			//erl: constructor debugging
			InstanceCount++;
			//Console.WriteLine("Constructing instance {0} of FlagstoneAddon", InstanceCount);
			// -- end debug
		}

		public FlagStoneAddon(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0); // Version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}

	public class FlagStoneAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new FlagStoneAddon();
			}
		}

		[Constructable]
		public FlagStoneAddonDeed()
		{
			Name = "a flag stone deed";
		}

		public FlagStoneAddonDeed(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0); // Version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}
}

public class FlagstoneBase : AddonComponent
{
	[Constructable]
	public FlagstoneBase()
		: this(1306)
	{
		Name = "a flag stone";
		Hue = 937;
	}

	public FlagstoneBase(int itemID)
		: base(itemID)
	{
	}

	public FlagstoneBase(Serial serial)
		: base(serial)
	{
	}

	public override void OnDoubleClick(Mobile from)
	{
		if (from.InRange(this, 2))
		{
			from.SendGump(new ConfirmFlagstoneUseGump(from, this));
		}
		else
		{
			from.SendMessage("You must be closer. ");
		}

	}


	public override void Serialize(GenericWriter writer)
	{
		base.Serialize(writer);

		writer.Write((int)0);

	}

	public override void Deserialize(GenericReader reader)
	{
		base.Deserialize(reader);

		int version = reader.ReadInt();
	}
}

public class FlagstoneRune : AddonComponent
{
	[Constructable]
	public FlagstoneRune()
		: this(3686)
	{
		Name = "a flag stone";
		Hue = 137;
	}

	public FlagstoneRune(int itemID)
		: base(itemID)
	{
	}

	public FlagstoneRune(Serial serial)
		: base(serial)
	{
	}

	public override void OnDoubleClick(Mobile from)
	{
		if (from.InRange(this, 2))
		{
			from.SendGump(new ConfirmFlagstoneUseGump(from, this));

		}
		else
		{
			from.SendMessage("You must be closer. ");
		}

	}


	public override void Serialize(GenericWriter writer)
	{
		base.Serialize(writer);

		writer.Write((int)0);

	}

	public override void Deserialize(GenericReader reader)
	{
		base.Deserialize(reader);

		int version = reader.ReadInt();
	}
}
