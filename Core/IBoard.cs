using System;

namespace MonopolyKata.Core
{
    public interface IBoard
    {
        void MovePlayer(String player, Int32 numberOfSpaces);
        void TeleportPlayer(String player, Int32 location);
        Int32 GetPlayerLocation(String player);
    }
}
