using Play_investe.Enums;
using StoreFIAP.Entity;

namespace Play_investe.Entity
{
    public class Bound : Entitys
    {      

        public LiquidityType LiquidityType { get; set; }
        public bool AvailableForWithdrawal { get; set; } = false;
        public List<Investment> Investments { get; set; }
        public string Type { get; set; }
        public float Index { get; set; }
        public float Percent { get; set; }

        public Bound() { }
        public Bound(LiquidityType liquidityType,  float index, float percent)
        {
            LiquidityType = liquidityType;
            Index = index;
            Percent = percent;
            CreatedDate = DateTime.Now;

            if (index < 0)
            {
                 Type = "Indexed Bound";
            }
            else
            {
                 Type = "Fixed Bound";     
            }
                   
           
           
        }

    }
}
