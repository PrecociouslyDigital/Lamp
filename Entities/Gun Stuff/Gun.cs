using Godot;
using System;

public abstract class Gun : Node2D
{

    private static readonly PackedScene bulletTrailPrefab = ResourceLoader.Load("res://Entities/Gun Stuff/Trail.tscn") as PackedScene;
    public abstract bool canFire
    {
        get;
    }

    public void Fire()
    {
        if(canFire)
        {

        }
    }

    public static Line2D DrawBulletTrail(Vector2 start, Vector2 end)
    {
        var bulletTrail = bulletTrailPrefab.Instance<Line2D>();

        bulletTrail.Points = new[] { start, end };

        return bulletTrail;
    }

    [Signal]
    delegate void Fired();

    [Signal]
    delegate void DryFire();


}

