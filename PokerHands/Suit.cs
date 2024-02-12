using System.ComponentModel;

namespace PokerHandsKata;

public enum Suit
{
    None,
    [Description("H")]
    Hearts,
    [Description("D")]
    Diamonds,
    [Description("C")]
    Clubs,
    [Description("S")]
    Spades
}
