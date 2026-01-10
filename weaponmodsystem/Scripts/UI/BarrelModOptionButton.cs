using Godot;
using System;

public partial class BarrelModOptionButton : OptionButton
{
    [Export] public WeaponLoadoutController loadout;
    [Export] public BarrelModResource[] availableMods;

    public override void _Ready()
    {
        ItemSelected += OnItemSelected;
    }

    private void OnItemSelected(long index)
    {
        loadout.SetBarrelMod(availableMods[index]);
    }
}
