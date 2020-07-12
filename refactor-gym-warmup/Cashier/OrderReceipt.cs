using System.Text;

namespace refactor_gym_warmup_2020.cashier
{
 /**
 * OrderReceipt prints the details of order including customer name, address, description, quantity,
 * price and amount. It also calculates the sales tax @ 10% and prints as part
 * of order. It computes the total order amount (amount of individual lineItems +
 * total sales tax) and prints it.
 *
 */
    public class OrderReceipt
    {
        private Order order;

        public OrderReceipt(Order order)
        {
            this.order = order;
        }

        public string GetItemOutput(LineItem lineItem)
        {
            StringBuilder output = new StringBuilder();
            
            output.Append(lineItem.GetDescription());
            output.Append('\t');
            output.Append(lineItem.GetPrice());
            output.Append('\t');
            output.Append(lineItem.GetQuantity());
            output.Append('\t');
            output.Append(lineItem.TotalAmount());
            output.Append('\n');

            return output.ToString();
        }

        public double GetTotalSalesTax()
        {
            double totalSalesTax = 0d;
            
            foreach (LineItem lineItem in order.GetLineItems())
            {
                // calculate sales tax @ rate of 10%
                totalSalesTax += lineItem.TotalAmount() * .10;
            }

            return totalSalesTax;
        }

        public double GetTotal()
        {
            double total = 0d;
            
            foreach (LineItem lineItem in order.GetLineItems())
            {
                total += lineItem.TotalAmount() * (1 + .10);
            }

            return total;
        }

        public string PrintReceipt()
        {
            StringBuilder output = new StringBuilder();

            // print headers
            output.Append("======Printing Orders======\n");

            // print date, bill no, customer name
//        output.Append("Date - " + order.getDate();
            output.Append(order.GetCustomerName());
            output.Append(order.GetCustomerAddress());
//        output.Append(order.getCustomerLoyaltyNumber());

            foreach (LineItem lineItem in order.GetLineItems())
            {
                output.Append(GetItemOutput(lineItem));
            }

            // prints the state tax
            output.Append("Sales Tax").Append('\t').Append(GetTotalSalesTax());

            // print total amount
            output.Append("Total Amount").Append('\t').Append(GetTotal());
            return output.ToString();
        }
    }
}