using System.Collections.Generic;

public class Player
{
    public Team team { get; private set; }
    public SideBoard sideBoard { get; private set; }   

    public Player(Team team)
    {
        this.team = team;
        sideBoard = new SideBoard();
    }

}

public class SideBoard
{
    public Queue<Pawn> pawns = new Queue<Pawn>();
    public Queue<Spear> spear = new Queue<Spear>();
    public Queue<Horse> horse = new Queue<Horse>();
    public Queue<Silver> silvers = new Queue<Silver>();
    public Queue<Gold> gold = new Queue<Gold>();
    public Queue<Tower> tower = new Queue<Tower>();
    public Queue<Bishop> bishop = new Queue<Bishop>();

}

