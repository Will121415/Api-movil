using Entidad;

namespace api_movil.Models
{
    public class InvoiceDetailInputModel
    {

        public int QuantityProduct { get; set; }
        public float Discount { get; set; }
        public int IdProduct{ get; set; }

        public InvoiceDetailInputModel()
        {
            
        }
    }

    public class InvoiceDetailViewModel:InvoiceDetailInputModel
    {
        
        public  ProductViewModel Product { get; set; }
        public decimal UnitValue { get; set; }
        public decimal TolalDetail { get; set; }

        public InvoiceDetailViewModel()
        {
            
        }
        public InvoiceDetailViewModel(InvoiceDetail detailModel)
        {
            UnitValue = detailModel.UnitValue;
            Discount = detailModel.Discount;
            TolalDetail = detailModel.TolalDetail;
            QuantityProduct = detailModel.QuantityProduct;
            Product = new ProductViewModel(detailModel.Product);
        }
    }
}