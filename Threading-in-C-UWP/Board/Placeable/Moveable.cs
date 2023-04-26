namespace Threading_in_C_UWP.Board.placeable
{
    public abstract class Moveable : Placeable
    {
        public Moveable() { }
        public abstract int getMovement();
    }
}