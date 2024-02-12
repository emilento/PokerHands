using PokerHandsKata;

var lines = await File.ReadAllLinesAsync("input.txt");

foreach (var line in lines)
{
    var blackHand = new Hand();
    var whiteHand = new Hand();

    var blockType = BlockType.Unknown;
    foreach (var block in line.Split(" ", StringSplitOptions.RemoveEmptyEntries))
    {
        if (block == "Black:")
        {
            blockType = BlockType.Black;
            continue;
        }

        if (block == "White:")
        {
            blockType = BlockType.White;
            continue;
        }

        var rank = Enum.GetValues<Rank>().FirstOrDefault(r => r.GetDescription() == block[0].ToString());
        var suit = Enum.GetValues<Suit>().FirstOrDefault(r => r.GetDescription() == block[1].ToString());

        if (rank == Rank.None || suit == Suit.None)
        {
            continue;
        }

        if (blockType == BlockType.Black)
        {
            blackHand.Cards.Add(new Card(suit, rank));
        }

        if (blockType == BlockType.White)
        {
            whiteHand.Cards.Add(new Card(suit, rank));
        }
    }

    if (blackHand.Cards.Count != 5 || whiteHand.Cards.Count != 5)
    {
        Console.WriteLine("Parsing error.");
        continue;
    }

    var blackHandRank = new HandEvaluator().Evaluate(blackHand);
    var whiteHandRank = new HandEvaluator().Evaluate(whiteHand);

    if (blackHandRank > whiteHandRank)
    {
        Console.WriteLine($"Black wins - with {blackHandRank}.");
    }
    else if (blackHandRank < whiteHandRank)
    {
        Console.WriteLine($"White wins - with {whiteHandRank}.");
    }
    else
    {
        var blackCardRank = blackHand.Cards.OrderByDescending(c => c.Rank).First().Rank;
        var whiteCardRank = whiteHand.Cards.OrderByDescending(c => c.Rank).First().Rank;

        if (blackCardRank > whiteCardRank)
        {
            Console.WriteLine($"Black wins - with {blackHandRank}: {blackCardRank}.");
        }
        else if (blackCardRank < whiteCardRank)
        {
            Console.WriteLine($"White wins - with {whiteHandRank}: {whiteCardRank}.");
        }
        else
        {
            Console.WriteLine("Tie.");
        }
    }
}
