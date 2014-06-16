using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Game
{
    class AStarSearch
    {
        private List<Node> openList = new List<Node>();
        private List<Node> closedList = new List<Node>();
        private List<TilePath> tiles = new List<TilePath>();

        public bool Diagonal = true;

        private Node start;
        private Node end;
        private Node current;
        private Vector2 mapSize;

        public AStarSearch(List<TilePath> t, Vector2 mapSize)
        {
            this.mapSize = mapSize;
            tiles = t;
        }
        public AStarSearch(List<TilePath> t, Vector2 mapSize, bool diagonal)
        {
            this.mapSize = mapSize;
            tiles = t;
            Diagonal = diagonal;
        }
        public List<TilePath> SearchPath()
        {
            int i;
            for ( i = 0; i < tiles.Count; i++)
            {
                if (tiles[i].Type == 1)
                    start = new Node(tiles[i].ID, null);
                if (tiles[i].Type == 2)
                    end = new Node(tiles[i].ID, null);
            }

            openList.Add(start);
            current = start;

            while (true)
            {
                if (openList.Count == 0)
                    break;

                current = FindSmallestF();

                if (current.CellIndex == end.CellIndex)
                    break;

                openList.Remove(current);
                closedList.Add(current);

                if (Diagonal)
                {
                    //Diagonal
                    AddAdjacentCellToOpenList(current, 1, -1, 14);
                    AddAdjacentCellToOpenList(current, -1, -1, 14);
                    AddAdjacentCellToOpenList(current, -1, 1, 14);
                    AddAdjacentCellToOpenList(current, 1, 1, 14);
                }
                //Straight
                AddAdjacentCellToOpenList(current, 0, -1, 10);
                AddAdjacentCellToOpenList(current, -1, 0, 10);
                AddAdjacentCellToOpenList(current, 1, 0, 10);
                AddAdjacentCellToOpenList(current, 0, 1, 10);

            }
            while (current != null)
            {
                bool endOnClosed = false;
                for(int v = 0; v< openList.Count; v++)
                    if (openList[v].CellIndex == end.CellIndex)
                        endOnClosed = true;
                if (endOnClosed && tiles[current.CellIndex].Type != 2 && tiles[current.CellIndex].Type != 1)
                    tiles[current.CellIndex].Type = 4;
                current = current.Parent;
            }
            
            return tiles;
        }


        private Node FindSmallestF()
        {
            var smallestF = int.MaxValue;
            Node selectedNode = null;

            foreach (var node in openList)
            {
                if (node.F < smallestF)
                {
                    selectedNode = node;
                    smallestF = node.F;
                }
            }

            return selectedNode;
        }


        private void AddAdjacentCellToOpenList(Node parentNode, int columnOffset, int rowOffset, int gCost)
        {
            var adjacentCellIndex = GetAdjacentCellIndex(parentNode.CellIndex, columnOffset, rowOffset);

            // ignore unwalkable nodes (or nodes outside the grid)
            if (adjacentCellIndex == -1)
                return;

            // ignore nodes on the closed list
            if (closedList.Any(n => n.CellIndex == adjacentCellIndex))
                return;

            var adjacentNode = openList.SingleOrDefault(n => n.CellIndex == adjacentCellIndex);
            if (adjacentNode != null)
            {
                if (parentNode.G + gCost < adjacentNode.G)
                {
                    adjacentNode.Parent = parentNode;
                    adjacentNode.G = parentNode.G + gCost;
                    adjacentNode.F = adjacentNode.G + adjacentNode.H;
                }

                return;
            }

            var node = new Node(adjacentCellIndex, parentNode) { G = gCost, H = GetDistance(adjacentCellIndex, end.CellIndex) };
            node.F = node.G + node.H;
            openList.Add(node);
        }

        public int GetAdjacentCellIndex(int cellIndex, int columnOffset, int rowOffset)
        {
            var x = cellIndex % (int)mapSize.X;
            var y = cellIndex / (int)mapSize.X;

            if ((x + columnOffset < 0 || x + columnOffset > mapSize.X - 1) ||
                (y + rowOffset < 0 || y + rowOffset > mapSize.Y - 1))
                return -1;

            if (tiles[((y + rowOffset) * (int)mapSize.X) + (x + columnOffset)].Type == 3)
                return -1;

            return cellIndex + columnOffset + (rowOffset * (int)mapSize.X);
        }

        public int GetDistance(int startTileID, int endTileID)
        {
            var startX = (int)tiles[startTileID].TilePos.X / (int)mapSize.X;
            var startY = (int)tiles[startTileID].TilePos.Y / (int)mapSize.Y;

            var endX = (int)tiles[endTileID].TilePos.X / (int)mapSize.X;
            var endY = (int)tiles[endTileID].TilePos.Y / (int)mapSize.Y;

            return Math.Abs(startX - endX) + Math.Abs(startY - endY);   
        }
    }
}
