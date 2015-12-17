using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NeXt.APT.NameTranslator;
using NeXt.APT.Patchnotes;
using NeXt.APT.VdfIntegration;
using NeXt.Vdf;

namespace NeXt.APT
{
    public partial class MainWindow : Window
    {
        private class HeroTVItem : TreeViewItem
        {
            public HeroTVItem(Hero hero)
                : base()
            {
                Hero = hero;
                Header = hero.DisplayName;
            }

            public Hero Hero { get; private set; }
        }
        private class AbilityTVItem : TreeViewItem
        {
            public AbilityTVItem(Ability ability)
                : base()
            {
                Ability = ability;
                Header = ability.DisplayName;
            }

            public Ability Ability { get; private set; }
        }
        private class ItemTVItem : TreeViewItem
        {
            public ItemTVItem(Item item)
                : base()
            {
                Item = item;
                Header = item.DisplayName;
            }

            public Item Item { get; private set; }
        }

        private class TextTVItem : TreeViewItem
        {
            public TextTVItem(string text)
            {
                tb = new TextBox();
                tb.Text = text;
                Header = text;
                MouseDoubleClick += this_MouseDoubleClick;
                tb.LostFocus += tb_LostFocus;
                tb.LostKeyboardFocus += tb_LostKeyboardFocus;
                tb.KeyDown += tb_KeyDown;
                PreviewMouseLeftButtonDown += TextTVItem_MouseLeftButtonDown;

                this.Unselected += TextTVItem_Unselected;
            }

            void TextTVItem_Unselected(object sender, RoutedEventArgs e)
            {
                IsEditable = false;
            }

            void TextTVItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                if (IsSelected)
                {
                    IsEditable = true;
                }
            }

            void tb_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.Key == Key.Return)
                {
                    IsEditable = false;
                }
            }

            void this_MouseDoubleClick(object sender, MouseButtonEventArgs e)
            {
                this.IsEditable = true;
            }
            void tb_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
            {
                this.IsEditable = false;
            }

            void tb_LostFocus(object sender, RoutedEventArgs e)
            {
                this.IsEditable = false;
            }

            private TextBox tb;

            public bool IsEditable
            {
                get
                {
                    return Header == tb;
                }
                set
                {
                    Header = value ? (object)tb : (object)Text;
                }
            }

            public string Text
            {
                get
                {
                    return tb.Text;
                }

            }
        }

        private string dotaLangfile;
        public MainWindow()
        {
            InitializeComponent();
            //C:\Program Files (x86)\Steam\SteamApps\common\dota 2 beta\game\dota\resource
            dotaLangfile = System.IO.Path.Combine(Steam.Locator.Dota2Folder, "game", "dota", "resource", "dota_english.txt");
            langfiletxt.Text = dotaLangfile;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var heroRaw = heroPatchText.Text;
            var itemRaw = itemPatchText.Text;
            if (string.IsNullOrEmpty(heroRaw))
            {
                return;
            }
            if (string.IsNullOrEmpty(itemRaw))
            {
                return;
            }
            errorText.Clear();

            Translator tl = new Translator();
            tl.HeroChanged += tl_HeroChanged;
            tl.AbilityChangeReady += tl_AbilityChangeReady;
            tl.AbilityNotFound += tl_AbilityNotFound;
            tl.HeroNotFound += tl_HeroNotFound;
            tl.MatchingHeroNotFound += tl_MatchingHeroNotFound;
            tl.ItemChangeReady += tl_ItemChangeReady;
            tl.ItemNotFound += tl_ItemNotFound;
            tl.MatchingItemNotFound += tl_MatchingItemNotFound;

            tl.TranslateRawHeroes(heroRaw);
            tl.TranslateRawItems(itemRaw);

            currentHeroItem.Items.Add(currentAbilityItem);
            heroTV.Items.Add(currentHeroItem);
            itemTV.Items.Add(currentItemElement);

            heroPatchText.Visibility = System.Windows.Visibility.Collapsed;
            itemPatchText.Visibility = System.Windows.Visibility.Collapsed;

            heroTV.Visibility = System.Windows.Visibility.Visible;
            itemTV.Visibility = System.Windows.Visibility.Visible;

            parse.Visibility = System.Windows.Visibility.Collapsed;
            preview.Visibility = System.Windows.Visibility.Visible;
        }

        void tl_MatchingItemNotFound(object sender, NotFoundEventArgs e)
        {
            errorText.AppendText("No Item specified: " + e.RawText + Environment.NewLine);
        }

        void tl_ItemNotFound(object sender, NotFoundEventArgs e)
        {
            errorText.AppendText("Item not found: " + e.RawText + Environment.NewLine);
        }

        private ItemTVItem currentItemElement;
        void tl_ItemChangeReady(object sender, ItemChangeReadyEventArgs e)
        {
            if (currentItemElement == null)
            {
                currentItemElement = new ItemTVItem(e.Item);
            }
            else if (currentItemElement.Item != e.Item)
            {
                itemTV.Items.Add(currentItemElement);
                currentItemElement = new ItemTVItem(e.Item);
            }
            currentItemElement.Items.Add(new TextTVItem(e.Text));
        }

        private HeroTVItem nextHeroItem;
        private HeroTVItem currentHeroItem;
        private AbilityTVItem currentAbilityItem;

        void tl_MatchingHeroNotFound(object sender, NotFoundEventArgs e)
        {
            errorText.AppendText("No Hero specified: " + e.RawText + Environment.NewLine);
        }

        void tl_HeroNotFound(object sender, NotFoundEventArgs e)
        {
            errorText.AppendText("Hero not found: " + e.RawText + Environment.NewLine);
        }

        void tl_AbilityNotFound(object sender, NotFoundEventArgs e)
        {
            errorText.AppendText("No Ability Found: " + e.RawText + Environment.NewLine);
        }

        void tl_AbilityChangeReady(object sender, AbilityChangeReadyEventArgs e)
        {
            if (currentAbilityItem == null)
            {
                currentAbilityItem = new AbilityTVItem(e.Ability);
            }
            else
            {
                if (e.Ability != currentAbilityItem.Ability)
                {
                    currentHeroItem.Items.Add(currentAbilityItem);
                    currentAbilityItem = new AbilityTVItem(e.Ability);
                    if (nextHeroItem != null)
                    {
                        heroTV.Items.Add(currentHeroItem);
                        currentHeroItem = nextHeroItem;
                        nextHeroItem = null;
                    }
                }
            }

            if (currentAbilityItem.Items.Count == 0)
            {
                currentAbilityItem.Items.Add(new TextTVItem("-----------------"));
                currentAbilityItem.Items.Add(new TextTVItem("Changes in 6.86:"));
            }

            currentAbilityItem.Items.Add(new TextTVItem("- " + e.Text));
        }

        void tl_HeroChanged(object sender, HeroChangedEventArgs e)
        {
            if (currentHeroItem == null)
            {
                currentHeroItem = new HeroTVItem(e.Hero);
            }
            else
            {
                nextHeroItem = new HeroTVItem(e.Hero);
            }
        }

        private void preview_Click(object sender, RoutedEventArgs e)
        {
            var builder = new AlterationDataBuilder();

            if (heroTV.Items != null)
                foreach (HeroTVItem hero in heroTV.Items)
                {
                    foreach (AbilityTVItem item in hero.Items)
                    {
                        builder.AddAbility(item.Ability.InternalIdentifier);
                        foreach (TextTVItem txt in item.Items)
                        {
                            builder.Append(txt.Text);
                        }
                    }
                }

            if (itemTV.Items != null && itemTV.Items.Count > 1)
                foreach (ItemTVItem itm in itemTV.Items)
                {
                    builder.AddItem(itm.Item.InternalIdentifier);
                    foreach (TextTVItem txt in itm.Items)
                    {
                        builder.Append(txt.Text);
                    }
                }

            var data = builder.Build();

            var deserializer = VdfDeserializer.FromFile(dotaLangfile);

            fullfile = (VdfTable)deserializer.Deserialize();

            var alterTable = fullfile["Tokens"] as VdfTable;

            VdfAlterer alterer = new VdfAlterer(alterTable, data);
            alterer.AlterationMade += alterer_AlterationMade;
            changelist = new List<VdfValue>();
            alterer.Apply();

            bool header = true;
            changesPreview.Items.Clear();
            foreach (var val in changelist)
            {
                if (val == null)
                {
                    header = true;
                    changesPreview.Items.Add
                    (
                        new Separator()
                    );
                    continue;
                }

                if (header)
                {
                    changesPreview.Items.Add(
                        new ListBoxItem()
                        {
                            Content = string.Format("\"{0}\"\t\"{1}\"", val.Name, (val as VdfString).Content),
                            Background = new SolidColorBrush(Colors.LightCyan)
                        }
                    );
                    header = false;
                }
                else
                {
                    changesPreview.Items.Add(
                        new ListBoxItem()
                        {
                            Content = string.Format("\"{0}\"\t\"{1}\"", val.Name, (val as VdfString).Content),
                            Background = new SolidColorBrush(Colors.LightGreen)
                        }
                    );
                }
            }

            preview.Visibility = System.Windows.Visibility.Collapsed;
            heroTV.Visibility = System.Windows.Visibility.Collapsed;
            itemTV.Visibility = System.Windows.Visibility.Collapsed;
            changesPreview.Visibility = System.Windows.Visibility.Visible;
            apply.Visibility = System.Windows.Visibility.Visible;
        }
        private VdfTable fullfile;
        private List<VdfValue> changelist;

        void alterer_AlterationMade(object sender, AlterationMadeEventArgs e)
        {
            int idx = changelist.IndexOf(e.Previous);
            if (idx >= 0)
            {
                if (idx < changelist.Count - 1)
                {
                    changelist.Insert(idx + 1, e.NewValue);
                }
                else
                {
                    changelist.Add(e.NewValue);
                }
            }
            else
            {
                if (changelist.Count != 0)
                {
                    changelist.Add(null);
                }
                changelist.Add(e.Previous);
                changelist.Add(e.NewValue);
            }
        }

        private void apply_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.Title = "Save backup file to:";
            dlg.FileName = "dota_english.txt";
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text Files (.txt)|*.txt";

            if (dlg.ShowDialog() == true)
            {
                var doChange = false;
                try
                {
                    System.IO.File.Copy(dotaLangfile, dlg.FileName, true);
                    doChange = true;

                }
                finally { }

                if (doChange)
                {
                    var serial = new VdfSerializer(fullfile);
                    serial.Serialize(dotaLangfile);

                    MessageBox.Show("Successfully added patch notes to your game, hold the Alt key while hovering over an ability or item to show them", "Done", MessageBoxButton.OK, MessageBoxImage.None);
                }
                else
                {
                    MessageBox.Show("Saving the backup file failed, no changes were saved.", "Backup failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
