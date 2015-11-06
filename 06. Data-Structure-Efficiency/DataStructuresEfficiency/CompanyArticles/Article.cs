namespace CompanyArticles
{
    using System;

    public class Article : IComparable<Article>
    {
        public Article(int barcode, string title, string vendor, decimal price)
        {
            this.Barcode = barcode;
            this.Title = title;
            this.Vendor = vendor;
            this.Price = price;
        }

        public int Barcode { get; set; }
        
        public string Title { get; set; }

        public string Vendor { get; set; }

        public decimal Price { get; set; }

        public int CompareTo(Article other)
        {
            int result = this.Price.CompareTo(other.Price);
            if (result == 0)
            {
                result = this.Title.CompareTo(other.Title);
                if (result == 0)
                {
                    result = this.Vendor.CompareTo(other.Vendor);
                    if (result == 0)
                    {
                        return this.Barcode.CompareTo(other.Barcode);
                    }
                    return this.Vendor.CompareTo(other.Vendor);
                }
                return this.Title.CompareTo(other.Title);
            }
            return this.Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            return this.Barcode + ", " + this.Vendor + ", " +
                    this.Title + "-> " + this.Price;
        }
    }
}
