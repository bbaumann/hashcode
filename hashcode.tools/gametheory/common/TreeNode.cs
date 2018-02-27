using System;
using System.Linq;
using System.Collections.Generic;

namespace hashcode.tools.gametheory.common
{
    public class TreeNode<M, G> : IComparable<TreeNode<M, G>>
    {
        public double[] Evaluation { get; private set; }
        public M Move { get; private set; }
        public G Game { get; private set; }
        public int Depth { get; private set; }
        public int PlayerId { get; private set; }
        private IScoreConverter _converter;

        public TreeNode(double[] evaluation, M move, G game, int depth, IScoreConverter converter, int playerId)
        {
            this.Evaluation = evaluation;
            this.Move = move;
            this.Game = game;
            this.Depth = depth;
            this._converter = converter;
            this.PlayerId = playerId;
        }

        public void decrementDepth()
        {
            Depth--;
        }

        public override string ToString()
        {
            return "TreeNode [evaluation=[" + String.Join(";", Evaluation.Cast<string>()) + "], move=" + Move + ", depth=" + Depth + "]";
        }

        public int CompareTo(TreeNode<M, G> other)
        {
            return Compare(this.Evaluation, 1.0d, this.PlayerId,
                other.Evaluation, 1.0d, other.PlayerId, this._converter);
        }


        public static TreeNode<M, G> GetBest(List<TreeNode<M, G>> moves, int playerId)
        {
            moves.Sort();
            return moves.FirstOrDefault();
        }

        private static int Compare(double[] scores1, double evaluation1Factor, int player1Id, double[] scores2, double evaluation2Factor, int player2Id,
                IScoreConverter converter)
        {
            double diff = converter.convert(scores1, player1Id) * evaluation1Factor - converter.convert(scores2, player2Id) * evaluation2Factor;
            if (diff < 0)
            {
                return 1;
            }
            if (diff > 0)
            {
                return -1;
            }
            return 0;
        }

        public bool IsBetter(TreeNode<M, G> other)
        {
            return this.CompareTo(other) > 0;
        }
    }
}