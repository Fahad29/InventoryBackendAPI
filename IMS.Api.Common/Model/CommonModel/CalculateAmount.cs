namespace IMS.Api.Common.Model.CommonModel
{
    using System;

    public class CalculateAmount
    {
        private decimal _totalAmount;
        private decimal _vat;

        public CalculateAmount(decimal totalAmount, decimal vat)
        {
            _totalAmount = totalAmount; // Use the property to apply validation
            _vat = vat; // Use the property to apply validation
        }

        //public decimal TotalAmount
        //{
        //    get { return _totalAmount; }
        //    set
        //    {
        //        if (value < 0)
        //        {
        //            throw new ArgumentException("Total amount cannot be negative.");
        //        }

        //        _totalAmount = value;
        //    }
        //}

        //public decimal Vat
        //{
        //    get { return _vat; }
        //    set
        //    {
        //        if (value < 0 || value > 100)
        //        {
        //            throw new ArgumentException("VAT must be between 0 and 100.");
        //        }

        //        _vat = value;
        //    }
        //}

        public decimal VatAmount
        {
            get { return CalculateVatAmount(); }
        }

        public decimal PriceWithoutVat
        {
            get { return CalculateAmountWithoutVAT(); }
        }

        private decimal CalculateAmountWithoutVAT()
        {
            return _totalAmount - CalculateVatAmount();
        }

        private decimal CalculateVatAmount()
        {
            return _totalAmount * (_vat / 100);
        }
    }


}
