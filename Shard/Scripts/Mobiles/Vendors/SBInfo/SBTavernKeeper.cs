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

/* Scripts/Mobiles/Vendors/SBInfo/SBTavernKeeper.cs
 * ChangeLog
 *  04/19/05, Kit
 *	Added Vendor rental contract
 *  11/12/04, Jade
 *      Changed spelling to make housesitter one word.
 *  11/07/2004, Jade
 *      Added new House Sitter deeds to the inventory of items for sale.
 *	4/24/04, mith
 *		Commented all items from SellList so that NPCs don't buy from players.
 */

using System;
using System.Collections;
using Server.Items;

namespace Server.Mobiles
{
	public class SBTavernKeeper : SBInfo
	{
		private ArrayList m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBTavernKeeper()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override ArrayList BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : ArrayList
		{
			public InternalBuyInfo()
			{
				Add(new BeverageBuyInfo(typeof(BeverageBottle), BeverageType.Ale, 7, 20, 0x99F, 0));
				Add(new BeverageBuyInfo(typeof(BeverageBottle), BeverageType.Wine, 7, 20, 0x9C7, 0));
				Add(new BeverageBuyInfo(typeof(BeverageBottle), BeverageType.Liquor, 7, 20, 0x99B, 0));
				Add(new BeverageBuyInfo(typeof(Jug), BeverageType.Cider, 13, 20, 0x9C8, 0));
				Add(new BeverageBuyInfo(typeof(Pitcher), BeverageType.Milk, 7, 20, 0x9F0, 0));
				Add(new BeverageBuyInfo(typeof(Pitcher), BeverageType.Ale, 11, 20, 0x1F95, 0));
				Add(new BeverageBuyInfo(typeof(Pitcher), BeverageType.Cider, 11, 20, 0x1F97, 0));
				Add(new BeverageBuyInfo(typeof(Pitcher), BeverageType.Liquor, 11, 20, 0x1F99, 0));
				Add(new BeverageBuyInfo(typeof(Pitcher), BeverageType.Wine, 11, 20, 0x1F9B, 0));
				Add(new BeverageBuyInfo(typeof(Pitcher), BeverageType.Water, 11, 20, 0x1F9D, 0));
				Add(new GenericBuyInfo(typeof(Pitcher), 7, 20, 0xFF6, 0));
				Add(new GenericBuyInfo(typeof(BreadLoaf), 7, 10, 0x103B, 0));
				Add(new GenericBuyInfo(typeof(CheeseWheel), 25, 10, 0x97E, 0));
				Add(new GenericBuyInfo(typeof(CookedBird), 17, 20, 0x9B7, 0));
				Add(new GenericBuyInfo(typeof(LambLeg), 8, 20, 0x160A, 0));
				// TODO: Bowl of *, baked pie
				Add(new GenericBuyInfo("1016450", typeof(Chessboard), 2, 20, 0xFA6, 0));
				Add(new GenericBuyInfo("1016449", typeof(CheckerBoard), 2, 20, 0xFA6, 0));
				Add(new GenericBuyInfo(typeof(Backgammon), 2, 20, 0xE1C, 0));
				Add(new GenericBuyInfo(typeof(Dices), 2, 20, 0xFA7, 0));

				if (Core.UOAI || Core.UOAR || Core.UOMO)
				{
					// Jade: Add new House Sitter deeds
					Add(new GenericBuyInfo("a housesitter contract", typeof(HouseSitterDeed), 2500, 20, 0x14F0, 0));
					Add(new GenericBuyInfo("1041243", typeof(ContractOfEmployment), 1025, 20, 0x14F0, 0));
					Add(new GenericBuyInfo("vendor rental contract", typeof(VendorRentalContract), 1025, 20, 0x14F0, 0));
				}
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if (!Core.UOAI && !Core.UOAR && !Core.UOSP && !Core.UOMO)
				{	// cash buyback
					Add(typeof(BeverageBottle), 3);
					Add(typeof(Jug), 6);
					Add(typeof(Pitcher), 5);
					Add(typeof(BreadLoaf), 3);
					Add(typeof(CheeseWheel), 12);
					Add(typeof(CookedBird), 8);
					Add(typeof(LambLeg), 4);
					Add(typeof(Chessboard), 1);
					Add(typeof(CheckerBoard), 1);
					Add(typeof(Backgammon), 1);
					Add(typeof(Dices), 1);
					Add(typeof(ContractOfEmployment), 512);
				}
			}
		}
	}
}