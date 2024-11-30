using System;

public class DeckIsEmptyException : Exception {
    public DeckIsEmptyException() : base("Combatant's deck is empty!") {
        
    }
}