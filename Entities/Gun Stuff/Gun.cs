using Godot;
using System;

public abstract class Gun : RayCast2D
{

    private static readonly PackedScene bulletTrailPrefab = ResourceLoader.Load("res://Entities/Gun Stuff/Trail.tscn") as PackedScene;

    public abstract bool canFire
    {
        get;
    }

    public void TryFire()
    {
        if(canFire)
        {

            Fire();
            EmitSignal(nameof(Fired));
        }
        else
        {
            EmitSignal(nameof(DryFire));
        }
    }

    protected void Fire()
    {
        //Should be a very large number that should hit everything
        this.CastTo = this.Transform.y * 1e10f;
        // Should we use a SegmentShape2D for the ability to "pierce?"
        // or maybe just have objects mark themselves as unhittable after being "killed?"
        this.ForceRaycastUpdate();

        if (this.IsColliding())
        {
            if(this.GetCollider() is Hittable)
            {
                (this.GetCollider() as Hittable).OnHit(new HitInfo(
                    hitType: HitType.Bullet,
                    direction: this.GlobalTransform.y)
                );
            }

            this.AddChild(DrawBulletTrail(this.GlobalPosition, this.GetCollisionPoint()));
        }
        else
        {
            this.AddChild(DrawBulletTrail(this.GlobalPosition, this.GlobalPosition + this.GlobalTransform.y * 1e10f));
        }

    }

    public static Line2D DrawBulletTrail(Vector2 start, Vector2 end)
    {
        var bulletTrail = bulletTrailPrefab.Instance<Line2D>();
        bulletTrail.SetAsToplevel(true);
        bulletTrail.Points = new[] { start, end };

        return bulletTrail;
    }

    [Signal]
    delegate void Fired();

    [Signal]
    delegate void DryFire();


}

