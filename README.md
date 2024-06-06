# Intuition
<!-- Describe your first thoughts on how to solve this problem. -->
To solve the problem of grouping cards into consecutive sequences of a given size, the key insight is that we need to ensure every card can form part of exactly one sequence of the required length. This means that each card should appear in groups with its immediate successors. By sorting the cards first, we can easily check for consecutive sequences. We then use a counting mechanism to keep track of the occurrences of each card and decrement these counts as we form valid groups.

# Approach
<!-- Describe your approach to solving the problem. -->
1. Initial Check: First, check if the total number of cards is divisible by the group size. If not, return false because it's impossible to split the cards into equal groups of the desired size.
2. Sorting: Sort the hand array to process the cards in ascending order.
3. Counting Occurrences: Use a dictionary to count the occurrences of each card.
4. Forming Groups: Iterate through each card in the sorted hand. For each card, try to form a group of groupSize consecutive cards starting from that card. If the required card for the group is not available or has already been used up, return false.
5. Success: If all cards are successfully grouped, return true.
# Complexity
- Time complexity:
<!-- Add your time complexity here, e.g. $$O(n)$$ -->
The time complexity is O(nlogn+n⋅k), where n is the number of cards and k is the group size. Sorting the cards takes O(nlogn), and forming the groups involves iterating through the sorted cards and decrementing counts, which takes O(n⋅k).

- Space complexity:
<!-- Add your space complexity here, e.g. $$O(n)$$ -->
The space complexity is O(n), where n is the number of unique cards. This space is used for the dictionary that counts the occurrences of each card.

# Code
```
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
}
```
