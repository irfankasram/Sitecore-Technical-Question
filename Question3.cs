using System;
using System.Collections.Generic;

public class MinefieldSolver
{
    private int[,] minefield;
    private bool[,] visited;
    private bool[,] visitedByAlly;
    private int n, m;
    private List<(int, int)> path;

    public MinefieldSolver(int[,] minefield)
    {
        this.minefield = minefield;
        n = minefield.GetLength(0);
        m = minefield.GetLength(1);
        visited = new bool[n, m];
        visitedByAlly = new bool[n, m];
        path = new List<(int, int)>();
    }

    public List<(int, int)> GetSafePath()
    {
        DFS(0, 0);
        return path;
    }

    private bool DFS(int i, int j)
    {
        if (i < 0 || i >= n || j < 0 || j >= m)
        {
            return false;
        }
        if (visited[i, j] || minefield[i, j] == 1)
        {
            return false;
        }
        visited[i, j] = true;
        path.Add((i, j));
        if (i == n - 1 && j == m - 1)
        {
            return true;
        }
        bool foundSafePath = false;
        if (DFS(i - 1, j))
        { // Check top
            foundSafePath = true;
        }
        else if (DFS(i, j + 1))
        { // Check right
            foundSafePath = true;
        }
        else if (DFS(i + 1, j))
        { // Check bottom
            foundSafePath = true;
        }
        else if (DFS(i, j - 1))
        { // Check left
            foundSafePath = true;
        }
        if (foundSafePath)
        {
            // Totoshka moves to the next field
            if (path.Count > 1)
            {
                (int, int) prevPos = path[path.Count - 2];
                visitedByAlly[prevPos.Item1, prevPos.Item2] = true;
            }
            // Ally moves to the field that Totoshka was previously in
            (int, int) currPos = path[path.Count - 1];

            if (visitedByAlly[currPos.Item1, currPos.Item2] || minefield[currPos.Item1, currPos.Item2] == 1)
            {
                // Ally cannot move to that field, Totoshka must backtrack
                path.RemoveAt(path.Count - 1);
                visited[i, j] = false;
                return false;
            }
            else
            {
                visitedByAlly[currPos.Item1, currPos.Item2] = true;
            }
        }
    }

}