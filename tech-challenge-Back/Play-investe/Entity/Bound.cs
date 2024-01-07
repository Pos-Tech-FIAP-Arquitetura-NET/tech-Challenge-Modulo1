using Play_investe.Enums;
using Play_investe.Entity;

namespace Play_investe.Entity
{
    public class Bound : Entitys
    {      

        public LiquidityType LiquidityType { get; set; }
        public bool AvailableForWithdrawal { get; set; } = false;
        public List<Investment> Investments { get; set; }
        public string Type { get; set; }
        public string? Index { get; set; }
        public float Percent { get; set; }
    

        public Bound() { }
        public Bound(LiquidityType liquidityType,  string index, float percent)
        {
            LiquidityType = liquidityType;
            Index = index;
            Percent = percent;                 
            
            if(liquidityType == 0)
            {
                AvailableForWithdrawal = true;
            }

            if (index.Length > 0)
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
