using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_backend.Controllers
{
    public static class Graph
    {
        public static Dictionary<int, int> rows = new Dictionary<int, int>();
        public static Dictionary<int, int> columns = new Dictionary<int, int>();
        public static Dictionary<int, int> rowsAlternative = new Dictionary<int, int>();
        public static Dictionary<int, int> columnsAlternative = new Dictionary<int, int>();
        private static double minscore = 0.0;

        public static IList<int> ShiftValues(int startIndex, IList<int> list)
        {
            for (int i=startIndex; i<list.Count-1; i++)
            {
                list[i] = list[i + 1];
            }
            list[list.Count - 1] = int.MinValue;
            return list;
        }

        public static void ChangeRow(int row, int count)
        {
            var newValues = ShiftValues(row, rows.Values.ToList());
            for (int i=0; i<rows.Count; i++)
            {
                rows[i] = newValues[i];
            }
        }

        public static void ChangeColumn(int column, int count)
        {
            var newValues = ShiftValues(column, columns.Values.ToList());
            for (int i = 0; i < columns.Count; i++)
            {
                columns[i] = newValues[i];
            }
        }

        public static List<List<double>> RowsReduction(List<List<double>> list)
        {
            var mins = list.Select(x => x.Min()).ToList();
            var result = new List<List<double>>(list);
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list[0].Count; j++)
                {
                    result[i][j] -= mins[i];
                }
            }
            return result;
        }

        public static List<List<double>> ColumnsReduction(List<List<double>> list)
        {
            var transponed = Transpose(list);
            var reduction = RowsReduction(transponed);
            return Transpose(reduction);
        }

        public static List<List<double>> Transpose(List<List<double>> list)
        {
            var result = Copy(list);
            for (int i = 0; i < result.Count; i++)
            {
                for (int j = i + 1; j < result.Count; j++)
                {
                    var tmp = result[i][j];
                    result[i][j] = result[j][i];
                    result[j][i] = tmp;
                }
            }
            return result;
        }

        public static double GetLowerLimit(List<List<double>> list)
        {
            var transponed = Transpose(list);
            var rowLimit = list.Select(x => x.Min());
            var columnLimit = transponed.Select(x => x.Min());
            return rowLimit.Sum() + columnLimit.Sum();
        }

        public static List<List<double>> TruncateMatrix(List<List<double>> list, int i, int j)
        {
            var result = new List<List<double>>(list);
            int newRow = 0, newColumn=0;
            try
            {
                newRow = columns.Where(x => x.Value == rows[i]).First().Key;
            }
            catch (InvalidOperationException)
            {
                newRow = int.MinValue;
            }
            try
            {
                newColumn = rows.Where(x => x.Value == columns[j]).First().Key;
            }
            catch (InvalidOperationException)
            {
                newColumn = int.MinValue;
            }
            if (newRow != int.MinValue && newColumn != int.MinValue)
            {
                result[newColumn][newRow] = double.PositiveInfinity;
            }
            result.RemoveAt(i);
            result.ForEach(x => x.RemoveAt(j));
            return result;
        }

        public static double GetRowMin(List<double> list)
        {
            return list.Min();
        }

        public static (int, int) GetMaxScore(List<List<double>> list)
        {
            int row = 0, column = 0;
            double max = 0.0;
            List<double> rowmins = new List<double>() { 0.0, 0.0, 0.0, 0.0, 0.0};
            List<double> colmins = new List<double>() { 0.0, 0.0, 0.0, 0.0, 0.0};
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    if (list[i][j] == 0)
                    {
                        list[i][j] = double.PositiveInfinity;
                        var rowmin = GetRowMin(list[i]);
                        rowmins[i] = rowmin;
                        var colmin = GetRowMin(Transpose(list)[j]);
                        colmins[j] = colmin;
                        var score = rowmin + colmin;
                        if (score > max)
                        {
                            max = score;
                            row = i;
                            column = j;
                        }
                        list[i][j] = 0.0;
                    }
                }
            }
            if (minscore == 0.0)
            {
                minscore = colmins.Sum() + rowmins.Sum();
            }
            return (row, column);
        }

        public static (int, int) GetMaxScore(List<List<double>> list, int row)
        {
            int column = 0;
            double max = 0.0;
            for (int j = 0; j < list.Count; j++)
            {
                if (list[row][j] == 0)
                {
                    var rowmin = (list[row].Count(x => x == 0.0) == 1) ? GetRowMin(list[row].Except(new List<double>() { list[row][j] }).ToList()) : 0.0;
                    var colmin = (Transpose(list)[j].Count(x => x == 0.0) == 1) ? GetRowMin(Transpose(list)[j].Except(new List<double>() { list[row][j] }).ToList()) : 0.0;
                    var score = rowmin + colmin;
                    if (score > max)
                    {
                        max = score;
                        column = j;
                    }
                }
            }
            return (row, column);
        }

        public static (int, int) HasCycles(List<List<double>> list, Dictionary<int, int> tuples)
        {
            int lastVertex=-1;
            for (int i=0; i<list.Count; i++)
            {
                if (IsInGraph(rows[i], tuples))
                {
                    lastVertex = i;
                    break;
                }
            }
            for (int j=0; j<list.Count; j++)
            {
                if (IsInGraph(columns[j], tuples) && list[lastVertex][j] != double.PositiveInfinity) return (lastVertex, j);
            }
            return (-1, -1);
        }

        public static bool IsInGraph(int vertex, Dictionary<int, int> tuples)
        {
            return tuples.Keys.Contains(vertex) || tuples.Values.Contains(vertex);
        }

        public static string Calculate(List<List<double>> list)
        {
            List<List<double>> alternativeTree = Copy(list);
            List<List<double>> withEdge = Copy(list);
            List<List<double>> withoutEdge = Copy(list);
            for (int i=0; i<list.Count; i++)
            {
                rows.Add(i, i);
                columns.Add(i, i);
            }
            var tmp = Copy(list);
            var dictionary = new Dictionary<int, int>();
            minscore = StartScore(tmp);
            while (tmp.Count > 1)
            {

                if (tmp.Count > 2)
                {
                    tmp = RowsReduction(tmp);
                    tmp = ColumnsReduction(tmp);
                    var hasCycles = HasCycles(tmp, dictionary);
                    if (hasCycles.Item1 != -1)
                    {
                        tmp[hasCycles.Item1][hasCycles.Item2] = double.PositiveInfinity;
                    }
                }
                (int, int) tuple;
                tuple = GetMaxScore(tmp);

                if (NeededReduction(tuple.Item1, tuple.Item2, tmp))
                {
                    tmp = TruncateMatrix(tmp, tuple.Item1, tuple.Item2);
                    dictionary.Add(rows[tuple.Item1], columns[tuple.Item2]);
                    ChangeRow(tuple.Item1, tmp.Count);
                    ChangeColumn(tuple.Item2, tmp.Count);
                }
                else
                {
                    DeleteNonHamiltonCycle(tmp, tuple.Item1, tuple.Item2);
                }
                minscore = 0.0;
            }
            rows.Clear();
            columns.Clear();
            return GetEdges(dictionary);
        }

        public static void DeleteNonHamiltonCycle(List<List<double>> list, int i, int j)
        {
            int newRow = 0, newColumn = 0;
            try
            {
                newRow = columns.Where(x => x.Value == rows[i]).First().Key;
            }
            catch (InvalidOperationException)
            {
                newRow = int.MinValue;
            }
            try
            {
                newColumn = rows.Where(x => x.Value == columns[j]).First().Key;
            }
            catch (InvalidOperationException)
            {
                newColumn = int.MinValue;
            }
            if (newRow != int.MinValue && newColumn != int.MinValue)
            {
                list[newColumn][newRow] = double.PositiveInfinity;
            }
        }

        public static string GetEdges(IDictionary<int, int> dict)
        {
            var builder = new StringBuilder();
            builder.Append(dict.FirstOrDefault().Key);
            builder.Append(dict.FirstOrDefault().Value);
            var previous = dict.FirstOrDefault().Value;
            while (true)
            {
                try
                {
                    builder.Append(dict[previous]);
                    previous = dict[previous];
                }
                catch (KeyNotFoundException)
                {
                    break;
                }
            }
            return builder.ToString();
        }

        public static double StartScore(List<List<double>> list)
        {
            double result = 0.0;
            list.ForEach(x => result += GetRowMin(x));
            var tmp = Copy(list);
            tmp = RowsReduction(tmp);
            var transponed = Transpose(tmp);
            transponed.ForEach(x => result += GetRowMin(x));
            return result;
        }

        public static bool NeededReduction(int i, int j, List<List<double>> list)
        {
            double except = GetMinScore(list, i, j);
            var tmp = Copy(list);
            tmp = TruncateMatrix(tmp, i, j);
            double with = GetMinScore(tmp);
            return with <= except;
        }

        public static List<List<double>> Copy(List<List<double>> list)
        {
            var result = new List<List<double>>();
            for (int i=0; i<list.Count; i++)
            {
                result.Add(new List<double>());
                for (int j=0; j<list.Count; j++)
                {
                    result[i].Add(list[i][j]);
                }
            }
            return result;
        }

        public static List<List<double>> GetWithoutEdge(List<List<double>> list, int i, int j)
        {
            var result = Copy(list);
            DeleteNonHamiltonCycle(result, i, j);
            return result;
        }

        public static List<List<double>> GetWithEdge(List<List<double>> list, int i, int j)
        {
            var result = Copy(list);
            return TruncateMatrix(result, i, j);
        }

        public static double GetMinScore(List<List<double>> list)
        {
            double with = minscore;
            list.ForEach(x => with += GetRowMin(x));
            var transpones = Transpose(list);
            transpones.ForEach(x => with += GetRowMin(x));
            return with;
        }

        public static double GetMinScore(List<List<double>> list, int i, int j)
        {
            list[i][j] = double.PositiveInfinity;
            double except = minscore + GetRowMin(list[i]) + GetRowMin(Transpose(list)[j]);
            list[i][j] = 0;
            return except;
        }

    }
}
