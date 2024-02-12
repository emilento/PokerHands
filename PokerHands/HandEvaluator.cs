namespace PokerHandsKata;

public class HandEvaluator
{
    public HandRank Evaluate(Hand hand)
    {
        if (IsStraightFlush(hand))
        {
            return HandRank.StraightFlush;
        }

        if (IsFourOfAKind(hand))
        {
            return HandRank.FourOfAKind;
        }

        if (IsFullHouse(hand))
        {
            return HandRank.FullHouse;
        }

        if (IsFlush(hand))
        {
            return HandRank.Flush;
        }

        if (IsStraight(hand))
        {
            return HandRank.Straight;
        }

        if (IsThreeOfAKind(hand))
        {
            return HandRank.ThreeOfAKind;
        }

        if (IsTwoPair(hand))
        {
            return HandRank.TwoPair;
        }

        if (IsOnePair(hand))
        {
            return HandRank.OnePair;
        }

        return HandRank.HighCard;
    }

    private bool IsStraightFlush(Hand hand)
    {
        return IsFlush(hand) && IsStraight(hand);
    }

    private bool IsFourOfAKind(Hand hand)
    {
        var rankGroups = hand.Cards.GroupBy(card => card.Rank);
        return rankGroups.Any(group => group.Count() == 4);
    }

    private bool IsFullHouse(Hand hand)
    {
        var rankGroups = hand.Cards.GroupBy(card => card.Rank);
        return rankGroups.Any(group => group.Count() == 3) && rankGroups.Any(group => group.Count() == 2);
    }

    private bool IsFlush(Hand hand)
    {
        return hand.Cards.GroupBy(card => card.Suit).Count() == 1;
    }

    private bool IsStraight(Hand hand)
    {
        var sortedRanks = hand.Cards.Select(card => (int)card.Rank).OrderBy(rank => rank).ToList();

        for (int i = 1; i < sortedRanks.Count; i++)
        {
            if (sortedRanks[i] != sortedRanks[i - 1] + 1)
            {
                return false;
            }
        }

        return true;
    }

    private bool IsThreeOfAKind(Hand hand)
    {
        var rankGroup = hand.Cards.GroupBy(c => c.Rank);
        return rankGroup.Any(group => group.Count() == 3);
    }

    private bool IsTwoPair(Hand hand)
    {
        var rankGroup = hand.Cards.GroupBy(c => c.Rank);
        return rankGroup.Count(group => group.Count() == 2) == 2;
    }

    private bool IsOnePair(Hand hand)
    {
        var rankGroup = hand.Cards.GroupBy(c => c.Rank);
        return rankGroup.Any(group => group.Count() == 2);
    }
}
