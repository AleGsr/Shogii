using Unity.Mathematics;

public enum PieceType
{
    Pawn,
    Spear,
    Horse,
    Silver,
    Gold,
    Tower,
    Bishop,
    King
}

public enum Team
{
    White,
    Black
}


public abstract class Piece
{
    public int2 coor;
    public PieceType type;
    public Team team;

    public Piece(int2 coor, PieceType type, Team team)
    {
        this.coor = coor;
        this.type = type;   
        this.team = team;
    }

}

public class Pawn: Piece {
    public Pawn(int2 coor, Team team) : base(coor,PieceType.Pawn, team) {
        this.coor = coor;
        this.type = PieceType.Pawn;
        this.team = team;
    }
}

public class Spear : Piece {
    public Spear(int2 coor, Team team) : base(coor, PieceType.Spear, team) {
        this.coor = coor;
        this.type = PieceType.Spear;
        this.team = team;
    }
}

public class Horse : Piece {
    public Horse(int2 coor, Team team) : base(coor, PieceType.Horse, team) {
        this.coor = coor;
        this.type = PieceType.Horse;
        this.team = team;
    }
}

public class Silver : Piece {
    public Silver(int2 coor, Team team) : base(coor, PieceType.Silver, team) {
        this.coor = coor;
        this.type = PieceType.Silver;
        this.team = team;
    }
}

public class Gold : Piece {
    public Gold(int2 coor, Team team) : base(coor, PieceType.Gold, team) {
        this.coor = coor;
        this.type = PieceType.Gold;
        this.team = team;
    }
}

public class Tower : Piece {
    public Tower(int2 coor, Team team) : base(coor, PieceType.Tower, team) {
        this.coor = coor;
        this.type = PieceType.Tower;
        this.team = team;
    }
}

public class Bishop : Piece {
    public Bishop(int2 coor, Team team) : base(coor, PieceType.Bishop, team) {
        this.coor = coor;
        this.type = PieceType.Bishop;
        this.team = team;
    }
}

public class King : Piece {
    public King(int2 coor, Team team) : base(coor, PieceType.King, team) {
        this.coor = coor;
        this.type = PieceType.King;
        this.team = team;
    }
}