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

using System;
using System.Collections;
using Server;

namespace Server.Mobiles
{
	public class BlacksmithGuildmaster : BaseGuildmaster
	{
		public override NpcGuild NpcGuild { get { return NpcGuild.BlacksmithsGuild; } }

		public override bool ClickTitle { get { return true; } }

		[Constructable]
		public BlacksmithGuildmaster()
			: base("blacksmith")
		{
			SetSkill(SkillName.ArmsLore, 65.0, 88.0);
			SetSkill(SkillName.Blacksmith, 90.0, 100.0);
			SetSkill(SkillName.Macing, 36.0, 68.0);
			SetSkill(SkillName.Parry, 36.0, 68.0);
		}

		public override VendorShoeType ShoeType
		{
			get { return VendorShoeType.ThighBoots; }
		}

		public override void InitOutfit()
		{
			base.InitOutfit();

			Item item = (Utility.RandomBool() ? null : new Server.Items.RingmailChest());

			if (item != null && !EquipItem(item))
			{
				item.Delete();
				item = null;
			}

			if (item == null)
				AddItem(new Server.Items.FullApron());

			AddItem(new Server.Items.Bascinet());
			AddItem(new Server.Items.SmithHammer());
		}

		public BlacksmithGuildmaster(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}