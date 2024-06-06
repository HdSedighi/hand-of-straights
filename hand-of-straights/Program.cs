using System;
using System.Collections.Generic;

public class Solution {
    public bool IsNStraightHand(int[] hand, int groupSize) {
        if (hand.Length % groupSize != 0) {
            return false;
        }

        // Sort the hand to handle the cards in ascending order
        Array.Sort(hand);
        
        // Use a dictionary to count the occurrences of each card
        Dictionary<int, int> cardCount = new Dictionary<int, int>();
        foreach (int card in hand) {
            if (cardCount.ContainsKey(card)) {
                cardCount[card]++;
            } else {
                cardCount[card] = 1;
            }
        }

        // Iterate through each card in the sorted hand
        foreach (int card in hand) {
            if (cardCount[card] == 0) continue;

            // Try to form a group starting with the current card
            for (int i = 0; i < groupSize; i++) {
                int currentCard = card + i;
                if (!cardCount.ContainsKey(currentCard) || cardCount[currentCard] == 0) {
                    return false;
                }
                cardCount[currentCard]--;
            }
        }

        return true;
    }

    public static void Main(string[] args) {
        Solution sol = new Solution();

        // Example 1
        int[] hand1 = {1, 2, 3, 6, 2, 3, 4, 7, 8};
        int groupSize1 = 3;
        Console.WriteLine(sol.IsNStraightHand(hand1, groupSize1)); // Output: true

        // Example 2
        int[] hand2 = {1, 2, 3, 4, 5};
        int groupSize2 = 4;
        Console.WriteLine(sol.IsNStraightHand(hand2, groupSize2)); // Output: false
    }
}
