using System;
using System.Collections.Generic;
using System.Text;

namespace BattleTechNET.TotalWarfare
{
    public class BattleValueLedger
    {
        public BattleValueLedger()
        {
            RootNode = new BattleValueNode();
            
        }
        public BattleValueNode RootNode { get; set; }
    }

    public class BattleValueNode
    {
        public BattleValueNode() { Factor = 1;Summand = 0;Children = new List<BattleValueNode>(); }

        public string Name { get; set; }
        public List<BattleValueNode> Children { get; set; }
        private BattleValueNode mParent = null;
        public BattleValueNode Parent
        {
            get { return mParent; }
            set
            {
                if (mParent != null)
                {
                    if(mParent.Children.Contains(this))
                    {
                        mParent.Children.Remove(this);
                    }
                }
                mParent = value;
                mParent.Children.Add(this);
            }
        }
        public double Summand { get; set; }
        public double Factor { get; set; }
        public string GetTree(int iDepth)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < iDepth; i++) sb.Append(" ");
            sb.Append($"+ {Name} (");
            if (Summand != 0) sb.Append($"{Summand}");
            if (Factor != 1) sb.Append($"x{Factor}");
            sb.Append($") = {Value})");
            sb.AppendLine();
            foreach(BattleValueNode node in Children)
            {
                sb.Append(node.GetTree(iDepth + 1));
            }
            return sb.ToString();
        }

        public double Value
        {
            get
            {
                double d = 0;
                foreach(BattleValueNode child in Children)
                {
                    d += child.Value;
                }
                d += Summand;
                d *= Factor;
                return d;
            }
        }
    }
}
