using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeXt.APT.NameTranslator
{
    public class Ability
    {
        public Ability(string displayname, string identifier)
        {
            displayName = displayname;
            internalName = identifier;
            IsMinor = false;
        }

        public Ability(string displayname, string identifier, bool isMinor) : this(displayname, identifier)
        {
            IsMinor = isMinor;
        }

        public bool IsMinor { get; private set; }

        private string displayName;

        public bool MatchesName(string text)
        {
            if (displayName.Contains('('))
                displayName = displayName.Substring(0, displayName.IndexOf('(') - 1);
            if (displayName.Contains(':'))
                displayName = displayName.Substring(0, displayName.IndexOf(':'));

            return text.IndexOf(displayName, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private string internalName;
        public string InternalIdentifier
        {
            get
            {
                return string.Format("DOTA_Tooltip_ability_{0}", internalName);
            }
        }
        public string DisplayName
        {
            get
            {
                return displayName;
            }
        }
    }

    public class Hero
    {
        private Hero(string displayName, string internalName)
        {
            this.displayName = displayName;
            this.InternalName = internalName;
            abilities = new List<Ability>();
        }

        private string displayName;
        private string InternalName;

        private List<Ability> abilities;

        public bool MatchesName(string text)
        {

            return displayName.EditDistance(text) < 0.15;
            //return text.IndexOf(displayName, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        public string DisplayName
        {
            get
            {
                return displayName;
            }
        }

        public Ability[] MatchingAbilities(string text)
        {
            var l = new List<Ability>();
            foreach(var ability in abilities)
            {
                if (ability.MatchesName(text))
                {
                    l.Add(ability);
                }
            }

            return l.ToArray();
        }

        public static List<Hero> Build()
        {
            var list = new List<Hero>();
            Hero hero;
            //Queen of Pain
            hero = new Hero("Queen of Pain", "queenofpain");
            hero.abilities.Add(new Ability("Shadow Strike", "queenofpain_shadow_strike"));
            hero.abilities.Add(new Ability("Blink", "queenofpain_blink"));
            hero.abilities.Add(new Ability("Scream Of Pain", "queenofpain_scream_of_pain"));
            hero.abilities.Add(new Ability("Sonic Wave", "queenofpain_sonic_wave"));
            list.Add(hero);
            //Anti-Mage
            hero = new Hero("Anti-Mage", "antimage");
            hero.abilities.Add(new Ability("Mana Break", "antimage_mana_break"));
            hero.abilities.Add(new Ability("Blink", "antimage_blink"));
            hero.abilities.Add(new Ability("Spell Shield", "antimage_spell_shield"));
            hero.abilities.Add(new Ability("Mana Void", "antimage_mana_void"));
            list.Add(hero);
            //Kunkka
            hero = new Hero("Kunkka", "kunkka");
            hero.abilities.Add(new Ability("Torrent", "kunkka_torrent"));
            hero.abilities.Add(new Ability("Tidebringer", "kunkka_tidebringer"));
            hero.abilities.Add(new Ability("X Marks the Spot", "kunkka_x_marks_the_spot"));
            hero.abilities.Add(new Ability("Return", "kunkka_return"));
            hero.abilities.Add(new Ability("Ghostship", "kunkka_ghostship"));
            list.Add(hero);
            //Lina
            hero = new Hero("Lina", "lina");
            hero.abilities.Add(new Ability("Dragon Slave", "lina_dragon_slave"));
            hero.abilities.Add(new Ability("Light Strike Array", "lina_light_strike_array"));
            hero.abilities.Add(new Ability("Fiery Soul", "lina_fiery_soul"));
            hero.abilities.Add(new Ability("Laguna Blade", "lina_laguna_blade"));
            list.Add(hero);
            //Mirana
            hero = new Hero("Mirana", "mirana");
            hero.abilities.Add(new Ability("Sacred Arrow", "mirana_arrow"));
            hero.abilities.Add(new Ability("Moonlight Shadow", "mirana_invis"));
            hero.abilities.Add(new Ability("Leap", "mirana_leap"));
            hero.abilities.Add(new Ability("Starstorm", "mirana_starfall"));
            list.Add(hero);
            //Slardar
            hero = new Hero("Slardar", "slardar");
            hero.abilities.Add(new Ability("Sprint", "slardar_sprint"));
            hero.abilities.Add(new Ability("Slithereen Crush", "slardar_slithereen_crush"));
            hero.abilities.Add(new Ability("Bash", "slardar_bash"));
            hero.abilities.Add(new Ability("Amplify Damage", "slardar_amplify_damage"));
            list.Add(hero);
            //Lion
            hero = new Hero("Lion", "lion");
            hero.abilities.Add(new Ability("Earth Spike", "lion_impale"));
            hero.abilities.Add(new Ability("Hex", "lion_voodoo"));
            hero.abilities.Add(new Ability("Mana Drain", "lion_mana_drain"));
            hero.abilities.Add(new Ability("Finger of Death", "lion_finger_of_death"));
            list.Add(hero);
            //Phantom Assassin
            hero = new Hero("Phantom Assassin", "phantom_assassin");
            hero.abilities.Add(new Ability("Stifling Dagger", "phantom_assassin_stifling_dagger"));
            hero.abilities.Add(new Ability("Phantom Strike", "phantom_assassin_phantom_strike"));
            hero.abilities.Add(new Ability("Blur", "phantom_assassin_blur"));
            hero.abilities.Add(new Ability("Coup de Grace", "phantom_assassin_coup_de_grace"));
            list.Add(hero);
            //Tidehunter
            hero = new Hero("Tidehunter", "tidehunter");
            hero.abilities.Add(new Ability("Gush", "tidehunter_gush"));
            hero.abilities.Add(new Ability("Kraken Shell", "tidehunter_kraken_shell"));
            hero.abilities.Add(new Ability("Anchor Smash", "tidehunter_anchor_smash"));
            hero.abilities.Add(new Ability("Ravage", "tidehunter_ravage"));
            list.Add(hero);
            //Witch Doctor
            hero = new Hero("Witch Doctor", "witch_doctor");
            hero.abilities.Add(new Ability("Paralyzing Cask", "witch_doctor_paralyzing_cask"));
            hero.abilities.Add(new Ability("Voodoo Restoration", "witch_doctor_voodoo_restoration"));
            hero.abilities.Add(new Ability("Maledict", "witch_doctor_maledict"));
            hero.abilities.Add(new Ability("Death Ward", "witch_doctor_death_ward"));
            list.Add(hero);
            //Vengeful Spirit
            hero = new Hero("Vengeful Spirit", "vengefulspirit");
            hero.abilities.Add(new Ability("Magic Missile", "vengefulspirit_magic_missile"));
            hero.abilities.Add(new Ability("Wave of Terror", "vengefulspirit_wave_of_terror"));
            hero.abilities.Add(new Ability("Vengeance Aura", "vengefulspirit_command_aura"));
            hero.abilities.Add(new Ability("Nether Swap", "vengefulspirit_nether_swap"));
            list.Add(hero);
            //Juggernaut
            hero = new Hero("Juggernaut", "juggernaut");
            hero.abilities.Add(new Ability("Blade Fury", "juggernaut_blade_fury"));
            hero.abilities.Add(new Ability("Healing Ward", "juggernaut_healing_ward"));
            hero.abilities.Add(new Ability("Blade Dance", "juggernaut_blade_dance"));
            hero.abilities.Add(new Ability("Omnislash", "juggernaut_omni_slash"));
            list.Add(hero);
            //Earthshaker
            hero = new Hero("Earthshaker", "earthshaker");
            hero.abilities.Add(new Ability("Fissure", "earthshaker_fissure"));
            hero.abilities.Add(new Ability("Enchant Totem", "earthshaker_enchant_totem"));
            hero.abilities.Add(new Ability("Aftershock", "earthshaker_aftershock"));
            hero.abilities.Add(new Ability("Echo Slam", "earthshaker_echo_slam"));
            list.Add(hero);
            //Pudge
            hero = new Hero("Pudge", "pudge");
            hero.abilities.Add(new Ability("Meat Hook", "pudge_meat_hook"));
            hero.abilities.Add(new Ability("Rot", "pudge_rot"));
            hero.abilities.Add(new Ability("Flesh Heap", "pudge_flesh_heap"));
            hero.abilities.Add(new Ability("Dismember", "pudge_dismember"));
            list.Add(hero);
            //Bane
            hero = new Hero("Bane", "bane");
            hero.abilities.Add(new Ability("Enfeeble", "bane_enfeeble"));
            hero.abilities.Add(new Ability("Brain Sap", "bane_brain_sap"));
            hero.abilities.Add(new Ability("Nightmare", "bane_nightmare"));
            hero.abilities.Add(new Ability("Nightmare End", "bane_nightmare_end"));
            hero.abilities.Add(new Ability("Fiend's Grip", "bane_fiends_grip"));
            list.Add(hero);
            //Crystal Maiden
            hero = new Hero("Crystal Maiden", "crystal_maiden");
            hero.abilities.Add(new Ability("Crystal Nova", "crystal_maiden_crystal_nova"));
            hero.abilities.Add(new Ability("Frostbite", "crystal_maiden_frostbite"));
            hero.abilities.Add(new Ability("Arcane Aura", "crystal_maiden_brilliance_aura"));
            hero.abilities.Add(new Ability("Freezing Field", "crystal_maiden_freezing_field"));
            list.Add(hero);
            //Sven
            hero = new Hero("Sven", "sven");
            hero.abilities.Add(new Ability("Storm Hammer", "sven_storm_bolt"));
            hero.abilities.Add(new Ability("Great Cleave", "sven_great_cleave"));
            hero.abilities.Add(new Ability("Warcry", "sven_warcry"));
            hero.abilities.Add(new Ability("God's Strength", "sven_gods_strength"));
            list.Add(hero);
            //Wraith King
            hero = new Hero("Wraith King", "skeleton_king");
            hero.abilities.Add(new Ability("Wraithfire Blast", "skeleton_king_hellfire_blast"));
            hero.abilities.Add(new Ability("Vampiric Aura", "skeleton_king_vampiric_aura"));
            hero.abilities.Add(new Ability("Mortal Strike", "skeleton_king_mortal_strike"));
            hero.abilities.Add(new Ability("Reincarnation", "skeleton_king_reincarnation"));
            list.Add(hero);
            //Storm Spirit
            hero = new Hero("Storm Spirit", "storm_spirit");
            hero.abilities.Add(new Ability("Static Remnant", "storm_spirit_static_remnant"));
            hero.abilities.Add(new Ability("Electric Vortex", "storm_spirit_electric_vortex"));
            hero.abilities.Add(new Ability("Overload", "storm_spirit_overload"));
            hero.abilities.Add(new Ability("Ball Lightning", "storm_spirit_ball_lightning"));
            list.Add(hero);
            //Sand King
            hero = new Hero("Sand King", "sand_king");
            hero.abilities.Add(new Ability("Burrowstrike", "sandking_burrowstrike"));
            hero.abilities.Add(new Ability("Sand Storm", "sandking_sand_storm"));
            hero.abilities.Add(new Ability("Caustic Finale", "sandking_caustic_finale"));
            hero.abilities.Add(new Ability("Epicenter", "sandking_epicenter"));
            list.Add(hero);
            //Shadow Fiend
            hero = new Hero("Shadow Fiend", "nevermore");
            hero.abilities.Add(new Ability("Shadowraze", "nevermore_shadowraze1"));
            hero.abilities.Add(new Ability("Shadowraze", "nevermore_shadowraze2"));
            hero.abilities.Add(new Ability("Shadowraze", "nevermore_shadowraze3"));
            hero.abilities.Add(new Ability("Necromastery", "nevermore_necromastery"));
            hero.abilities.Add(new Ability("Presence of the Dark Lord", "nevermore_dark_lord"));
            hero.abilities.Add(new Ability("Requiem of Souls", "nevermore_requiem"));
            list.Add(hero);
            //Drow Ranger
            hero = new Hero("Drow Ranger", "drow_ranger");
            hero.abilities.Add(new Ability("Frost Arrows", "drow_ranger_frost_arrows"));
            hero.abilities.Add(new Ability("Gust", "drow_ranger_wave_of_silence"));
            hero.abilities.Add(new Ability("Precision Aura", "drow_ranger_trueshot"));
            hero.abilities.Add(new Ability("Marksmanship", "drow_ranger_marksmanship"));
            list.Add(hero);
            //Axe
            hero = new Hero("Axe", "axe");
            hero.abilities.Add(new Ability("Berserker's Call", "axe_berserkers_call"));
            hero.abilities.Add(new Ability("Battle Hunger", "axe_battle_hunger"));
            hero.abilities.Add(new Ability("Counter Helix", "axe_counter_helix"));
            hero.abilities.Add(new Ability("Culling Blade", "axe_culling_blade"));
            list.Add(hero);
            //Bloodseeker
            hero = new Hero("Bloodseeker", "bloodseeker");
            hero.abilities.Add(new Ability("Bloodrage", "bloodseeker_bloodrage"));
            hero.abilities.Add(new Ability("Blood Rite", "bloodseeker_blood_bath"));
            hero.abilities.Add(new Ability("Thirst", "bloodseeker_thirst"));
            hero.abilities.Add(new Ability("Rupture", "bloodseeker_rupture"));
            list.Add(hero);
            //Phantom Lancer
            hero = new Hero("Phantom Lancer", "phantom_lancer");
            hero.abilities.Add(new Ability("Spirit Lance", "phantom_lancer_spirit_lance"));
            hero.abilities.Add(new Ability("Doppelganger", "phantom_lancer_doppelwalk"));
            hero.abilities.Add(new Ability("Phantom Rush", "phantom_lancer_phantom_edge"));
            hero.abilities.Add(new Ability("Juxtapose", "phantom_lancer_juxtapose"));
            list.Add(hero);
            //Razor
            hero = new Hero("Razor", "razor");
            hero.abilities.Add(new Ability("Plasma Field", "razor_plasma_field"));
            hero.abilities.Add(new Ability("Static Link", "razor_static_link"));
            hero.abilities.Add(new Ability("Unstable Current", "razor_unstable_current"));
            hero.abilities.Add(new Ability("Eye of the Storm", "razor_eye_of_the_storm"));
            list.Add(hero);
            //Morphling
            hero = new Hero("Morphling", "morphling");
            hero.abilities.Add(new Ability("Waveform", "morphling_waveform"));
            hero.abilities.Add(new Ability("Adaptive Strike", "morphling_adaptive_strike"));
            hero.abilities.Add(new Ability("Morph (Agility Gain)", "morphling_morph_agi"));
            hero.abilities.Add(new Ability("Morph (Strength Gain)", "morphling_morph_str"));
            hero.abilities.Add(new Ability("Morph Strength", "morphling_morph_agi"));
            hero.abilities.Add(new Ability("Morph Agility", "morphling_morph_str"));
            hero.abilities.Add(new Ability("Morph", "morphling_morph_agi"));
            hero.abilities.Add(new Ability("Morph", "morphling_morph_str"));
            hero.abilities.Add(new Ability("Replicate", "morphling_replicate"));
            hero.abilities.Add(new Ability("Hybrid", "morphling_hybrid"));
            list.Add(hero);
            //Zeus
            hero = new Hero("Zeus", "zuus");
            hero.abilities.Add(new Ability("Arc Lightning", "zuus_arc_lightning"));
            hero.abilities.Add(new Ability("Lightning Bolt", "zuus_lightning_bolt"));
            hero.abilities.Add(new Ability("Static Field", "zuus_static_field"));
            hero.abilities.Add(new Ability("Thundergod's Wrath", "zuus_thundergods_wrath"));
            list.Add(hero);
            //Tiny
            hero = new Hero("Tiny", "tiny");
            hero.abilities.Add(new Ability("Avalanche", "tiny_avalanche"));
            hero.abilities.Add(new Ability("Toss", "tiny_toss"));
            hero.abilities.Add(new Ability("Craggy Exterior", "tiny_craggy_exterior"));
            hero.abilities.Add(new Ability("Grow", "tiny_grow"));
            list.Add(hero);
            //Puck
            hero = new Hero("Puck", "puck");
            hero.abilities.Add(new Ability("Illusory Orb", "puck_illusory_orb"));
            hero.abilities.Add(new Ability("Ethereal Jaunt", "puck_ethereal_jaunt"));
            hero.abilities.Add(new Ability("Waning Rift", "puck_waning_rift"));
            hero.abilities.Add(new Ability("Phase Shift", "puck_phase_shift"));
            hero.abilities.Add(new Ability("Dream Coil", "puck_dream_coil"));
            list.Add(hero);
            //Windranger
            hero = new Hero("Windranger", "windrunner");
            hero.abilities.Add(new Ability("Focus Fire", "windrunner_focusfire"));
            hero.abilities.Add(new Ability("Powershot", "windrunner_powershot"));
            hero.abilities.Add(new Ability("Shackleshot", "windrunner_shackleshot"));
            hero.abilities.Add(new Ability("Windrun", "windrunner_windrun"));
            list.Add(hero);
            //Lich
            hero = new Hero("Lich", "lich");
            hero.abilities.Add(new Ability("Frost Blast", "lich_frost_nova"));
            hero.abilities.Add(new Ability("Ice Armor", "lich_frost_armor"));
            hero.abilities.Add(new Ability("Sacrifice", "lich_dark_ritual"));
            hero.abilities.Add(new Ability("Chain Frost", "lich_chain_frost"));
            list.Add(hero);
            //Shadow Shaman
            hero = new Hero("Shadow Shaman", "shadow_shaman");
            hero.abilities.Add(new Ability("Ether Shock", "shadow_shaman_ether_shock"));
            hero.abilities.Add(new Ability("Hex", "shadow_shaman_voodoo"));
            hero.abilities.Add(new Ability("Shackles", "shadow_shaman_shackles"));
            hero.abilities.Add(new Ability("Mass Serpent Ward", "shadow_shaman_mass_serpent_ward"));
            list.Add(hero);
            //Riki
            hero = new Hero("Riki", "riki");
            hero.abilities.Add(new Ability("Smoke Screen", "riki_smoke_screen"));
            hero.abilities.Add(new Ability("Smokescreen", "riki_smoke_screen"));
            hero.abilities.Add(new Ability("Backstab", "riki_backstab"));
            hero.abilities.Add(new Ability("Permanent Invisibility", "riki_permanent_invisibility"));
            hero.abilities.Add(new Ability("Blink Strike", "riki_blink_strike"));
            list.Add(hero);
            //Enigma
            hero = new Hero("Enigma", "enigma");
            hero.abilities.Add(new Ability("Malefice", "enigma_malefice"));
            hero.abilities.Add(new Ability("Demonic Conversion", "enigma_demonic_conversion"));
            hero.abilities.Add(new Ability("Midnight Pulse", "enigma_midnight_pulse"));
            hero.abilities.Add(new Ability("Black Hole", "enigma_black_hole"));
            list.Add(hero);
            //Tinker
            hero = new Hero("Tinker", "tinker");
            hero.abilities.Add(new Ability("Laser", "tinker_laser"));
            hero.abilities.Add(new Ability("Heat-Seeking Missile", "tinker_heat_seeking_missile"));
            hero.abilities.Add(new Ability("March of the Machines", "tinker_march_of_the_machines"));
            hero.abilities.Add(new Ability("Rearm", "tinker_rearm"));
            list.Add(hero);
            //Sniper
            hero = new Hero("Sniper", "sniper");
            hero.abilities.Add(new Ability("Shrapnel", "sniper_shrapnel"));
            hero.abilities.Add(new Ability("Headshot", "sniper_headshot"));
            hero.abilities.Add(new Ability("Take Aim", "sniper_take_aim"));
            hero.abilities.Add(new Ability("Assassinate", "sniper_assassinate"));
            list.Add(hero);
            //Necrophos
            hero = new Hero("Necrophos", "necrolyte");
            hero.abilities.Add(new Ability("Death Pulse", "necrolyte_death_pulse"));
            hero.abilities.Add(new Ability("Heartstopper Aura", "necrolyte_heartstopper_aura"));
            hero.abilities.Add(new Ability("Sadist", "necrolyte_sadist"));
            hero.abilities.Add(new Ability("Reaper's Scythe", "necrolyte_reapers_scythe"));
            list.Add(hero);
            //Warlock
            hero = new Hero("Warlock", "warlock");
            hero.abilities.Add(new Ability("Fatal Bonds", "warlock_fatal_bonds"));
            hero.abilities.Add(new Ability("Shadow Word", "warlock_shadow_word"));
            hero.abilities.Add(new Ability("Upheaval", "warlock_upheaval"));
            hero.abilities.Add(new Ability("Chaotic Offering", "warlock_rain_of_chaos"));
            list.Add(hero);
            //Beastmaster
            hero = new Hero("Beastmaster", "beastmaster");
            hero.abilities.Add(new Ability("Wild Axes", "beastmaster_wild_axes"));
            hero.abilities.Add(new Ability("Call of the Wild: Hawk", "beastmaster_call_of_the_wild"));
            hero.abilities.Add(new Ability("Call of the Wild (Hawk)", "beastmaster_call_of_the_wild"));
            hero.abilities.Add(new Ability("Call of the Wild Hawk", "beastmaster_call_of_the_wild"));
            hero.abilities.Add(new Ability("Call of the Wild: Boar", "beastmaster_call_of_the_wild_boar"));
            hero.abilities.Add(new Ability("Call of the Wild Boar", "beastmaster_call_of_the_wild_boar"));
            hero.abilities.Add(new Ability("Call of the Wild (Boar)", "beastmaster_call_of_the_wild_boar"));
            hero.abilities.Add(new Ability("Inner Beast", "beastmaster_inner_beast"));
            hero.abilities.Add(new Ability("Primal Roar", "beastmaster_primal_roar"));
            list.Add(hero);
            //Venomancer
            hero = new Hero("Venomancer", "venomancer");
            hero.abilities.Add(new Ability("Venomous Gale", "venomancer_venomous_gale"));
            hero.abilities.Add(new Ability("Poison Sting", "venomancer_poison_sting"));
            hero.abilities.Add(new Ability("Plague Ward", "venomancer_plague_ward"));
            hero.abilities.Add(new Ability("Poison Nova", "venomancer_poison_nova"));
            list.Add(hero);
            //Faceless Void
            hero = new Hero("Faceless Void", "faceless_void");
            hero.abilities.Add(new Ability("Time Walk", "faceless_void_time_walk"));
            hero.abilities.Add(new Ability("Backtrack", "faceless_void_backtrack"));
            hero.abilities.Add(new Ability("Time Lock", "faceless_void_time_lock"));
            hero.abilities.Add(new Ability("Chronosphere", "faceless_void_chronosphere"));
            list.Add(hero);
            //Death Prophet
            hero = new Hero("Death Prophet", "death_prophet");
            hero.abilities.Add(new Ability("Crypt Swarm", "death_prophet_carrion_swarm"));
            hero.abilities.Add(new Ability("Silence", "death_prophet_silence"));
            hero.abilities.Add(new Ability("Witchcraft", "death_prophet_witchcraft"));
            hero.abilities.Add(new Ability("Exorcism", "death_prophet_exorcism"));
            list.Add(hero);
            //Pugna
            hero = new Hero("Pugna", "pugna");
            hero.abilities.Add(new Ability("Nether Blast", "pugna_nether_blast"));
            hero.abilities.Add(new Ability("Decrepify", "pugna_decrepify"));
            hero.abilities.Add(new Ability("Nether Ward", "pugna_nether_ward"));
            hero.abilities.Add(new Ability("Life Drain", "pugna_life_drain"));
            list.Add(hero);
            //Templar Assassin
            hero = new Hero("Templar Assassin", "templar_assassin");
            hero.abilities.Add(new Ability("Refraction", "templar_assassin_refraction"));
            hero.abilities.Add(new Ability("Meld", "templar_assassin_meld"));
            hero.abilities.Add(new Ability("Psi Blades", "templar_assassin_psi_blades"));
            hero.abilities.Add(new Ability("Psionic Trap", "templar_assassin_psionic_trap"));
            hero.abilities.Add(new Ability("Trap", "templar_assassin_trap"));
            list.Add(hero);
            //Viper
            hero = new Hero("Viper", "viper");
            hero.abilities.Add(new Ability("Poison Attack", "viper_poison_attack"));
            hero.abilities.Add(new Ability("Nethertoxin", "viper_nethertoxin"));
            hero.abilities.Add(new Ability("Corrosive Skin", "viper_corrosive_skin"));
            hero.abilities.Add(new Ability("Viper Strike", "viper_viper_strike"));
            list.Add(hero);
            //Luna
            hero = new Hero("Luna", "luna");
            hero.abilities.Add(new Ability("Lucent Beam", "luna_lucent_beam"));
            hero.abilities.Add(new Ability("Moon Glaive", "luna_moon_glaive"));
            hero.abilities.Add(new Ability("Lunar Blessing", "luna_lunar_blessing"));
            hero.abilities.Add(new Ability("Eclipse", "luna_eclipse"));
            list.Add(hero);
            //Dragon Knight
            hero = new Hero("Dragon Knight", "dragon_knight");
            hero.abilities.Add(new Ability("Breathe Fire", "dragon_knight_breathe_fire"));
            hero.abilities.Add(new Ability("Dragon Tail", "dragon_knight_dragon_tail"));
            hero.abilities.Add(new Ability("Dragon Blood", "dragon_knight_dragon_blood"));
            hero.abilities.Add(new Ability("Elder Dragon Form", "dragon_knight_elder_dragon_form"));
            hero.abilities.Add(new Ability("Corrosive Breath", "dragon_knight_elder_dragon_form", true));
            hero.abilities.Add(new Ability("Splash Attack", "dragon_knight_elder_dragon_form", true));
            hero.abilities.Add(new Ability("Frost Breath", "dragon_knight_elder_dragon_form", true));
            list.Add(hero);
            //Dazzle
            hero = new Hero("Dazzle", "dazzle");
            hero.abilities.Add(new Ability("Poison Touch", "dazzle_poison_touch"));
            hero.abilities.Add(new Ability("Shallow Grave", "dazzle_shallow_grave"));
            hero.abilities.Add(new Ability("Shadow Wave", "dazzle_shadow_wave"));
            hero.abilities.Add(new Ability("Weave", "dazzle_weave"));
            list.Add(hero);
            //Clockwerk
            hero = new Hero("Clockwerk", "rattletrap");
            hero.abilities.Add(new Ability("Battery Assault", "rattletrap_battery_assault"));
            hero.abilities.Add(new Ability("Power Cogs", "rattletrap_power_cogs"));
            hero.abilities.Add(new Ability("Rocket Flare", "rattletrap_rocket_flare"));
            hero.abilities.Add(new Ability("Hookshot", "rattletrap_hookshot"));
            list.Add(hero);
            //Leshrac
            hero = new Hero("Leshrac", "leshrac");
            hero.abilities.Add(new Ability("Split Earth", "leshrac_split_earth"));
            hero.abilities.Add(new Ability("Diabolic Edict", "leshrac_diabolic_edict"));
            hero.abilities.Add(new Ability("Lightning Storm", "leshrac_lightning_storm"));
            hero.abilities.Add(new Ability("Pulse Nova", "leshrac_pulse_nova"));
            list.Add(hero);
            //Nature's Prophet
            hero = new Hero("Nature's Prophet", "furion");
            hero.abilities.Add(new Ability("Sprout", "furion_sprout"));
            hero.abilities.Add(new Ability("Teleportation", "furion_teleportation"));
            hero.abilities.Add(new Ability("Nature's Call", "furion_force_of_nature"));
            hero.abilities.Add(new Ability("Wrath of Nature", "furion_wrath_of_nature"));
            list.Add(hero);
            //Lifestealer
            hero = new Hero("Lifestealer", "life_stealer");
            hero.abilities.Add(new Ability("Rage", "life_stealer_rage"));
            hero.abilities.Add(new Ability("Feast", "life_stealer_feast"));
            hero.abilities.Add(new Ability("Open Wounds", "life_stealer_open_wounds"));
            hero.abilities.Add(new Ability("Infest", "life_stealer_infest"));
            hero.abilities.Add(new Ability("Control", "life_stealer_control"));
            hero.abilities.Add(new Ability("Consume", "life_stealer_consume"));
            hero.abilities.Add(new Ability("Assimilate", "life_stealer_assimilate"));
            list.Add(hero);
            //Dark Seer
            hero = new Hero("Dark Seer", "dark_seer");
            hero.abilities.Add(new Ability("Vacuum", "dark_seer_vacuum"));
            hero.abilities.Add(new Ability("Ion Shell", "dark_seer_ion_shell"));
            hero.abilities.Add(new Ability("Surge", "dark_seer_surge"));
            hero.abilities.Add(new Ability("Wall of Replica", "dark_seer_wall_of_replica"));
            list.Add(hero);
            //Clinkz
            hero = new Hero("Clinkz", "clinkz");
            hero.abilities.Add(new Ability("Strafe", "clinkz_strafe"));
            hero.abilities.Add(new Ability("Searing Arrows", "clinkz_searing_arrows"));
            hero.abilities.Add(new Ability("Skeleton Walk", "clinkz_wind_walk"));
            hero.abilities.Add(new Ability("Death Pact", "clinkz_death_pact"));
            list.Add(hero);
            //Omniknight
            hero = new Hero("Omniknight", "omniknight");
            hero.abilities.Add(new Ability("Purification", "omniknight_purification"));
            hero.abilities.Add(new Ability("Repel", "omniknight_repel"));
            hero.abilities.Add(new Ability("Degen Aura", "omniknight_degen_aura"));
            hero.abilities.Add(new Ability("Guardian Angel", "omniknight_guardian_angel"));
            list.Add(hero);
            //Enchantress
            hero = new Hero("Enchantress", "enchantress");
            hero.abilities.Add(new Ability("Untouchable", "enchantress_untouchable"));
            hero.abilities.Add(new Ability("Enchant", "enchantress_enchant"));
            hero.abilities.Add(new Ability("Nature's Attendants", "enchantress_natures_attendants"));
            hero.abilities.Add(new Ability("Impetus", "enchantress_impetus"));
            list.Add(hero);
            //Huskar
            hero = new Hero("Huskar", "huskar");
            hero.abilities.Add(new Ability("Inner Vitality", "huskar_inner_vitality"));
            hero.abilities.Add(new Ability("Burning Spear", "huskar_burning_spear"));
            hero.abilities.Add(new Ability("Berserker's Blood", "huskar_berserkers_blood"));
            hero.abilities.Add(new Ability("Life Break", "huskar_life_break"));
            list.Add(hero);
            //Night Stalker
            hero = new Hero("Night Stalker", "night_stalker");
            hero.abilities.Add(new Ability("Void", "night_stalker_void"));
            hero.abilities.Add(new Ability("Crippling Fear", "night_stalker_crippling_fear"));
            hero.abilities.Add(new Ability("Hunter in the Night", "night_stalker_hunter_in_the_night"));
            hero.abilities.Add(new Ability("Darkness", "night_stalker_darkness"));
            list.Add(hero);
            //Broodmother
            hero = new Hero("Broodmother", "broodmother");
            hero.abilities.Add(new Ability("Spawn Spiderlings", "broodmother_spawn_spiderlings"));
            hero.abilities.Add(new Ability("Spin Web", "broodmother_spin_web"));
            hero.abilities.Add(new Ability("Incapacitating Bite", "broodmother_incapacitating_bite"));
            hero.abilities.Add(new Ability("Insatiable Hunger", "broodmother_insatiable_hunger"));
            list.Add(hero);
            //Bounty Hunter
            hero = new Hero("Bounty Hunter", "bounty_hunter");
            hero.abilities.Add(new Ability("Shuriken Toss", "bounty_hunter_shuriken_toss"));
            hero.abilities.Add(new Ability("Jinada", "bounty_hunter_jinada"));
            hero.abilities.Add(new Ability("Shadow Walk", "bounty_hunter_wind_walk"));
            hero.abilities.Add(new Ability("Track", "bounty_hunter_track"));
            list.Add(hero);
            //Weaver
            hero = new Hero("Weaver", "weaver");
            hero.abilities.Add(new Ability("The Swarm", "weaver_the_swarm"));
            hero.abilities.Add(new Ability("Shukuchi", "weaver_shukuchi"));
            hero.abilities.Add(new Ability("Geminate Attack", "weaver_geminate_attack"));
            hero.abilities.Add(new Ability("Time Lapse", "weaver_time_lapse"));
            list.Add(hero);
            //Jakiro
            hero = new Hero("Jakiro", "jakiro");
            hero.abilities.Add(new Ability("Dual Breath", "jakiro_dual_breath"));
            hero.abilities.Add(new Ability("Ice Path", "jakiro_ice_path"));
            hero.abilities.Add(new Ability("Liquid Fire", "jakiro_liquid_fire"));
            hero.abilities.Add(new Ability("Macropyre", "jakiro_macropyre"));
            list.Add(hero);
            //Batrider
            hero = new Hero("Batrider", "batrider");
            hero.abilities.Add(new Ability("Sticky Napalm", "batrider_sticky_napalm"));
            hero.abilities.Add(new Ability("Flamebreak", "batrider_flamebreak"));
            hero.abilities.Add(new Ability("Firefly", "batrider_firefly"));
            hero.abilities.Add(new Ability("Flaming Lasso", "batrider_flaming_lasso"));
            list.Add(hero);
            //Chen
            hero = new Hero("Chen", "chen");
            hero.abilities.Add(new Ability("Penitence", "chen_penitence"));
            hero.abilities.Add(new Ability("Test of Faith", "chen_test_of_faith_teleport"));
            hero.abilities.Add(new Ability("Holy Persuasion", "chen_holy_persuasion"));
            hero.abilities.Add(new Ability("Hand of God", "chen_hand_of_god"));
            list.Add(hero);
            //Spectre
            hero = new Hero("Spectre", "spectre");
            hero.abilities.Add(new Ability("Spectral Dagger", "spectre_spectral_dagger"));
            hero.abilities.Add(new Ability("Desolate", "spectre_desolate"));
            hero.abilities.Add(new Ability("Dispersion", "spectre_dispersion"));
            hero.abilities.Add(new Ability("Haunt", "spectre_haunt"));
            hero.abilities.Add(new Ability("Reality", "spectre_reality"));
            list.Add(hero);
            //Doom
            hero = new Hero("Doom", "doom_bringer");
            hero.abilities.Add(new Ability("Devour", "doom_bringer_devour"));
            hero.abilities.Add(new Ability("Scorched Earth", "doom_bringer_scorched_earth"));
            hero.abilities.Add(new Ability("LVL? Death", "doom_bringer_lvl_death"));
            hero.abilities.Add(new Ability("Doom", "doom_bringer_doom"));
            list.Add(hero);
            //Ancient Apparition
            hero = new Hero("Ancient Apparition", "ancient_apparition");
            hero.abilities.Add(new Ability("Cold Feet", "ancient_apparition_cold_feet"));
            hero.abilities.Add(new Ability("Ice Vortex", "ancient_apparition_ice_vortex"));
            hero.abilities.Add(new Ability("Chilling Touch", "ancient_apparition_chilling_touch"));
            hero.abilities.Add(new Ability("Ice Blast", "ancient_apparition_ice_blast"));
            list.Add(hero);
            //Ursa
            hero = new Hero("Ursa", "ursa");
            hero.abilities.Add(new Ability("Earthshock", "ursa_earthshock"));
            hero.abilities.Add(new Ability("Overpower", "ursa_overpower"));
            hero.abilities.Add(new Ability("Fury Swipes", "ursa_fury_swipes"));
            hero.abilities.Add(new Ability("Enrage", "ursa_enrage"));
            list.Add(hero);
            //Spirit Breaker
            hero = new Hero("Spirit Breaker", "spirit_breaker");
            hero.abilities.Add(new Ability("Charge of Darkness", "spirit_breaker_charge_of_darkness"));
            hero.abilities.Add(new Ability("Empowering Haste", "spirit_breaker_empowering_haste"));
            hero.abilities.Add(new Ability("Greater Bash", "spirit_breaker_greater_bash"));
            hero.abilities.Add(new Ability("Nether Strike", "spirit_breaker_nether_strike"));
            list.Add(hero);
            //Gyrocopter
            hero = new Hero("Gyrocopter", "gyrocopter");
            hero.abilities.Add(new Ability("Rocket Barrage", "gyrocopter_rocket_barrage"));
            hero.abilities.Add(new Ability("Homing Missile", "gyrocopter_homing_missile"));
            hero.abilities.Add(new Ability("Flak Cannon", "gyrocopter_flak_cannon"));
            hero.abilities.Add(new Ability("Call Down", "gyrocopter_call_down"));
            list.Add(hero);
            //Alchemist
            hero = new Hero("Alchemist", "alchemist");
            hero.abilities.Add(new Ability("Acid Spray", "alchemist_acid_spray"));
            hero.abilities.Add(new Ability("Unstable Concoction", "alchemist_unstable_concoction"));
            hero.abilities.Add(new Ability("Unstable Concoction Throw", "alchemist_unstable_concoction_throw"));
            hero.abilities.Add(new Ability("Greevil's Greed", "alchemist_goblins_greed"));
            hero.abilities.Add(new Ability("Chemical Rage", "alchemist_chemical_rage"));
            list.Add(hero);
            //Invoker
            hero = new Hero("Invoker", "invoker");
            hero.abilities.Add(new Ability("Quas", "invoker_quas"));
            hero.abilities.Add(new Ability("Wex", "invoker_wex"));
            hero.abilities.Add(new Ability("Exort", "invoker_exort"));
            hero.abilities.Add(new Ability("Invoke", "invoker_invoke"));
            hero.abilities.Add(new Ability("Deafening Blast", "invoker_deafening_blast"));
            hero.abilities.Add(new Ability("Ice Wall", "invoker_ice_wall"));
            hero.abilities.Add(new Ability("Forge Spirit", "invoker_forge_spirit"));
            hero.abilities.Add(new Ability("Sun Strike", "invoker_sun_strike"));
            hero.abilities.Add(new Ability("Chaos Meteor", "invoker_chaos_meteor"));
            hero.abilities.Add(new Ability("Alacrity", "invoker_alacrity"));
            hero.abilities.Add(new Ability("EMP", "invoker_emp"));
            hero.abilities.Add(new Ability("Tornado", "invoker_tornado"));
            hero.abilities.Add(new Ability("Ghost Walk", "invoker_ghost_walk"));
            hero.abilities.Add(new Ability("Cold Snap", "invoker_cold_snap"));
            list.Add(hero);
            //Silencer
            hero = new Hero("Silencer", "silencer");
            hero.abilities.Add(new Ability("Curse of the Silent", "silencer_curse_of_the_silent"));
            hero.abilities.Add(new Ability("Glaives of Wisdom", "silencer_glaives_of_wisdom"));
            hero.abilities.Add(new Ability("Last Word", "silencer_last_word"));
            hero.abilities.Add(new Ability("Global Silence", "silencer_global_silence"));
            list.Add(hero);
            //Outworld Devourer
            hero = new Hero("Outworld Devourer", "obsidian_destroyer");
            hero.abilities.Add(new Ability("Arcane Orb", "obsidian_destroyer_arcane_orb"));
            hero.abilities.Add(new Ability("Astral Imprisonment", "obsidian_destroyer_astral_imprisonment"));
            hero.abilities.Add(new Ability("Essence Aura", "obsidian_destroyer_essence_aura"));
            hero.abilities.Add(new Ability("Sanity's Eclipse", "obsidian_destroyer_sanity_eclipse"));
            list.Add(hero);
            //Lycan
            hero = new Hero("Lycan", "lycan");
            hero.abilities.Add(new Ability("Summon Wolves", "lycan_summon_wolves"));
            hero.abilities.Add(new Ability("Howl", "lycan_howl"));
            hero.abilities.Add(new Ability("Feral Impulse", "lycan_feral_impulse"));
            hero.abilities.Add(new Ability("Shapeshift", "lycan_shapeshift"));
            list.Add(hero);
            //Brewmaster
            hero = new Hero("Brewmaster", "brewmaster");
            hero.abilities.Add(new Ability("Thunder Clap", "brewmaster_thunder_clap"));
            hero.abilities.Add(new Ability("Drunken Haze", "brewmaster_drunken_haze"));
            hero.abilities.Add(new Ability("Drunken Brawler", "brewmaster_drunken_brawler"));
            hero.abilities.Add(new Ability("Primal Split", "brewmaster_primal_split"));
            list.Add(hero);
            //Shadow Demon
            hero = new Hero("Shadow Demon", "shadow_demon");
            hero.abilities.Add(new Ability("Disruption", "shadow_demon_disruption"));
            hero.abilities.Add(new Ability("Soul Catcher", "shadow_demon_soul_catcher"));
            hero.abilities.Add(new Ability("Shadow Poison", "shadow_demon_shadow_poison"));
            hero.abilities.Add(new Ability("Shadow Poison Release", "shadow_demon_shadow_poison_release"));
            hero.abilities.Add(new Ability("Demonic Purge", "shadow_demon_demonic_purge"));
            list.Add(hero);
            //Lone Druid
            hero = new Hero("Lone Druid", "lone_druid");
            hero.abilities.Add(new Ability("Summon Spirit Bear", "lone_druid_spirit_bear"));
            hero.abilities.Add(new Ability("Rabid", "lone_druid_rabid"));
            hero.abilities.Add(new Ability("Synergy", "lone_druid_synergy"));
            hero.abilities.Add(new Ability("True Form", "lone_druid_true_form"));
            hero.abilities.Add(new Ability("Druid Form", "lone_druid_true_form_druid"));
            hero.abilities.Add(new Ability("Battle Cry", "lone_druid_true_form_battle_cry"));
            list.Add(hero);
            //Chaos Knight
            hero = new Hero("Chaos Knight", "chaos_knight");
            hero.abilities.Add(new Ability("Chaos Bolt", "chaos_knight_chaos_bolt"));
            hero.abilities.Add(new Ability("Reality Rift", "chaos_knight_reality_rift"));
            hero.abilities.Add(new Ability("Chaos Strike", "chaos_knight_chaos_strike"));
            hero.abilities.Add(new Ability("Phantasm", "chaos_knight_phantasm"));
            list.Add(hero);
            //Treant Protector
            hero = new Hero("Treant Protector", "treant");
            hero.abilities.Add(new Ability("Nature's Guise", "treant_natures_guise"));
            hero.abilities.Add(new Ability("Leech Seed", "treant_leech_seed"));
            hero.abilities.Add(new Ability("Living Armor", "treant_living_armor"));
            hero.abilities.Add(new Ability("Overgrowth", "treant_overgrowth"));
            hero.abilities.Add(new Ability("Eyes In The Forest", "treant_eyes_in_the_forest"));
            list.Add(hero);
            //Meepo
            hero = new Hero("Meepo", "meepo");
            hero.abilities.Add(new Ability("Earthbind", "meepo_earthbind"));
            hero.abilities.Add(new Ability("Poof", "meepo_poof"));
            hero.abilities.Add(new Ability("Geostrike", "meepo_geostrike"));
            hero.abilities.Add(new Ability("Divided We Stand", "meepo_divided_we_stand"));
            list.Add(hero);
            //Ogre Magi
            hero = new Hero("Ogre Magi", "ogre_magi");
            hero.abilities.Add(new Ability("Fireblast", "ogre_magi_fireblast"));
            hero.abilities.Add(new Ability("Unrefined Fireblast", "ogre_magi_unrefined_fireblast"));
            hero.abilities.Add(new Ability("Ignite", "ogre_magi_ignite"));
            hero.abilities.Add(new Ability("Bloodlust", "ogre_magi_bloodlust"));
            hero.abilities.Add(new Ability("Multicast", "ogre_magi_multicast"));
            list.Add(hero);
            //Undying
            hero = new Hero("Undying", "undying");
            hero.abilities.Add(new Ability("Decay", "undying_decay"));
            hero.abilities.Add(new Ability("Soul Rip", "undying_soul_rip"));
            hero.abilities.Add(new Ability("Tombstone", "undying_tombstone"));
            hero.abilities.Add(new Ability("Flesh Golem", "undying_flesh_golem"));
            list.Add(hero);
            //Rubick
            hero = new Hero("Rubick", "rubick");
            hero.abilities.Add(new Ability("Telekinesis", "rubick_telekinesis"));
            hero.abilities.Add(new Ability("Telekinesis Land", "rubick_telekinesis_land"));
            hero.abilities.Add(new Ability("Fade Bolt", "rubick_fade_bolt"));
            hero.abilities.Add(new Ability("Null Field", "rubick_null_field"));
            hero.abilities.Add(new Ability("Spell Steal", "rubick_spell_steal"));
            list.Add(hero);
            //Disruptor
            hero = new Hero("Disruptor", "disruptor");
            hero.abilities.Add(new Ability("Thunder Strike", "disruptor_thunder_strike"));
            hero.abilities.Add(new Ability("Glimpse", "disruptor_glimpse"));
            hero.abilities.Add(new Ability("Kinetic Field", "disruptor_kinetic_field"));
            hero.abilities.Add(new Ability("Static Storm", "disruptor_static_storm"));
            list.Add(hero);
            //Nyx Assassin
            hero = new Hero("Nyx Assassin", "nyx_assassin");
            hero.abilities.Add(new Ability("Impale", "nyx_assassin_impale"));
            hero.abilities.Add(new Ability("Mana Burn", "nyx_assassin_mana_burn"));
            hero.abilities.Add(new Ability("Spiked Carapace", "nyx_assassin_spiked_carapace"));
            hero.abilities.Add(new Ability("Vendetta", "nyx_assassin_vendetta"));
            hero.abilities.Add(new Ability("Burrow", "nyx_assassin_burrow"));
            list.Add(hero);
            //Naga Siren
            hero = new Hero("Naga Siren", "naga_siren");
            hero.abilities.Add(new Ability("Mirror Image", "naga_siren_mirror_image"));
            hero.abilities.Add(new Ability("Ensnare", "naga_siren_ensnare"));
            hero.abilities.Add(new Ability("Rip Tide", "naga_siren_rip_tide"));
            hero.abilities.Add(new Ability("Song of the Siren", "naga_siren_song_of_the_siren"));
            list.Add(hero);
            //Keeper of the Light
            hero = new Hero("Keeper of the Light", "keeper_of_the_light");
            hero.abilities.Add(new Ability("Illuminate", "keeper_of_the_light_illuminate"));
            hero.abilities.Add(new Ability("Release Illuminate", "keeper_of_the_light_illuminate_end"));
            hero.abilities.Add(new Ability("Mana Leak", "keeper_of_the_light_mana_leak"));
            hero.abilities.Add(new Ability("Chakra Magic", "keeper_of_the_light_chakra_magic"));
            hero.abilities.Add(new Ability("Spirit Form", "keeper_of_the_light_spirit_form"));
            hero.abilities.Add(new Ability("Recall", "keeper_of_the_light_recall"));
            hero.abilities.Add(new Ability("Blinding Light", "keeper_of_the_light_blinding_light"));
            hero.abilities.Add(new Ability("Illuminate", "keeper_of_the_light_spirit_form_illuminate"));
            list.Add(hero);
            //Visage
            hero = new Hero("Visage", "visage");
            hero.abilities.Add(new Ability("Grave Chill", "visage_grave_chill"));
            hero.abilities.Add(new Ability("Soul Assumption", "visage_soul_assumption"));
            hero.abilities.Add(new Ability("Gravekeeper's Cloak", "visage_gravekeepers_cloak"));
            hero.abilities.Add(new Ability("Summon Familiars", "visage_summon_familiars"));
            hero.abilities.Add(new Ability("Familiars", "visage_summon_familiars", true));
            list.Add(hero);
            //Io
            hero = new Hero("Io", "wisp");
            hero.abilities.Add(new Ability("Tether", "wisp_tether"));
            hero.abilities.Add(new Ability("Break Tether", "wisp_tether_break"));
            hero.abilities.Add(new Ability("Spirits", "wisp_spirits"));
            hero.abilities.Add(new Ability("Spirits In", "wisp_spirits_in"));
            hero.abilities.Add(new Ability("Spirits Out", "wisp_spirits_out"));
            hero.abilities.Add(new Ability("Overcharge", "wisp_overcharge"));
            hero.abilities.Add(new Ability("Relocate", "wisp_relocate"));
            list.Add(hero);
            //Slark
            hero = new Hero("Slark", "slark");
            hero.abilities.Add(new Ability("Dark Pact", "slark_dark_pact"));
            hero.abilities.Add(new Ability("Pounce", "slark_pounce"));
            hero.abilities.Add(new Ability("Essence Shift", "slark_essence_shift"));
            hero.abilities.Add(new Ability("Shadow Dance", "slark_shadow_dance"));
            list.Add(hero);
            //Medusa
            hero = new Hero("Medusa", "medusa");
            hero.abilities.Add(new Ability("Split Shot", "medusa_split_shot"));
            hero.abilities.Add(new Ability("Mystic Snake", "medusa_mystic_snake"));
            hero.abilities.Add(new Ability("Mana Shield", "medusa_mana_shield"));
            hero.abilities.Add(new Ability("Stone Gaze", "medusa_stone_gaze"));
            list.Add(hero);
            //Troll Warlord
            hero = new Hero("Troll Warlord", "troll_warlord");
            hero.abilities.Add(new Ability("Berserker's Rage", "troll_warlord_berserkers_rage"));
            hero.abilities.Add(new Ability("Berserker’s Rage", "troll_warlord_berserkers_rage"));
            hero.abilities.Add(new Ability("Whirling Axes (Ranged)", "troll_warlord_whirling_axes_ranged"));
            hero.abilities.Add(new Ability("Whirling Axes (Melee)", "troll_warlord_whirling_axes_melee"));
            hero.abilities.Add(new Ability("Ranged Whirling Axes", "troll_warlord_whirling_axes_ranged"));
            hero.abilities.Add(new Ability("Melee Whirling Axes", "troll_warlord_whirling_axes_melee"));
            hero.abilities.Add(new Ability("Fervor", "troll_warlord_fervor"));
            hero.abilities.Add(new Ability("Battle Trance", "troll_warlord_battle_trance"));
            list.Add(hero);
            //Centaur Warrunner
            hero = new Hero("Centaur Warrunner", "centaur");
            hero.abilities.Add(new Ability("Hoof Stomp", "centaur_hoof_stomp"));
            hero.abilities.Add(new Ability("Double Edge", "centaur_double_edge"));
            hero.abilities.Add(new Ability("Return", "centaur_return"));
            hero.abilities.Add(new Ability("Stampede", "centaur_stampede"));
            list.Add(hero);
            //Magnus
            hero = new Hero("Magnus", "magnataur");
            hero.abilities.Add(new Ability("Shockwave", "magnataur_shockwave"));
            hero.abilities.Add(new Ability("Empower", "magnataur_empower"));
            hero.abilities.Add(new Ability("Skewer", "magnataur_skewer"));
            hero.abilities.Add(new Ability("Reverse Polarity", "magnataur_reverse_polarity"));
            list.Add(hero);
            //Timbersaw
            hero = new Hero("Timbersaw", "shredder");
            hero.abilities.Add(new Ability("Whirling Death", "shredder_whirling_death"));
            hero.abilities.Add(new Ability("Timber Chain", "shredder_timber_chain"));
            hero.abilities.Add(new Ability("Reactive Armor", "shredder_reactive_armor"));
            hero.abilities.Add(new Ability("Chakram", "shredder_chakram"));
            hero.abilities.Add(new Ability("Return Chakram", "shredder_return_chakram"));
            hero.abilities.Add(new Ability("Chakram", "shredder_chakram_2"));
            hero.abilities.Add(new Ability("Return Chakram", "shredder_return_chakram_2"));
            list.Add(hero);
            //Bristleback
            hero = new Hero("Bristleback", "bristleback");
            hero.abilities.Add(new Ability("Viscous Nasal Goo", "bristleback_viscous_nasal_goo"));
            hero.abilities.Add(new Ability("Quill Spray", "bristleback_quill_spray"));
            hero.abilities.Add(new Ability("Bristleback", "bristleback_bristleback"));
            hero.abilities.Add(new Ability("Warpath", "bristleback_warpath"));
            list.Add(hero);
            //Tusk
            hero = new Hero("Tusk", "tusk");
            hero.abilities.Add(new Ability("Ice Shards", "tusk_ice_shards"));
            hero.abilities.Add(new Ability("Snowball", "tusk_snowball"));
            hero.abilities.Add(new Ability("Launch Snowball", "tusk_launch_snowball"));
            hero.abilities.Add(new Ability("Frozen Sigil", "tusk_frozen_sigil"));
            hero.abilities.Add(new Ability("Walrus PUNCH!", "tusk_walrus_punch"));
            hero.abilities.Add(new Ability("Walrus Kick", "tusk_walrus_kick"));
            list.Add(hero);
            //Skywrath Mage
            hero = new Hero("Skywrath Mage", "skywrath_mage");
            hero.abilities.Add(new Ability("Arcane Bolt", "skywrath_mage_arcane_bolt"));
            hero.abilities.Add(new Ability("Concussive Shot", "skywrath_mage_concussive_shot"));
            hero.abilities.Add(new Ability("Ancient Seal", "skywrath_mage_ancient_seal"));
            hero.abilities.Add(new Ability("Mystic Flare", "skywrath_mage_mystic_flare"));
            list.Add(hero);
            //Abaddon
            hero = new Hero("Abaddon", "abaddon");
            hero.abilities.Add(new Ability("Mist Coil", "abaddon_death_coil"));
            hero.abilities.Add(new Ability("Aphotic Shield", "abaddon_aphotic_shield"));
            hero.abilities.Add(new Ability("Curse of Avernus", "abaddon_frostmourne"));
            hero.abilities.Add(new Ability("Borrowed Time", "abaddon_borrowed_time"));
            list.Add(hero);
            //Elder Titan
            hero = new Hero("Elder Titan", "elder_titan");
            hero.abilities.Add(new Ability("Echo Stomp", "elder_titan_echo_stomp"));
            hero.abilities.Add(new Ability("Echo Stomp", "elder_titan_echo_stomp_spirit"));
            hero.abilities.Add(new Ability("Astral Spirit", "elder_titan_ancestral_spirit"));
            hero.abilities.Add(new Ability("Return Astral Spirit", "elder_titan_return_spirit"));
            hero.abilities.Add(new Ability("Natural Order", "elder_titan_natural_order"));
            hero.abilities.Add(new Ability("Earth Splitter", "elder_titan_earth_splitter"));
            list.Add(hero);
            //Legion Commander
            hero = new Hero("Legion Commander", "legion_commander");
            hero.abilities.Add(new Ability("Overwhelming Odds", "legion_commander_overwhelming_odds"));
            hero.abilities.Add(new Ability("Press The Attack", "legion_commander_press_the_attack"));
            hero.abilities.Add(new Ability("Moment of Courage", "legion_commander_moment_of_courage"));
            hero.abilities.Add(new Ability("Duel", "legion_commander_duel"));
            list.Add(hero);
            //Ember Spirit
            hero = new Hero("Ember Spirit", "ember_spirit");
            hero.abilities.Add(new Ability("Searing Chains", "ember_spirit_searing_chains"));
            hero.abilities.Add(new Ability("Sleight of Fist", "ember_spirit_sleight_of_fist"));
            hero.abilities.Add(new Ability("Flame Guard", "ember_spirit_flame_guard"));
            hero.abilities.Add(new Ability("Fire Remnant", "ember_spirit_fire_remnant"));
            hero.abilities.Add(new Ability("Activate Fire Remnant", "ember_spirit_activate_fire_remnant"));
            list.Add(hero);
            //Earth Spirit
            hero = new Hero("Earth Spirit", "earth_spirit");
            hero.abilities.Add(new Ability("Boulder Smash", "earth_spirit_boulder_smash"));
            hero.abilities.Add(new Ability("Rolling Boulder", "earth_spirit_rolling_boulder"));
            hero.abilities.Add(new Ability("Geomagnetic Grip", "earth_spirit_geomagnetic_grip"));
            hero.abilities.Add(new Ability("Stone Remnant", "earth_spirit_stone_caller"));
            hero.abilities.Add(new Ability("Magnetize", "earth_spirit_magnetize"));
            hero.abilities.Add(new Ability("Enchant Remnant", "earth_spirit_petrify"));
            list.Add(hero);
            //Abyssal Underlord
            hero = new Hero("Abyssal Underlord", "abyssal_underlord");
            hero.abilities.Add(new Ability("Firestorm", "abyssal_underlord_firestorm"));
            hero.abilities.Add(new Ability("Pit of Malice", "abyssal_underlord_pit_of_malice"));
            hero.abilities.Add(new Ability("Atrophy Aura", "abyssal_underlord_atrophy_aura"));
            hero.abilities.Add(new Ability("Dark Rift", "abyssal_underlord_dark_rift"));
            list.Add(hero);
            //Phoenix
            hero = new Hero("Phoenix", "phoenix");
            hero.abilities.Add(new Ability("Icarus Dive", "phoenix_icarus_dive"));
            hero.abilities.Add(new Ability("Stop Icarus Dive", "phoenix_icarus_dive_stop"));
            hero.abilities.Add(new Ability("Fire Spirits", "phoenix_fire_spirits"));
            hero.abilities.Add(new Ability("Launch Fire Spirit", "phoenix_launch_fire_spirit"));
            hero.abilities.Add(new Ability("Sun Ray", "phoenix_sun_ray"));
            hero.abilities.Add(new Ability("Stop Sun Ray", "phoenix_sun_ray_stop"));
            hero.abilities.Add(new Ability("Supernova", "phoenix_supernova"));
            list.Add(hero);
            //Terrorblade
            hero = new Hero("Terrorblade", "terrorblade");
            hero.abilities.Add(new Ability("Reflection", "terrorblade_reflection"));
            hero.abilities.Add(new Ability("Conjure Image", "terrorblade_conjure_image"));
            hero.abilities.Add(new Ability("Metamorphosis", "terrorblade_metamorphosis"));
            hero.abilities.Add(new Ability("Sunder", "terrorblade_sunder"));
            list.Add(hero);
            //Oracle
            hero = new Hero("Oracle", "oracle");
            hero.abilities.Add(new Ability("Fortune's End", "oracle_fortunes_end"));
            hero.abilities.Add(new Ability("Fate's Edict", "oracle_fates_edict"));
            hero.abilities.Add(new Ability("Purifying Flames", "oracle_purifying_flames"));
            hero.abilities.Add(new Ability("False Promise", "oracle_false_promise"));
            list.Add(hero);
            //Techies
            hero = new Hero("Techies", "techies");
            hero.abilities.Add(new Ability("Land Mine", "techies_land_mines"));
            hero.abilities.Add(new Ability("Stasis Trap", "techies_stasis_trap"));
            hero.abilities.Add(new Ability("Suicide Squad, Attack!", "techies_suicide"));
            hero.abilities.Add(new Ability("Remote Mine", "techies_remote_mines"));
            hero.abilities.Add(new Ability("Focused Detonate", "techies_focused_detonate"));
            hero.abilities.Add(new Ability("Minefield Sign", "techies_minefield_sign"));
            list.Add(hero);
            //Winter Wyvern
            hero = new Hero("Winter Wyvern", "winter_wyvern");  
            hero.abilities.Add(new Ability("Arctic Burn", "winter_wyvern_arctic_burn"));
            hero.abilities.Add(new Ability("Splinter Blast", "winter_wyvern_splinter_blast"));
            hero.abilities.Add(new Ability("Cold Embrace", "winter_wyvern_cold_embrace"));
            hero.abilities.Add(new Ability("Winter's Curse", "winter_wyvern_winters_curse"));
            list.Add(hero);
            //Arc Warden
            hero = new Hero("Arc Warden", "arc_warden");
            hero.abilities.Add(new Ability("Flux", "arc_warden_flux"));
            hero.abilities.Add(new Ability("Magnetic Field", "arc_warden_magnetic_field"));
            hero.abilities.Add(new Ability("Spark Wraith", "arc_warden_spark_wraith"));
            hero.abilities.Add(new Ability("Tempest Double", "arc_warden_tempest_double"));
            list.Add(hero);

            return list;
        }
    }
}
