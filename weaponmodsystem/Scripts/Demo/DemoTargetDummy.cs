using Godot;
using System;

public partial class DemoTargetDummy : Node3D, IDamageable
{
    [Export] public float MaxHealth = 100f;
    private float _currentHealth;

    [Export] public NodePath DebugUIPath;
    private DebugUi _debugUI;

    public override void _Ready()
    {
        _currentHealth = MaxHealth;
        _debugUI = GetNodeOrNull<DebugUi>(DebugUIPath);
        UpdateLabel();
    }

    public void ApplyDamage(float amount)
    {
        _currentHealth -= amount;
        _currentHealth = Mathf.Max(_currentHealth, 0);

        UpdateLabel();

        GD.Print($"Dummy took {amount} damage");
    }

    private void UpdateLabel()
    {
        _debugUI.UpdateTargetDummyLabel(_currentHealth, MaxHealth);
    }
}
