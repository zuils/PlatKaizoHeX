using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PKHeX.Core;
using PKHeX.WinForms.Controls;

namespace PKHeX.WinForms;

public partial class SAV_Find : Form
{
    private readonly SaveFile SAV;
    private readonly SAVEditor BoxView;
    private readonly PKMEditor PKME_Tabs;
    private List<(string display, int box, int slot, bool isParty)> foundPokemon = [];

    public SAV_Find(PKMEditor f1, SAVEditor saveditor)
    {
        InitializeComponent();
        WinFormsUtil.TranslateInterface(this, Main.CurrentLanguage);
        SAV = saveditor.SAV;
        BoxView = saveditor;
        PKME_Tabs = f1;

        TB_Name.TextChanged += TB_Name_TextChanged;
    }

    private void TB_Name_TextChanged(object sender, EventArgs e)
    {
        string name = TB_Name.Text.Trim().ToLowerInvariant();
        if (string.IsNullOrEmpty(name))
        {
            LB_Results.Items.Clear();
            foundPokemon.Clear();
            return;
        }

        foundPokemon.Clear();
        LB_Results.Items.Clear();

        var species = GameInfo.Strings.Species;

        // Search party
        for (int i = 0; i < SAV.PartyCount; i++)
        {
            var pkmn = SAV.GetPartySlotAtIndex(i);
            if (!pkmn.IsEgg && species[pkmn.Species].ToLowerInvariant().StartsWith(name))
            {
                string display = $"{species[pkmn.Species]} - Party Slot {i + 1}";
                LB_Results.Items.Add(display);
                foundPokemon.Add((display, -1, i, true));
            }
        }

        // Search boxes
        for (int box = 0; box < SAV.BoxCount; box++)
        {
            for (int slot = 0; slot < SAV.BoxSlotCount; slot++)
            {
                var pkmn = SAV.GetBoxSlotAtIndex(box, slot);
                if (!pkmn.IsEgg && species[pkmn.Species].ToLowerInvariant().StartsWith(name))
                {
                    string display = $"{species[pkmn.Species]} - Box {box + 1} Slot {slot + 1}";
                    LB_Results.Items.Add(display);
                    foundPokemon.Add((display, box, slot, false));
                }
            }
        }

        if (LB_Results.Items.Count > 0)
            LB_Results.SelectedIndex = 0;
    }

    private void B_Find_Click(object sender, EventArgs e)
    {
        if (LB_Results.SelectedIndex < 0 || LB_Results.SelectedIndex >= foundPokemon.Count)
        {
            WinFormsUtil.Alert("Please select a Pokémon from the list.");
            return;
        }

        var selected = foundPokemon[LB_Results.SelectedIndex];
        PKM pkmn;
        if (selected.isParty)
        {
            pkmn = SAV.GetPartySlotAtIndex(selected.slot);
            BoxView.TabControl.SelectedTab = BoxView.PartyTab;
        }
        else
        {
            pkmn = SAV.GetBoxSlotAtIndex(selected.box, selected.slot);
            BoxView.TabControl.SelectedTab = BoxView.BoxTab;
            BoxView.BoxEditor.CurrentBox = selected.box;
        }

        PKME_Tabs.PopulateFields(pkmn);
        Close();
    }
}