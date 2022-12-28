using Godot;
using System;

public enum HitType
{
    Bullet,
    Fire,
}


public readonly struct HitInfo
{
    public readonly Vector2 direction;
    public readonly HitType hitType;

    public HitInfo(Vector2 direction, HitType hitType)
    {
        this.direction = direction;
        this.hitType = hitType;
    }
}
public abstract class Hittable : Node2D
{

    public abstract bool OnHit(HitInfo hitInfo);
}
