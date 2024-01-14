using Play_investe.Enums;
using Play_investe.Entity;
using Play_investe.DTO;

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
        public Bound(SaveBoundDTO savebounDto)
        {
            LiquidityType = savebounDto.LiquidityType;
            Index = savebounDto.Index;
            Percent = savebounDto.Percent;                 
            
            if(savebounDto.LiquidityType == 0)
            {
                AvailableForWithdrawal = true;
            }

            if (savebounDto.Index.Length > 0)
            {
                 Type = "Indexed Bound";
            }
            else
            {
                 Type = "Fixed Bound";     
            }
                   
           
           
        }

        public DateTime GetDueDate(LiquidityType liquidityType)
        {
            var aquisitionDay = DateTime.Now;
            int diasLiquidez = (int)liquidityType;

            var dueDate = aquisitionDay.AddDays(diasLiquidez);

            return dueDate;
        }

    }
}
