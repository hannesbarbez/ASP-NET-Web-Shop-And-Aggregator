using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using app0.App_Data;

namespace app0.App_Logic
{
    internal class StoreComparer
    {
        private CompupartsServiceProxy.CompupartsSoapClient cpClient;
        private UnderthehoodServiceProxy.UnderTheHoodSoapClient uthClient;
        private XhardwareServiceProxy.XHardwareSoapClient xhClient;

        private CompupartsServiceProxy.ServiceResponse CpSr;
        private UnderthehoodServiceProxy.ServiceResponse UthSr;
        private XhardwareServiceProxy.ServiceResponse XhSr;

        private bool cpIsBestBuy = false;
        private bool uthIsBestBuy = false;
        private bool xhIsBestBuy = false;

        internal double CpPrice
        {
            get
            {
                try
                {
                    return this.CpSr.Price;
                }
                catch
                {
                    return -1;
                }
            }
        }

        internal double UthPrice
        {
            get
            {
                try
                {
                    return this.UthSr.Price;
                }
                catch
                {
                    return -1;
                }
            }
        }

        internal double XhPrice
        {
            get
            {
                try
                {
                    return this.XhSr.Price;
                }
                catch
                {
                    return -1;
                }
            }
        }

        internal int CpStock
        {
            get
            {
                try
                {
                    return this.CpSr.QuantityInStock;
                }
                catch
                {
                    return -1;
                }
            }
        }

        internal int UthStock
        {
            get
            {
                try
                {
                    return this.UthSr.QuantityInStock;
                }
                catch
                {
                    return -1;
                }
            }
        }

        internal int XhStock
        {
            get
            {
                try
                {
                    return this.XhSr.QuantityInStock;
                }
                catch
                {
                    return -1;
                }
            }
        }

        internal DateTime CpDate
        {
            get
            {
                try
                {
                    return this.CpSr.DeliveryDate.Date;
                }
                catch
                {
                    return new DateTime(1980, 1, 1);
                }
            }
        }

        internal DateTime XhDate
        {
            get
            {
                try
                {
                    return this.XhSr.DeliveryDate.Date;
                }
                catch
                {
                    return new DateTime(1980, 1, 1);
                }
            }
        }

        internal DateTime UthDate
        {
            get
            {
                try
                {
                    return this.UthSr.DeliveryDate.Date;
                }
                catch
                {
                    return new DateTime(1980, 1, 1);
                }
            }
        }

        internal bool CpHasBestPrice
        {
            get
            {
                try
                {
                    if (CpPrice > 0)
                    {
                        if (UthPrice <= 0 && XhPrice <= 0) return true;
                        else if (UthPrice <= 0) return CpPrice <= XhPrice;
                        else if (XhPrice <= 0) return CpPrice <= UthPrice;
                        return (CpPrice <= XhPrice && CpPrice <= UthPrice);
                    }
                    return false;
                }
                catch
                {
                    return false;
                }
            }
        }

        internal bool XhHasBestPrice
        {
            get
            {
                try
                {
                    if (XhPrice > 0)
                    {
                        if (UthPrice < 0 && CpPrice <= 0) return true;
                        else if (UthPrice < 0) return XhPrice <= CpPrice;
                        else if (CpPrice < 0) return XhPrice <= UthPrice;
                        return (XhPrice <= CpPrice && XhPrice <= UthPrice);
                    }
                    return false;
                }
                catch
                {
                    return false;
                }
            }
        }

        internal bool UthHasBestPrice
        {
            get
            {
                try
                {
                    if (UthPrice > 0)
                    {
                        if (XhPrice < 0 && CpPrice < 0) return true;
                        else if (XhPrice < 0) return UthPrice <= CpPrice;
                        else if (CpPrice < 0) return UthPrice < XhPrice;
                        return (UthPrice <= CpPrice && UthPrice <= XhPrice);
                    }
                    return false;
                }
                catch
                {
                    return false;
                }
            }
        }

        internal bool CpHasMoreStock
        {
            get
            {
                try
                {
                    if (CpStock > 0)
                    {
                        if (UthStock < 1 && XhStock < 1) return true;
                        else if (UthStock < 1) return CpStock >= XhStock;
                        else if (XhStock < 1) return CpStock >= UthStock;
                        return (CpStock >= UthStock && CpStock >= XhStock);
                    }
                    return false;
                }
                catch
                {
                    return false;
                }
            }
        }

        internal bool UthHasMoreStock
        {
            get
            {
                try
                {
                    if (UthStock > 0)
                    {
                        if (CpStock < 1 && XhStock < 1) return true;
                        else if (CpStock < 1) return UthStock >= XhStock;
                        else if (XhStock < 1) return UthStock >= CpStock;
                        return (UthStock >= CpStock && UthStock >= XhStock);
                    }
                    return false;
                }
                catch
                {
                    return false;
                }
            }
        }

        internal bool XhHasMoreStock
        {
            get
            {
                try
                {
                    if (XhStock > 0)
                    {
                        if (CpStock < 1 && UthStock < 1) return true;
                        else if (CpStock < 1) return XhStock >= UthStock;
                        else if (UthStock < 1) return XhStock >= CpStock;
                        return (XhStock >= UthStock && XhStock >= CpStock);
                    }
                    return false;
                }
                catch
                {
                    return false;
                }
            }
        }

        internal bool CpHasBestDeliveryDate
        {
            get
            {
                try
                {
                    if (ValidCpDate)
                    {
                        if (!(ValidUthDate && ValidXhDate)) return true;
                        else if (!ValidUthDate) return CpDate <= XhDate;
                        else if (!ValidXhDate) return CpDate <= UthDate;
                        return (CpDate <= XhDate && CpDate <= UthDate);
                    }
                    return false;
                }
                catch
                {
                    return false;
                }
            }
        }

        internal bool UthHasBestDeliveryDate
        {
            get
            {
                try
                {
                    if (ValidUthDate)
                    {
                        if (!(ValidCpDate && ValidXhDate)) return true;
                        else if (!ValidCpDate) return UthDate <= XhDate;
                        else if (!ValidXhDate) return UthDate <= CpDate;
                        return (UthDate <= XhDate && UthDate <= CpDate);
                    }
                    return false;
                }
                catch
                {
                    return false;
                }
            }
        }

        internal bool XhHasBestDeliveryDate
        {
            get
            {
                try
                {
                    if (ValidXhDate)
                    {
                        if (!(ValidUthDate && ValidCpDate)) return true;
                        else if (!ValidUthDate) return XhDate <= CpDate;
                        else if (!ValidCpDate) return XhDate <= UthDate;
                        return (XhDate <= CpDate && XhDate <= UthDate);
                    }
                    return false;
                }
                catch
                {
                    return false;
                }
            }
        }

        internal bool ValidCpDate
        {
            get
            {
                try
                {
                    return CpDate > DateTime.Now;
                }
                catch
                {
                    return false;
                }
            }
        }

        internal bool ValidUthDate
        {
            get
            {
                try
                {
                    return UthDate > DateTime.Now;
                }
                catch
                {
                    return false;
                }
            }
        }

        internal bool ValidXhDate
        {
            get
            {
                try
                {
                    return XhDate > DateTime.Now;
                }
                catch
                {
                    return false;
                }
            }
        }


        internal bool CpIsBestBuy
        {
            get
            {
                try
                {
                    return cpIsBestBuy;
                }
                catch
                {
                    return false;
                }
            }
        }

        internal bool UthIsBestBuy
        {
            get
            {
                try
                {
                    return uthIsBestBuy;
                }
                catch
                {
                    return false;
                }
            }
        }

        internal bool XhIsBestBuy
        {
            get
            {
                try
                {
                    return xhIsBestBuy;
                }
                catch
                {
                    return false;
                }
            }
        }

        internal void DetermineBestBuy()
        {
            if (CpHasBestPrice && CpHasBestDeliveryDate && CpHasMoreStock) cpIsBestBuy = true;
            else if (UthHasBestPrice && UthHasBestDeliveryDate && UthHasMoreStock) uthIsBestBuy = true;
            else if (XhHasBestPrice && XhHasBestDeliveryDate && XhHasMoreStock) xhIsBestBuy = true;

            else if (CpHasBestPrice && CpHasBestDeliveryDate && CpStock > 0 && CpStock > XhStock && CpStock > UthStock) cpIsBestBuy = true;
            else if (CpHasBestPrice && CpHasBestDeliveryDate && CpStock > 0 && CpStock > XhStock) cpIsBestBuy = true;
            else if (CpHasBestPrice && CpHasBestDeliveryDate && CpStock > 0 && CpStock > UthStock) cpIsBestBuy = true;

            else if (UthHasBestPrice && UthHasBestDeliveryDate && UthStock > 0 && UthStock > XhStock && UthStock > CpStock) uthIsBestBuy = true;
            else if (UthHasBestPrice && UthHasBestDeliveryDate && UthStock > 0 && UthStock > XhStock) uthIsBestBuy = true;
            else if (UthHasBestPrice && UthHasBestDeliveryDate && UthStock > 0 && UthStock > CpStock) uthIsBestBuy = true;

            else if (XhHasBestPrice && XhHasBestDeliveryDate && XhStock > 0 && XhStock > CpStock && XhStock > UthStock) xhIsBestBuy = true;
            else if (XhHasBestPrice && XhHasBestDeliveryDate && XhStock > 0 && XhStock > CpStock) xhIsBestBuy = true;
            else if (XhHasBestPrice && XhHasBestDeliveryDate && XhStock > 0 && XhStock > UthStock) xhIsBestBuy = true;

            else if (CpDate == UthDate && UthDate == XhDate)
            {
                if (CpPrice == UthPrice && UthPrice == XhPrice)
                {
                    if (CpHasMoreStock) cpIsBestBuy = true;
                    else if (UthHasMoreStock) uthIsBestBuy = true;
                    else if (XhHasMoreStock) uthIsBestBuy = true;
                }

                else if (CpHasBestPrice && CpStock > 0) cpIsBestBuy = true;
                else if (UthHasBestPrice && UthStock > 0) uthIsBestBuy = true;
                else if (XhHasBestPrice && XhStock > 0) xhIsBestBuy = true;
            }

            else if (CpPrice == UthPrice && UthPrice == XhPrice)
            {
                if (CpHasBestDeliveryDate && CpStock > 0) cpIsBestBuy = true;
                else if (UthHasBestDeliveryDate && UthStock > 0) uthIsBestBuy = true;
                else if (XhHasBestDeliveryDate && XhStock > 0) xhIsBestBuy = true;
            }

            else if (CpStock == UthStock && UthStock == XhStock)
            {
                if (CpDate == UthDate && UthDate == XhDate)
                {
                    if (CpHasBestPrice) cpIsBestBuy = true;
                    else if (UthHasBestPrice) uthIsBestBuy = true;
                    else if (XhHasBestPrice) xhIsBestBuy = true;
                }
                if (CpHasBestPrice) cpIsBestBuy = true;
                else if (UthHasBestPrice) uthIsBestBuy = true;
                else if (XhHasBestPrice) xhIsBestBuy = true;
            }

            else if (CpHasBestPrice && CpHasBestDeliveryDate) cpIsBestBuy = true;
            else if (UthHasBestPrice && UthHasBestDeliveryDate) uthIsBestBuy = true;
            else if (XhHasBestPrice && XhHasBestDeliveryDate) xhIsBestBuy = true;

            else if (CpHasBestPrice && CpStock > 0) cpIsBestBuy = true;
            else if (UthHasBestPrice && UthStock > 0) uthIsBestBuy = true;
            else if (XhHasBestPrice && XhStock > 0) xhIsBestBuy = true;

            else if (CpHasBestDeliveryDate) cpIsBestBuy = true;
            else if (UthHasBestDeliveryDate) uthIsBestBuy = true;
            else if (XhHasBestDeliveryDate) xhIsBestBuy = true;

            else if (CpHasBestPrice) cpIsBestBuy = true;
            else if (UthHasBestPrice) uthIsBestBuy = true;
            else if (XhHasBestPrice) xhIsBestBuy = true;
        }

        internal StoreComparer(AggProduct p)
        {
            this.cpClient = new CompupartsServiceProxy.CompupartsSoapClient();
            this.uthClient = new UnderthehoodServiceProxy.UnderTheHoodSoapClient();
            this.xhClient = new XhardwareServiceProxy.XHardwareSoapClient();

            try
            {
                this.CpSr = this.cpClient.GetAllInformation((int)p.cp_id);
            }
            catch { }
            try
            {
                this.UthSr = this.uthClient.GetAllInformation((int)p.uth_id);
            }
            catch { }
            try
            {
                this.XhSr = this.xhClient.GetAllInformation((int)p.xh_id);
            }
            catch { }

            DetermineBestBuy();
        }
    }
}