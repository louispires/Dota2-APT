using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeXt.APT.NameTranslator
{
    public class Item
    {
        private Item(string displayname, string internalIdentifier)
        {
            DisplayName = displayname;
            InternalIdentifier = internalIdentifier;
        }

        public string DisplayName { get; private set; }

        public string InternalIdentifier { get; private set; }

        public bool MatchesName(string text)
        {
            return DisplayName.EditDistance(text) < 0.15;
        }

        public static List<Item> BuildList()
        {
            var list = new List<Item>();
            //Abyssal Blade
            list.Add(new Item("Abyssal Blade", "DOTA_Tooltip_ability_item_abyssal_blade"));
            //Armlet of Mordiggian
            list.Add(new Item("Armlet of Mordiggian", "DOTA_Tooltip_ability_item_armlet"));
            //Assault Cuirass
            list.Add(new Item("Assault Cuirass", "DOTA_Tooltip_ability_item_assault"));
            //Skull Basher
            list.Add(new Item("Skull Basher", "DOTA_Tooltip_ability_item_basher"));
            //Belt of Strength
            list.Add(new Item("Belt of Strength", "DOTA_Tooltip_ability_item_belt_of_strength"));
            //Battle Fury
            list.Add(new Item("Battle Fury", "DOTA_Tooltip_ability_item_bfury"));
            //Black King Bar
            list.Add(new Item("Black King Bar", "DOTA_Tooltip_ability_item_black_king_bar"));
            //Blade Mail
            list.Add(new Item("Blade Mail", "DOTA_Tooltip_ability_item_blade_mail"));
            //Blades of Attack
            list.Add(new Item("Blades of Attack", "DOTA_Tooltip_ability_item_blades_of_attack"));
            //Blade of Alacrity
            list.Add(new Item("Blade of Alacrity", "DOTA_Tooltip_ability_item_blade_of_alacrity"));
            //Blink Dagger
            list.Add(new Item("Blink Dagger", "DOTA_Tooltip_ability_item_blink"));
            //Bloodstone
            list.Add(new Item("Bloodstone", "DOTA_Tooltip_ability_item_bloodstone"));
            //Boots of Speed
            list.Add(new Item("Boots of Speed", "DOTA_Tooltip_ability_item_boots"));
            //Band of Elvenskin
            list.Add(new Item("Band of Elvenskin", "DOTA_Tooltip_ability_item_boots_of_elves"));
            //Bottle
            list.Add(new Item("Bottle", "DOTA_Tooltip_ability_item_bottle"));
            //Bracer
            list.Add(new Item("Bracer", "DOTA_Tooltip_ability_item_bracer"));
            //Iron Branch
            list.Add(new Item("Iron Branch", "DOTA_Tooltip_ability_item_branches"));
            //Broadsword
            list.Add(new Item("Broadsword", "DOTA_Tooltip_ability_item_broadsword"));
            //Buckler
            list.Add(new Item("Buckler", "DOTA_Tooltip_ability_item_buckler"));
            //Butterfly
            list.Add(new Item("Butterfly", "DOTA_Tooltip_ability_item_butterfly"));
            //Chainmail
            list.Add(new Item("Chainmail", "DOTA_Tooltip_ability_item_chainmail"));
            //Circlet
            list.Add(new Item("Circlet", "DOTA_Tooltip_ability_item_circlet"));
            //Clarity
            list.Add(new Item("Clarity", "DOTA_Tooltip_ability_item_clarity"));
            //Claymore
            list.Add(new Item("Claymore", "DOTA_Tooltip_ability_item_claymore"));
            //Cloak
            list.Add(new Item("Cloak", "DOTA_Tooltip_ability_item_cloak"));
            //Crimson Guard
            list.Add(new Item("Crimson Guard", "DOTA_Tooltip_ability_item_crimson_guard"));
            //Animal Courier
            list.Add(new Item("Animal Courier", "DOTA_Tooltip_ability_item_courier"));
            //Flying Courier
            list.Add(new Item("Flying Courier", "DOTA_Tooltip_ability_item_flying_courier"));
            //Eul's Scepter of Divinity
            list.Add(new Item("Eul's Scepter of Divinity", "DOTA_Tooltip_ability_item_cyclone"));
            //Dagon
            list.Add(new Item("Dagon", "DOTA_Tooltip_ability_item_dagon"));
            //Dagon
            list.Add(new Item("Dagon", "DOTA_Tooltip_ability_item_dagon_2"));
            //Dagon
            list.Add(new Item("Dagon", "DOTA_Tooltip_ability_item_dagon_3"));
            //Dagon
            list.Add(new Item("Dagon", "DOTA_Tooltip_ability_item_dagon_4"));
            //Dagon
            list.Add(new Item("Dagon", "DOTA_Tooltip_ability_item_dagon_5"));
            //Demon Edge
            list.Add(new Item("Demon Edge", "DOTA_Tooltip_ability_item_demon_edge"));
            //Desolator
            list.Add(new Item("Desolator", "DOTA_Tooltip_ability_item_desolator"));
            //Diffusal Blade
            list.Add(new Item("Diffusal Blade", "DOTA_Tooltip_ability_item_diffusal_blade"));
            //Diffusal Blade
            list.Add(new Item("Diffusal Blade", "DOTA_Tooltip_ability_item_diffusal_blade_2"));
            //Dust of Appearance
            list.Add(new Item("Dust of Appearance", "DOTA_Tooltip_ability_item_dust"));
            //Eaglesong
            list.Add(new Item("Eaglesong", "DOTA_Tooltip_ability_item_eagle"));
            //Energy Booster
            list.Add(new Item("Energy Booster", "DOTA_Tooltip_ability_item_energy_booster"));
            //Ethereal Blade
            list.Add(new Item("Ethereal Blade", "DOTA_Tooltip_ability_item_ethereal_blade"));
            //Healing Salve
            list.Add(new Item("Healing Salve", "DOTA_Tooltip_ability_item_flask"));
            //Force Staff
            list.Add(new Item("Force Staff", "DOTA_Tooltip_ability_item_force_staff"));
            //Gauntlets of Strength
            list.Add(new Item("Gauntlets of Strength", "DOTA_Tooltip_ability_item_gauntlets"));
            //Gem of True Sight
            list.Add(new Item("Gem of True Sight", "DOTA_Tooltip_ability_item_gem"));
            //Ghost Scepter
            list.Add(new Item("Ghost Scepter", "DOTA_Tooltip_ability_item_ghost"));
            //Gloves of Haste
            list.Add(new Item("Gloves of Haste", "DOTA_Tooltip_ability_item_gloves"));
            //Daedalus
            list.Add(new Item("Daedalus", "DOTA_Tooltip_ability_item_greater_crit"));
            //Hand of Midas
            list.Add(new Item("Hand of Midas", "DOTA_Tooltip_ability_item_hand_of_midas"));
            //Headdress
            list.Add(new Item("Headdress", "DOTA_Tooltip_ability_item_headdress"));
            //Heart of Tarrasque
            list.Add(new Item("Heart of Tarrasque", "DOTA_Tooltip_ability_item_heart"));
            //Helm of Iron Will
            list.Add(new Item("Helm of Iron Will", "DOTA_Tooltip_ability_item_helm_of_iron_will"));
            //Helm of the Dominator
            list.Add(new Item("Helm of the Dominator", "DOTA_Tooltip_ability_item_helm_of_the_dominator"));
            //Hood of Defiance
            list.Add(new Item("Hood of Defiance", "DOTA_Tooltip_ability_item_hood_of_defiance"));
            //Hyperstone
            list.Add(new Item("Hyperstone", "DOTA_Tooltip_ability_item_hyperstone"));
            //Shadow Blade
            list.Add(new Item("Shadow Blade", "DOTA_Tooltip_ability_item_invis_sword"));
            //Silver Edge
            list.Add(new Item("Silver Edge", "DOTA_Tooltip_ability_item_silver_edge"));
            //Glimmer Cape
            list.Add(new Item("Glimmer Cape", "DOTA_Tooltip_ability_item_glimmer_cape"));
            //Octarine Core
            list.Add(new Item("Octarine Core", "DOTA_Tooltip_ability_item_octarine_core"));
            //Enchanted Mango
            list.Add(new Item("Enchanted Mango", "DOTA_Tooltip_ability_item_enchanted_mango"));
            //Lotus Orb
            list.Add(new Item("Lotus Orb", "DOTA_Tooltip_ability_item_lotus_orb"));
            //Guardian Greaves
            list.Add(new Item("Guardian Greaves", "DOTA_Tooltip_ability_item_guardian_greaves"));
            //Observer and Sentry Wards
            list.Add(new Item("Observer and Sentry Wards", "DOTA_Tooltip_ability_item_ward_dispenser"));
            //Solar Crest
            list.Add(new Item("Solar Crest", "DOTA_Tooltip_ability_item_solar_crest"));
            //Javelin
            list.Add(new Item("Javelin", "DOTA_Tooltip_ability_item_javelin"));
            //Crystalys
            list.Add(new Item("Crystalys", "DOTA_Tooltip_ability_item_lesser_crit"));
            //Morbid Mask
            list.Add(new Item("Morbid Mask", "DOTA_Tooltip_ability_item_lifesteal"));
            //Linken's Sphere
            list.Add(new Item("Linken's Sphere", "DOTA_Tooltip_ability_item_sphere"));
            //Maelstrom
            list.Add(new Item("Maelstrom", "DOTA_Tooltip_ability_item_maelstrom"));
            //Magic Stick
            list.Add(new Item("Magic Stick", "DOTA_Tooltip_ability_item_magic_stick"));
            //Magic Wand
            list.Add(new Item("Magic Wand", "DOTA_Tooltip_ability_item_magic_wand"));
            //Manta Style
            list.Add(new Item("Manta Style", "DOTA_Tooltip_ability_item_manta"));
            //Mantle of Intelligence
            list.Add(new Item("Mantle of Intelligence", "DOTA_Tooltip_ability_item_mantle"));
            //Mask of Madness
            list.Add(new Item("Mask of Madness", "DOTA_Tooltip_ability_item_mask_of_madness"));
            //Mekansm
            list.Add(new Item("Mekansm", "DOTA_Tooltip_ability_item_mekansm"));
            //Mithril Hammer
            list.Add(new Item("Mithril Hammer", "DOTA_Tooltip_ability_item_mithril_hammer"));
            //Mjollnir
            list.Add(new Item("Mjollnir", "DOTA_Tooltip_ability_item_mjollnir"));
            //Monkey King Bar
            list.Add(new Item("Monkey King Bar", "DOTA_Tooltip_ability_item_monkey_king_bar"));
            //Mystic Staff
            list.Add(new Item("Mystic Staff", "DOTA_Tooltip_ability_item_mystic_staff"));
            //Necronomicon
            list.Add(new Item("Necronomicon", "DOTA_Tooltip_ability_item_necronomicon"));
            //Necronomicon
            list.Add(new Item("Necronomicon", "DOTA_Tooltip_ability_item_necronomicon_2"));
            //Necronomicon
            list.Add(new Item("Necronomicon", "DOTA_Tooltip_ability_item_necronomicon_3"));
            //Null Talisman
            list.Add(new Item("Null Talisman", "DOTA_Tooltip_ability_item_null_talisman"));
            //Oblivion Staff
            list.Add(new Item("Oblivion Staff", "DOTA_Tooltip_ability_item_oblivion_staff"));
            //Ogre Club
            list.Add(new Item("Ogre Club", "DOTA_Tooltip_ability_item_ogre_axe"));
            //Orchid Malevolence
            list.Add(new Item("Orchid Malevolence", "DOTA_Tooltip_ability_item_orchid"));
            //Perseverance
            list.Add(new Item("Perseverance", "DOTA_Tooltip_ability_item_pers"));
            //Phase Boots
            list.Add(new Item("Phase Boots", "DOTA_Tooltip_ability_item_phase_boots"));
            //Pipe of Insight
            list.Add(new Item("Pipe of Insight", "DOTA_Tooltip_ability_item_pipe"));
            //Platemail
            list.Add(new Item("Platemail", "DOTA_Tooltip_ability_item_platemail"));
            //Point Booster
            list.Add(new Item("Point Booster", "DOTA_Tooltip_ability_item_point_booster"));
            //Poor Man's Shield
            list.Add(new Item("Poor Man's Shield", "DOTA_Tooltip_ability_item_poor_mans_shield"));
            //Power Treads
            list.Add(new Item("Power Treads", "DOTA_Tooltip_ability_item_power_treads"));
            //Quarterstaff
            list.Add(new Item("Quarterstaff", "DOTA_Tooltip_ability_item_quarterstaff"));
            //Quelling Blade
            list.Add(new Item("Quelling Blade", "DOTA_Tooltip_ability_item_quelling_blade"));
            //Radiance
            list.Add(new Item("Radiance", "DOTA_Tooltip_ability_item_radiance"));
            //Divine Rapier
            list.Add(new Item("Divine Rapier", "DOTA_Tooltip_ability_item_rapier"));
            //Reaver
            list.Add(new Item("Reaver", "DOTA_Tooltip_ability_item_reaver"));
            //Refresher Orb
            list.Add(new Item("Refresher Orb", "DOTA_Tooltip_ability_item_refresher"));
            //Aegis of the Immortal
            list.Add(new Item("Aegis of the Immortal", "DOTA_Tooltip_ability_item_aegis"));
            //Cheese
            list.Add(new Item("Cheese", "DOTA_Tooltip_ability_item_cheese"));
            //Sacred Relic
            list.Add(new Item("Sacred Relic", "DOTA_Tooltip_ability_item_relic"));
            //Ring of Basilius
            list.Add(new Item("Ring of Basilius", "DOTA_Tooltip_ability_item_ring_of_basilius"));
            //Ring of Health
            list.Add(new Item("Ring of Health", "DOTA_Tooltip_ability_item_ring_of_health"));
            //Ring of Protection
            list.Add(new Item("Ring of Protection", "DOTA_Tooltip_ability_item_ring_of_protection"));
            //Ring of Regen
            list.Add(new Item("Ring of Regen", "DOTA_Tooltip_ability_item_ring_of_regen"));
            //Robe of the Magi
            list.Add(new Item("Robe of the Magi", "DOTA_Tooltip_ability_item_robe"));
            //Rod of Atos
            list.Add(new Item("Rod of Atos", "DOTA_Tooltip_ability_item_rod_of_atos"));
            //Sange
            list.Add(new Item("Sange", "DOTA_Tooltip_ability_item_sange"));
            //Heaven's Halberd
            list.Add(new Item("Heaven's Halberd", "DOTA_Tooltip_ability_item_heavens_halberd"));
            //Sange and Yasha
            list.Add(new Item("Sange and Yasha", "DOTA_Tooltip_ability_item_sange_and_yasha"));
            //Satanic
            list.Add(new Item("Satanic", "DOTA_Tooltip_ability_item_satanic"));
            //Scythe of Vyse
            list.Add(new Item("Scythe of Vyse", "DOTA_Tooltip_ability_item_sheepstick"));
            //Shiva's Guard
            list.Add(new Item("Shiva's Guard", "DOTA_Tooltip_ability_item_shivas_guard"));
            //Eye of Skadi
            list.Add(new Item("Eye of Skadi", "DOTA_Tooltip_ability_item_skadi"));
            //Slippers of Agility
            list.Add(new Item("Slippers of Agility", "DOTA_Tooltip_ability_item_slippers"));
            //Sage's Mask
            list.Add(new Item("Sage's Mask", "DOTA_Tooltip_ability_item_sobi_mask"));
            //Soul Booster
            list.Add(new Item("Soul Booster", "DOTA_Tooltip_ability_item_soul_booster"));
            //Soul Ring
            list.Add(new Item("Soul Ring", "DOTA_Tooltip_ability_item_soul_ring"));
            //Staff of Wizardry
            list.Add(new Item("Staff of Wizardry", "DOTA_Tooltip_ability_item_staff_of_wizardry"));
            //Stout Shield
            list.Add(new Item("Stout Shield", "DOTA_Tooltip_ability_item_stout_shield"));
            //Moon Shard
            list.Add(new Item("Moon Shard", "DOTA_Tooltip_ability_item_moon_shard"));
            //Talisman of Evasion
            list.Add(new Item("Talisman of Evasion", "DOTA_Tooltip_ability_item_talisman_of_evasion"));
            //Tango
            list.Add(new Item("Tango", "DOTA_Tooltip_ability_item_tango"));
            //Tango (Shared)
            list.Add(new Item("Tango (Shared)", "DOTA_Tooltip_ability_item_tango_single"));
            list.Add(new Item("Shared Tango", "DOTA_Tooltip_ability_item_tango_single"));
            //Town Portal Scroll
            list.Add(new Item("Town Portal Scroll", "DOTA_Tooltip_ability_item_tpscroll"));
            //Tranquil Boots
            list.Add(new Item("Tranquil Boots", "DOTA_Tooltip_ability_item_tranquil_boots"));
            //Boots of Travel
            list.Add(new Item("Boots of Travel", "DOTA_Tooltip_ability_item_travel_boots"));
            //Boots of Travel
            list.Add(new Item("Boots of Travel", "DOTA_Tooltip_ability_item_travel_boots_2"));
            //Ultimate Orb
            list.Add(new Item("Ultimate Orb", "DOTA_Tooltip_ability_item_ultimate_orb"));
            //Aghanim's Scepter
            list.Add(new Item("Aghanim's Scepter", "DOTA_Tooltip_ability_item_ultimate_scepter"));
            //Urn of Shadows
            list.Add(new Item("Urn of Shadows", "DOTA_Tooltip_ability_item_urn_of_shadows"));
            //Vanguard
            list.Add(new Item("Vanguard", "DOTA_Tooltip_ability_item_vanguard"));
            //Vitality Booster
            list.Add(new Item("Vitality Booster", "DOTA_Tooltip_ability_item_vitality_booster"));
            //Vladmir's Offering
            list.Add(new Item("Vladmir's Offering", "DOTA_Tooltip_ability_item_vladmir"));
            //Void Stone
            list.Add(new Item("Void Stone", "DOTA_Tooltip_ability_item_void_stone"));
            //Observer Ward
            list.Add(new Item("Observer Ward", "DOTA_Tooltip_ability_item_ward_observer"));
            //Sentry Ward
            list.Add(new Item("Sentry Ward", "DOTA_Tooltip_ability_item_ward_sentry"));
            //Wraith Band
            list.Add(new Item("Wraith Band", "DOTA_Tooltip_ability_item_wraith_band"));
            //Yasha
            list.Add(new Item("Yasha", "DOTA_Tooltip_ability_item_yasha"));
            //Arcane Boots
            list.Add(new Item("Arcane Boots", "DOTA_Tooltip_ability_item_arcane_boots"));
            //Orb of Venom
            list.Add(new Item("Orb of Venom", "DOTA_Tooltip_ability_item_orb_of_venom"));
            //Drum of Endurance
            list.Add(new Item("Drum of Endurance", "DOTA_Tooltip_ability_item_ancient_janggo"));
            //Medallion of Courage
            list.Add(new Item("Medallion of Courage", "DOTA_Tooltip_ability_item_medallion_of_courage"));
            //Smoke of Deceit
            list.Add(new Item("Smoke of Deceit", "DOTA_Tooltip_ability_item_smoke_of_deceit"));
            //Veil of Discord
            list.Add(new Item("Veil of Discord", "DOTA_Tooltip_ability_item_veil_of_discord"));
            //Ring of Aquila
            list.Add(new Item("Ring of Aquila", "DOTA_Tooltip_ability_item_ring_of_aquila"));
            //Shadow Amulet
            list.Add(new Item("Shadow Amulet", "DOTA_Tooltip_ability_item_shadow_amulet"));
            //Faerie Fire 
            list.Add(new Item("Faerie Fire", "DOTA_Tooltip_ability_item_faerie_fire"));
            //Dragon Lance
            list.Add(new Item("Dragon Lance", "DOTA_Tooltip_ability_item_dragon_lance"));
            //Aether Lens
            list.Add(new Item("Aether Lens", "DOTA_Tooltip_ability_item_aether_lens"));
            //Iron Talon
            list.Add(new Item("Iron Talon", "DOTA_Tooltip_ability_item_iron_talon"));
            return list;
        }
    }
}
