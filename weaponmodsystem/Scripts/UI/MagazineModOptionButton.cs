using Godot;
using System;

public partial class MagazineModOptionButton : OptionButton
{
    [Export] public WeaponLoadoutController loadout;
    [Export] public MagazineModResource[] availableMods;

    public override void _Ready()
    {
        ItemSelected += OnItemSelected;
    }

    private void OnItemSelected(long index)
    {
        loadout.SetMagazineMod(availableMods[index]);
    }
}
