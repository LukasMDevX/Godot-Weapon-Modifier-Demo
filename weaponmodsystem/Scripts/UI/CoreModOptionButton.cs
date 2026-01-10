using Godot;
using System;

public partial class CoreModOptionButton : OptionButton
{
    [Export] public WeaponLoadoutController loadout;
    [Export] public CoreModResource[] availableMods;

    public override void _Ready()
    {
        ItemSelected += OnItemSelected;
    }

    private void OnItemSelected(long index)
    {
        loadout.SetCoreMod(availableMods[index]);
    }
}
