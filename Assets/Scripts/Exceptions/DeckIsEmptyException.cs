using System;

public class DeckIsEmptyException : Exception {
    public DeckIsEmptyException(string msg) {
        base(msg);
    }
}